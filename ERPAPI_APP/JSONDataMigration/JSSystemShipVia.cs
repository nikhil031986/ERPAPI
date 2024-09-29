using Newtonsoft.Json;

namespace ERPAPI_APP.JSONDataMigration
{
    public partial class JSEasyPostMethod
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
    }

    public partial class JSSystemShipVia
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("slug")]
        public string slug { get; set; }
        [JsonProperty("shipViaCode")]
        public string shipViaCode { get; set; }
        [JsonProperty("description")] 
        public string description { get; set; }
        [JsonProperty("packageType")]
        public string packageType { get; set; }
        [JsonProperty("webDescription")]
        public string webDescription { get; set; }
        [JsonProperty("saturdayDeliveryOption")]
        public bool saturdayDeliveryOption { get; set; }
        [JsonProperty("creditCardPreAuthOption")]
        public bool creditCardPreAuthOption { get; set; }
        [JsonProperty("freeShip")]
        public bool freeShip { get; set; }
        [JsonProperty("web")]
        public bool web { get; set; }
        [JsonProperty("easyPostMethod")]
        public JSEasyPostMethod easyPostMethod { get; set; }
        [JsonProperty("expedite")]
        public bool expedite { get; set; }
        [JsonProperty("freeFreightAllowed")]
        public bool freeFreightAllowed { get; set; }
        [JsonProperty("international")]
        public bool international { get; set; }
        [JsonProperty("collect")]
        public bool collect { get; set; }
        [JsonProperty("carrier")]
        public JSCarrier carrier { get; set; }
        [JsonProperty("isReturnMethod")]
        public bool isReturnMethod { get; set; }
        [JsonProperty("billingOptions")]
        public List<BillingOption> billingOptions { get; set; }
        [JsonProperty("handlingChargeAmount")]
        public string handlingChargeAmount { get; set; }
        [JsonProperty("handlingChargePercent")]
        public string handlingChargePercent { get; set; }
        [JsonProperty("isPickup")]
        public bool isPickup { get; set; }
        [JsonProperty("isDelivery")]
        public bool isDelivery { get; set; }
        [JsonProperty("ediServiceLevelCode")]
        public string ediServiceLevelCode { get; set; }
        [JsonProperty("createdAt")]
        public DateTime createdAt { get; set; }
        [JsonProperty("updatedAt")]
        public DateTime updatedAt { get; set; }
        [JsonProperty("updatedBy")]
        public UpdatedBy updatedBy { get; set; }
        [JsonProperty("createdBy")]
        public CreatedBy createdBy { get; set; }
    }

    public partial class JSSystemShipVia
    {
        public static JSSystemShipVia[] FromJson(string json) => JsonConvert.DeserializeObject<JSSystemShipVia[]>(json, ERPAPI_APP.JSONDataMigration.Converter.Settings);
    }
}
