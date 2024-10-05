using Newtonsoft.Json;

namespace ERPAPI_APP.JSONDataMigration
{
    public partial class JSItemImportFromWeb
    {
        public static JSItemImportFromWeb[] FromJson(string json) => JsonConvert.DeserializeObject<JSItemImportFromWeb[]>(json, Converter.Settings);
    }

    public partial class JSItemImportFromWeb
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("item")]
        public string Item { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("web_description")]
        public string WebDescription { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }

        [JsonProperty("ship_width")]
        public string ShipWidth { get; set; }

        [JsonProperty("ship_height")]
        public string ShipHeight { get; set; }

        [JsonProperty("ship_length")]
        public string ShipLength { get; set; }

        [JsonProperty("commodity_code")]
        public string CommodityCode { get; set; }

        [JsonProperty("default_country_of_origin")]
        public string DefaultCountryOfOrigin { get; set; }

        [JsonProperty("custom_attributes")]
        public string CustomAttributes { get; set; }

        [JsonProperty("primary_vendor_id")]
        public long? PrimaryVendorId { get; set; }

        [JsonProperty("main_image_file_id")]
        public long? MainImageFileId { get; set; }

        [JsonProperty("product_line")]
        public string? ProductLine { get; set; }

        [JsonProperty("category_ids")]
        public long CategoryIds { get; set; }

        [JsonProperty("unit_symbol")]
        public string UnitSymbol { get; set; }

        [JsonProperty("display_unit_symbol")]
        public string DisplayUnitSymbol { get; set; }

        [JsonProperty("files")]
        public JSFile[] Files { get; set; }
    }
    public partial class JSFile
    {
        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("item_id")]
        public long ItemId { get; set; }

        [JsonProperty("file_id")]
        public long FileId { get; set; }

        [JsonProperty("file_name")]
        public string FileName { get; set; }

        [JsonProperty("e_tag")]
        public string ETag { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }
    }

}
