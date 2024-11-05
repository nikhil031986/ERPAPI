using Azure.Identity;
using ERPAPI_APP.JSONDataMigration;
using ERPAPI_APP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using Newtonsoft.Json;
using System.Dynamic;
using System.Numerics;
using System.Transactions;
using static System.Formats.Asn1.AsnWriter;

namespace ERPAPI_APP.DataBaseAccess
{
    internal static class DAItems
    {
        internal static async Task<List<ItemCategory>> GetItemCategory()
        {
            // List<ItemCategory> items = new List<ItemCategory>();
            var item = DaCommonDBFunction.GetData<ItemCategory>("ItemCategories", i => i.Category != string.Empty).ToList();
            //using (var scope = new TransactionScope(
            //            TransactionScopeOption.Required,
            //            new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            //{
            //    using (var context = new ErpDbContext())
            //    {
            //        items = context.ItemCategories.ToList();
            //    }
            //    scope.Complete();
            //}
            return item;
        }

        internal static async Task<List<ItemCategory>> GetItetmWiseCategory()
        {
            List<ItemCategory> itemCategories = new List<ItemCategory>();
            using (var scope = new TransactionScope(
                        TransactionScopeOption.Required,
                        new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                using (var context = new ErpDbContext())
                {
                    List<int> SelectedCategoryIds = context.ItemMasters.Where(x => x.CategoryId != null && x.CategoryId > 0)
               .Select(x => (int)x.CategoryId).ToList<int>();
                    List<int> parentId = context.ItemCategories.Where(x => SelectedCategoryIds.Contains((int)x.CategoryTranId) && x.ParentCategory > 0)
                        .Select(x => (int)x.ParentCategory).ToList();
                    SelectedCategoryIds.AddRange(parentId);

                    itemCategories = context.ItemCategories.Where(x => SelectedCategoryIds.Contains((int)x.CategoryTranId)).ToList();
                }
                scope.Complete();
            }
            return itemCategories;
        }

        internal static string getImagePath(string ItemCode)
        {
            try
            {
                if (File.Exists("./Images/" + ItemCode + ".jpg"))
                {
                    return "Images/" + ItemCode + ".jpg";
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        internal static async Task<ItemByCategory> GetItemByItemCode(string ItemCode)
        {
            ItemByCategory retItemByCategory = new ItemByCategory();
            try
            {
                using (var scope = new TransactionScope(
                        TransactionScopeOption.Required,
                        new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    using (var context = new ErpDbContext())
                    {
                        retItemByCategory = context.ItemMasters.Where(x => x.ItemName == ItemCode).Select(x => new ItemByCategory
                        {
                            Item_Id = x.ItemId,
                            Item_Name = x.ItemName,
                            Item_Description = x.ItemDescription,
                            webdescription = x.WebDescription,
                            Item_Price = GetItemPriceByItemCode(x.ItemName, 2),
                            weight = x.Weight,
                            Ship_width = x.ShipWidth,
                            ship_Height = x.ShipHeight,
                            Ship_Length = x.ShipLength,
                            countryoforgin = x.DefaultCountryOfOrigin,
                            vendor = context.CustomerMasters.Where(v => v.CustomerTranId == x.PrimaryVendorId).ToList(),
                            itemUnit = context.UnitMasters.Where(u => u.UnitId == x.UnitId).Select(u => u.UnitName).FirstOrDefault(),
                            displayunit = context.UnitMasters.Where(u => u.UnitId == x.DisplayUnitId).Select(u => u.UnitName).FirstOrDefault(),
                            Item_Images = context.ItemImages.Where(m => m.ItemMasterId == x.ItemTranId).ToList(),
                            Item_Category = context.ItemCategories.Where(m => m.CategoryTranId == x.CategoryId).ToList(),
                            ImageUrl = getImagePath(x.ItemName),
                        }).Single();
                    }
                    scope.Complete();
                }
                return retItemByCategory;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                retItemByCategory = null;
            }
        }

        internal static async Task<List<UnitMaster>> GetAllUnit()
        {
            List<UnitMaster> ret = new List<UnitMaster>();
            try
            {
                using (var scope = new TransactionScope(
                    TransactionScopeOption.Required,
                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    using (var context = new ErpDbContext())
                    {
                        ret = context.UnitMasters.Where(x => !string.IsNullOrWhiteSpace(x.UnitName)).ToList();
                    }
                    scope.Complete();
                }
                return ret;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { ret = null; }
        }

        internal static async Task<int?> GetIdFromCategoryName(string CategoryName)
        {
            int? retValue = 0;
            using (var scope = new TransactionScope(
                    TransactionScopeOption.Required,
                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                using (var context = new ErpDbContext())
                {
                    retValue = context.ItemCategories.Where(x => x.Category == CategoryName).
                            Select(x => x.CategoryTranId).Single();
                }
                scope.Complete();
            }
            return retValue;
        }

        internal static async Task<List<ItemByCategory>> ItemGetByCategory(int categoriaId)
        {
            List<ItemByCategory> ret = new List<ItemByCategory>();
            try
            {
                using (var scope = new TransactionScope(
    TransactionScopeOption.Required,
    new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    using (var context = new ErpDbContext())
                    {
                        ret = context.ItemMasters.Where(x => x.CategoryId == categoriaId).Select(x => new ItemByCategory
                        {
                            Item_Id = x.ItemId,
                            Item_Name = x.ItemName,
                            Item_Description = x.ItemDescription,
                            webdescription = x.WebDescription,
                            Item_Price = GetItemPriceByItemCode(x.ItemName, 2),
                            weight = x.Weight,
                            Ship_width = x.ShipWidth,
                            ship_Height = x.ShipHeight,
                            Ship_Length = x.ShipLength,
                            countryoforgin = x.DefaultCountryOfOrigin,
                            vendor = context.CustomerMasters.Where(v => v.CustomerTranId == x.PrimaryVendorId).ToList(),
                            itemUnit = context.UnitMasters.Where(u => u.UnitId == x.UnitId).Select(u => u.UnitName).FirstOrDefault(),
                            displayunit = context.UnitMasters.Where(u => u.UnitId == x.DisplayUnitId).Select(u => u.UnitName).FirstOrDefault(),
                            Item_Images = context.ItemImages.Where(m => m.ItemMasterId == x.ItemTranId).ToList(),
                            Item_Category = context.ItemCategories.Where(m => m.CategoryTranId == x.CategoryId).ToList(),
                            ImageUrl = getImagePath(x.ItemName),
                        })
                       .ToList();
                    }
                    scope.Complete();
                }
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static async Task<List<MasterMenu>> GetMenuItem()
        {
            List<MasterMenu> ret = new List<MasterMenu>();
            try
            {
                using (var scope = new TransactionScope(
                    TransactionScopeOption.Required,
                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    using (var context = new ErpDbContext())
                    {
                        ret = context.ItemCategories.Where(x => x.ParentCategory == 0).Select(x => new MasterMenu
                        {
                            Category = x.Category,
                            ParentCategory = 0,
                            Id = x.Id,
                            ChildMenuItem = context.ItemCategories.Where(o => o.ParentCategory == x.CategoryTranId).ToList(),
                            ChildCount = context.ItemCategories.Where(o => o.ParentCategory == x.CategoryTranId).ToList().Count(),
                        }).ToList();
                    }
                    scope.Complete();
                }
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static async Task<List<GetCartDetail>> GetCartItem(string refKey)
        {
            List<GetCartDetail> cart = new List<GetCartDetail>();
            try
            {
                using (var scope = new TransactionScope(
                 TransactionScopeOption.Required,
                 new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    using (var context = new ErpDbContext())
                    {
                        cart = context.CartItems
                                .Join(context.ItemMasters, p => p.ItemCode, pc => pc.ItemName, (p, pc) => new { p, pc })
                                .Where(x => x.p.RefKey == refKey)
                                .Select(m => new GetCartDetail
                                {
                                    ItemCode = m.p.ItemCode,
                                    Unit = m.p.Unit,
                                    Quntity = m.p.Quantity,
                                    imagePath = getImagePath(m.p.ItemCode),
                                    Item_Description = m.pc.ItemDescription,
                                    ItemPrice = GetItemPriceByItemCode(m.p.ItemCode, 2),
                                }).ToList();
                    }
                    scope.Complete();
                }
                return cart;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static async Task<JsonResult> AddItemInCart(string Item_Code, decimal quntity, string refkey, string unit)
        {
            try
            {
                using (var scope = new TransactionScope(
                  TransactionScopeOption.Required,
                  new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    using (var context = new ErpDbContext())
                    {
                        var existsInDb = context.CartItems.Where(x => x.ItemCode == Item_Code && x.RefKey == refkey).DefaultIfEmpty().Single();
                        if (existsInDb != null)
                        {
                            existsInDb.Quantity = existsInDb.Quantity + quntity;
                            context.CartItems.Update(existsInDb);
                            context.SaveChanges();
                        }
                        else
                        {
                            var newCart = new CartItem
                            {
                                ItemCode = Item_Code,
                                Quantity = quntity,
                                RefKey = refkey,
                                Unit = unit,
                                CreateDate = DateTime.Now,
                            };
                            context.CartItems.Add(newCart);
                            context.SaveChanges();
                        }
                    }
                    scope.Complete();
                }
                return new JsonResult(new { message = "Record add " + Item_Code })
                {
                    StatusCode = StatusCodes.Status200OK, // Status code here ,
                };
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Record Not Add." })
                {
                    StatusCode = StatusCodes.Status400BadRequest // Status code here 
                };
            }

        }

        internal static async Task<JsonResult> DeleteFromCart(string Itemcode, string refkey)
        {
            try
            {
                using (var scope = new TransactionScope(
                 TransactionScopeOption.Required,
                 new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    using (var context = new ErpDbContext())
                    {
                        var existsInDb = context.CartItems.Where(x => x.ItemCode == Itemcode && x.RefKey == refkey).DefaultIfEmpty().Single();
                        if (existsInDb != null)
                        {
                            context.CartItems.Remove(existsInDb);
                            context.SaveChanges();
                        }
                    }
                    scope.Complete();
                }
                return new JsonResult(new { message = "Record remove from the cart." })
                {
                    StatusCode = StatusCodes.Status200OK, // Status code here ,
                };
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Record Not remove from the cart." })
                {
                    StatusCode = StatusCodes.Status400BadRequest // Status code here 
                };
            }
        }
        internal static decimal GetItemPriceByItemCode(string ItemCode, int qty)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, "https://sandbox.10xerp.com/api/item_pricing_information");
                    request.Headers.Add("accept", "application/json");
                    request.Headers.Add("X-AUTH-TOKEN", "1a2849a62a1bc2f6b07583840c20ba3187b3423d9215fa1f31a0c387baf74e48");
                    request.Headers.Add("Cookie", "PHPSESSID=7t3q0h8qa149811gu8sp311b60");
                    var content = new StringContent("{\r\n  \"items\": [\r\n    {\r\n      \"itemName\": \"" + ItemCode + "\",\r\n      \"quantityInUnit\": " + qty.ToString() + "\r\n    }\r\n  ]\r\n}", null, "application/json");
                    request.Content = content;
                    var response = client.Send(request);
                    response.EnsureSuccessStatusCode();
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    var dictionary = JsonConvert.DeserializeObject<dynamic>(responseBody);
                    if (!string.IsNullOrWhiteSpace(Convert.ToString(dictionary[0]["finalPricePerUnit"])))
                    {
                        return Convert.ToDecimal(dictionary[0]["finalPricePerUnit"].ToString());
                    }
                    else
                    {
                        return decimal.Zero;
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        internal static async Task<JsonResult> GetItemPrice(string ItemCode, int Qty)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, "https://sandbox.10xerp.com/api/item_pricing_information");
                    request.Headers.Add("accept", "application/json");
                    request.Headers.Add("X-AUTH-TOKEN", "1a2849a62a1bc2f6b07583840c20ba3187b3423d9215fa1f31a0c387baf74e48");
                    request.Headers.Add("Cookie", "PHPSESSID=7t3q0h8qa149811gu8sp311b60");
                    var content = new StringContent("{\r\n  \"items\": [\r\n    {\r\n      \"itemName\": \"" + ItemCode + "\",\r\n      \"quantityInUnit\": " + Qty.ToString() + "\r\n    }\r\n  ]\r\n}", null, "application/json");
                    request.Content = content;
                    var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var dictionary = JsonConvert.DeserializeObject<dynamic>(responseBody);
                    return new JsonResult(new { message = dictionary[0]["finalPricePerUnit"].ToString() })
                    {
                        StatusCode = StatusCodes.Status200OK, // Status code here ,
                    };
                }
            }
            catch (Exception)
            {
                return new JsonResult(new { message = "0" })
                {
                    StatusCode = StatusCodes.Status400BadRequest // Status code here 
                };
            }
        }
    }
}
