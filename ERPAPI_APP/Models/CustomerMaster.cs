using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class CustomerMaster
{
    public int CustomerId { get; set; }

    public string? CustomerCode { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Slug { get; set; }

    public string? PhoneExtension { get; set; }

    public string? Titled { get; set; }

    public string? Email { get; set; }

    public string? Contact { get; set; }

    public string? Phone { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int CustomerTranId { get; set; }

    public int AveragePayDays { get; set; }

    public bool BoFlag { get; set; }

    public bool AlwaysShipCompleteFlag { get; set; }

    public bool PoRequiredFlag { get; set; }

    public bool CcfFlag { get; set; }

    public string CrLimit { get; set; } = null!;

    public string? InvoiceEmail { get; set; }

    public string? Customer { get; set; }

    public string? SicCode { get; set; }

    public string? TaxId { get; set; }

    public string? TaxExempt { get; set; }

    public int? GraceDays { get; set; }

    public bool? HasConsolidatedInvoices { get; set; }

    public bool? IsAssessFinanceCharges { get; set; }

    public string? StatementDestinationEmail { get; set; }

    public string? OrderAcknowledgementEmail { get; set; }

    public string? ShippingConfirmationEmail { get; set; }

    public string? PickupConfirmationEmail { get; set; }

    public string? OrderAcknowledgementEmailSelect { get; set; }

    public string? ShippingConfirmationEmailSelect { get; set; }

    public string? PickupConfirmationEmailSelect { get; set; }

    public bool? IsAlwaysPassCreditCheck { get; set; }

    public bool? IsPreferFullLots { get; set; }

    public bool? IsRequireFullLots { get; set; }

    public string? ExternalDocparserParserId { get; set; }

    public bool? LocationToBlind { get; set; }

    public bool? InvoiceOptionEmail { get; set; }

    public bool? InvoiceOptionPrint { get; set; }

    public bool? CooRequiredFlag { get; set; }

    public bool? IsStateTaxExempt { get; set; }

    public bool? IsSyncToHubSpot { get; set; }

    public string? Website { get; set; }

    public bool? PrintPriceOnPickingSlip { get; set; }

    public bool? PrintPriceOnPackingSlip { get; set; }

    public bool? IsDraft { get; set; }

    public int? QualityCheckTarget { get; set; }

    public string? FontColor { get; set; }

    public string? BorderColor { get; set; }

    public string? ShadingColor { get; set; }

    public string? LabelQuantity { get; set; }

    public string? PackingSlipPdfTemplate { get; set; }

    public int PaymentTermId { get; set; }

    public int LogoMasterId { get; set; }

    public int OrderSourceMasterId { get; set; }

    public int CustomerGroupId { get; set; }
}
