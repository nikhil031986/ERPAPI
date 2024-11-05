using ERPAPI_APP.JSONDataMigration;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ERPAPI_APP.Models
{
    public partial class AspNetUserList
    {
        public int UserId { get; set; }
        public string EmailId { get; set; }
        public List<CustomerMaster> Customer { get; set; }
        public List<Company> Compny { get; set; }
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
    public partial class taxItemDetails
    {
        public string? product_tax_code { get; set; }
        public decimal? unit_price { get; set; }
        public decimal? quantity { get; set; }
    }
    public partial class TaxCalulation
    {
        public string? from_country { get; set; }
        public string? from_zip { get; set; }
        public string? from_state { get; set; }
        public string? from_city { get; set; }
        public string? to_country { get; set; }
        public string? to_zip { get; set; }
        public string? to_state { get; set; }
        public string? to_city { get; set; }
        public decimal? amount { get; set; }
        public decimal? shipping { get; set; }
        public List<taxItemDetails>? line_items { get; set; }
    }
    public partial class ItemByCategory
    {
        public int Item_Id { get; set; }
        public string? Item_Name { get; set; }
        public string? Item_Description { get; set; }
        public string? webdescription { get; set; }
        public decimal? Item_Price { get; set; }
        public decimal? weight { get; set; }
        public decimal? Ship_width { get; set; }
        public decimal? ship_Height { get; set; }
        public decimal? Ship_Length { get; set; }
        public string? itemUnit { get; set; }
        public string? displayunit { get; set; }
        public string? countryoforgin { get; set; }
        public List<CustomerMaster>? vendor { get; set; }
        public List<ItemImage>? Item_Images { get; set; }
        public List<ItemCategory>? Item_Category { get; set; }
        public string? ImageUrl { get; set; }
    }

    public partial class GetOrderDetail
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public string? imgPath { get; set; }

        public string ItemCode { get; set; } = null!;

        public string? itemDesc { get; set; }

        public decimal ItemPrice { get; set; }

        public string Unit { get; set; } = null!;

        public decimal Qty { get; set; } = 0;
    }

    public partial class GetOrderMaster
    {
        public int Id { get; set; }

        public string? OrderId { get; set; }

        public int CustomerId { get; set; }

        public CustomerMaster? customer { get; set; }

        public DateTime? OrderDate { get; set; }

        public int? PaymentMethodId { get; set; }

        public PaymentMethod? pymethod { get; set; }

        public int? PaymentTermId { get; set; }

        public PaymentTerm? pyTerm { get; set; }

        public decimal? TotalAmout { get; set; }

        public decimal? DiscountAmount { get; set; }

        public List<GetOrderDetail>? OrderDetails { get; set; } = new List<GetOrderDetail>();

        public List<GetOrderPayment>? OrderPayments { get; set; } = new List<GetOrderPayment>();

        public List<GetOrderShipment>? OrderShipments { get; set; } = new List<GetOrderShipment>();
    }

    public partial class GetOrderShipment
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public string? Address1 { get; set; }

        public string? Address2 { get; set; }

        public string? State { get; set; }

        public string? Contry { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

    }

    public partial class GetOrderPayment
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int? PaymentType { get; set; }

        public int? PaymentTerm { get; set; }

        public decimal? Amount { get; set; }
    }

    public partial class OrderDetailEntry
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public string ItemCode { get; set; } = null!;

        public decimal ItemPrice { get; set; }

        public string Unit { get; set; } = null!;

        public decimal Qty { get; set; } = 0;

        public DateTime? CreateAt { get; set; }
    }

    public partial class OrderMasterEntry
    {
        public int Id { get; set; }

        public string? OrderId { get; set; }

        public int CustomerId { get; set; }

        public DateTime? OrderDate { get; set; }

        public int? PaymentMethodId { get; set; }

        public int? PaymentTermId { get; set; }

        public decimal? TotalAmout { get; set; }

        public decimal? DiscountAmount { get; set; }

        public List<OrderDetailEntry>? OrderDetails { get; set; } = new List<OrderDetailEntry>();

        public List<OrderPaymentEntry>? OrderPayments { get; set; } = new List<OrderPaymentEntry>();

        public List<OrderShipmentEntry>? OrderShipments { get; set; } = new List<OrderShipmentEntry>();
    }

    public partial class OrderShipmentEntry
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public string? Address1 { get; set; }

        public string? Address2 { get; set; }

        public string? State { get; set; }

        public string? Contry { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

    }

    public partial class paymentDetailsEntry
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public decimal? Amount { get; set; }

        public string? PaymentThrow { get; set; }

        public string? CardNumber { get; set; }

        public string? CvcCheck { get; set; }

        public string? ExpMonth { get; set; }

        public string? ExpYear { get; set; }

        public string? Funding { get; set; }

        public string? Last4 { get; set; }

        public string? EmailId { get; set; }

        public string? ClientIp { get; set; }

        public string? TokenValue { get; set; }

    }

    public partial class OrderPaymentEntry
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int? PaymentType { get; set; }

        public int? PaymentTerm { get; set; }

        public decimal? Amount { get; set; }
    }

    public partial class objcustomerDetails
    {
        public int? customerId { get; set; }
        public CustomerMaster? CustomerMaster { get; set; }
        public ContactMaster? ContactDetails { get; set; }
        public CustomerLocationInformation? customerLocationInformation { get; set; }
        public List<PaymentTerm>? PaymentTerm { get; set; }
        public List<PaymentMethod>? PaymentMethod { get; set; }
        public List<SystemShipVium>? systemShipVia { get; set; }
        public List<PrimaryShippingLocation>? shipingLocation { get; set; }
        public List<CustomerLocationInformation> shipAddresses { get; set; }
    }


    public partial class GetCartDetail
    {
        public string? ItemCode { get; set; }
        public string? imagePath { get; set; }
        public string? Unit { get; set; }
        public decimal Quntity { get; set; }
        public decimal? ItemPrice { get; set; }
        public string? Item_Description { get; set; }
    }

    public partial class MasterMenu
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public int ParentCategory { get; set; }
        public List<ItemCategory> ChildMenuItem { get; set; }
        public int ChildCount { get; set; }
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

        public List<RegionMaster> region { get; set; }

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
