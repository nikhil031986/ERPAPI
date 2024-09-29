using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace ERPAPI_APP.JSONDataMigration
{
    public class BillingOption
    {
        public int id { get; set; }
        public string description { get; set; }
        public string value { get; set; }
        public bool addToInvoice { get; set; }
        public string slug { get; set; }
        public bool isRequireBillingAccount { get; set; }
        public bool isUseCompanyAccount { get; set; }
    }

    public class JSCarrier
    {
        public int id { get; set; }
        public string slug { get; set; }
        public string carrier { get; set; }
        public string shipViaAccount { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public UpdatedBy updatedBy { get; set; }
    }

    public class CrAttention
    {
        public int id { get; set; }
        public string slug { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneExtension { get; set; }
        public string titled { get; set; }
        public string contact { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string customer { get; set; }
        public string email { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public UpdatedBy updatedBy { get; set; }
        public CreatedBy createdBy { get; set; }
    }

    public class CreatedBy
    {
        public int id { get; set; }
        public string slug { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string name { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public CreatedBy createdBy { get; set; }
        public UpdatedBy updatedBy { get; set; }
    }

    public class CustomAttributes
    {
        [JsonProperty("keyword$value")]
        public string keywordvalue { get; set; }
    }

    public class CustomerGroup
    {
        public int id { get; set; }
        public string value { get; set; }
        public string description { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public CreatedBy createdBy { get; set; }
        public UpdatedBy updatedBy { get; set; }
    }

    public class LabelPrinter
    {
        public int id { get; set; }
        public string slug { get; set; }
        public SelectedPrinter selectedPrinter { get; set; }
        public string printerName { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public CreatedBy createdBy { get; set; }
        public UpdatedBy updatedBy { get; set; }
    }

    public class LabelTool
    {
        public int id { get; set; }
        public string templateName { get; set; }
        public string slug { get; set; }
    }

    public class Logo
    {
        public int id { get; set; }
        public string size { get; set; }
        public string eTag { get; set; }
        public string contentType { get; set; }
        public string fileName { get; set; }
        public string key { get; set; }
        public string description { get; set; }
        public int fileOrder { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

    public partial class OrderSource
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("slug")]
        public string slug { get; set; }
        [JsonProperty("code")]
        public string code { get; set; }
        [JsonProperty("createdAt")]
        public DateTime createdAt { get; set; }
        [JsonProperty("updatedAt")]
        public DateTime updatedAt { get; set; }
    }

    public partial class OrderSource
    {
        public static OrderSource[] FromJson(string json) => JsonConvert.DeserializeObject<OrderSource[]>(json, ERPAPI_APP.JSONDataMigration.Converter.Settings);
    }

    public class ParentCustomer
    {
        public string email { get; set; }
        public int id { get; set; }
        public string slug { get; set; }
        public int averagePayDays { get; set; }
        public bool boFlag { get; set; }
        public bool alwaysShipCompleteFlag { get; set; }
        public bool poRequiredFlag { get; set; }
        public bool ccfFlag { get; set; }
        public string crLimit { get; set; }
        public string phone { get; set; }
        public string invoiceEmail { get; set; }
        public string customer { get; set; }
        public string name { get; set; }
        public string sicCode { get; set; }
        public string taxId { get; set; }
        public string taxExempt { get; set; }
        public PrimaryAttention primaryAttention { get; set; }
        public CrAttention crAttention { get; set; }
        public SalesRepresentative salesRepresentative { get; set; }
        public CustomAttributes customAttributes { get; set; }
        public PaymentTerm paymentTerm { get; set; }
        public bool taxFlag { get; set; }
        public int graceDays { get; set; }
        public int qualityCheckTarget { get; set; }
        public bool hasConsolidatedInvoices { get; set; }
        public PrimaryCustomerLocation primaryCustomerLocation { get; set; }
        public PrimaryShippingLocation primaryShippingLocation { get; set; }
        public bool isAssessFinanceCharges { get; set; }
        public string statementDestinationEmail { get; set; }
        public string orderAcknowledgementEmail { get; set; }
        public string shippingConfirmationEmail { get; set; }
        public string pickupConfirmationEmail { get; set; }
        public string orderAcknowledgementEmailSelect { get; set; }
        public string shippingConfirmationEmailSelect { get; set; }
        public string pickupConfirmationEmailSelect { get; set; }
        public bool isAlwaysPassCreditCheck { get; set; }
        public bool isPreferFullLots { get; set; }
        public bool isRequireFullLots { get; set; }
        public string externalDocparserParserId { get; set; }
        public bool locationToBlind { get; set; }
        public bool invoiceOptionEmail { get; set; }
        public bool invoiceOptionPrint { get; set; }
        public bool cooRequiredFlag { get; set; }
        public bool isStateTaxExempt { get; set; }
        public bool isSyncToHubSpot { get; set; }
        public string website { get; set; }
        public bool printPriceOnPickingSlip { get; set; }
        public bool printPriceOnPackingSlip { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public CreatedBy createdBy { get; set; }
        public UpdatedBy updatedBy { get; set; }
        public bool isDraft { get; set; }
    }

    public class PaymentTerm
    {
        public int id { get; set; }
        public string slug { get; set; }
        public string description { get; set; }
        public int discountDays { get; set; }
        public int dueDays { get; set; }
        public double totalDiscountPercent { get; set; }
        public string termsCode { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

    public class PrimaryAttention
    {
        public int id { get; set; }
        public string slug { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneExtension { get; set; }
        public string titled { get; set; }
        public string contact { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string customer { get; set; }
        public string email { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public UpdatedBy updatedBy { get; set; }
        public CreatedBy createdBy { get; set; }
    }

    public class PrimaryCustomerLocation
    {
        public string name { get; set; }
        public string location { get; set; }
        public Region region { get; set; }
        public string address1 { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string postal { get; set; }
        public string state { get; set; }
        public string shipViaAccount { get; set; }
        public string slug { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string phone { get; set; }
        public bool isResidential { get; set; }
        public BillingOption billingOption { get; set; }
        public SystemShipVia systemShipVia { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public UpdatedBy updatedBy { get; set; }
        public CreatedBy createdBy { get; set; }
    }

    public class PrimaryShippingLocation
    {
        public string name { get; set; }
        public string location { get; set; }
        public Region region { get; set; }
        public string address1 { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string postal { get; set; }
        public string state { get; set; }
        public string shipViaAccount { get; set; }
        public string slug { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string phone { get; set; }
        public bool isResidential { get; set; }
        public BillingOption billingOption { get; set; }
        public SystemShipVia systemShipVia { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public UpdatedBy updatedBy { get; set; }
        public CreatedBy createdBy { get; set; }
    }

    public partial class CustomerDetails
    {
        public string email { get; set; }
        public int id { get; set; }
        public string slug { get; set; }
        public int averagePayDays { get; set; }
        public bool boFlag { get; set; }
        public bool alwaysShipCompleteFlag { get; set; }
        public bool poRequiredFlag { get; set; }
        public bool ccfFlag { get; set; }
        public string crLimit { get; set; }
        public string phone { get; set; }
        public string invoiceEmail { get; set; }
        public string customer { get; set; }
        public string name { get; set; }
        public string sicCode { get; set; }
        public string taxId { get; set; }
        public string taxExempt { get; set; }
        public PrimaryAttention primaryAttention { get; set; }
        public CrAttention crAttention { get; set; }
        public SalesRepresentative salesRepresentative { get; set; }
        public object customAttributes { get; set; }
        public PaymentTerm paymentTerm { get; set; }
        public bool taxFlag { get; set; }
        public int graceDays { get; set; }
        public bool hasConsolidatedInvoices { get; set; }
        public PrimaryCustomerLocation primaryCustomerLocation { get; set; }
        public PrimaryShippingLocation primaryShippingLocation { get; set; }
        public bool isAssessFinanceCharges { get; set; }
        public string statementDestinationEmail { get; set; }
        public string orderAcknowledgementEmail { get; set; }
        public string shippingConfirmationEmail { get; set; }
        public string pickupConfirmationEmail { get; set; }
        public string orderAcknowledgementEmailSelect { get; set; }
        public string shippingConfirmationEmailSelect { get; set; }
        public string pickupConfirmationEmailSelect { get; set; }
        public bool isAlwaysPassCreditCheck { get; set; }
        public bool isPreferFullLots { get; set; }
        public bool isRequireFullLots { get; set; }
        public string externalDocparserParserId { get; set; }
        public bool locationToBlind { get; set; }
        public bool invoiceOptionEmail { get; set; }
        public bool invoiceOptionPrint { get; set; }
        public bool cooRequiredFlag { get; set; }
        public bool isStateTaxExempt { get; set; }
        public bool isSyncToHubSpot { get; set; }
        public string website { get; set; }
        public bool printPriceOnPickingSlip { get; set; }
        public bool printPriceOnPackingSlip { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public UpdatedBy updatedBy { get; set; }
        public bool isDraft { get; set; }
        public CustomerGroup customerGroup { get; set; }
        public int? qualityCheckTarget { get; set; }
        public OrderSource orderSource { get; set; }
        public CreatedBy createdBy { get; set; }
        public DateTime? deletedAt { get; set; }
        public ParentCustomer parentCustomer { get; set; }
        public string fontColor { get; set; }
        public string borderColor { get; set; }
        public string shadingColor { get; set; }
        public Logo logo { get; set; }
        public string labelQuantity { get; set; }
        public string packingSlipPdfTemplate { get; set; }
        public LabelTool labelTool { get; set; }
        public LabelPrinter labelPrinter { get; set; }
    }

    public partial class CustomerDetails
    {
        public static CustomerDetails[] FromJson(string json) => JsonConvert.DeserializeObject<CustomerDetails[]>(json, ERPAPI_APP.JSONDataMigration.Converter.Settings);
    }

    public class SelectedPrinter
    {
        public string printerId { get; set; }
        public string printerName { get; set; }
        public string computerName { get; set; }
        public string computerId { get; set; }
    }

    public class UpdatedBy
    {
        public int id { get; set; }
        public string slug { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string name { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public CreatedBy createdBy { get; set; }
        public UpdatedBy updatedBy { get; set; }
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
