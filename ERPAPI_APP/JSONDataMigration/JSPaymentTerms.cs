using Newtonsoft.Json;

namespace ERPAPI_APP.JSONDataMigration
{
    public partial class JSPaymentTerms
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("slug")]
        public string slug { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("discountDays")]
        public int discountDays { get; set; }
        [JsonProperty("dueDays")]
        public int dueDays { get; set; }
        [JsonProperty("totalDiscountPercent")]
        public double totalDiscountPercent { get; set; }
        [JsonProperty("termsCode")]
        public string termsCode { get; set; }
        [JsonProperty("createdAt")]
        public DateTime createdAt { get; set; }
        [JsonProperty("updatedAt")]
        public DateTime updatedAt { get; set; }
        [JsonProperty("updatedBy")]
        public UpdatedBy updatedBy { get; set; }
    }

    public partial class JSPaymentTerms
    {
        public static JSPaymentTerms[] FromJson(string json) => JsonConvert.DeserializeObject<JSPaymentTerms[]>(json, ERPAPI_APP.JSONDataMigration.Converter.Settings);
    }
}
