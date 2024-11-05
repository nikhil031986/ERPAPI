using ERPAPI_APP.JSONDataMigration;
using ERPAPI_APP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Formats.Asn1;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Transactions;
using static System.Reflection.Metadata.BlobBuilder;

namespace ERPAPI_APP.DataBaseAccess
{
    internal class DBAUser
    {
        private static readonly ErpDbContext erpDbContext = new ErpDbContext();

        internal static async Task<List<AspNetUserList>> getUser()
            => await erpDbContext.AspNetUsers.Select(x => new AspNetUserList
            {
                UserId = x.UserId,
                EmailId = x.EmailId,
                Customer = erpDbContext.CustomerMasters.Where(c => c.CustomerId == x.CustomerId).ToList(),
                Compny = erpDbContext.Companies.Where(c => c.Id == x.CompanyId).ToList(),
                AspNetRoles = erpDbContext.AspNetRoles
                            .Join(erpDbContext.AspNetUserRoles, p => p.Id, pc => pc.AspNetRoleId, (p, pc) => new { p, pc })
                            .Where(k => k.pc.AspNetUserId == x.UserId).Select(m => m.p).ToList<AspNetRole>(),
            }).ToListAsync();

        private static async Task<string> GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in getHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        private static byte[] getHash(string inputData)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputData));
        }

        /// <summary>
        /// internal method to generate a JWT token using the user's data.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        internal static Task<string> IssueToken(AspNetUser user)
        {
            // Creates a new symmetric security key from the JWT key specified in the app configuration.
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(UtilObject.Key));
            // Sets up the signing credentials using the above security key and specifying the HMAC SHA256 algorithm.
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            user.UserConfigs.ToList().ForEach(x =>
            {
                x.User = null;
            });
            // Defines a set of claims to be included in the token.
            var claims = new List<Claim>
            {
                // Custom claim using the user's ID.
                new Claim("Myapp_User_Id",user.UserId.ToString()),
                // Standard claim for user identifier, using username.
                new Claim("NameIdentifier", user.EmailId),
                // Standard claim for user's email.
                new Claim("User_Email", user.EmailId),
                // Add Customer Id
                new Claim("Customer_Id",user.CustomerId.ToString()),
                //Add config Values
                new Claim("configDetail",JsonSerializer.Serialize(user.UserConfigs)),
                // Standard JWT claim for subject, using user ID.
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString())
            };

            // Adds a role claim for each role associated with the user.
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));

            IdentityModelEventSource.ShowPII = true;
            // Creates a new JWT token with specified parameters including issuer, audience, claims, expiration time, and signing credentials.
            var token = new JwtSecurityToken(
                issuer: UtilObject.Issuer,
                audience: UtilObject.Audience,
                claims: claims,
                expires: DateTime.Now.AddHours(1), // Token expiration set to 1 hour from the current time.
                signingCredentials: credentials);

            // Serializes the JWT token to a string and returns it.
            var newToken = new JwtSecurityTokenHandler().WriteToken(token);
            return Task.Delay(100)
        .ContinueWith(t => newToken);
        }

        internal static async Task<string> Login(string userEmailId, string password)
        {
            try
            {

                using (var scope = new TransactionScope(
                        TransactionScopeOption.Required,
                        new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    using (var context = new ErpDbContext())
                    {
                        var dbUser = context.AspNetUsers.Where(x => x.EmailId == userEmailId).SingleOrDefault();
                        if (dbUser == null)
                        {
                            return "Usesr not found..";
                        }
                        else
                        {
                            var userpassword = GetHashString(password);
                            dbUser.UserConfigs = context.UserConfigs.Where(x => x.UserId == dbUser.UserId).ToList();
                            if (dbUser.PasswordHas.ToUpper() == "NEWPASSWORD" && dbUser.IsFirstTimeLogin)
                            {
                                return "Create new password.";
                            }
                            else if (dbUser.PasswordHas == userpassword.Result.ToString())
                            {
                                return await IssueToken(dbUser);
                            }
                            else
                            {
                                return "Password not match.";
                            }
                        }
                    }
                    scope.Complete();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static async Task<AspNetUserList> singUpUser(SingUp singup)
        {
            try
            {

                var newCustomer = await DBACustomer.CreateNewCustomer(singup);

                var newContact = await DAContact.CreateContact(singup, newCustomer.CustomerId);
                var newUser = new AspNetUser
                {
                    EmailId = singup.emailId,
                    PasswordHas = await GetHashString(singup.password),
                    IsActive = true,
                    CompanyId = 1,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    IsFirstTimeLogin = false,
                    CustomerId = newCustomer.CustomerId,
                };
                await erpDbContext.AspNetUsers.AddAsync(newUser);
                await erpDbContext.SaveChangesAsync();

                var newUserRol = new AspNetUserRole
                {
                    AspNetUserId = newUser.UserId,
                    AspNetRoleId = 1,
                };

                await erpDbContext.AspNetUserRoles.AddAsync(newUserRol);
                await erpDbContext.SaveChangesAsync();
                var retValue = await erpDbContext.AspNetUsers.Where(x => x.UserId == newUser.UserId).Select(x => new AspNetUserList
                {
                    UserId = x.UserId,
                    EmailId = x.EmailId,
                    Customer = erpDbContext.CustomerMasters.Where(c => c.CustomerId == x.CustomerId).ToList(),
                    Compny = erpDbContext.Companies.Where(c => c.Id == x.CompanyId).ToList(),
                    AspNetRoles = erpDbContext.AspNetRoles
                            .Join(erpDbContext.AspNetUserRoles, p => p.Id, pc => pc.AspNetRoleId, (p, pc) => new { p, pc })
                            .Where(k => k.pc.AspNetUserId == x.UserId).Select(m => m.p).ToList<AspNetRole>(),
                }).SingleOrDefaultAsync();

                return retValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static async Task<string> PasswordUpdate(string userEmailId, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userEmailId))
                {
                    return "Please enter emailId.";
                }
                if (string.IsNullOrWhiteSpace(password))
                {
                    return "Please enter password.";
                }
                var dbUser = erpDbContext.AspNetUsers.Where(x => x.EmailId == userEmailId).SingleOrDefault();
                if (dbUser == null)
                {
                    return "User not found.";
                }
                else
                {
                    var hasPassword = await GetHashString(password);
                    dbUser.PasswordHas = hasPassword;
                    erpDbContext.AspNetUsers.Update(dbUser);
                    erpDbContext.SaveChanges();
                    return "Password changed.";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal static async Task<bool> CheckEmailId(string emailId)
        {
            try
            {
                var userEmailId = await erpDbContext.AspNetUsers.Where(x => x.EmailId == emailId).SingleOrDefaultAsync();
                if (userEmailId == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static async Task<List<objcustomerDetails>> GetCustomerDetails(int customerId)
        {
            List<objcustomerDetails> objcustomerDetails = new List<objcustomerDetails>();
            try
            {
                using (var scope = new TransactionScope(
                       TransactionScopeOption.Required,
                       new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    using (var context = new ErpDbContext())
                    {
                        var addoj = new objcustomerDetails();
                        var objItem = context.CustomerMasters.Where(x => x.CustomerId == customerId).FirstOrDefault();
                        if (objItem != null)
                        {
                            addoj.customerId = objItem.CustomerId;
                            addoj.CustomerMaster = objItem;
                            addoj.shipAddresses = context.CustomerLocationInformations.Where(x => x.CustomerId == customerId).ToList();
                            addoj.customerLocationInformation = context.CustomerLocationInformations.Where(x => x.CustomerId == customerId).FirstOrDefault();
                            var cont = context.ContactMasters.Where(x => x.CustomerId == customerId).FirstOrDefault();
                            if (cont != null)
                            {
                                addoj.ContactDetails = cont;
                            }
                            addoj.systemShipVia = context.SystemShipVia.ToList();
                            var payterm = context.PaymentTerms.ToList();
                            addoj.PaymentTerm = payterm;
                            var objpaymentMethod = context.PaymentMethods.ToList();
                            addoj.PaymentMethod = objpaymentMethod;
                            addoj.shipingLocation = context.PrimaryShippingLocations.Where(x => x.CustomerId == customerId).ToList();
                            objcustomerDetails.Add(addoj);
                        }
                    }
                    scope.Complete();
                }

                return objcustomerDetails;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
