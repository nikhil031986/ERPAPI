using Newtonsoft.Json;

namespace ERPAPI_APP.JSONDataMigration
{
    public partial class ItemModule
    {
        [JsonProperty("item_id")]
        public long ItemId { get; set; }

        [JsonProperty("warehouse_id")]
        public long WarehouseId { get; set; }

        [JsonProperty("purchase_orders")]
        public object[] PurchaseOrders { get; set; }

        [JsonProperty("quantity_on_purchase_order")]
        public long QuantityOnPurchaseOrder { get; set; }

        [JsonProperty("quantity_on_hand")]
        public long QuantityOnHand { get; set; }

        [JsonProperty("quantity_committed")]
        public long QuantityCommitted { get; set; }

        [JsonProperty("quantity_available")]
        public long QuantityAvailable { get; set; }

        [JsonProperty("item_name")]
        public string ItemName { get; set; }

        [JsonProperty("warehouse_code")]
        public string WarehouseCode { get; set; }

        [JsonProperty("unit_id")]
        public long UnitId { get; set; }

        [JsonProperty("unit_symbol")]
        public string UnitSymbol { get; set; }

        [JsonProperty("display_unit_id")]
        public long DisplayUnitId { get; set; }

        [JsonProperty("display_unit_symbol")]
        public string DisplayUnitSymbol { get; set; }
    }

    public partial class ItemModule
    {
        public static ItemModule[] FromJson(string json) => JsonConvert.DeserializeObject<ItemModule[]>(json, ERPAPI_APP.JSONDataMigration.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ItemModule[] self) => JsonConvert.SerializeObject(self, ERPAPI_APP.JSONDataMigration.Converter.Settings);
    }

    public class JSBaseUnit
    {
        public int id { get; set; }
        public string symbol { get; set; }
        public string label { get; set; }
        public string groupLabel { get; set; }
        public bool visible { get; set; }
        public bool isCustomUnit { get; set; }
        public double conversionFactor { get; set; }
        public string upcCode { get; set; }
        public string length { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

    public partial class JsUnti_Master
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("groupLabel")]
        public string GroupLabel { get; set; }

        [JsonProperty("visible")]
        public bool Visible { get; set; }

        [JsonProperty("isCustomUnit")]
        public bool IsCustomUnit { get; set; }

        [JsonProperty("conversionFactor")]
        public double ConversionFactor { get; set; }

        [JsonProperty("upcCode")]
        public string UpcCode { get; set; }

        [JsonProperty("length")]
        public string Length { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("baseUnit", NullValueHandling = NullValueHandling.Ignore)]
        public JSUnit BaseUnit { get; set; }

        [JsonProperty("item", NullValueHandling = NullValueHandling.Ignore)]
        public JSItem Item { get; set; }

        [JsonProperty("deletedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DeletedAt { get; set; }

        [JsonProperty("createdBy", NullValueHandling = NullValueHandling.Ignore)]
        public CreatedBy CreatedBy { get; set; }

        [JsonProperty("updatedBy", NullValueHandling = NullValueHandling.Ignore)]
        public UpdatedBy UpdatedBy { get; set; }
    }
    
    public partial class JSUnit
    {
        public int id { get; set; }
        public string symbol { get; set; }
        public string label { get; set; }
        public string groupLabel { get; set; }
        public bool visible { get; set; }
        public bool isCustomUnit { get; set; }
        public double conversionFactor { get; set; }
        public string upcCode { get; set; }
        public string length { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

    public partial class JSItem
    {
        public int id { get; set; }
        public JSUnit unit { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public UpdatedBy updatedBy { get; set; }
        public CreatedBy createdBy { get; set; }
    }
    public partial class JsUnti_Master
    {
        public static JsUnti_Master[] FromJson(string json) => JsonConvert.DeserializeObject<JsUnti_Master[]>(json, ERPAPI_APP.JSONDataMigration.Converter.Settings);
    }
}
