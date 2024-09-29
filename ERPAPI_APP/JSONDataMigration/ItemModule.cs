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
}
