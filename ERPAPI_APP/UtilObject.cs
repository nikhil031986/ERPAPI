using ERPAPI_APP.DataBaseAccess;
using ERPAPI_APP.JSONDataMigration;
using ERPAPI_APP.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Formats.Asn1;

namespace ERPAPI_APP
{
    internal static class UtilObject
    {
        internal static string Issuer = "https://localhost:7035"; //Authentication Server Domain URL Base Address
        internal static string Audience = "http://localhost:5001"; //
        internal static string Key = "KHPK6Ucf/zjvU4qW8/vkuuGLHeIo0l9ACJiTaAPLKbk=";

        internal static ErpDbContext erpDbContext = new ErpDbContext();

        internal static async Task<JsonResult> DataMigration()
        {
            var Migration = await MigrateDate();
            if (Migration)
            {
                return new JsonResult(new { message = "Data migration completed." })
                {
                    StatusCode = StatusCodes.Status200OK // Status code here 
                };
            }
            else
            {
                return new JsonResult(new { message = "Data migration not completed some error." })
                {
                    StatusCode = StatusCodes.Status405MethodNotAllowed // Status code here 
                };
            }
        }

        private static async Task<bool> MigrateDate()
        {
            try
            {
                var listOfAPI = await UtilObject.erpDbContext.MigrationConfigs.ToListAsync();
                foreach (MigrationConfig config in listOfAPI)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        DbLog log = new DbLog
                        {
                            LogDate = DateTime.Now,
                            RequestApi = config.Apidetails,
                            RequestDate = DateTime.Now,
                        };

                        client.DefaultRequestHeaders.Add(config.TokanType, config.Apitokan);
                        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, config.Apidetails);
                        request.Headers.Add("accept", "application/json");
                        HttpResponseMessage response = await client.SendAsync(request);
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();

                        log.ResponseValue = responseBody;
                        log.ResponseDate = DateTime.Now;

                        await DALogDetails.InsertLog(log);

                        switch (config.Id)
                        {
                            case 1:
                                await DAItems.InsertItems(responseBody);
                                break;
                            case 2:
                                await DAContact.InsertContact(responseBody);
                                break;
                            case 3:
                                await InsertAddOn(AddOnMainClass.FromJson(responseBody).ToList());
                                break;
                            case 4:
                                await InsertBillingOption(responseBody);
                                break;
                            case 5:
                                await InsertCustomerLocation(responseBody);
                                break;
                            case 6:
                                await InsertWareHouse(responseBody);
                                break;
                            case 7:
                                await InsertContactMaster(responseBody);
                                break;
                            case 9:
                                await InsertPaymentTerms(responseBody);
                                break;
                            case 10:
                                await InsertSystemShipVia(responseBody);
                                break;
                            case 11:
                                await InsertOrderSourFromAPI(responseBody);
                                break;
                            default:
                                break;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                await DALogDetails.InsertLog(new DbLog { ErrorMsg = ex.Message, ErrorDateTime = DateTime.Now });
                return false;
            }
            finally
            {
                GC.Collect();
            }

        }

