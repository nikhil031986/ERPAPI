using ERPAPI_APP.JSONDataMigration;
using ERPAPI_APP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Formats.Asn1;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ERPAPI_APP.DataBaseAccess
{
    internal class DBAUser
    {
        internal static async Task<List<AspNetUserList>> getUser()
            => await UtilObject.erpDbContext.AspNetUsers.Select(x => new AspNetUserList
            {
                UserId = x.UserId,
                EmailId = x.EmailId,
                Customer = UtilObject.erpDbContext.CustomerMasters.Where(c => c.CustomerId == x.CustomerId).ToList(),
                Compny = UtilObject.erpDbContext.Companies.Where(c => c.Id == x.CompanyId).ToList(),
                AspNetRoles = UtilObject.erpDbContext.AspNetRoles
                            .Join(UtilObject.erpDbContext.AspNetUserRoles, p => p.Id, pc => pc.AspNetRoleId, (p, pc) => new { p, pc })
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

            // Defines a set of claims to be included in the token.
            var claims = new List<Claim>
            {
                // Custom claim using the user's ID.
                new Claim("Myapp_User_Id",user.UserId.ToString()),
                // Standard claim for user identifier, using username.
                new Claim(ClaimTypes.NameIdentifier, user.EmailId),
                // Standard claim for user's email.
                new Claim(ClaimTypes.Email, user.EmailId),
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

                var dbUser = UtilObject.erpDbContext.AspNetUsers.Where(x => x.EmailId == userEmailId).SingleOrDefault();

                var userpassword = GetHashString(password);
                if (dbUser == null)
                {
                    return "Usesr not found..";
                }
                else
                {
                    if(dbUser.PasswordHas.ToUpper() == "NEWPASSWORD" && dbUser.IsFirstTimeLogin)
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

                var newContact= await DAContact.CreateContact(singup, newCustomer.CustomerId);
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
                await UtilObject.erpDbContext.AspNetUsers.AddAsync(newUser);
                await UtilObject.erpDbContext.SaveChangesAsync();

                var newUserRol = new AspNetUserRole
                {
                    AspNetUserId = newUser.UserId,
                    AspNetRoleId = 1,
                };

                await UtilObject.erpDbContext.AspNetUserRoles.AddAsync(newUserRol);
                await UtilObject.erpDbContext.SaveChangesAsync();
                var retValue =await UtilObject.erpDbContext.AspNetUsers.Where(x=> x.UserId == newUser.UserId).Select(x => new AspNetUserList
                {
                    UserId = x.UserId,
                    EmailId = x.EmailId,
                    Customer = UtilObject.erpDbContext.CustomerMasters.Where(c => c.CustomerId == x.CustomerId).ToList(),
                    Compny = UtilObject.erpDbContext.Companies.Where(c => c.Id == x.CompanyId).ToList(),
                    AspNetRoles = UtilObject.erpDbContext.AspNetRoles
                            .Join(UtilObject.erpDbContext.AspNetUserRoles, p => p.Id, pc => pc.AspNetRoleId, (p, pc) => new { p, pc })
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
                if(string.IsNullOrWhiteSpace(userEmailId))
                {
                    return "Please enter emailId.";
                }
                if(string.IsNullOrWhiteSpace(password))
                {
                    return "Please enter password.";
                }
                var dbUser = UtilObject.erpDbContext.AspNetUsers.Where(x => x.EmailId == userEmailId).SingleOrDefault();
                if (dbUser == null)
                {
                    return "User not found.";
                }
                else
                {
                    var hasPassword = await GetHashString(password);
                    dbUser.PasswordHas = hasPassword;
                    UtilObject.erpDbContext.AspNetUsers.Update(dbUser);
                    UtilObject.erpDbContext.SaveChanges();
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
                var userEmailId = await UtilObject.erpDbContext.AspNetUsers.Where(x => x.EmailId == emailId).SingleOrDefaultAsync();
                if(userEmailId == null)
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
    }
}
