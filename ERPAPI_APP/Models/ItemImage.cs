using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class ItemImage
{
    public int Id { get; set; }

    public string Sku { get; set; } = null!;

    public int ItemMasterId { get; set; }

    public string FileName { get; set; } = null!;

    public string ETag { get; set; } = null!;

    public string Key { get; set; } = null!;

    public int ItemImageTranId { get; set; }
}
