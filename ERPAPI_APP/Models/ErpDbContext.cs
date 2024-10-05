using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ERPAPI_APP.Models;

public partial class ErpDbContext : DbContext
{
    public ErpDbContext()
    {
    }

    public ErpDbContext(DbContextOptions<ErpDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AddOn> AddOns { get; set; }

    public virtual DbSet<AddOnDetail> AddOnDetails { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }

    public virtual DbSet<BillingOption> BillingOptions { get; set; }

    public virtual DbSet<Carrier> Carriers { get; set; }

    public virtual DbSet<CategoryMaster> CategoryMasters { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<ContactMaster> ContactMasters { get; set; }

    public virtual DbSet<CustomerGroup> CustomerGroups { get; set; }

    public virtual DbSet<CustomerLocationInformation> CustomerLocationInformations { get; set; }

    public virtual DbSet<CustomerMaster> CustomerMasters { get; set; }

    public virtual DbSet<DbLog> DbLogs { get; set; }

    public virtual DbSet<EasyPostMethod> EasyPostMethods { get; set; }

    public virtual DbSet<ItemCategory> ItemCategories { get; set; }

    public virtual DbSet<ItemImage> ItemImages { get; set; }

    public virtual DbSet<ItemMaster> ItemMasters { get; set; }

    public virtual DbSet<ItemPriceInformation> ItemPriceInformations { get; set; }

    public virtual DbSet<ItemStockDetail> ItemStockDetails { get; set; }

    public virtual DbSet<LogoMaster> LogoMasters { get; set; }

    public virtual DbSet<MigrationConfig> MigrationConfigs { get; set; }

    public virtual DbSet<OrderSourceMaster> OrderSourceMasters { get; set; }

    public virtual DbSet<OriginCountry> OriginCountries { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<PaymentTerm> PaymentTerms { get; set; }

    public virtual DbSet<RegionMaster> RegionMasters { get; set; }

    public virtual DbSet<SalesTaxis> SalesTaxes { get; set; }

    public virtual DbSet<SystemShipVium> SystemShipVia { get; set; }

    public virtual DbSet<UnitMaster> UnitMasters { get; set; }

    public virtual DbSet<WarehouseMaster> WarehouseMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // add IConfigurationRoot  to get connection string 
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddOn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AddOn__3214EC07D596E548");

            entity.ToTable("AddOn");

            entity.Property(e => e.Amount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.OrderInvoice).IsUnicode(false);
            entity.Property(e => e.PurchaseOrderBill)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TaxAmount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.TaxCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TaxRate).HasColumnType("numeric(18, 2)");
        });

        modelBuilder.Entity<AddOnDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AddOnDet__3214EC07292DA7CE");

            entity.ToTable("AddOnDetail");

