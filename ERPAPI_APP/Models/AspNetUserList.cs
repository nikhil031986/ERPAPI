namespace ERPAPI_APP.Models
{
    public partial class AspNetUserList
    {
        public int UserId { get; set; }
        public string EmailId { get; set; }
        public List<CustomerMaster> Customer { get;set; }
        public List<Company> Compny { get;set; }
        public List<AspNetRole> AspNetRoles { get; set; }
    }

    public partial class ContactDetails
    {
        public ContactMaster contactMaster { get; set; }
        public CustomerMaster customer { get; set; }
    }

    public partial class UserDetails
    {
        public string UserEmailId { get; set; }
        public string password { get; set; }
    }
    public partial class SingUp
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string emailId { get; set; }
        public string password { get; set; }
        public string companyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
    }
    public partial class GetCustomerLocation
    {
        public int CustomerLocationId { get; set; }

        public CustomerMaster Customer { get; set; }

        public List<RegionMaster> region {  get; set; }   

        public DateTime? Dob { get; set; }

        public string? Location { get; set; }

        public string? Address1 { get; set; }

        public string? Address2 { get; set; }

        public string? Address3 { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Country { get; set; }

        public string? Postal { get; set; }

        public string? Phone { get; set; }

        public bool? BlindShip { get; set; }

        public string? Name { get; set; }

        public string? ShipViaAccount { get; set; }

        public string? Slug { get; set; }

        public string? ShipAttention { get; set; }

        public bool? HasConsolidatedShipments { get; set; }

        public bool? IsResidential { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? CustomerLocationTranId { get; set; }
    }

    public partial class GetAddOnData
    {
        public int Id { get; set; }

        public decimal? Amount { get; set; }

        public string? OrderInvoice { get; set; }

        public bool? TaxFlag { get; set; }

        public bool? TaxOverride { get; set; }

        public string? TaxCode { get; set; }

        public decimal? TaxRate { get; set; }

        public decimal? TaxAmount { get; set; }

        public string? PurchaseOrderBill { get; set; }

        public int? AddOnTranId { get; set; }

        public List<AddOnDetail> AddonDetails { get; set; }
    }

    public partial class GetSystemShipVium
    {
        public int Id { get; set; }

        public string? Slug { get; set; }

        public string? ShipViaCode { get; set; }

        public string? Description { get; set; }

        public string? PackageType { get; set; }

        public string? WebDescription { get; set; }

        public bool? SaturdayDeliveryOption { get; set; }

        public bool? CreditCardPreAuthOption { get; set; }

        public bool? FreeShip { get; set; }

        public bool? Web { get; set; }

        public List<EasyPostMethod> EasyPostMethods { get; set; }

        public bool? Expedite { get; set; }

        public bool? FreeFreightAllowed { get; set; }

        public bool? International { get; set; }

        public bool? Collect { get; set; }

        public List<Carrier> carrier { get; set; }

        public bool? IsReturnMethod { get; set; }

        public string? BillingOptions { get; set; }

        public string? HandlingChargeAmount { get; set; }

        public string? HandlingChargePercent { get; set; }

        public bool? IsPickup { get; set; }

        public bool? IsDelivery { get; set; }

        public string? EdiServiceLevelCode { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? SystemShipViaTranId { get; set; }
    }

    public partial class GetCustomer
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

        public List<PaymentTerm> paymentTerm { get; set; }

        public List<LogoMaster> Logo { get; set; }

        public List<OrderSourceMaster> orderSource { get; set; }

        public List<CustomerGroup> customerGroup { get; set; }
    }
}
