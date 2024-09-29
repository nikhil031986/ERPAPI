using Newtonsoft.Json;

namespace ERPAPI_APP.JSONDataMigration
{
    public partial class JsWarehouse
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("attention")]
        public string attention { get; set; }
        [JsonProperty("code")]
        public string code { get; set; }
        [JsonProperty("external")]
        public bool external { get; set; }
        [JsonProperty("web")]
        public bool web { get; set; }
        [JsonProperty("slug")]
        public string slug { get; set; }
        [JsonProperty("email")]
        public string email { get; set; }
        [JsonProperty("transferShipViaAccount")]
        public string transferShipViaAccount { get; set; }
        [JsonProperty("address1")]
        public string address1 { get; set; }
        [JsonProperty("address2")]
        public string address2 { get; set; }
        [JsonProperty("address3")]
        public string address3 { get; set; }
        [JsonProperty("city")]
        public string city { get; set; }
        [JsonProperty("country")]
        public string country { get; set; }
        [JsonProperty("postal")]
        public string postal { get; set; }
        [JsonProperty("state")]
        public string state { get; set; }
        [JsonProperty("phone")]
        public string phone { get; set; }
        [JsonProperty("isResidential")]
        public bool isResidential { get; set; }
        [JsonProperty("createdAt")]
        public DateTime createdAt { get; set; }
        [JsonProperty("updatedAt")]
        public DateTime updatedAt { get; set; }
        [JsonProperty("updatedBy")]
        public UpdatedBy updatedBy { get; set; }
        [JsonProperty("createdBy")]
        public CreatedBy createdBy { get; set; }
    }

    public partial class JsWarehouse
    {
        public static JsWarehouse[] FromJson(string json) => JsonConvert.DeserializeObject<JsWarehouse[]>(json, ERPAPI_APP.JSONDataMigration.Converter.Settings);
    }
}