            entity.Property(e => e.AddOnDetailTranId).HasColumnName("AddOnDetail_tranId");
            entity.Property(e => e.AddonId).HasColumnName("Addon_Id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TotCd)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AspNetRo__3214EC07BF521179");

            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))")
                .HasColumnName("Role_Name");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__AspNetUs__206D91704D8343D9");

            entity.Property(e => e.UserId).HasColumnName("User_Id");
            entity.Property(e => e.CompanyId).HasColumnName("Company_Id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");
            entity.Property(e => e.EmailId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))");
            entity.Property(e => e.PasswordHas)
                .HasMaxLength(200)
                .HasDefaultValueSql("(char((10)))");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<AspNetUserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AspNetUs__3214EC07AC65928B");

            entity.Property(e => e.AspNetRoleId).HasColumnName("AspNetRole_Id");
            entity.Property(e => e.AspNetUserId).HasColumnName("AspNetUser_Id");
        });

        modelBuilder.Entity<BillingOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BillingO__3214EC07019747DC");

            entity.ToTable("BillingOption");

            entity.Property(e => e.AddToInvoice)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BillingOptionTranId).HasColumnName("BillingOption_TranId");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Slug)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("value");
        });

        modelBuilder.Entity<Carrier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Carrier__3214EC07339421B0");

            entity.ToTable("Carrier");

            entity.Property(e => e.Carrier1)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("carrier");
            entity.Property(e => e.CarrierTranId).HasColumnName("Carrier_TranId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ShipViaAccount)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Slug)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<CategoryMaster>(entity =>
        {
            entity.HasKey(e => e.CategoryId);

            entity.ToTable("Category_Master");

            entity.Property(e => e.CategoryId).HasColumnName("Category_Id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Category_Name");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Company__3214EC0733503B76");

            entity.ToTable("Company");

            entity.Property(e => e.CompanyCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))")
                .HasColumnName("Company_Code");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))")
                .HasColumnName("Company_Name");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Logo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<ContactMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contact___3214EC07159D4A53");

            entity.ToTable("Contact_Master");

            entity.Property(e => e.Contact)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ContactTranId).HasColumnName("Contact_TranId");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PhoneExtension)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Slug)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Titled)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<CustomerGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC074D91CE20");

            entity.ToTable("CustomerGroup");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CustomerGroupTranId).HasColumnName("CustomerGroup_TranId");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.Value)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CustomerLocationInformation>(entity =>
        {
            entity.HasKey(e => e.CustomerLocationId);

            entity.ToTable("Customer_Location_Information");

            entity.Property(e => e.CustomerLocationId).HasColumnName("Customer_Location_Id");
            entity.Property(e => e.Address1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Address3)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BlindShip).HasColumnName("Blind_Ship");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");
            entity.Property(e => e.CustomerLocationTranId).HasColumnName("CustomerLocation_TranId");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.Location).IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Postal)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.RegionId).HasColumnName("Region_Id");
            entity.Property(e => e.ShipAttention)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("shipAttention");
            entity.Property(e => e.ShipViaAccount)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Slug)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("slug");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<CustomerMaster>(entity =>
        {
            entity.HasKey(e => e.CustomerId);

            entity.ToTable("Customer_Master");

            entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");
            entity.Property(e => e.BorderColor)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Contact)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CrLimit)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Customer)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CustomerCode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Customer_Code");
            entity.Property(e => e.CustomerGroupId).HasColumnName("CustomerGroup_Id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ExternalDocparserParserId)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.FontColor)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.InvoiceEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LabelQuantity)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.LogoMasterId).HasColumnName("Logo_Master_Id");
            entity.Property(e => e.OrderAcknowledgementEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OrderAcknowledgementEmailSelect)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OrderSourceMasterId).HasColumnName("OrderSource_Master_Id");
            entity.Property(e => e.PackingSlipPdfTemplate)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PaymentTermId).HasColumnName("PaymentTerm_Id");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneExtension)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Phone_Extension");
            entity.Property(e => e.PickupConfirmationEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PickupConfirmationEmailSelect)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ShadingColor)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ShippingConfirmationEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ShippingConfirmationEmailSelect)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SicCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Slug)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StatementDestinationEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TaxExempt)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TaxId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Titled)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.Website)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DbLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DbLog__3214EC076AEC03BB");

            entity.ToTable("DbLog");

            entity.Property(e => e.ErrorDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Error_DateTime");
            entity.Property(e => e.ErrorMsg)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))")
                .HasColumnName("Error_Msg");
            entity.Property(e => e.LogDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Log_Date");
            entity.Property(e => e.RequestApi)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))")
                .HasColumnName("Request_API");
            entity.Property(e => e.RequestDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Request_Date");
            entity.Property(e => e.ResponseDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Response_Date");
            entity.Property(e => e.ResponseValue)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))")
                .HasColumnName("Response_Value");
        });

        modelBuilder.Entity<EasyPostMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EasyPost__3214EC07D354A6CC");

            entity.ToTable("EasyPostMethod");

            entity.Property(e => e.EsyPostMethodTranId).HasColumnName("EsyPostMethod_TranId");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ItemCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Item_Cat__3214EC07C431EB3D");

            entity.ToTable("Item_Category");

            entity.Property(e => e.Category)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))");
            entity.Property(e => e.CategoryTranId).HasColumnName("Category_TranId");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))");
            entity.Property(e => e.CommodityCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))")
                .HasColumnName("commodityCode");
            entity.Property(e => e.CountryOfOrigin)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))")
                .HasColumnName("countryOfOrigin");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.FactoryMinimumLinePrice)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("factoryMinimumLinePrice");
            entity.Property(e => e.ParentCategory)
                .HasDefaultValue(0)
                .HasColumnName("Parent_Category");
            entity.Property(e => e.ProductionMinimumLinePrice)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("productionMinimumLinePrice");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<ItemImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Item_Ima__3214EC075F90B80B");

            entity.ToTable("Item_Image");

            entity.Property(e => e.ETag)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))")
                .HasColumnName("eTag");
            entity.Property(e => e.FileName)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))")
                .HasColumnName("File_Name");
            entity.Property(e => e.ItemImageTranId).HasColumnName("ItemImage_TranId");
            entity.Property(e => e.ItemMasterId).HasColumnName("Item_MasterId");
            entity.Property(e => e.Key)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))");
            entity.Property(e => e.Sku)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))")
                .HasColumnName("SKU");
        });

        modelBuilder.Entity<ItemMaster>(entity =>
        {
            entity.HasKey(e => e.ItemId);

            entity.ToTable("Item_Master");

            entity.Property(e => e.ItemId).HasColumnName("Item_Id");
            entity.Property(e => e.CategoryId).HasColumnName("Category_Id");
            entity.Property(e => e.CommodityCode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Commodity_Code");
            entity.Property(e => e.CustomAttributes)
                .IsUnicode(false)
                .HasColumnName("Custom_Attributes");
            entity.Property(e => e.DefaultCountryOfOrigin)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Default_Country_of_Origin");
            entity.Property(e => e.DisplayUnitId).HasColumnName("Display_Unit_Id");
            entity.Property(e => e.Files).IsUnicode(false);
            entity.Property(e => e.ItemCode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Item_Code");
            entity.Property(e => e.ItemDescription)
                .IsUnicode(false)
                .HasColumnName("Item_Description");
            entity.Property(e => e.ItemName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Item_Name");
            entity.Property(e => e.ItemPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Item_Price");
            entity.Property(e => e.ItemTranId).HasDefaultValue(0);
            entity.Property(e => e.MainImageFileId).HasColumnName("Main_Image_File_Id");
            entity.Property(e => e.PrimaryVendorId).HasColumnName("Primary_Vendor_Id");
            entity.Property(e => e.ProductLine)
                .IsUnicode(false)
                .HasColumnName("Product_Line");
            entity.Property(e => e.ShipHeight)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Ship_Height");
            entity.Property(e => e.ShipLength)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Ship_Length");
            entity.Property(e => e.ShipWidth)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Ship_Width");
            entity.Property(e => e.Sku)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SKU");
            entity.Property(e => e.UnitId).HasColumnName("Unit_Id");
            entity.Property(e => e.WebDescription)
                .IsUnicode(false)
                .HasColumnName("Web_Description");
            entity.Property(e => e.Weight).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<ItemPriceInformation>(entity =>
        {
            entity.HasKey(e => e.ItemPriceId);

            entity.ToTable("Item_Price_Information");

            entity.Property(e => e.ItemPriceId).HasColumnName("Item_Price_Id");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");
            entity.Property(e => e.DisplayUnitId).HasColumnName("Display_Unit_Id");
            entity.Property(e => e.FinalPricePerDisplayUnit)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Final_Price_Per_Display_Unit");
            entity.Property(e => e.FinalPricePerUnit)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Final_Price_Per_Unit");
            entity.Property(e => e.ItemId).HasColumnName("Item_Id");
            entity.Property(e => e.PriceBreaks)
                .IsUnicode(false)
                .HasColumnName("Price_Breaks");
            entity.Property(e => e.QuantityBreaksPerDispalyUnit)
                .IsUnicode(false)
                .HasColumnName("Quantity_Breaks_Per_Dispaly_Unit");
            entity.Property(e => e.QuantityInDisplayUnit).HasColumnName("Quantity_In_Display_Unit");
            entity.Property(e => e.UnitId).HasColumnName("Unit_Id");
        });

        modelBuilder.Entity<ItemStockDetail>(entity =>
        {
            entity.HasKey(e => e.StockId);

            entity.ToTable("Item_Stock_Details");

            entity.Property(e => e.StockId).HasColumnName("Stock_Id");
            entity.Property(e => e.DisplayUnitId).HasColumnName("Display_Unit_Id");
            entity.Property(e => e.ItemId).HasColumnName("Item_Id");
            entity.Property(e => e.PurchaseOrders)
                .IsUnicode(false)
                .HasColumnName("Purchase_Orders");
            entity.Property(e => e.QuantityAvailable).HasColumnName("Quantity_Available");
            entity.Property(e => e.QuantityCommitted).HasColumnName("Quantity_Committed");
            entity.Property(e => e.QuantityOnHand).HasColumnName("Quantity_On_Hand");
            entity.Property(e => e.QuantityOnPurchaseOrder).HasColumnName("Quantity_On_Purchase_Order");
            entity.Property(e => e.UnitId).HasColumnName("Unit_Id");
            entity.Property(e => e.WarehouseId).HasColumnName("Warehouse_Id");
        });

        modelBuilder.Entity<LogoMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Logo_Mas__3214EC078F4EE508");

            entity.ToTable("Logo_Master");

            entity.Property(e => e.ContentType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contentType");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ETag)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("eTag");
            entity.Property(e => e.FileName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Key)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LogoTranId).HasColumnName("Logo_TranId");
            entity.Property(e => e.Size)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<MigrationConfig>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Migratio__3214EC07A21C6BC3");

            entity.ToTable("MigrationConfig");

            entity.Property(e => e.Apidetails)
                .IsUnicode(false)
                .HasColumnName("APIDetails");
            entity.Property(e => e.Apitokan)
                .IsUnicode(false)
                .HasColumnName("APITokan");
            entity.Property(e => e.CompanyId).HasColumnName("Company_Id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CreateAT");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Httpmethod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))")
                .HasColumnName("HTTPMETHOD");
            entity.Property(e => e.MethodName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))");
            entity.Property(e => e.TokanType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Tokan_Type");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<OrderSourceMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderSou__3214EC070ECB7079");

            entity.ToTable("OrderSource_Master");

            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.OrderSourceTranId).HasColumnName("OrderSource_TranId");
            entity.Property(e => e.Slug)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<OriginCountry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OriginCo__3214EC07D40CD0CA");

            entity.ToTable("OriginCountry");

            entity.Property(e => e.CountryCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))");
            entity.Property(e => e.CountryName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))");
            entity.Property(e => e.CountryTranId)
                .HasDefaultValue(0)
                .HasColumnName("Country_TranId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Slug)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payment___3214EC07B700AEE9");

            entity.ToTable("Payment_method");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MethodDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))");
            entity.Property(e => e.PaymentMethod1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))")
                .HasColumnName("PaymentMethod");
            entity.Property(e => e.PaymentMethodTranId).HasColumnName("PaymentMethod_TranId");
            entity.Property(e => e.Slug)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<PaymentTerm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payment___3214EC07998755DE");

            entity.ToTable("Payment_terms");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PaymentTermsTranId).HasColumnName("PaymentTerms_TranId");
            entity.Property(e => e.Slug)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TermsCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TotalDiscountPercent).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<RegionMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Region_M__3214EC079074115F");

            entity.ToTable("Region_Master");

            entity.Property(e => e.CountryName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Region)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.RegionTranId).HasColumnName("Region_TranId");
            entity.Property(e => e.Slug)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.States).IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<SalesTaxis>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sales_Ta__3214EC072B77D5EB");

            entity.ToTable("Sales_Taxes");

            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))");
            entity.Property(e => e.GeneralLedgerAccountId).HasDefaultValue(0);
            entity.Property(e => e.SalesTaxesTranId)
                .HasDefaultValue(0)
                .HasColumnName("SalesTaxes_TranId");
            entity.Property(e => e.Slug)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))");
            entity.Property(e => e.State)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))");
            entity.Property(e => e.TaxCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))");
            entity.Property(e => e.TaxRate)
                .HasDefaultValue(0.00m)
                .HasColumnType("numeric(18, 2)");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<SystemShipVium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SystemSh__3214EC07DE447409");

            entity.Property(e => e.BillingOptions)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("billingOptions");
            entity.Property(e => e.CarrierId).HasColumnName("Carrier_Id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EasyPostMethodId).HasColumnName("EasyPostMethod_Id");
            entity.Property(e => e.EdiServiceLevelCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HandlingChargeAmount)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HandlingChargePercent)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PackageType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ShipViaCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Slug)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SystemShipViaTranId).HasColumnName("SystemShipVia_TranId");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.WebDescription)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UnitMaster>(entity =>
        {
            entity.HasKey(e => e.UnitId);

            entity.ToTable("Unit_Master");

            entity.Property(e => e.UnitId).HasColumnName("Unit_Id");
            entity.Property(e => e.ConversionFactor).HasColumnType("numeric(18, 3)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.GroupLabel)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))")
                .HasColumnName("Group_Label");
            entity.Property(e => e.Height).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Length).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.UnitName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Unit_Name");
            entity.Property(e => e.UnitSymbol)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Unit_Symbol");
            entity.Property(e => e.UnitTranId).HasDefaultValue(0);
            entity.Property(e => e.UpcCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(char((10)))");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Visible).HasDefaultValue(true);
            entity.Property(e => e.Width).HasColumnType("numeric(18, 2)");
        });

        modelBuilder.Entity<WarehouseMaster>(entity =>
        {
            entity.HasKey(e => e.WarehouseId);

            entity.ToTable("Warehouse_Master");

            entity.Property(e => e.WarehouseId).HasColumnName("Warehouse_Id");
            entity.Property(e => e.Address1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Address3)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Attention)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Postal)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Slug)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TransferShipViaAccount)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Transfer_Ship_Via_Account");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).IsUnicode(false);
            entity.Property(e => e.WarehouseCode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Warehouse_Code");
            entity.Property(e => e.WarehouseName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Warehouse_Name");
            entity.Property(e => e.WarehouseTranId).HasDefaultValue(0);
            entity.Property(e => e.WarehouseTransId).HasColumnName("Warehouse_Trans_Id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
