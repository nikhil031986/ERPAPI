using Newtonsoft.Json;

namespace ERPAPI_APP.JSONDataMigration
{
    public partial class AddOnMainClass
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("addOn")]
        public AddOn AddOn { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("orderInvoice", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderInvoice { get; set; }

        [JsonProperty("taxFlag")]
        public bool TaxFlag { get; set; }

        [JsonProperty("taxOverride")]
        public bool TaxOverride { get; set; }

        [JsonProperty("taxCode")]
        public string TaxCode { get; set; }

        [JsonProperty("taxRate")]
        public string TaxRate { get; set; }

        [JsonProperty("taxAmount")]
        public string TaxAmount { get; set; }

        [JsonProperty("purchaseOrderBill", NullValueHandling = NullValueHandling.Ignore)]
        public string PurchaseOrderBill { get; set; }
    }

    public partial class AddOn
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("totCd")]
        public string TotCd { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public partial class AddOnMainClass
    {
        public static AddOnMainClass[] FromJson(string json) => JsonConvert.DeserializeObject<AddOnMainClass[]>(json, ERPAPI_APP.JSONDataMigration.Converter.Settings);
    }
}
