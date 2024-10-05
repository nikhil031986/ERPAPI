using Newtonsoft.Json;
using System;

namespace ERPAPI_APP.JSONDataMigration
{
    public partial class JSSalesTaxes
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("slug")]
        public string slug { get; set; }
        [JsonProperty("taxCode")]
        public string taxCode { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("country")]
        public string country {  get; set; }
        [JsonProperty("state")]
        public string state { get; set; }
        [JsonProperty("taxRate")]
        public double taxRate {  get; set; }
        [JsonProperty("createdAt")]
        public DateTime createdAt {  get; set; }
        [JsonProperty("updatedAt")]
        public DateTime updatedAt { get; set; }
        [JsonProperty("updatedBy")]
        public UpdatedBy updatedBy { get; set; }
        [JsonProperty("createdBy")]
        public CreatedBy createdBy { get; set; }
        [JsonProperty("generalLedgerAccount")]
        public JSgeneralLedgerAccount generalLedgerAccount { get; set; }
    }

    public partial class JSgeneralLedgerAccount
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("number")]
        public int number { get; set; }
    }

    public partial class JSSalesTaxes
    {
        public static JSSalesTaxes[] FromJson(string json) => JsonConvert.DeserializeObject<JSSalesTaxes[]>(json, Converter.Settings);
    }

    public partial class JSpayment_methods
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("paymentMethod")]
        public string paymentMethod { get; set; }
        [JsonProperty("methodDescription")]
        public string methodDescription {  get; set; }
        [JsonProperty("slug")]
        public string slug {  get; set; }
        [JsonProperty("isAccountsPayableMethod")]
        public bool isAccountsPayableMethod {  get; set; }
        [JsonProperty("isCreditCardPayment")]
        public bool isCreditCardPayment {  get; set; }
        [JsonProperty("createdAt")]
        public DateTime createdAt {  get; set; }
        [JsonProperty("updatedAt")]
        public DateTime updatedAt { get; set; }
    }

    public partial class JSpayment_methods
    {
        public static JSpayment_methods[] FromJson(string json) => JsonConvert.DeserializeObject<JSpayment_methods[]>(json, Converter.Settings);
    }
    public partial class JSOriginCountry
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("countryCode")]
        public string countryCode { get; set; }
        [JsonProperty("countryName")]
        public string countryName { get; set; }
        [JsonProperty("slug")]
        public string slug { get; set; }
        [JsonProperty("createdAt")]
        public DateTime? createdAt { get; set; }
        [JsonProperty("updatedAt")]
        public DateTime? updatedAt { get; set; }
    }

    public partial class JSOriginCountry
    {
        public static JSOriginCountry[] FromJson(string json) => JsonConvert.DeserializeObject<JSOriginCountry[]>(json,Converter.Settings);
    }

    public partial class JSItemCategory
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("code")]
        public string code { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("factoryMinimumLinePrice")]
        public double factoryMinimumLinePrice { get; set; }
        [JsonProperty("productionMinimumLinePrice")]
        public double productionMinimumLinePrice { get; set; }
        [JsonProperty("parent")]
        public ParentITemCategory parent { get; set; }
        [JsonProperty("commodityCode")]
        public string commodityCode { get; set; }
        [JsonProperty("countryOfOrigin")]
        public string countryOfOrigin { get; set; }
        [JsonProperty("createdAt")]
        public DateTime createdAt { get; set; }
        [JsonProperty("updatedAt")]
        public DateTime updatedAt { get; set; }
        [JsonProperty("updatedBy")]
        public UpdatedBy updatedBy { get; set; }
        [JsonProperty("createdBy")]
        public CreatedBy createdBy { get; set; }
        [JsonProperty("customAttributes")]
        public object customAttributes { get; set; }
        [JsonProperty("buyer")]
        public Buyer buyer { get; set; }
    }

    public partial class JSItemCategory
    {
        public static JSItemCategory[] FromJson(string json) => JsonConvert.DeserializeObject<JSItemCategory[]>(json, ERPAPI_APP.JSONDataMigration.Converter.Settings);
    }

    public partial class ParentITemCategory
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public double factoryMinimumLinePrice { get; set; }
        public double productionMinimumLinePrice { get; set; }
        public string commodityCode { get; set; }
        public string countryOfOrigin { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public UpdatedBy updatedBy { get; set; }
        public CreatedBy createdBy { get; set; }
        public object customAttributes { get; set; }
        public ParentITemCategory parent { get; set; }
    }

    public partial class Buyer
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

}
