using Newtonsoft.Json;

namespace ERPAPI_APP.JSONDataMigration
{
    public class JSCustomer
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("slug")]
        public string slug { get; set; }
        [JsonProperty("customer")]
        public string customer { get; set; }
        [JsonProperty("createdAt")]
        public DateTime createdAt { get; set; }
        [JsonProperty("updatedAt")]
        public DateTime updatedAt { get; set; }
        [JsonProperty("updatedBy")]
        public UpdatedBy updatedBy { get; set; }
    }

    public partial class JSContact
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("slug")]
        public string slug { get; set; }
        [JsonProperty("firstName")]
        public string firstName { get; set; }
        [JsonProperty("lastName")]
        public string lastName { get; set; }
        [JsonProperty("phoneExtension")]
        public string phoneExtension { get; set; }
        [JsonProperty("titled")]
        public string titled { get; set; }
        [JsonProperty("contact")]
        public string contact { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("phone")]
        public string phone { get; set; }
        [JsonProperty("customer")]
        public JSCustomer customer { get; set; }
        [JsonProperty("email")]
        public string email { get; set; }
        [JsonProperty("files")]
        public List<object> files { get; set; }
        [JsonProperty("createdAt")]
        public DateTime createdAt { get; set; }
        [JsonProperty("updatedAt")]
        public DateTime updatedAt { get; set; }
        [JsonProperty("updatedBy")]
        public UpdatedBy updatedBy { get; set; }
        [JsonProperty("deletedAt")]
        public DateTime? deletedAt { get; set; }
    }

    public partial class JSContact
    {
        public static JSContact[] FromJson(string json) => JsonConvert.DeserializeObject<JSContact[]>(json, ERPAPI_APP.JSONDataMigration.Converter.Settings);
    }
}
