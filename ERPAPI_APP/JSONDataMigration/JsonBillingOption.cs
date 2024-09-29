using Newtonsoft.Json;

namespace ERPAPI_APP.JSONDataMigration
{
    public partial class JsonBillingOption
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("addToInvoice", NullValueHandling = NullValueHandling.Ignore)]
        public string AddToInvoice { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("isRequireBillingAccount")]
        public bool IsRequireBillingAccount { get; set; }

        [JsonProperty("isUseCompanyAccount")]
        public bool IsUseCompanyAccount { get; set; }
    }

    public partial class JsonBillingOption
    {
        public static JsonBillingOption[] FromJson(string json) => JsonConvert.DeserializeObject<JsonBillingOption[]>(json, ERPAPI_APP.JSONDataMigration.Converter.Settings);
    }
}