        private static async Task InsertEasyPostMethods(JSSystemShipVia[] jSSystemShipVias)
        {
            try
            {
                foreach (var item in jSSystemShipVias.ToList().Where(x => x.easyPostMethod != null))
                {
                    var recordExist = erpDbContext.EasyPostMethods.Where(x => x.EsyPostMethodTranId == item.easyPostMethod.id).SingleOrDefault();
                    if (recordExist != null)
                    {
                        recordExist.Name = item.easyPostMethod.name;
                        recordExist.EsyPostMethodTranId = item.easyPostMethod.id;
                        erpDbContext.EasyPostMethods.Update(recordExist);
                    }
                    else
                    {
                        var newEsyPost = new EasyPostMethod
                        {
                            Name = item.easyPostMethod.name,
                            EsyPostMethodTranId = item.easyPostMethod.id,
                        };
                        erpDbContext.EasyPostMethods.Add(newEsyPost);
                    }
                    erpDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static async Task InsertCarriers(JSSystemShipVia[] jSSystemShipVias)
        {
            try
            {
                foreach (var item in jSSystemShipVias.ToList().Where(x => x.carrier != null))
                {
                    var recordExistCarriers = erpDbContext.Carriers.Where(x => x.CarrierTranId == item.carrier.id).SingleOrDefault();
                    if (recordExistCarriers != null)
                    {
                        recordExistCarriers.CarrierTranId = item.carrier.id;
                        recordExistCarriers.Slug = item.carrier.slug;
                        recordExistCarriers.Carrier1 = item.carrier.carrier;
                        recordExistCarriers.ShipViaAccount = item.carrier.shipViaAccount;
                        recordExistCarriers.CreatedAt = item.carrier.createdAt;
                        recordExistCarriers.UpdatedAt = item.carrier.updatedAt;
                        erpDbContext.Carriers.Update(recordExistCarriers);
                    }
                    else
                    {
                        var newCarrier = new Carrier
                        {
                            CarrierTranId = item.carrier.id,
                            Slug = item.carrier.slug,
                            Carrier1 = item.carrier.carrier,
                            ShipViaAccount = item.carrier.shipViaAccount,
                            CreatedAt = item.carrier.createdAt,
                            UpdatedAt = item.carrier.updatedAt,
                        };
                        erpDbContext.Carriers.Add(newCarrier);
                    }
                    erpDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static async Task InsertSystemShipVia(string strsystemShipVia)
        {
            try
            {
                var systemShipVias = JSSystemShipVia.FromJson(strsystemShipVia);

                await InsertEasyPostMethods(systemShipVias);
                await InsertCarriers(systemShipVias);

                foreach (var item in systemShipVias)
                {
                    EasyPostMethod EasyPostMethod = null;
                    if (item.easyPostMethod != null)
                    {

                        EasyPostMethod = erpDbContext.EasyPostMethods.Where(x => x.EsyPostMethodTranId == item.easyPostMethod.id).SingleOrDefault();
                    }
                    Carrier carrier = null;
                    if (item.carrier != null)
                    {
                        carrier = erpDbContext.Carriers.Where(x => x.CarrierTranId == item.carrier.id).SingleOrDefault();
                    }
                    var existsSystemShipVia = erpDbContext.SystemShipVia.Where(x => x.SystemShipViaTranId == item.id).SingleOrDefault();
                    if (existsSystemShipVia != null)
                    {
                        existsSystemShipVia.Slug = item.slug;
                        existsSystemShipVia.ShipViaCode = item.shipViaCode;
                        existsSystemShipVia.Description = item.description;
                        existsSystemShipVia.PackageType = item.packageType;
                        existsSystemShipVia.WebDescription = item.webDescription;
                        existsSystemShipVia.SaturdayDeliveryOption = item.saturdayDeliveryOption;
                        existsSystemShipVia.CreditCardPreAuthOption = item.creditCardPreAuthOption;
                        existsSystemShipVia.FreeShip = item.freeShip;
                        existsSystemShipVia.Web = item.web;
                        existsSystemShipVia.EasyPostMethodId = EasyPostMethod != null ? EasyPostMethod.Id : 0;
                        existsSystemShipVia.Expedite = item.expedite;
                        existsSystemShipVia.FreeFreightAllowed = item.freeFreightAllowed;
                        existsSystemShipVia.International = item.international;
                        existsSystemShipVia.Collect = item.collect;
                        existsSystemShipVia.CarrierId = carrier != null ? carrier.Id : 0;
                        existsSystemShipVia.IsReturnMethod = item.isReturnMethod;
                        existsSystemShipVia.BillingOptions = string.Join(",", item.billingOptions.Select(x => x.id).ToArray());
                        existsSystemShipVia.HandlingChargeAmount = item.handlingChargeAmount;
                        existsSystemShipVia.HandlingChargePercent = item.handlingChargePercent;
                        existsSystemShipVia.IsPickup = item.isPickup;
                        existsSystemShipVia.IsDelivery = item.isDelivery;
                        existsSystemShipVia.EdiServiceLevelCode = item.ediServiceLevelCode;
                        existsSystemShipVia.CreatedAt = item.createdAt;
                        existsSystemShipVia.UpdatedAt = item.updatedAt;
                        existsSystemShipVia.SystemShipViaTranId = item.id;
                        erpDbContext.SystemShipVia.Update(existsSystemShipVia);
                    }
                    else
                    {
                        var newSystemShipVia = new SystemShipVium
                        {
                            Slug = item.slug,
                            ShipViaCode = item.shipViaCode,
                            Description = item.description,
                            PackageType = item.packageType,
                            WebDescription = item.webDescription,
                            SaturdayDeliveryOption = item.saturdayDeliveryOption,
                            CreditCardPreAuthOption = item.creditCardPreAuthOption,
                            FreeShip = item.freeShip,
                            Web = item.web,
                            EasyPostMethodId = EasyPostMethod != null ? EasyPostMethod.Id : 0,
                            Expedite = item.expedite,
                            FreeFreightAllowed = item.freeFreightAllowed,
                            International = item.international,
                            Collect = item.collect,
                            CarrierId = carrier != null ? carrier.Id : 0,
                            IsReturnMethod = item.isReturnMethod,
                            BillingOptions = string.Join(",", item.billingOptions.Select(x => x.id).ToArray()),
                            HandlingChargeAmount = item.handlingChargeAmount,
                            HandlingChargePercent = item.handlingChargePercent,
                            IsPickup = item.isPickup,
                            IsDelivery = item.isDelivery,
                            EdiServiceLevelCode = item.ediServiceLevelCode,
                            CreatedAt = item.createdAt,
                            UpdatedAt = item.updatedAt,
                            SystemShipViaTranId = item.id,
                        };
                        erpDbContext.SystemShipVia.Add(newSystemShipVia);
                    }
                    erpDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static async Task InsertPaymentTerms(string payementTerms)
        {
            try
            {
                var objpaymentTerms = JSPaymentTerms.FromJson(payementTerms);
                foreach (var item in objpaymentTerms)
                {
                    var dbData = erpDbContext.PaymentTerms.Where(x => x.PaymentTermsTranId == item.id).SingleOrDefault();
                    if (dbData != null)
                    {
                        dbData.PaymentTermsTranId = item.id;
                        dbData.DueDays = item.dueDays;
                        dbData.DiscountDays = item.discountDays;
                        dbData.Slug = item.slug;
                        dbData.TermsCode = item.termsCode;
                        dbData.Description = item.description;
                        dbData.TotalDiscountPercent = await ConvertToDecimal(item.totalDiscountPercent.ToString());
                        dbData.UpdatedAt = item.updatedAt;
                        dbData.CreatedAt = item.createdAt;
                        await DAPaymentTerms.UpdatePaymentTerm(dbData);
                    }
                    else
                    {
                        var newPaymentTerm = new Models.PaymentTerm
                        {
                            PaymentTermsTranId = item.id,
                            DueDays = item.dueDays,
                            DiscountDays = item.discountDays,
                            Slug = item.slug,
                            TermsCode = item.termsCode,
                            Description = item.description,
                            TotalDiscountPercent = await ConvertToDecimal(item.totalDiscountPercent.ToString()),
                            UpdatedAt = item.updatedAt,
                            CreatedAt = item.createdAt,
                        };
                        await DAPaymentTerms.InsertPaymentTerm(newPaymentTerm);
                    }
                    erpDbContext.SaveChanges();
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            { GC.Collect(); }
        }

        private static async Task InsertUserMaster(JSContact jSContact)
        {
            try
            {
                var currentCustomer = erpDbContext.ContactMasters.Where(x => x.ContactTranId == jSContact.id).SingleOrDefault();
                if (currentCustomer != null)
                {
                    var getAspNetRol = erpDbContext.AspNetRoles.Where(x => x.RoleName.ToUpper() == "SYSTEMCREATE").SingleOrDefault();
                    var UserExist = erpDbContext.AspNetUsers.Where(x => x.CustomerId == currentCustomer.Id).SingleOrDefault();
                    if (UserExist != null)
                    {
                        UserExist.CustomerId = currentCustomer.Id;
                        UserExist.EmailId = currentCustomer.Email;
                        UserExist.CompanyId = 1;
                        UserExist.IsActive = true;
                        UserExist.IsFirstTimeLogin = true;
                        erpDbContext.AspNetUsers.Update(UserExist);
                        erpDbContext.SaveChanges();
                    }
                    else
                    {
                        var newAspNetUser = new AspNetUser
                        {
                            CustomerId = currentCustomer.Id,
                            EmailId = currentCustomer.Email,
                            CompanyId = 1,
                            PasswordHas = "NewPassword",
                            CreateAt = DateTime.Now,
                            UpdateAt = DateTime.Now,
                            IsActive = true,
                            IsFirstTimeLogin = true,
                        };
                        erpDbContext.AspNetUsers.Add(newAspNetUser);
                        erpDbContext.SaveChanges();

                        var newAspNetUserRol = new AspNetUserRole
                        {
                            AspNetUserId = newAspNetUser.UserId,
                            AspNetRoleId = getAspNetRol.Id,
                        };
                        erpDbContext.AspNetUserRoles.Add(newAspNetUserRol);
                        erpDbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static async Task InsertContactMaster(string contactModelData)
        {
            try
            {
                var jsContacts = JSContact.FromJson(contactModelData);
                foreach (var jsContact in jsContacts)
                {
                    var custMst = erpDbContext.CustomerMasters.Where(x => x.CustomerTranId == jsContact.customer.id).SingleOrDefault();
                    var contMst = erpDbContext.ContactMasters.Where(x => x.ContactTranId == jsContact.id).SingleOrDefault();
                    if (contMst != null)
                    {
                        contMst.ContactTranId = jsContact.id;
                        contMst.Contact = jsContact.contact;
                        contMst.Email = jsContact.email;
                        contMst.UpdatedAt = jsContact.updatedAt;
                        contMst.DeletedAt = jsContact.deletedAt;
                        contMst.FirstName = jsContact.firstName;
                        contMst.LastName = jsContact.lastName;
                        contMst.Phone = jsContact.phone;
                        contMst.Name = jsContact.name;
                        contMst.PhoneExtension = jsContact.phoneExtension;
                        contMst.Slug = jsContact.slug;
                        contMst.Titled = jsContact.titled;
                        contMst.CustomerId = custMst != null ? custMst.CustomerId : 0;
                        contMst.CreatedAt = jsContact.createdAt;
                        erpDbContext.ContactMasters.Update(contMst);
                    }
                    else
                    {
                        var newContact = new ContactMaster
                        {
                            ContactTranId = jsContact.id,
                            Contact = jsContact.contact,
                            Email = jsContact.email,
                            UpdatedAt = jsContact.updatedAt,
                            DeletedAt = jsContact.deletedAt,
                            FirstName = jsContact.firstName,
                            LastName = jsContact.lastName,
                            Phone = jsContact.phone,
                            Name = jsContact.name,
                            PhoneExtension = jsContact.phoneExtension,
                            Slug = jsContact.slug,
                            Titled = jsContact.titled,
                            CustomerId = custMst != null ? custMst.CustomerId : 0,
                            CreatedAt = jsContact.createdAt,
                        };
                        erpDbContext.ContactMasters.Add(newContact);
                    }
                    erpDbContext.SaveChanges();

                    await InsertUserMaster(jsContact);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }

        private static async Task InsertWareHouse(string warehouses)
        {
            try
            {
                var jswarehouse = JsWarehouse.FromJson(warehouses);
                foreach (var item in jswarehouse)
                {
                    var warhous = erpDbContext.WarehouseMasters.Where(x => x.WarehouseTranId == item.id).SingleOrDefault();
                    if (warhous != null)
                    {
                        warhous.Address1 = item.address1;
                        warhous.Address2 = item.address2;
                        warhous.Address3 = item.address3;
                        warhous.Attention = item.attention;
                        warhous.City = item.city;
                        warhous.Country = item.country;
                        warhous.Email = item.email;
                        warhous.IsResidential = item.isResidential;
                        warhous.IsWeb = item.web;
                        warhous.Phone = item.phone;
                        warhous.Postal = item.postal;
                        warhous.Slug = item.slug;
                        warhous.State = item.state;
                        warhous.TransferShipViaAccount = item.transferShipViaAccount;
                        warhous.UpdatedAt = item.updatedAt;
                        warhous.WarehouseCode = item.code;
                        warhous.WarehouseName = item.name;
                        warhous.CreatedAt = item.createdAt;
                        //warhous.UpdatedBy = item.updatedBy.id;
                        erpDbContext.WarehouseMasters.Update(warhous);
                    }
                    else
                    {
                        var newWarHouse = new WarehouseMaster
                        {
                            Address1 = item.address1,
                            Address2 = item.address2,
                            Address3 = item.address3,
                            Attention = item.attention,
                            City = item.city,
                            Country = item.country,
                            Email = item.email,
                            IsResidential = item.isResidential,
                            IsWeb = item.web,
                            Phone = item.phone,
                            Postal = item.postal,
                            Slug = item.slug,
                            State = item.state,
                            TransferShipViaAccount = item.transferShipViaAccount,
                            UpdatedAt = item.updatedAt,
                            WarehouseCode = item.code,
                            WarehouseName = item.name,
                            WarehouseTranId = item.id,
                            CreatedAt = item.createdAt,
                        };
                        erpDbContext.WarehouseMasters.Add(newWarHouse);
                    }
                    erpDbContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static async Task InsertRegion(JSCustomer_Location[] customerLocation)
        {
            try
            {
                foreach (var regions in customerLocation.ToList().Where(x => x.Region != null).Select(x => x.Region).ToList())
                {
                    var dbRegion = erpDbContext.RegionMasters.Where(x => x.RegionTranId == regions.Id).SingleOrDefault();
                    if (dbRegion != null)
                    {
                        dbRegion.Slug = regions.Slug;
                        dbRegion.States = string.Join(",", regions.States);
                        dbRegion.CreatedAt = regions.CreatedAt.DateTime;
                        dbRegion.UpdatedAt = regions.UpdatedAt.DateTime;
                        dbRegion.Region = regions.RegionRegion;
                        dbRegion.CountryName = regions.CountryName;
                        dbRegion.RegionTranId = (int)regions.Id;
                        erpDbContext.RegionMasters.Update(dbRegion);
                    }
                    else
                    {
                        var newRegion = new RegionMaster
                        {
                            Slug = regions.Slug,
                            States = string.Join(",", regions.States),
                            CreatedAt = regions.CreatedAt.DateTime,
                            UpdatedAt = regions.UpdatedAt.DateTime,
                            Region = regions.RegionRegion,
                            CountryName = regions.CountryName,
                            RegionTranId = (int)regions.Id,
                        };
                        erpDbContext.RegionMasters.Add(newRegion);
                    }
                    erpDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static async Task InsertCustomerLocation(string customerLocation)
        {
            try
            {
                var custLocation = JSCustomer_Location.FromJson(customerLocation);

                await InsertRegion(custLocation);

                foreach (var cust in custLocation)
                {
                    RegionMaster region = null;
                    if (cust.Region != null)
                    {
                        region = erpDbContext.RegionMasters.Where(x => x.RegionTranId == cust.Region.Id).SingleOrDefault();
                    }
                    var dbcustLocation = erpDbContext.CustomerLocationInformations.Where(x => x.CustomerLocationTranId == cust.Id).ToList().SingleOrDefault();
                    if (dbcustLocation != null)
                    {
                        dbcustLocation.Address1 = cust.Address1;
                        dbcustLocation.Address2 = cust.Address2;
                        dbcustLocation.Address3 = cust.Address3;
                        dbcustLocation.Slug = cust.Slug;
                        dbcustLocation.BlindShip = cust.BlindShip;
                        dbcustLocation.City = cust.City;
                        dbcustLocation.Name = cust.Name;
                        dbcustLocation.Location = cust.Location;
                        dbcustLocation.State = cust.State;
                        dbcustLocation.Country = cust.Country;
                        dbcustLocation.CustomerId = erpDbContext.CustomerMasters.Where(x => x.CustomerTranId == cust.Customer.Id).Select(x => x.CustomerId).SingleOrDefault();
                        dbcustLocation.CustomerLocationTranId = (int)cust.Id;
                        dbcustLocation.Dob = await ConvertDateTime(cust.DateOfBirth);
                        dbcustLocation.CreatedAt = await ConvertDateTime(Convert.ToString(cust.CreatedAt.DateTime));
                        dbcustLocation.UpdatedAt = await ConvertDateTime(Convert.ToString(cust.UpdatedAt.DateTime));
                        dbcustLocation.Postal = cust.Postal;
                        dbcustLocation.Phone = cust.Phone;
                        dbcustLocation.ShipViaAccount = cust.ShipViaAccount;
                        dbcustLocation.ShipAttention = cust.ShipAttention;
                        dbcustLocation.HasConsolidatedShipments = cust.HasConsolidatedShipments;
                        dbcustLocation.IsResidential = cust.IsResidential;
                        dbcustLocation.RegionId = region != null ? region.Id : 0;
                        erpDbContext.CustomerLocationInformations.Update(dbcustLocation);
                    }
                    else
                    {
                        var newCustLocation = new CustomerLocationInformation
                        {
                            Address1 = cust.Address1,
                            Address2 = cust.Address2,
                            Address3 = cust.Address3,
                            Slug = cust.Slug,
                            BlindShip = cust.BlindShip,
                            City = cust.City,
                            Name = cust.Name,
                            Location = cust.Location,
                            State = cust.State,
                            Country = cust.Country,
                            CustomerId = erpDbContext.CustomerMasters.Where(x => x.CustomerTranId == cust.Customer.Id).Select(x => x.CustomerId).SingleOrDefault(),
                            CustomerLocationTranId = (int)cust.Id,
                            Dob = await ConvertDateTime(cust.DateOfBirth),
                            CreatedAt = await ConvertDateTime(Convert.ToString(cust.CreatedAt.DateTime)),
                            UpdatedAt = await ConvertDateTime(Convert.ToString(cust.UpdatedAt.DateTime)),
                            Postal = cust.Postal,
                            Phone = cust.Phone,
                            ShipViaAccount = cust.ShipViaAccount,
                            ShipAttention = cust.ShipAttention,
                            HasConsolidatedShipments = cust.HasConsolidatedShipments,
                            IsResidential = cust.IsResidential,
                            RegionId = region != null ? region.Id : 0,
                        };
                        erpDbContext.CustomerLocationInformations.Add(newCustLocation);
                    }
                    erpDbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { GC.Collect(); }
        }

        private static async Task<DateTime> ConvertDateTime(string DateTimeValue)
        {
            var CurrentDate = DateTime.Now;
            if (string.IsNullOrWhiteSpace(DateTimeValue))
            {
                CurrentDate = DateTime.Now;
            }
            else
            {
                var conv = DateTime.TryParse(DateTimeValue, out CurrentDate);
            }
            return CurrentDate;
        }

        private static async Task InsertBillingOption(string billingOption)
        {
            try
            {
                var lstbillingOption = JsonBillingOption.FromJson(billingOption);
                foreach (var item in lstbillingOption)
                {
                    var billingItem = erpDbContext.BillingOptions.Where(x => x.BillingOptionTranId == item.Id).SingleOrDefault();
                    if (billingItem != null)
                    {
                        billingItem.BillingOptionTranId = (int)item.Id;
                        billingItem.Slug = item.Slug;
                        billingItem.Value = item.Value;
                        billingItem.AddToInvoice = item.AddToInvoice;
                        billingItem.Description = item.description;
                        billingItem.IsRequireBillingAccount = item.IsRequireBillingAccount;
                        billingItem.IsUseCompanyAccount = item.IsUseCompanyAccount;
                        erpDbContext.BillingOptions.Update(billingItem);
                    }
                    else
                    {
                        var newBilling = new Models.BillingOption
                        {
                            BillingOptionTranId = (int)item.Id,
                            Slug = item.Slug,
                            Value = item.Value,
                            AddToInvoice = item.AddToInvoice,
                            Description = item.description,
                            IsRequireBillingAccount = item.IsRequireBillingAccount,
                            IsUseCompanyAccount = item.IsUseCompanyAccount,
                        };
                        erpDbContext.BillingOptions.Add(newBilling);
                    }
                    erpDbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { GC.Collect(); }
        }

       
        private static async Task<decimal> ConvertToDecimal(string value)
        {
            decimal retValue = decimal.Zero;
            var ret = decimal.TryParse(value, out retValue);
            return retValue;
        }

        private static async Task InsertAddOn(List<AddOnMainClass> addOnMainClass)
        {
            try
            {
                foreach (AddOnMainClass addonMntbl in addOnMainClass)
                {
                    var objAddon = erpDbContext.AddOns.Where(x => x.AddOnTranId == addonMntbl.Id).SingleOrDefault();
                    if (objAddon != null)
                    {
                        objAddon.Amount = await ConvertToDecimal(addonMntbl.Amount);
                        objAddon.OrderInvoice = Convert.ToString(addonMntbl.OrderInvoice);
                        objAddon.TaxFlag = addonMntbl.TaxFlag;
                        objAddon.TaxOverride = addonMntbl.TaxOverride;
                        objAddon.TaxCode = addonMntbl.TaxCode;
                        objAddon.TaxRate = await ConvertToDecimal(addonMntbl.TaxRate);
                        objAddon.TaxAmount = await ConvertToDecimal(addonMntbl.TaxAmount);
                        objAddon.PurchaseOrderBill = Convert.ToString(addonMntbl.PurchaseOrderBill);
                        objAddon.AddOnTranId = Convert.ToInt32(addonMntbl.Id);
                        erpDbContext.AddOns.Update(objAddon);
                    }
                    else
                    {
                        var addOn = new Models.AddOn
                        {
                            Amount = await ConvertToDecimal(addonMntbl.Amount),
                            OrderInvoice = Convert.ToString(addonMntbl.OrderInvoice),
                            TaxFlag = addonMntbl.TaxFlag,
                            TaxOverride = addonMntbl.TaxOverride,
                            TaxCode = addonMntbl.TaxCode,
                            TaxRate = await ConvertToDecimal(addonMntbl.TaxRate),
                            TaxAmount = await ConvertToDecimal(addonMntbl.TaxAmount),
                            PurchaseOrderBill = Convert.ToString(addonMntbl.PurchaseOrderBill),
                            AddOnTranId = Convert.ToInt32(addonMntbl.Id)
                        };
                        erpDbContext.AddOns.Add(addOn);
                    }
                    erpDbContext.SaveChanges();

                    var addonId = erpDbContext.AddOns.Where(x => x.AddOnTranId == addonMntbl.Id).FirstOrDefault().Id;
                    var objAddonDetails = erpDbContext.AddOnDetails.Where(x => x.AddOnDetailTranId == addonMntbl.AddOn.Id && x.AddonId == addonId).SingleOrDefault();
                    if (objAddonDetails != null)
                    {
                        objAddonDetails.AddOnDetailTranId = Convert.ToInt32(addonMntbl.AddOn.Id);
                        objAddonDetails.TotCd = addonMntbl.AddOn.TotCd;
                        objAddonDetails.AddonId = addonId;
                        objAddonDetails.Name = addonMntbl.AddOn.Name;
                        objAddonDetails.Description = addonMntbl.AddOn.Description;
                        erpDbContext.AddOnDetails.Update(objAddonDetails);
                    }
                    else
                    {
                        var newAddonDetail = new AddOnDetail
                        {
                            AddOnDetailTranId = Convert.ToInt32(addonMntbl.AddOn.Id),
                            TotCd = addonMntbl.AddOn.TotCd,
                            AddonId = addonId,
                            Name = addonMntbl.AddOn.Name,
                            Description = addonMntbl.AddOn.Description
                        };
                        erpDbContext.AddOnDetails.Add(newAddonDetail);
                    }
                    erpDbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { GC.Collect(); }
        }

        private static async Task InsertOrderSourFromAPI(string orderSourcesAPI)
        {
            try
            {
                var ordersoursData = OrderSource.FromJson(orderSourcesAPI);
                foreach (var item in ordersoursData)
                {
                    var dbOrderSource = erpDbContext.OrderSourceMasters.Where(x => x.OrderSourceTranId == item.id).SingleOrDefault();
                    if (dbOrderSource != null)
                    {
                        dbOrderSource.Slug = item.slug;
                        dbOrderSource.OrderSourceTranId = item.id;
                        dbOrderSource.Code = item.code;
                        dbOrderSource.UpdatedAt = item.updatedAt == DateTime.MinValue ? DateTime.Now : item.updatedAt;
                        dbOrderSource.CreatedAt = item.createdAt == DateTime.MinValue ? DateTime.Now : item.createdAt;
                        erpDbContext.OrderSourceMasters.Update(dbOrderSource);
                    }
                    else
                    {
                        var newOrderSource = new OrderSourceMaster
                        {
                            Slug = item.slug,
                            OrderSourceTranId = item.id,
                            Code = item.code,
                            UpdatedAt = item.updatedAt == DateTime.MinValue ? DateTime.Now : item.updatedAt,
                            CreatedAt = item.createdAt == DateTime.MinValue ? DateTime.Now : item.createdAt,
                        };
                        erpDbContext.OrderSourceMasters.Add(newOrderSource);
                    }
                    erpDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static async Task InsertOrderSource(CustomerDetails[] customerDetails)
        {
            try
            {
                foreach (var item in customerDetails.Where(x => x.orderSource != null).Select(x => x.orderSource).ToList())
                {
                    var dbOrderSource = erpDbContext.OrderSourceMasters.Where(x => x.OrderSourceTranId == item.id).SingleOrDefault();
                    if (dbOrderSource != null)
                    {
                        dbOrderSource.Slug = item.slug;
                        dbOrderSource.OrderSourceTranId = item.id;
                        dbOrderSource.Code = item.code;
                        dbOrderSource.UpdatedAt = item.updatedAt;
                        dbOrderSource.CreatedAt = item.createdAt;
                        erpDbContext.OrderSourceMasters.Update(dbOrderSource);
                    }
                    else
                    {
                        var newOrderSource = new OrderSourceMaster
                        {
                            Slug = item.slug,
                            OrderSourceTranId = item.id,
                            Code = item.code,
                            UpdatedAt = item.updatedAt,
                            CreatedAt = item.createdAt,
                        };
                        erpDbContext.OrderSourceMasters.Add(newOrderSource);
                    }
                    erpDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static async Task InsertLogoMaster(CustomerDetails[] customerDetails)
        {
            try
            {
                foreach (var item in customerDetails.Where(x => x.logo != null).Select(x => x.logo).ToList())
                {
                    var dblogo = erpDbContext.LogoMasters.Where(x => x.LogoTranId == item.id).SingleOrDefault();
                    if (dblogo != null)
                    {
                        dblogo.Size = item.size;
                        dblogo.ETag = item.eTag;
                        dblogo.ContentType = item.contentType;
                        dblogo.FileName = item.fileName;
                        dblogo.Key = item.key;
                        dblogo.Description = item.description;
                        dblogo.FileOrder = item.fileOrder;
                        dblogo.CreatedAt = item.createdAt;
                        dblogo.UpdatedAt = item.updatedAt;
                        dblogo.LogoTranId = item.id;
                        erpDbContext.LogoMasters.Update(dblogo);
                    }
                    else
                    {
                        var newlogo = new LogoMaster
                        {
                            Size = item.size,
                            ETag = item.eTag,
                            ContentType = item.contentType,
                            FileName = item.fileName,
                            Key = item.key,
                            Description = item.description,
                            FileOrder = item.fileOrder,
                            CreatedAt = item.createdAt,
                            UpdatedAt = item.updatedAt,
                            LogoTranId = item.id,
                        };
                        erpDbContext.LogoMasters.Add(newlogo);
                    }
                    erpDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static async Task InsertPaymentTerm(CustomerDetails[] customerDetails)
        {
            try
            {
                foreach (var item in customerDetails.Where(x => x.paymentTerm != null).Select(x => x.paymentTerm).ToList())
                {
                    var dbPaymentTerm = erpDbContext.PaymentTerms.Where(x => x.PaymentTermsTranId == item.id).SingleOrDefault();
                    if (dbPaymentTerm != null)
                    {
                        dbPaymentTerm.Description = item.description;
                        dbPaymentTerm.DueDays = item.dueDays;
                        dbPaymentTerm.DiscountDays = item.discountDays;
                        dbPaymentTerm.TotalDiscountPercent = await ConvertToDecimal(Convert.ToString(item.totalDiscountPercent));
                        dbPaymentTerm.UpdatedAt = item.updatedAt;
                        dbPaymentTerm.CreatedAt = item.createdAt;
                        dbPaymentTerm.Slug = item.slug;
                        dbPaymentTerm.PaymentTermsTranId = item.id;
                        erpDbContext.PaymentTerms.Update(dbPaymentTerm);
                    }
                    else
                    {
                        var newPaymentTerm = new Models.PaymentTerm
                        {
                            Description = item.description,
                            DueDays = item.dueDays,
                            DiscountDays = item.discountDays,
                            TotalDiscountPercent = await ConvertToDecimal(Convert.ToString(item.totalDiscountPercent)),
                            UpdatedAt = item.updatedAt,
                            CreatedAt = item.createdAt,
                            Slug = item.slug,
                            PaymentTermsTranId = item.id,
                        };
                        erpDbContext.PaymentTerms.Add(newPaymentTerm);
                    }
                    erpDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        internal static async Task InsertCustomerGroup(CustomerDetails[] customerDetails)
        {
            try
            {
                foreach (var item in customerDetails.Where(x => x.customerGroup != null).Select(x => x.customerGroup).ToList())
                {
                    var dbCustomerGroup = erpDbContext.CustomerGroups.Where(x => x.CustomerGroupTranId == item.id).SingleOrDefault();
                    if (dbCustomerGroup != null)
                    {
                        dbCustomerGroup.Value = item.value;
                        dbCustomerGroup.Description = item.description;
                        dbCustomerGroup.CreatedAt = item.createdAt;
                        dbCustomerGroup.UpdatedAt = item.updatedAt;
                        dbCustomerGroup.CustomerGroupTranId = item.id;
                        erpDbContext.CustomerGroups.Update(dbCustomerGroup);
                    }
                    else
                    {
                        var newCustomerGroup = new Models.CustomerGroup
                        {
                            Value = item.value,
                            Description = item.description,
                            CreatedAt = item.createdAt,
                            UpdatedAt = item.updatedAt,
                            CustomerGroupTranId = item.id,
                        };
                        erpDbContext.CustomerGroups.Add(newCustomerGroup);
                    }
                    erpDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}
