using ERPAPI_APP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPAPI_APP.DataBaseAccess
{
    internal static class DBACustomer
    {
        internal static async Task<List<GetCustomer>> GetCustomer()
            => await UtilObject.erpDbContext.CustomerMasters.Select(x => new GetCustomer
            {
                CustomerId = x.CustomerId,
                CustomerCode = x.CustomerCode,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Slug = x.Slug,
                PhoneExtension = x.PhoneExtension,
                Titled = x.Titled,
                Email = x.Email,
                Contact = x.Contact,
                Phone = x.Phone,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                CustomerTranId = x.CustomerTranId,
                AveragePayDays = x.AveragePayDays,
                BoFlag = x.BoFlag,
                AlwaysShipCompleteFlag = x.AlwaysShipCompleteFlag,
                PoRequiredFlag = x.PoRequiredFlag,
                CcfFlag = x.CcfFlag,
                CrLimit = x.CrLimit,
                InvoiceEmail = x.InvoiceEmail,
                Customer = x.Customer,
                SicCode = x.SicCode,
                TaxId = x.TaxId,
                TaxExempt = x.TaxExempt,
                GraceDays = x.GraceDays,
                HasConsolidatedInvoices = x.HasConsolidatedInvoices,
                IsAssessFinanceCharges =x.IsAssessFinanceCharges,
                StatementDestinationEmail = x.StatementDestinationEmail,
                OrderAcknowledgementEmail = x.OrderAcknowledgementEmail,
                ShippingConfirmationEmail= x.ShippingConfirmationEmail,
                PickupConfirmationEmail= x.PickupConfirmationEmail,
                OrderAcknowledgementEmailSelect = x.OrderAcknowledgementEmailSelect,
                ShippingConfirmationEmailSelect= x.ShippingConfirmationEmailSelect,
                PickupConfirmationEmailSelect = x.PickupConfirmationEmailSelect,
                IsAlwaysPassCreditCheck = x.IsAlwaysPassCreditCheck,
                IsPreferFullLots = x.IsPreferFullLots,
                IsRequireFullLots = x.IsRequireFullLots,
                ExternalDocparserParserId = x.ExternalDocparserParserId,
                LocationToBlind =x.LocationToBlind,
                InvoiceOptionEmail = x.InvoiceOptionEmail,
                InvoiceOptionPrint = x.InvoiceOptionPrint,
                CooRequiredFlag = x.CooRequiredFlag,
                IsStateTaxExempt = x.IsStateTaxExempt,
                IsSyncToHubSpot  = x.IsSyncToHubSpot,
                Website = x.Website,
                PrintPriceOnPickingSlip =x.PrintPriceOnPickingSlip,
                PrintPriceOnPackingSlip= x.PrintPriceOnPackingSlip,
                IsDraft = x.IsDraft,
                QualityCheckTarget = x.QualityCheckTarget,
                FontColor = x.FontColor,
                BorderColor = x.BorderColor,
                ShadingColor = x.ShadingColor,
                LabelQuantity = x.LabelQuantity,
                PackingSlipPdfTemplate=x.PackingSlipPdfTemplate,
                paymentTerm = UtilObject.erpDbContext.PaymentTerms.Where(p=> p.Id == x.PaymentTermId).ToList(),
                Logo = UtilObject.erpDbContext.LogoMasters.Where(l=> l.Id == x.LogoMasterId).ToList(),
                orderSource= UtilObject.erpDbContext.OrderSourceMasters.Where(o=> o.Id == x.OrderSourceMasterId).ToList(),
                customerGroup = UtilObject.erpDbContext.CustomerGroups.Where(c=>c.Id == x.CustomerGroupId).ToList(),
    }).ToListAsync();

    internal static async Task<List<CustomerMaster>> FindCustomer(int? customerId)
        => await UtilObject.erpDbContext.CustomerMasters.Where(x => x.CustomerId == customerId).ToListAsync();
}
}
