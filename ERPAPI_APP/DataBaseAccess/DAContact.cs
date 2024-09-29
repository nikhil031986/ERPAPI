using ERPAPI_APP.JSONDataMigration;
using ERPAPI_APP.Models;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;

namespace ERPAPI_APP.DataBaseAccess
{
    internal class DAContact
    {
        internal static async Task<List<ContactDetails>> Contacts()
            => await UtilObject.erpDbContext.ContactMasters
                .Join(UtilObject.erpDbContext.CustomerMasters, p => p.CustomerId, pc => pc.CustomerId, (p, pc) => new { p, pc })
                .Select(m => new ContactDetails
                {
                    contactMaster = m.p,
                    customer = m.pc
                }).ToListAsync();

        internal static async Task InsertContact(string contactModelData)
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

        internal static async Task<ContactMaster> CreateContact(SingUp singUp)
        {
            try
            {
                var NewContact = new ContactMaster
                {
                    Slug = singUp.FirstName + " " + singUp.LastName,
                    FirstName = singUp.FirstName,
                    LastName = singUp.LastName,
                    CustomerId = 1,
                    Phone = singUp.Phone,
                    ContactTranId = 0,
                    PhoneExtension = string.Empty,
                    Titled = string.Empty,
                    Name = singUp.FirstName + " " + singUp.LastName,
                    Email = singUp.emailId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };
                
                await UtilObject.erpDbContext.ContactMasters.AddAsync(NewContact);
                await UtilObject.erpDbContext.SaveChangesAsync();
                return NewContact;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
