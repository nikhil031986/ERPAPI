using Newtonsoft.Json;

namespace ERPAPI_APP.JSONDataMigration
{

    public partial class JSCustomer_Location
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("dateOfBirth")]
        public string DateOfBirth { get; set; }

        [JsonProperty("blindShip")]
        public bool BlindShip { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("salesRepresentative", NullValueHandling = NullValueHandling.Ignore)]
        public SalesRepresentative SalesRepresentative { get; set; }

        [JsonProperty("region", NullValueHandling = NullValueHandling.Ignore)]
        public Region Region { get; set; }

        [JsonProperty("customer")]
        public CustomerClass Customer { get; set; }

        [JsonProperty("hasConsolidatedShipments")]
        public bool HasConsolidatedShipments { get; set; }

        [JsonProperty("notes")]
        public object[] Notes { get; set; }

        [JsonProperty("files")]
        public object[] Files { get; set; }

        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("postal")]
        public string Postal { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("shipViaAccount")]
        public string ShipViaAccount { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("shipAttention")]
        public string ShipAttention { get; set; }

        [JsonProperty("isManualAddress")]
        public bool IsManualAddress { get; set; }

        [JsonProperty("address2")]
        public string Address2 { get; set; }

        [JsonProperty("address3")]
        public string Address3 { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("isResidential")]
        public bool IsResidential { get; set; }

        [JsonProperty("billingOption", NullValueHandling = NullValueHandling.Ignore)]
        public BillingOption BillingOption { get; set; }

        [JsonProperty("systemShipVia", NullValueHandling = NullValueHandling.Ignore)]
        public SystemShipVia SystemShipVia { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("updatedBy", NullValueHandling = NullValueHandling.Ignore)]
        public SalesRepresentative UpdatedBy { get; set; }

        [JsonProperty("deletedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DeletedAt { get; set; }
    }

    public partial class JSCustomer_Location
    {
        public static JSCustomer_Location[] FromJson(string json) => JsonConvert.DeserializeObject<JSCustomer_Location[]>(json, ERPAPI_APP.JSONDataMigration.Converter.Settings);
    }
   
    public partial class CustomerClass
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("customer")]
        public string Customer { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("updatedBy")]
        public SalesRepresentative UpdatedBy { get; set; }
    }

    public partial class SalesRepresentative
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("createdBy", NullValueHandling = NullValueHandling.Ignore)]
        public SalesRepresentative CreatedBy { get; set; }
    }

    public partial class Region
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("countryName")]
        public string CountryName { get; set; }

        [JsonProperty("region")]
        public string RegionRegion { get; set; }

        [JsonProperty("states")]
        public string[] States { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }
    }

    public partial class SystemShipVia
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("shipViaCode")]
        public string ShipViaCode { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("easyPostMethod")]
        public string EasyPostMethod { get; set; }

        [JsonProperty("carrier")]
        public JSCarrier Carrier { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("updatedBy")]
        public SalesRepresentative UpdatedBy { get; set; }
    }

}
