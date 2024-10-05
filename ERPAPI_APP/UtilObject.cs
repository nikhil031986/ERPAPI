using Azure;
using ERPAPI_APP.DataBaseAccess;
using ERPAPI_APP.JSONDataMigration;
using ERPAPI_APP.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using System.Formats.Asn1;
using System.Reflection;
using System.Runtime.CompilerServices;

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
                    if (config.Id < 1017) continue;

                    using (HttpClient client = new HttpClient())
                    {
                        DbLog log = new DbLog
                        {
                            LogDate = DateTime.Now,
                            RequestApi = config.Apidetails,
                            RequestDate = DateTime.Now,
                        };
                        HttpMethod httpMethod = new HttpMethod(config.Httpmethod);
                        client.DefaultRequestHeaders.Add(config.TokanType, config.Apitokan);
                        HttpRequestMessage request = new HttpRequestMessage(httpMethod, config.Apidetails);
                        var content = new StringContent("{}", null, "application/json");
                        request.Content = content;
                        request.Headers.Add("accept", "application/json");
                        HttpResponseMessage response = await client.SendAsync(request);
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();

                        log.ResponseValue = responseBody;
                        log.ResponseDate = DateTime.Now;

                        await DALogDetails.InsertLog(log);

                        //dynamic obj = JsonConvert.DeserializeObject(responseBody);
                        //foreach(var item in obj)
                        //{
                        //    Console.WriteLine(item);
                        //}
                        var methodName = Convert.ToString(config.MethodName);
                        if (!string.IsNullOrWhiteSpace(methodName))
                        {
                            var className = "ERPAPI_APP.UtilObject";
                            Type typ = Type.GetType(className, true);
                            if (typ != null)
                            {
                                MethodInfo method = typ.GetMethod(methodName, BindingFlags.Static | BindingFlags.NonPublic);
                                if (method != null)
                                {
                                    method.Invoke(null, new object[] { responseBody });
                                }
                            }
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

        private static async Task InsertItemImage(JSFile[] jSFiles)
        {
            try
            {
                foreach (var jSFile in jSFiles)
                {
                    var dbImgeFile = await erpDbContext.ItemImages.Where(x => x.ItemImageTranId == jSFile.FileId).SingleOrDefaultAsync();
                    if (dbImgeFile != null)
                    {
                        dbImgeFile.FileName = jSFile.FileName;
                        dbImgeFile.ItemImageTranId = (int)jSFile.FileId;
                        dbImgeFile.Sku = jSFile.Sku;
                        dbImgeFile.ItemMasterId = (int)jSFile.ItemId;
                        dbImgeFile.ETag = jSFile.ETag;
                        dbImgeFile.Key = jSFile.Key;
                        erpDbContext.ItemImages.Update(dbImgeFile);
                        await erpDbContext.SaveChangesAsync();
                    }
                    else
                    {
                        var newImage = new ItemImage
                        {
                            FileName = jSFile.FileName,
                            ItemImageTranId = (int)jSFile.FileId,
                            Sku = jSFile.Sku,
                            ItemMasterId = (int)jSFile.ItemId,
                            ETag = jSFile.ETag,
                            Key = jSFile.Key,
                        };
                        await erpDbContext.ItemImages.AddAsync(newImage);
                        await erpDbContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static async Task InsertItemFromWeb(string jsItems)
        {
            try
            {
                dynamic dictionary = JsonConvert.DeserializeObject<ExpandoObject>(jsItems);
                foreach (var item in dictionary)
                {
                    var valueofItem = item.Value;
                    JSItemImportFromWeb newImportWebitem = new JSItemImportFromWeb();
                    PropertyInfo[] getproperty = newImportWebitem.GetType().GetProperties();
                    if (valueofItem != null)
                    {
                        foreach (var innerObject in valueofItem)
                        {
                            string propName = innerObject.Key.ToString();

                            PropertyInfo propertyInfo = getproperty.Where(x => x.Name.ToUpper() == propName.Replace("_", "").ToUpper()).SingleOrDefault();
                            if (propertyInfo != null)
                            {
                                if (innerObject.Key.ToString().ToUpper() == "FILES")
                                {
                                    List<JSFile> appendFile = new List<JSFile>();
                                    foreach (var file in innerObject.Value)
                                    {
                                        JSFile newFile = new JSFile();
                                        PropertyInfo[] fileobjproperty = newFile.GetType().GetProperties();
                                        foreach (var Filekey in file)
                                        {
                                            string fileobjVlaue = Filekey.Key.ToString();
                                            PropertyInfo fileobjPro = fileobjproperty.Where(x => x.Name.ToUpper() == fileobjVlaue.Replace("_", "").ToUpper()).SingleOrDefault();
                                            if (fileobjPro != null)
                                            {
                                                fileobjPro.SetValue(newFile, Filekey.Value, null);
                                            }
                                        }
                                        appendFile.Add(newFile);
                                    }
                                    propertyInfo.SetValue(newImportWebitem, appendFile.ToArray(), null);
                                }
                                else
                                {
                                    propertyInfo.SetValue(newImportWebitem, innerObject.Value, null);
                                }
                            }
                        }
                    }

                    if (newImportWebitem != null)
                    {
                        if (newImportWebitem.Files != null)
                        {
                            await InsertItemImage(newImportWebitem.Files);
                        }
                        var dbitem = await erpDbContext.ItemMasters.Where(x => x.ItemTranId == newImportWebitem.Id).SingleOrDefaultAsync();
                        var dbUnit = await erpDbContext.UnitMasters.Where(x => x.UnitSymbol == newImportWebitem.UnitSymbol).SingleOrDefaultAsync();
                        if (dbitem != null)
                        {
                            dbitem.ItemName = newImportWebitem.Item;
                            dbitem.ItemDescription = newImportWebitem.Description;
                            dbitem.WebDescription = newImportWebitem.WebDescription;
                            dbitem.Weight = await ConvertToDecimal(Convert.ToString(newImportWebitem.Weight));
                            dbitem.ShipWidth = await ConvertToDecimal(Convert.ToString(newImportWebitem.ShipWidth));
                            dbitem.ShipHeight = await ConvertToDecimal(Convert.ToString(newImportWebitem.ShipHeight));
                            dbitem.ShipLength = await ConvertToDecimal(Convert.ToString(newImportWebitem.ShipLength));
                            dbitem.CommodityCode = newImportWebitem.CommodityCode;
                            dbitem.DefaultCountryOfOrigin = newImportWebitem.DefaultCountryOfOrigin;
                            dbitem.PrimaryVendorId = newImportWebitem.PrimaryVendorId != null ? (int)newImportWebitem.PrimaryVendorId : 0;
                            dbitem.MainImageFileId = newImportWebitem.MainImageFileId != null ? (int)newImportWebitem.MainImageFileId : 0;
                            dbitem.UnitId = dbUnit != null ? dbUnit.UnitId : 0;
                            dbitem.DisplayUnitId = dbUnit != null ? dbUnit.UnitId : 0;
                            dbitem.ItemTranId = (int)newImportWebitem.Id;
                            erpDbContext.ItemMasters.Update(dbitem);
                            await erpDbContext.SaveChangesAsync();
                        }
                        else
                        {
                            var newItem = new ItemMaster
                            {
                                ItemTranId = (int)newImportWebitem.Id,
                                ItemName = newImportWebitem.Item,
                                ItemDescription = newImportWebitem.Description,
                                WebDescription = newImportWebitem.WebDescription,
                                Weight = await ConvertToDecimal(Convert.ToString(newImportWebitem.Weight)),
                                ShipWidth = await ConvertToDecimal(Convert.ToString(newImportWebitem.ShipWidth)),
                                ShipHeight = await ConvertToDecimal(Convert.ToString(newImportWebitem.ShipHeight)),
                                ShipLength = await ConvertToDecimal(Convert.ToString(newImportWebitem.ShipLength)),
                                CommodityCode = newImportWebitem.CommodityCode,
                                DefaultCountryOfOrigin = newImportWebitem.DefaultCountryOfOrigin,
                                PrimaryVendorId = newImportWebitem.PrimaryVendorId != null ? (int)newImportWebitem.PrimaryVendorId : 0,
                                MainImageFileId = newImportWebitem.MainImageFileId != null ? (int)newImportWebitem.MainImageFileId : 0,
                                UnitId = dbUnit != null ? dbUnit.UnitId : 0,
                                DisplayUnitId = dbUnit != null ? dbUnit.UnitId : 0,
                            };
                            await erpDbContext.ItemMasters.AddAsync(newItem);
                            await erpDbContext.SaveChangesAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private static async Task InsertUntiMaster(string jsUnitMasters)
        {
            try
            {
                var JSUnitMaster = JsUnti_Master.FromJson(jsUnitMasters);
                foreach (var item in JSUnitMaster)
                {
                    var dbUnit = await erpDbContext.UnitMasters.Where(x => x.UnitTranId == item.Id).SingleOrDefaultAsync();
                    if (dbUnit != null)
                    {
                        dbUnit.UnitSymbol = item.Symbol;
                        dbUnit.UnitName = item.Label;
                        dbUnit.GroupLabel = item.GroupLabel;
                        dbUnit.Visible = item.Visible;
                        dbUnit.IsCustomUnit = item.IsCustomUnit;
                        dbUnit.ConversionFactor = await ConvertToDecimal(Convert.ToString(item.ConversionFactor));
                        dbUnit.UpcCode = item.UpcCode;
                        dbUnit.Length = await ConvertToDecimal(Convert.ToString(item.Length));
                        dbUnit.Width = await ConvertToDecimal(Convert.ToString(item.Width));
                        dbUnit.Height = await ConvertToDecimal(Convert.ToString(item.Height));
                        dbUnit.CreatedAt = item.CreatedAt.Date;
                        dbUnit.UpdatedAt = item.UpdatedAt.Date;

                        erpDbContext.UnitMasters.Update(dbUnit);
                        await erpDbContext.SaveChangesAsync();
                    }
                    else
                    {
                        var newUnit = new UnitMaster
                        {
                            UnitSymbol = item.Symbol,
                            UnitName = item.Label,
                            GroupLabel = item.GroupLabel,
                            Visible = item.Visible,
                            IsCustomUnit = item.IsCustomUnit,
                            ConversionFactor = await ConvertToDecimal(Convert.ToString(item.ConversionFactor)),
                            UpcCode = item.UpcCode,
                            Length = await ConvertToDecimal(Convert.ToString(item.Length)),
                            Width = await ConvertToDecimal(Convert.ToString(item.Width)),
                            Height = await ConvertToDecimal(Convert.ToString(item.Height)),
                            CreatedAt = item.CreatedAt.Date,
                            UpdatedAt = item.UpdatedAt.Date,
                        };

                        await erpDbContext.UnitMasters.AddAsync(newUnit);
                        await erpDbContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static async Task InsertSales_Taxes(string jsSales_Taxes)
        {
            try
            {
                var JsSales_texes = JSSalesTaxes.FromJson(jsSales_Taxes);
                foreach (var item in JsSales_texes)
                {
                    var dbSalesText = await erpDbContext.SalesTaxes.Where(x => x.SalesTaxesTranId == item.id).SingleOrDefaultAsync();
                    if (dbSalesText != null)
                    {
                        dbSalesText.SalesTaxesTranId = item.id;
                        dbSalesText.Description = item.description;
                        dbSalesText.GeneralLedgerAccountId = item.generalLedgerAccount != null ? item.generalLedgerAccount.id : 0;
                        dbSalesText.UpdatedAt = item.updatedAt;
                        dbSalesText.CreatedAt = item.createdAt;
                        dbSalesText.Country = item.country;
                        dbSalesText.State = item.state;
                        dbSalesText.Slug = item.slug;
                        dbSalesText.TaxCode = item.taxCode;
                        dbSalesText.TaxRate = Convert.ToDecimal(item.taxRate);
                        erpDbContext.Update(dbSalesText);
                        await erpDbContext.SaveChangesAsync();
                    }
                    else
                    {
                        var newdbSalesText = new SalesTaxis
                        {
                            SalesTaxesTranId = item.id,
                            GeneralLedgerAccountId = item.generalLedgerAccount != null ? item.generalLedgerAccount.id : 0,
                            UpdatedAt = item.updatedAt,
                            CreatedAt = item.createdAt,
                            Description = item.description,
                            Country = item.country,
                            State = item.state,
                            Slug = item.slug,
                            TaxCode = item.taxCode,
                            TaxRate = Convert.ToDecimal(item.taxRate),
                        };
                        await erpDbContext.SalesTaxes.AddAsync(newdbSalesText);
                        await erpDbContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static async Task InsertPaymentMethod(string jspaymentmethods)
        {
            try
            {
                var paymentMethods = JSpayment_methods.FromJson(jspaymentmethods);
                foreach (var paymentMethod in paymentMethods)
                {
                    var dbPaymentMethod = await erpDbContext.PaymentMethods.Where(x => x.PaymentMethodTranId == paymentMethod.id).SingleOrDefaultAsync();
                    if (dbPaymentMethod != null)
                    {
                        dbPaymentMethod.PaymentMethod1 = paymentMethod.paymentMethod;
                        dbPaymentMethod.PaymentMethodTranId = paymentMethod.id;
                        dbPaymentMethod.IsCreditCardPayment = paymentMethod.isCreditCardPayment;
                        dbPaymentMethod.IsAccountsPayableMethod = paymentMethod.isAccountsPayableMethod;
                        dbPaymentMethod.MethodDescription = paymentMethod.methodDescription;
                        dbPaymentMethod.Slug = paymentMethod.slug;
                        dbPaymentMethod.UpdatedAt = paymentMethod.updatedAt;
                        dbPaymentMethod.CreatedAt = paymentMethod.createdAt;
                        erpDbContext.PaymentMethods.Update(dbPaymentMethod);
                        await erpDbContext.SaveChangesAsync();
                    }
                    else
                    {
                        var nwPaymentMethod = new PaymentMethod
                        {
                            PaymentMethod1 = paymentMethod.paymentMethod,
                            PaymentMethodTranId = paymentMethod.id,
                            IsCreditCardPayment = paymentMethod.isCreditCardPayment,
                            IsAccountsPayableMethod = paymentMethod.isAccountsPayableMethod,
                            MethodDescription = paymentMethod.methodDescription,
                            Slug = paymentMethod.slug,
                            UpdatedAt = paymentMethod.updatedAt,
                            CreatedAt = paymentMethod.createdAt,
                        };
                        await erpDbContext.PaymentMethods.AddAsync(nwPaymentMethod);
                        await erpDbContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static async Task InsertContact(string contactModelData)
        {
            try
            {
                var customers = CustomerDetails.FromJson(contactModelData);

                await UtilObject.InsertOrderSource(customers);
                await UtilObject.InsertPaymentTerm(customers);
                await UtilObject.InsertLogoMaster(customers);
                await UtilObject.InsertCustomerGroup(customers);

                foreach (CustomerDetails module in customers)
                {
                    LogoMaster logoDetails = null;
                    if (module.logo != null)
                    {
                        logoDetails = UtilObject.erpDbContext.LogoMasters.Where(x => x.LogoTranId == module.logo.id).SingleOrDefault();
                    }
                    OrderSourceMaster ordersource = null;
                    if (module.orderSource != null)
                    {
                        ordersource = UtilObject.erpDbContext.OrderSourceMasters.Where(x => x.OrderSourceTranId == module.orderSource.id).SingleOrDefault();
                    }
                    Models.PaymentTerm paymentTerms = null;
                    if (module.paymentTerm != null)
                    {
                        paymentTerms = UtilObject.erpDbContext.PaymentTerms.Where(x => x.PaymentTermsTranId == module.paymentTerm.id).SingleOrDefault();
                    }
                    Models.CustomerGroup customerGroup = null;
                    if (module.customerGroup != null)
                    {
                        customerGroup = UtilObject.erpDbContext.CustomerGroups.Where(x => x.CustomerGroupTranId == module.customerGroup.id).SingleOrDefault();
                    }
                    var dbCustomer = UtilObject.erpDbContext.CustomerMasters.Where(x => x.CustomerTranId == module.id).SingleOrDefault();
                    if (dbCustomer != null)
                    {
                        dbCustomer.CustomerCode = module.customer;
                        dbCustomer.FirstName = module.name;
                        dbCustomer.LastName = module.name;
                        dbCustomer.Slug = module.slug;
                        dbCustomer.PhoneExtension = module.phone;
                        dbCustomer.Email = module.email;
                        dbCustomer.Phone = module.phone;
                        dbCustomer.CreatedAt = module.createdAt;
                        dbCustomer.UpdatedAt = module.updatedAt;
                        dbCustomer.CustomerTranId = module.id;
                        dbCustomer.AveragePayDays = module.averagePayDays;
                        dbCustomer.BoFlag = module.boFlag;
                        dbCustomer.AlwaysShipCompleteFlag = module.alwaysShipCompleteFlag;
                        dbCustomer.PoRequiredFlag = module.poRequiredFlag;
                        dbCustomer.CcfFlag = module.ccfFlag;
                        dbCustomer.CrLimit = module.crLimit;
                        dbCustomer.InvoiceEmail = module.invoiceEmail;
                        dbCustomer.Customer = module.customer;
                        dbCustomer.SicCode = module.sicCode;
                        dbCustomer.TaxId = module.taxId;
                        dbCustomer.TaxExempt = module.taxExempt;
                        dbCustomer.GraceDays = module.graceDays;
                        dbCustomer.HasConsolidatedInvoices = module.hasConsolidatedInvoices;
                        dbCustomer.IsAssessFinanceCharges = module.isAssessFinanceCharges;
                        dbCustomer.StatementDestinationEmail = module.statementDestinationEmail;
                        dbCustomer.OrderAcknowledgementEmail = module.orderAcknowledgementEmail;
                        dbCustomer.ShippingConfirmationEmail = module.shippingConfirmationEmail;
                        dbCustomer.PickupConfirmationEmail = module.pickupConfirmationEmail;
                        dbCustomer.OrderAcknowledgementEmailSelect = module.orderAcknowledgementEmailSelect;
                        dbCustomer.ShippingConfirmationEmailSelect = module.shippingConfirmationEmailSelect;
                        dbCustomer.PickupConfirmationEmailSelect = module.pickupConfirmationEmailSelect;
                        dbCustomer.IsAlwaysPassCreditCheck = module.isAlwaysPassCreditCheck;
                        dbCustomer.IsPreferFullLots = module.isPreferFullLots;
                        dbCustomer.IsRequireFullLots = module.isRequireFullLots;
                        dbCustomer.ExternalDocparserParserId = module.externalDocparserParserId;
                        dbCustomer.LocationToBlind = module.locationToBlind;
                        dbCustomer.InvoiceOptionEmail = module.invoiceOptionEmail;
                        dbCustomer.InvoiceOptionPrint = module.invoiceOptionPrint;
                        dbCustomer.CooRequiredFlag = module.cooRequiredFlag;
                        dbCustomer.IsStateTaxExempt = module.isStateTaxExempt;
                        dbCustomer.IsSyncToHubSpot = module.isSyncToHubSpot;
                        dbCustomer.Website = module.website;
                        dbCustomer.PrintPriceOnPickingSlip = module.printPriceOnPackingSlip;
                        dbCustomer.PrintPriceOnPackingSlip = module.printPriceOnPackingSlip;
                        dbCustomer.IsDraft = module.isDraft;
                        dbCustomer.QualityCheckTarget = module.qualityCheckTarget;
                        dbCustomer.FontColor = module.fontColor;
                        dbCustomer.BorderColor = module.borderColor;
                        dbCustomer.ShadingColor = module.shadingColor;
                        dbCustomer.LabelQuantity = module.labelQuantity;
                        dbCustomer.PackingSlipPdfTemplate = module.packingSlipPdfTemplate;
                        dbCustomer.PaymentTermId = paymentTerms != null ? paymentTerms.Id : 0;
                        dbCustomer.LogoMasterId = logoDetails != null ? logoDetails.Id : 0;
                        dbCustomer.OrderSourceMasterId = ordersource != null ? ordersource.Id : 0;
                        dbCustomer.CustomerGroupId = customerGroup != null ? customerGroup.Id : 0;
                        UtilObject.erpDbContext.CustomerMasters.Update(dbCustomer);
                    }
                    else
                    {
                        var newCustomer = new CustomerMaster
                        {
                            CustomerCode = module.customer,
                            FirstName = module.name,
                            LastName = module.name,
                            Slug = module.slug,
                            PhoneExtension = module.phone,
                            Email = module.email,
                            Phone = module.phone,
                            CreatedAt = module.createdAt,
                            UpdatedAt = module.updatedAt,
                            CustomerTranId = module.id,
                            AveragePayDays = module.averagePayDays,
                            BoFlag = module.boFlag,
                            AlwaysShipCompleteFlag = module.alwaysShipCompleteFlag,
                            PoRequiredFlag = module.poRequiredFlag,
                            CcfFlag = module.ccfFlag,
                            CrLimit = module.crLimit,
                            InvoiceEmail = module.invoiceEmail,
                            Customer = module.customer,
                            SicCode = module.sicCode,
                            TaxId = module.taxId,
                            TaxExempt = module.taxExempt,
                            GraceDays = module.graceDays,
                            HasConsolidatedInvoices = module.hasConsolidatedInvoices,
                            IsAssessFinanceCharges = module.isAssessFinanceCharges,
                            StatementDestinationEmail = module.statementDestinationEmail,
                            OrderAcknowledgementEmail = module.orderAcknowledgementEmail,
                            ShippingConfirmationEmail = module.shippingConfirmationEmail,
                            PickupConfirmationEmail = module.pickupConfirmationEmail,
                            OrderAcknowledgementEmailSelect = module.orderAcknowledgementEmailSelect,
                            ShippingConfirmationEmailSelect = module.shippingConfirmationEmailSelect,
                            PickupConfirmationEmailSelect = module.pickupConfirmationEmailSelect,
                            IsAlwaysPassCreditCheck = module.isAlwaysPassCreditCheck,
                            IsPreferFullLots = module.isPreferFullLots,
                            IsRequireFullLots = module.isRequireFullLots,
                            ExternalDocparserParserId = module.externalDocparserParserId,
                            LocationToBlind = module.locationToBlind,
                            InvoiceOptionEmail = module.invoiceOptionEmail,
                            InvoiceOptionPrint = module.invoiceOptionPrint,
                            CooRequiredFlag = module.cooRequiredFlag,
                            IsStateTaxExempt = module.isStateTaxExempt,
                            IsSyncToHubSpot = module.isSyncToHubSpot,
                            Website = module.website,
                            PrintPriceOnPickingSlip = module.printPriceOnPackingSlip,
                            PrintPriceOnPackingSlip = module.printPriceOnPackingSlip,
                            IsDraft = module.isDraft,
                            QualityCheckTarget = module.qualityCheckTarget,
                            FontColor = module.fontColor,
                            BorderColor = module.borderColor,
                            ShadingColor = module.shadingColor,
                            LabelQuantity = module.labelQuantity,
                            PackingSlipPdfTemplate = module.packingSlipPdfTemplate,
                            PaymentTermId = paymentTerms != null ? paymentTerms.Id : 0,
                            LogoMasterId = logoDetails != null ? logoDetails.Id : 0,
                            OrderSourceMasterId = ordersource != null ? ordersource.Id : 0,
                            CustomerGroupId = customerGroup != null ? customerGroup.Id : 0,
                        };
                        UtilObject.erpDbContext.CustomerMasters.Add(newCustomer);
                    }
                    UtilObject.erpDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static async Task InsertItems(string itemModelData)
        {
            try
            {

                var item = ItemModule.FromJson(itemModelData);
                foreach (ItemModule itemModule in item)
                {
                    var ret = UtilObject.erpDbContext.Database.
                         ExecuteSqlRaw("EXEC INSERT_ITEM_MASTER @item_id, @warehouse_id, @purchase_orders, @quantity_on_purchase_order, " +
                         "@quantity_on_hand, @quantity_committed,  @quantity_available, @item_name, @warehouse_code, @unit_id, @unit_symbol, " +
                         "@display_unit_id, @display_unit_symbol",
                         parameters: new SqlParameter[]
                         {
                            new SqlParameter("item_id",itemModule.ItemId),
                            new SqlParameter("warehouse_id",itemModule.WarehouseId),
                            new SqlParameter("purchase_orders",string.Empty),
                            new SqlParameter("quantity_on_purchase_order",itemModule.QuantityOnPurchaseOrder),
                            new SqlParameter("quantity_on_hand",itemModule.QuantityOnHand),
                            new SqlParameter("quantity_committed",itemModule.QuantityCommitted),
                            new SqlParameter("quantity_available",itemModule.QuantityAvailable),
                            new SqlParameter("item_name",itemModule.ItemName),
                            new SqlParameter("warehouse_code",itemModule.WarehouseCode),
                            new SqlParameter("unit_id",itemModule.UnitId),
                            new SqlParameter("unit_symbol",itemModule.UnitSymbol),
                            new SqlParameter("display_unit_id",itemModule.DisplayUnitId),
                            new SqlParameter("display_unit_symbol",itemModule.DisplayUnitSymbol)
                         });
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

        private static async Task InsertOrginCountry(string jsOrgincontry)
        {
            try
            {
                var jsContry = JSOriginCountry.FromJson(jsOrgincontry);
                foreach (var item in jsContry)
                {
                    var dbOrgin = await erpDbContext.OriginCountries.Where(x => x.CountryTranId == item.id).SingleOrDefaultAsync();
                    if (dbOrgin != null)
                    {
                        dbOrgin.CountryCode = item.countryCode;
                        dbOrgin.CountryName = item.countryName;
                        dbOrgin.Slug = item.slug;
                        dbOrgin.CountryTranId = item.id;
                        dbOrgin.CreatedAt = item.createdAt;
                        dbOrgin.UpdatedAt = item.updatedAt;
                        erpDbContext.OriginCountries.Update(dbOrgin);
                        await erpDbContext.SaveChangesAsync();
                    }
                    else
                    {
                        var newOrginCountry = new OriginCountry
                        {
                            CountryCode = item.countryCode,
                            CountryName = item.countryName,
                            Slug = item.slug,
                            CountryTranId = item.id,
                            CreatedAt = item.createdAt,
                            UpdatedAt = item.updatedAt,
                        };
                        await erpDbContext.OriginCountries.AddAsync(newOrginCountry);
                        await erpDbContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static async Task InsertItemCategory(string jsItemCategorys)
        {
            try
            {
                var jsCategory = JSItemCategory.FromJson(jsItemCategorys);
                foreach (var item in jsCategory)
                {
                    var dbItemCategory = await erpDbContext.ItemCategories.Where(x => x.CategoryTranId == item.id).SingleOrDefaultAsync();
                    if (dbItemCategory != null)
                    {
                        dbItemCategory.ParentCategory = item.parent != null ? item.parent.id : 0;
                        dbItemCategory.Category = item.name;
                        dbItemCategory.FactoryMinimumLinePrice = Convert.ToDecimal(item.factoryMinimumLinePrice);
                        dbItemCategory.ProductionMinimumLinePrice = Convert.ToDecimal(item.productionMinimumLinePrice);
                        dbItemCategory.CountryOfOrigin = item.countryOfOrigin;
                        dbItemCategory.Code = item.code;
                        dbItemCategory.CommodityCode = item.commodityCode;
                        dbItemCategory.CreatedAt = Convert.ToDateTime(item.createdAt);
                        dbItemCategory.UpdatedAt = Convert.ToDateTime(item.updatedAt);
                        dbItemCategory.CategoryTranId = item.id;
                        erpDbContext.ItemCategories.Update(dbItemCategory);
                        await erpDbContext.SaveChangesAsync();
                    }
                    else
                    {
                        var newCategory = new ItemCategory
                        {
                            ParentCategory = item.parent != null ? item.parent.id : 0,
                            Category = item.name,
                            FactoryMinimumLinePrice = Convert.ToDecimal(item.factoryMinimumLinePrice),
                            ProductionMinimumLinePrice = Convert.ToDecimal(item.productionMinimumLinePrice),
                            CountryOfOrigin = item.countryOfOrigin,
                            Code = item.code,
                            CommodityCode = item.commodityCode,
                            CreatedAt = Convert.ToDateTime(item.createdAt),
                            UpdatedAt = Convert.ToDateTime(item.updatedAt),
                            CategoryTranId = item.id,
                        };
                        await erpDbContext.ItemCategories.AddAsync(newCategory);
                        await erpDbContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
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

        private static async Task InsertAddOn(string jsaddOnMainClass)
        {
            try
            {
                var addOnMainClass = AddOnMainClass.FromJson(jsaddOnMainClass);

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

        private static async Task InsertOrderSource(CustomerDetails[] customerDetails)
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

        private static async Task InsertLogoMaster(CustomerDetails[] customerDetails)
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

        private static async Task InsertPaymentTerm(CustomerDetails[] customerDetails)
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

        private static async Task InsertCustomerGroup(CustomerDetails[] customerDetails)
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
