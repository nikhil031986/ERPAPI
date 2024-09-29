USE [ERP_DB]
GO
/****** Object:  Table [dbo].[AddOn]    Script Date: 20/09/2024 7:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddOn](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [numeric](18, 2) NULL,
	[OrderInvoice] [varchar](max) NULL,
	[TaxFlag] [bit] NULL,
	[TaxOverride] [bit] NULL,
	[TaxCode] [varchar](50) NULL,
	[TaxRate] [numeric](18, 2) NULL,
	[TaxAmount] [numeric](18, 2) NULL,
	[PurchaseOrderBill] [varchar](100) NULL,
	[AddOnTranId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AddOnDetail]    Script Date: 20/09/2024 7:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddOnDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Addon_Id] [int] NOT NULL,
	[TotCd] [varchar](100) NULL,
	[Name] [varchar](100) NULL,
	[Description] [varchar](100) NULL,
	[AddOnDetail_tranId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 20/09/2024 7:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Role_Name] [varchar](50) NOT NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 20/09/2024 7:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AspNetUser_Id] [int] NOT NULL,
	[AspNetRole_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 20/09/2024 7:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[User_Id] [int] IDENTITY(1,1) NOT NULL,
	[EmailId] [varchar](100) NOT NULL,
	[PasswordHas] [nvarchar](200) NOT NULL,
	[Customer_Id] [int] NOT NULL,
	[Company_Id] [int] NOT NULL,
	[CreateAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillingOption]    Script Date: 20/09/2024 7:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillingOption](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NULL,
	[value] [varchar](100) NULL,
	[AddToInvoice] [varchar](100) NULL,
	[Slug] [varchar](100) NULL,
	[IsRequireBillingAccount] [bit] NULL,
	[IsUseCompanyAccount] [bit] NULL,
	[BillingOption_TranId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carrier]    Script Date: 20/09/2024 7:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Slug] [varchar](100) NULL,
	[carrier] [varchar](200) NULL,
	[ShipViaAccount] [varchar](100) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[Carrier_TranId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category_Master]    Script Date: 20/09/2024 7:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category_Master](
	[Category_Id] [int] IDENTITY(1,1) NOT NULL,
	[Category_Name] [varchar](100) NULL,
 CONSTRAINT [PK_Category_Master] PRIMARY KEY CLUSTERED 
(
	[Category_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 20/09/2024 7:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Company_Name] [varchar](100) NOT NULL,
	[Company_Code] [varchar](20) NOT NULL,
	[Logo] [varchar](100) NOT NULL,
	[CreateAt] [datetime] NOT NULL,
	[UpdateAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact_Master]    Script Date: 20/09/2024 7:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact_Master](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Slug] [varchar](100) NULL,
	[FirstName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[PhoneExtension] [varchar](10) NULL,
	[Titled] [varchar](100) NULL,
	[Contact] [varchar](100) NULL,
	[Name] [varchar](100) NULL,
	[Phone] [varchar](20) NULL,
	[CustomerId] [int] NULL,
	[Email] [varchar](100) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime] NULL,
	[Contact_TranId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer_Location_Information]    Script Date: 20/09/2024 7:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer_Location_Information](
	[Customer_Location_Id] [int] IDENTITY(1,1) NOT NULL,
	[Customer_Id] [int] NULL,
	[DOB] [datetime] NULL,
	[Location] [varchar](max) NULL,
	[Address1] [varchar](100) NULL,
	[Address2] [varchar](100) NULL,
	[Address3] [varchar](100) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
	[Postal] [varchar](10) NULL,
	[Phone] [varchar](20) NULL,
	[Blind_Ship] [bit] NULL,
	[Name] [varchar](100) NULL,
	[ShipViaAccount] [varchar](100) NULL,
	[slug] [varchar](100) NULL,
	[shipAttention] [varchar](100) NULL,
	[HasConsolidatedShipments] [bit] NULL,
	[IsResidential] [bit] NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[CustomerLocation_TranId] [int] NULL,
	[Region_Id] [int] NOT NULL,
 CONSTRAINT [PK_Customer_Location_Information] PRIMARY KEY CLUSTERED 
(
	[Customer_Location_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer_Master]    Script Date: 20/09/2024 7:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer_Master](
	[Customer_Id] [int] IDENTITY(1,1) NOT NULL,
	[Customer_Code] [varchar](100) NULL,
	[First_Name] [varchar](50) NULL,
	[Last_Name] [varchar](50) NULL,
	[Slug] [varchar](50) NULL,
	[Phone_Extension] [varchar](50) NULL,
	[Titled] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Contact] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[CustomerTranId] [int] NOT NULL,
	[AveragePayDays] [int] NOT NULL,
	[BoFlag] [bit] NOT NULL,
	[AlwaysShipCompleteFlag] [bit] NOT NULL,
	[PoRequiredFlag] [bit] NOT NULL,
	[CcfFlag] [bit] NOT NULL,
	[CrLimit] [varchar](50) NOT NULL,
	[InvoiceEmail] [varchar](100) NULL,
	[Customer] [varchar](100) NULL,
	[SicCode] [varchar](100) NULL,
	[TaxId] [varchar](50) NULL,
	[TaxExempt] [varchar](50) NULL,
	[GraceDays] [int] NULL,
	[HasConsolidatedInvoices] [bit] NULL,
	[IsAssessFinanceCharges] [bit] NULL,
	[StatementDestinationEmail] [varchar](100) NULL,
	[OrderAcknowledgementEmail] [varchar](100) NULL,
	[ShippingConfirmationEmail] [varchar](100) NULL,
	[PickupConfirmationEmail] [varchar](100) NULL,
	[OrderAcknowledgementEmailSelect] [varchar](100) NULL,
	[ShippingConfirmationEmailSelect] [varchar](100) NULL,
	[PickupConfirmationEmailSelect] [varchar](100) NULL,
	[IsAlwaysPassCreditCheck] [bit] NULL,
	[IsPreferFullLots] [bit] NULL,
	[IsRequireFullLots] [bit] NULL,
	[ExternalDocparserParserId] [varchar](100) NULL,
	[LocationToBlind] [bit] NULL,
	[InvoiceOptionEmail] [bit] NULL,
	[InvoiceOptionPrint] [bit] NULL,
	[CooRequiredFlag] [bit] NULL,
	[IsStateTaxExempt] [bit] NULL,
	[IsSyncToHubSpot] [bit] NULL,
	[Website] [varchar](100) NULL,
	[PrintPriceOnPickingSlip] [bit] NULL,
	[PrintPriceOnPackingSlip] [bit] NULL,
	[IsDraft] [bit] NULL,
	[QualityCheckTarget] [int] NULL,
	[FontColor] [varchar](100) NULL,
	[BorderColor] [varchar](100) NULL,
	[ShadingColor] [varchar](100) NULL,
	[LabelQuantity] [varchar](100) NULL,
	[PackingSlipPdfTemplate] [varchar](100) NULL,
	[PaymentTerm_Id] [int] NOT NULL,
	[Logo_Master_Id] [int] NOT NULL,
	[OrderSource_Master_Id] [int] NOT NULL,
	[CustomerGroup_Id] [int] NOT NULL,
 CONSTRAINT [PK_Customer_Master] PRIMARY KEY CLUSTERED 
(
	[Customer_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerGroup]    Script Date: 20/09/2024 7:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](100) NULL,
	[Description] [varchar](100) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[CustomerGroup_TranId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EasyPostMethod]    Script Date: 20/09/2024 7:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EasyPostMethod](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[EsyPostMethod_TranId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item_Master]    Script Date: 20/09/2024 7:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item_Master](
	[Item_Id] [int] IDENTITY(1,1) NOT NULL,
	[Item_Name] [varchar](100) NULL,
	[Item_Code] [varchar](100) NULL,
	[SKU] [varchar](100) NULL,
	[Category_Id] [int] NULL,
	[Item_Description] [varchar](max) NULL,
	[Web_Description] [varchar](max) NULL,
	[Item_Price] [decimal](18, 2) NULL,
	[Weight] [decimal](18, 2) NULL,
	[Ship_Width] [decimal](18, 2) NULL,
	[Ship_Height] [decimal](18, 2) NULL,
	[Ship_Length] [decimal](18, 2) NULL,
	[Commodity_Code] [varchar](100) NULL,
	[Default_Country_of_Origin] [varchar](100) NULL,
	[Custom_Attributes] [varchar](max) NULL,
	[Primary_Vendor_Id] [int] NULL,
	[Main_Image_File_Id] [int] NULL,
	[Product_Line] [varchar](max) NULL,
	[Unit_Id] [int] NULL,
	[Display_Unit_Id] [int] NULL,
	[Files] [varchar](max) NULL,
	[ItemTranId] [int] NULL,
 CONSTRAINT [PK_Item_Master] PRIMARY KEY CLUSTERED 
(
	[Item_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item_Price_Information]    Script Date: 20/09/2024 7:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item_Price_Information](
	[Item_Price_Id] [int] IDENTITY(1,1) NOT NULL,
	[Item_Id] [int] NULL,
	[Quantity_In_Display_Unit] [int] NULL,
	[Customer_Id] [int] NULL,
	[Unit_Id] [int] NULL,
	[Display_Unit_Id] [int] NULL,
	[Final_Price_Per_Unit] [decimal](18, 2) NULL,
	[Final_Price_Per_Display_Unit] [decimal](18, 2) NULL,
	[Quantity_Breaks_Per_Dispaly_Unit] [varchar](max) NULL,
	[Price_Breaks] [varchar](max) NULL,
 CONSTRAINT [PK_Item_Price_Information] PRIMARY KEY CLUSTERED 
(
	[Item_Price_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item_Stock_Details]    Script Date: 20/09/2024 7:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item_Stock_Details](
	[Stock_Id] [int] IDENTITY(1,1) NOT NULL,
	[Item_Id] [int] NULL,
	[Warehouse_Id] [int] NULL,
	[Purchase_Orders] [varchar](max) NULL,
	[Quantity_On_Purchase_Order] [int] NULL,
	[Quantity_On_Hand] [int] NULL,
	[Quantity_Committed] [int] NULL,
	[Quantity_Available] [int] NULL,
	[Unit_Id] [int] NULL,
	[Display_Unit_Id] [int] NULL,
 CONSTRAINT [PK_Item_Stock_Details] PRIMARY KEY CLUSTERED 
(
	[Stock_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logo_Master]    Script Date: 20/09/2024 7:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logo_Master](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Size] [varchar](20) NULL,
	[eTag] [varchar](200) NULL,
	[contentType] [varchar](100) NULL,
	[FileName] [varchar](100) NULL,
	[Key] [varchar](100) NULL,
	[Description] [varchar](100) NULL,
	[FileOrder] [int] NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[Logo_TranId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MigrationConfig]    Script Date: 20/09/2024 7:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MigrationConfig](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Company_Id] [int] NOT NULL,
	[APIDetails] [varchar](max) NOT NULL,
	[APITokan] [varchar](max) NULL,
	[Tokan_Type] [varchar](100) NULL,
	[CreateAT] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
	[Description] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderSource_Master]    Script Date: 20/09/2024 7:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderSource_Master](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Slug] [varchar](100) NULL,
	[Code] [varchar](100) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[OrderSource_TranId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment_terms]    Script Date: 20/09/2024 7:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment_terms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Slug] [varchar](100) NULL,
	[Description] [varchar](200) NULL,
	[DiscountDays] [int] NOT NULL,
	[DueDays] [int] NOT NULL,
	[TotalDiscountPercent] [numeric](18, 2) NOT NULL,
	[TermsCode] [varchar](100) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
	[PaymentTerms_TranId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Region_Master]    Script Date: 20/09/2024 7:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Region_Master](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Slug] [varchar](200) NULL,
	[CountryName] [varchar](200) NULL,
	[Region] [varchar](200) NULL,
	[States] [varchar](max) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
	[Region_TranId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemShipVia]    Script Date: 20/09/2024 7:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemShipVia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Slug] [varchar](100) NULL,
	[ShipViaCode] [varchar](100) NULL,
	[Description] [varchar](200) NULL,
	[PackageType] [varchar](100) NULL,
	[WebDescription] [varchar](200) NULL,
	[SaturdayDeliveryOption] [bit] NULL,
	[CreditCardPreAuthOption] [bit] NULL,
	[FreeShip] [bit] NULL,
	[Web] [bit] NULL,
	[EasyPostMethod_Id] [int] NULL,
	[Expedite] [bit] NULL,
	[FreeFreightAllowed] [bit] NULL,
	[International] [bit] NULL,
	[Collect] [bit] NULL,
	[Carrier_Id] [int] NULL,
	[IsReturnMethod] [bit] NULL,
	[billingOptions] [varchar](100) NULL,
	[HandlingChargeAmount] [varchar](50) NULL,
	[HandlingChargePercent] [varchar](50) NULL,
	[IsPickup] [bit] NULL,
	[IsDelivery] [bit] NULL,
	[EdiServiceLevelCode] [varchar](100) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[SystemShipVia_TranId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unit_Master]    Script Date: 20/09/2024 7:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit_Master](
	[Unit_Id] [int] IDENTITY(1,1) NOT NULL,
	[Unit_Name] [varchar](100) NULL,
	[Unit_Symbol] [varchar](100) NULL,
	[UnitTranId] [int] NULL,
 CONSTRAINT [PK_Unit_Master] PRIMARY KEY CLUSTERED 
(
	[Unit_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Warehouse_Master]    Script Date: 20/09/2024 7:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Warehouse_Master](
	[Warehouse_Id] [int] IDENTITY(1,1) NOT NULL,
	[Warehouse_Trans_Id] [int] NULL,
	[Warehouse_Name] [varchar](100) NULL,
	[Warehouse_Code] [varchar](100) NULL,
	[Attention] [varchar](100) NULL,
	[IsExternal] [bit] NULL,
	[IsWeb] [bit] NULL,
	[Slug] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Transfer_Ship_Via_Account] [varchar](100) NULL,
	[Address1] [varchar](100) NULL,
	[Address2] [varchar](100) NULL,
	[Address3] [varchar](100) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
	[Postal] [varchar](10) NULL,
	[Phone] [varchar](15) NULL,
	[IsResidential] [bit] NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[UpdatedBy] [varchar](max) NULL,
	[WarehouseTranId] [int] NULL,
 CONSTRAINT [PK_Warehouse_Master] PRIMARY KEY CLUSTERED 
(
	[Warehouse_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AddOn] ON 
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (1, CAST(15.73 AS Numeric(18, 2)), N'/api/order_invoices/1', 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), NULL, 1)
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (2, CAST(19.31 AS Numeric(18, 2)), N'/api/order_invoices/2', 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), NULL, 2)
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (3, CAST(13.52 AS Numeric(18, 2)), N'/api/order_invoices/3', 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), NULL, 3)
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (4, CAST(21.78 AS Numeric(18, 2)), N'/api/order_invoices/5', 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), NULL, 4)
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (5, CAST(16.94 AS Numeric(18, 2)), N'/api/order_invoices/6', 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), NULL, 5)
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (6, CAST(15.46 AS Numeric(18, 2)), N'/api/order_invoices/7', 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), NULL, 6)
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (7, CAST(16.11 AS Numeric(18, 2)), N'/api/order_invoices/8', 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), NULL, 7)
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (8, CAST(13.52 AS Numeric(18, 2)), N'/api/order_invoices/10', 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), NULL, 8)
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (9, CAST(19.09 AS Numeric(18, 2)), N'/api/order_invoices/11', 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), NULL, 9)
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (10, CAST(13.52 AS Numeric(18, 2)), N'/api/order_invoices/12', 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), NULL, 10)
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (11, CAST(125.00 AS Numeric(18, 2)), NULL, 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), N'/api/purchase_order_bills/2', 11)
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (12, CAST(28.50 AS Numeric(18, 2)), NULL, 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), N'/api/purchase_order_bills/3', 12)
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (13, CAST(112.50 AS Numeric(18, 2)), NULL, 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), N'/api/purchase_order_bills/4', 13)
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (14, CAST(19.77 AS Numeric(18, 2)), N'/api/order_invoices/13', 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), NULL, 14)
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (15, CAST(72.27 AS Numeric(18, 2)), N'/api/order_invoices/15', 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), NULL, 15)
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (16, CAST(56.00 AS Numeric(18, 2)), NULL, 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), N'/api/purchase_order_bills/5', 16)
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (17, CAST(78.67 AS Numeric(18, 2)), N'/api/order_invoices/16', 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), NULL, 17)
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (18, CAST(14.41 AS Numeric(18, 2)), N'/api/order_invoices/17', 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), NULL, 18)
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (19, CAST(14.39 AS Numeric(18, 2)), N'/api/order_invoices/18', 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), NULL, 19)
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (20, CAST(13.97 AS Numeric(18, 2)), N'/api/order_invoices/19', 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), NULL, 20)
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (21, CAST(13.13 AS Numeric(18, 2)), N'/api/order_invoices/20', 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), NULL, 21)
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (22, CAST(16.13 AS Numeric(18, 2)), N'/api/order_invoices/21', 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), NULL, 22)
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (23, CAST(28.50 AS Numeric(18, 2)), NULL, 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), N'/api/purchase_order_bills/6', 23)
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (24, CAST(18.96 AS Numeric(18, 2)), N'/api/order_invoices/22', 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), NULL, 24)
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (25, CAST(15.47 AS Numeric(18, 2)), N'/api/order_invoices/23', 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), NULL, 25)
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (26, CAST(15.00 AS Numeric(18, 2)), N'/api/order_invoices/22', 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), NULL, 26)
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (27, CAST(13.91 AS Numeric(18, 2)), N'/api/order_invoices/24', 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), NULL, 27)
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (28, CAST(60.89 AS Numeric(18, 2)), N'/api/order_invoices/25', 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), NULL, 28)
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (29, CAST(13.97 AS Numeric(18, 2)), N'/api/order_invoices/26', 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), NULL, 29)
GO
INSERT [dbo].[AddOn] ([Id], [Amount], [OrderInvoice], [TaxFlag], [TaxOverride], [TaxCode], [TaxRate], [TaxAmount], [PurchaseOrderBill], [AddOnTranId]) VALUES (30, CAST(24.12 AS Numeric(18, 2)), N'/api/order_invoices/27', 0, 0, N'', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), NULL, 30)
GO
SET IDENTITY_INSERT [dbo].[AddOn] OFF
GO
SET IDENTITY_INSERT [dbo].[AddOnDetail] ON 
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (1, 1, N'', N'Outbound Freight', N'Outbound Shipping Costs', 57)
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (2, 2, N'', N'FREIGHT OUTBOUND', N'FREIGHT OUTBOUND', 66)
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (3, 3, N'', N'FREIGHT OUTBOUND', N'FREIGHT OUTBOUND', 66)
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (4, 4, N'', N'FREIGHT OUTBOUND', N'FREIGHT OUTBOUND', 66)
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (5, 5, N'', N'FREIGHT OUTBOUND', N'FREIGHT OUTBOUND', 66)
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (6, 6, N'', N'FREIGHT OUTBOUND', N'FREIGHT OUTBOUND', 66)
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (7, 7, N'', N'FREIGHT OUTBOUND', N'FREIGHT OUTBOUND', 66)
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (8, 8, N'', N'FREIGHT OUTBOUND', N'FREIGHT OUTBOUND', 66)
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (9, 9, N'', N'FREIGHT OUTBOUND', N'FREIGHT OUTBOUND', 66)
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (10, 10, N'', N'FREIGHT OUTBOUND', N'FREIGHT OUTBOUND', 66)
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (11, 11, N'', N'Inbound Freight', N'Inbound Shipping Costs', 56)
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (12, 12, N'', N'Inbound Freight', N'Inbound Shipping Costs', 56)
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (13, 13, N'', N'Inbound Freight', N'Inbound Shipping Costs', 56)
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (14, 14, N'', N'FREIGHT OUTBOUND', N'FREIGHT OUTBOUND', 66)
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (15, 15, N'', N'FREIGHT OUTBOUND', N'FREIGHT OUTBOUND', 66)
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (16, 16, N'', N'Inbound Freight', N'Inbound Shipping Costs', 56)
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (17, 17, N'', N'FREIGHT OUTBOUND', N'FREIGHT OUTBOUND', 66)
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (18, 18, N'', N'FREIGHT OUTBOUND', N'FREIGHT OUTBOUND', 66)
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (19, 19, N'', N'FREIGHT OUTBOUND', N'FREIGHT OUTBOUND', 66)
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (20, 20, N'', N'FREIGHT OUTBOUND', N'FREIGHT OUTBOUND', 66)
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (21, 21, N'', N'FREIGHT OUTBOUND', N'FREIGHT OUTBOUND', 66)
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (22, 22, N'', N'FREIGHT OUTBOUND', N'FREIGHT OUTBOUND', 66)
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (23, 23, N'', N'Inbound Freight', N'Inbound Shipping Costs', 56)
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (24, 24, N'', N'FREIGHT OUTBOUND', N'FREIGHT OUTBOUND', 66)
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (25, 25, N'', N'FREIGHT OUTBOUND', N'FREIGHT OUTBOUND', 66)
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (26, 26, N'', N'Handling Charge', N'Handling Charge', 58)
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (27, 27, N'', N'FREIGHT OUTBOUND', N'FREIGHT OUTBOUND', 66)
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (28, 28, N'', N'FREIGHT OUTBOUND', N'FREIGHT OUTBOUND', 66)
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (29, 29, N'', N'FREIGHT OUTBOUND', N'FREIGHT OUTBOUND', 66)
GO
INSERT [dbo].[AddOnDetail] ([Id], [Addon_Id], [TotCd], [Name], [Description], [AddOnDetail_tranId]) VALUES (30, 30, N'', N'FREIGHT OUTBOUND', N'FREIGHT OUTBOUND', 66)
GO
SET IDENTITY_INSERT [dbo].[AddOnDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[AspNetRoles] ON 
GO
INSERT [dbo].[AspNetRoles] ([Id], [Role_Name], [CreateAt], [UpdateAt]) VALUES (1, N'Admin', CAST(N'2024-09-14T15:41:19.783' AS DateTime), CAST(N'2024-09-14T15:41:19.783' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[AspNetRoles] OFF
GO
SET IDENTITY_INSERT [dbo].[AspNetUserRoles] ON 
GO
INSERT [dbo].[AspNetUserRoles] ([Id], [AspNetUser_Id], [AspNetRole_Id]) VALUES (1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[AspNetUserRoles] OFF
GO
SET IDENTITY_INSERT [dbo].[AspNetUsers] ON 
GO
INSERT [dbo].[AspNetUsers] ([User_Id], [EmailId], [PasswordHas], [Customer_Id], [Company_Id], [CreateAt], [UpdateAt]) VALUES (1, N'melvina@bigh.com', N'Admin@sky12', 4, 1, CAST(N'2024-09-14T15:43:05.013' AS DateTime), CAST(N'2024-09-14T15:43:05.013' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[AspNetUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[BillingOption] ON 
GO
INSERT [dbo].[BillingOption] ([Id], [Description], [value], [AddToInvoice], [Slug], [IsRequireBillingAccount], [IsUseCompanyAccount], [BillingOption_TranId]) VALUES (1, N'Prepay & Add', N'sender', N'true', N'sender', 1, 1, 109)
GO
INSERT [dbo].[BillingOption] ([Id], [Description], [value], [AddToInvoice], [Slug], [IsRequireBillingAccount], [IsUseCompanyAccount], [BillingOption_TranId]) VALUES (2, N'Collect', N'receiver', N'false', N'receiver', 1, 0, 110)
GO
INSERT [dbo].[BillingOption] ([Id], [Description], [value], [AddToInvoice], [Slug], [IsRequireBillingAccount], [IsUseCompanyAccount], [BillingOption_TranId]) VALUES (3, N'Third Party', N'third_party', N'false', N'third-party', 0, 0, 111)
GO
INSERT [dbo].[BillingOption] ([Id], [Description], [value], [AddToInvoice], [Slug], [IsRequireBillingAccount], [IsUseCompanyAccount], [BillingOption_TranId]) VALUES (4, N'Allow', N'allow', N'false', N'allow', 1, 1, 112)
GO
INSERT [dbo].[BillingOption] ([Id], [Description], [value], [AddToInvoice], [Slug], [IsRequireBillingAccount], [IsUseCompanyAccount], [BillingOption_TranId]) VALUES (5, N'Prepay', N'receiver', N'false', N'receiver-1', 0, 0, 113)
GO
SET IDENTITY_INSERT [dbo].[BillingOption] OFF
GO
SET IDENTITY_INSERT [dbo].[Carrier] ON 
GO
INSERT [dbo].[Carrier] ([Id], [Slug], [carrier], [ShipViaAccount], [CreatedAt], [UpdatedAt], [Carrier_TranId]) VALUES (1, N'usps', N'USPS', N'123', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-12-20T17:10:46.000' AS DateTime), 13)
GO
INSERT [dbo].[Carrier] ([Id], [Slug], [carrier], [ShipViaAccount], [CreatedAt], [UpdatedAt], [Carrier_TranId]) VALUES (2, N'ups', N'UPS', N'123456', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-12-20T17:10:51.000' AS DateTime), 14)
GO
INSERT [dbo].[Carrier] ([Id], [Slug], [carrier], [ShipViaAccount], [CreatedAt], [UpdatedAt], [Carrier_TranId]) VALUES (3, N'fedex', N'FEDEX', N'123456789', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-12-20T17:10:56.000' AS DateTime), 15)
GO
SET IDENTITY_INSERT [dbo].[Carrier] OFF
GO
SET IDENTITY_INSERT [dbo].[Company] ON 
GO
INSERT [dbo].[Company] ([Id], [Company_Name], [Company_Code], [Logo], [CreateAt], [UpdateAt]) VALUES (1, N'ABC', N'ABC001', N'', CAST(N'2024-09-14T15:40:33.413' AS DateTime), CAST(N'2024-09-14T15:40:33.413' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Company] OFF
GO
SET IDENTITY_INSERT [dbo].[Contact_Master] ON 
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (1, N'joshua-rohan', N'Joshua', N'Rohan', N'120', N'GM', N'Joshua', N'Joshua Rohan', N'+14058182101', 1, N'joshua@generalseal.com', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-30T01:04:25.000' AS DateTime), NULL, 401)
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (3, N'lilian-torphy', N'Lilian', N'Torphy', N'123', N'Sales Manager', N'Lilian', N'Lilian Torphy', N'+1 (304) 400-0654', 1, N'lilian@generalseal.com', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-30T02:06:45.000' AS DateTime), NULL, 402)
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (4, N'alec-hermiston', N'Alec', N'Hermiston', N'', N'', N'Alec', N'Alec Hermiston', N'669.639.4268', 1, N'', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-30T02:07:06.000' AS DateTime), 403)
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (5, N'dock-turcotte', N'Dock', N'Turcotte', N'', N'', N'Dock', N'Dock Turcotte', N'508.980.8865', 1, N'', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-30T02:07:11.000' AS DateTime), 404)
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (6, N'nathanael-hermann', N'Nathanael', N'Hermann', N'', N'', N'Nathanael', N'Nathanael Hermann', N'724-236-5010', 1, N'', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-30T02:07:15.000' AS DateTime), 405)
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (7, N'sheila-schumm', N'Sheila', N'Schumm', N'', N'', N'Sheila', N'Sheila Schumm', N'(445) 325-7545', 1, N'', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-30T02:07:20.000' AS DateTime), 406)
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (8, N'creola-crona', N'Creola', N'Crona', N'', N'', N'Creola', N'Creola Crona', N'(541) 977-0031', 1, N'', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-30T02:07:25.000' AS DateTime), 407)
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (9, N'edmund-kreiger', N'Edmund', N'Kreiger', N'', N'', N'Edmund', N'Edmund Kreiger', N'1-820-300-9207', 1, N'', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-30T02:07:30.000' AS DateTime), 408)
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (10, N'aiden-altenwerth', N'Aiden', N'Altenwerth', N'', N'', N'Aiden', N'Aiden Altenwerth', N'628.236.7184', 1, N'', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-30T02:07:35.000' AS DateTime), 409)
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (11, N'suzanne-cormier', N'Suzanne', N'Cormier', N'', N'Purchasing', N'Suzanne', N'Suzanne Cormier', N'+14057284495', 1, N'suzanne@generalseal.com', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-30T02:08:41.000' AS DateTime), NULL, 410)
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (12, N'daphney-smith', N'Daphney', N'Smith', N'101', N'Operations Manager', N'Daphney', N'Daphney Smith', N'+12146304379', 2, N'daphneya@standard.com', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2024-03-14T20:59:25.000' AS DateTime), NULL, 411)
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (13, N'412-caleb-jacobs', N'Caleb', N'Jacobs', N'109', N'Purchasing', N'Caleb', N'Caleb Jacobs', N'+12146304379', 2, N'caleb@standard.com', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-29T20:08:35.000' AS DateTime), NULL, 412)
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (14, N'greyson-douglas', N'Greyson', N'Douglas', N'', N'Sales Manager', N'Greyson', N'Greyson Douglas', N'+13212122695', 2, N'greyson@standard.com', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-29T20:09:26.000' AS DateTime), NULL, 413)
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (15, N'414-keeley-johnson', N'Keeley', N'Johnson', N'', N'Accounting', N'Keeley', N'Keeley Johnson', N'+1-267-235-1595', 2, N'keeley@standard.com', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-29T21:55:20.000' AS DateTime), NULL, 414)
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (16, N'margot-olson', N'Margot', N'Olson', N'', N'', N'Margot', N'Margot Olson', N'+19493461963', 2, N'', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-09-19T02:57:02.000' AS DateTime), 415)
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (17, N'jaiden-oberbrunner', N'Jaiden', N'Oberbrunner', N'', N'', N'Jaiden', N'Jaiden Oberbrunner', N'1-401-485-4779', 2, N'', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-09-19T02:57:11.000' AS DateTime), 416)
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (18, N'connie-dooley', N'Connie', N'Dooley', N'', N'', N'Connie', N'Connie Dooley', N'229.639.9728', 2, N'', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-09-19T02:57:16.000' AS DateTime), 417)
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (19, N'karley-skiles', N'Karley', N'Skiles', N'', N'', N'Karley', N'Karley Skiles', N'1-725-971-7859', 2, N'', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-09-19T02:57:21.000' AS DateTime), 418)
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (20, N'janie-upton', N'Janie', N'Upton', N'', N'', N'Janie', N'Janie Upton', N'814-951-8780', 2, N'', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-09-19T02:57:27.000' AS DateTime), 419)
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (21, N'ernest-collier', N'Ernest', N'Collier', N'', N'', N'Ernest', N'Ernest Collier', N'(909) 982-2974', 2, N'', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-09-19T02:57:32.000' AS DateTime), 420)
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (22, N'idella-koepp', N'Idella', N'Koepp', N'125', N'Sales', N'Idella', N'Idella Koepp', N'+1.281.401.4400', 3, N'idella@abcmaterials.com', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-30T03:15:53.000' AS DateTime), NULL, 421)
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (23, N'selina-hamill', N'Selina', N'Hamill', N'', N'', N'Selina', N'Selina Hamill', N'+1.971.356.8793', 3, N'', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-24T14:30:09.000' AS DateTime), NULL, 422)
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (24, N'jarrell-ullrich', N'Jarrell', N'Ullrich', N'', N'', N'Jarrell', N'Jarrell Ullrich', N'+1 (918) 498-6762', 3, N'', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-24T14:30:09.000' AS DateTime), NULL, 423)
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (25, N'monique-schinner', N'Monique', N'Schinner', N'', N'', N'Monique', N'Monique Schinner', N'727.710.2635', 3, N'', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-24T14:30:09.000' AS DateTime), NULL, 424)
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (26, N'gia-gutmann', N'Gia', N'Gutmann', N'', N'', N'Gia', N'Gia Gutmann', N'+1.828.778.0996', 3, N'', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-24T14:30:09.000' AS DateTime), NULL, 425)
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (27, N'nathaniel-block', N'Nathaniel', N'Block', N'', N'', N'Nathaniel', N'Nathaniel Block', N'1-878-803-1672', 3, N'', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-24T14:30:09.000' AS DateTime), NULL, 426)
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (28, N'ezekiel-schumm', N'Ezekiel', N'Schumm', N'', N'', N'Ezekiel', N'Ezekiel Schumm', N'+1-425-723-7800', 3, N'', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-24T14:30:09.000' AS DateTime), NULL, 427)
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (29, N'alia-herman', N'Alia', N'Herman', N'', N'', N'Alia', N'Alia Herman', N'+1 (479) 489-1088', 3, N'', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-24T14:30:09.000' AS DateTime), NULL, 428)
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (30, N'jeromy-nolan', N'Jeromy', N'Nolan', N'', N'', N'Jeromy', N'Jeromy Nolan', N'+13043599716', 3, N'', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-24T14:30:09.000' AS DateTime), NULL, 429)
GO
INSERT [dbo].[Contact_Master] ([Id], [Slug], [FirstName], [LastName], [PhoneExtension], [Titled], [Contact], [Name], [Phone], [CustomerId], [Email], [CreatedAt], [UpdatedAt], [DeletedAt], [Contact_TranId]) VALUES (31, N'dewayne-koch', N'Dewayne', N'Koch', N'', N'', N'Dewayne', N'Dewayne Koch', N'682.740.7609', 3, N'', CAST(N'2023-08-24T14:30:09.000' AS DateTime), CAST(N'2023-08-24T14:30:09.000' AS DateTime), NULL, 430)
GO
SET IDENTITY_INSERT [dbo].[Contact_Master] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer_Location_Information] ON 
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (1, 1, CAST(N'2024-09-19T10:00:42.473' AS DateTime), N'00 - 2', N'48 E Hill St', N'', N'', N'Oklahoma City', N'OK', N'US', N'73105', N'+14058182101', 0, N'General Seal Supply', N'123456', N'00---2', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-11-29T08:09:52.000' AS DateTime), 21201, 1)
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (2, 1, CAST(N'2024-09-19T10:00:42.530' AS DateTime), N'01', N'Enid Roads 5', N'Suite 706', N'', N'Ullrichside', N'Pennsylvania', N'TK', N'20827', N'352.359.8855', 0, N'1797 Gonzalo Pike', N'', N'01', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-08-24T04:00:09.000' AS DateTime), 21202, 0)
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (3, 1, CAST(N'2024-09-19T10:00:42.533' AS DateTime), N'02', N'Dorris Haven 71', N'Apt. 619', N'', N'West Brigittebury', N'Maryland', N'NI', N'71794', N'469-723-1257', 0, N'957 Gaston Trail Suite 356', N'', N'02', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-08-24T04:00:09.000' AS DateTime), 21203, 0)
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (4, 1, CAST(N'2024-09-19T10:00:42.533' AS DateTime), N'03', N'Quitzon Branch 57', N'Suite 459', N'', N'Sporerton', N'Connecticut', N'TN', N'95465-7690', N'+1-762-768-1479', 0, N'792 Nona Junction', N'', N'03', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-08-24T04:00:09.000' AS DateTime), 21204, 0)
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (5, 1, CAST(N'2024-09-19T10:00:42.537' AS DateTime), N'04', N'Daniella Port 97', N'Suite 381', N'', N'South Albina', N'Missouri', N'AW', N'18563-3920', N'+1 (240) 367-1551', 0, N'46787 Olson Burg', N'', N'04', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-08-24T04:00:09.000' AS DateTime), 21205, 0)
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (6, 1, CAST(N'2024-09-19T10:00:42.540' AS DateTime), N'05', N'Padberg Street 78', N'Apt. 807', N'', N'Port Marie', N'Nevada', N'SD', N'48975-0943', N'+1 (469) 621-3230', 0, N'353 Turcotte Pass Apt. 896', N'', N'05', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-08-24T04:00:09.000' AS DateTime), 21206, 0)
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (7, 1, CAST(N'2024-09-19T10:00:42.540' AS DateTime), N'06', N'Tad Mountain 42', N'Suite 090', N'', N'Port Trisha', N'Iowa', N'BH', N'65715', N'+1-520-807-4592', 0, N'34842 Lubowitz Knolls', N'', N'06', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-08-24T04:00:09.000' AS DateTime), 21207, 0)
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (8, 1, CAST(N'2024-09-19T10:00:42.543' AS DateTime), N'07', N'Stracke Lakes 80', N'Apt. 002', N'', N'Ankundingview', N'Arizona', N'KW', N'24666-0354', N'1-531-809-3716', 0, N'17828 Walter Park', N'', N'07', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-08-24T04:00:09.000' AS DateTime), 21208, 0)
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (9, 1, CAST(N'2024-09-19T10:00:42.543' AS DateTime), N'08', N'Rose Forest 7', N'Apt. 790', N'', N'Maryjanestad', N'Missouri', N'PR', N'57793-9892', N'1-689-653-8990', 0, N'79753 Enola Rapid Apt. 015', N'', N'08', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-08-24T04:00:09.000' AS DateTime), 21209, 0)
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (10, 1, CAST(N'2024-09-19T10:00:42.547' AS DateTime), N'09', N'Ernesto Points 7', N'Apt. 747', N'', N'Hicklestad', N'Indiana', N'KE', N'60284', N'551.201.6761', 0, N'59749 Schuppe Lane Suite 034', N'', N'09', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-08-24T04:00:09.000' AS DateTime), 21210, 0)
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (11, 2, CAST(N'2024-09-19T10:00:42.550' AS DateTime), N'00 - 2', N'1720 Regal Row', N'', N'', N'Dallas', N'TX', N'US', N'75235', N'+12146304379', 0, N'Standard Supply', N'123456', N'00---2', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-11-29T08:10:11.000' AS DateTime), 21211, 1)
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (12, 2, CAST(N'2024-09-19T10:00:42.557' AS DateTime), N'01 - 2', N'171 Paradise Blvd', N'', N'', N'Athens', N'GA', N'US', N'30607', N'+14047907210', 0, N'Standard Supply', N'123456', N'01---2', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-11-29T08:10:32.000' AS DateTime), 21212, 2)
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (13, 2, CAST(N'2024-09-19T10:00:42.560' AS DateTime), N'02', N'Orn Centers 98', N'Suite 626', N'', N'Mallieport', N'North Carolina', N'SZ', N'49296', N'+1-608-312-5836', 0, N'39080 Russel Brook', N'', N'02', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-08-24T04:00:09.000' AS DateTime), 21213, 0)
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (14, 2, CAST(N'2024-09-19T10:00:42.563' AS DateTime), N'03', N'Toy Meadow 68', N'Suite 759', N'', N'Daishaville', N'Florida', N'PS', N'05157', N'+1-712-556-3310', 0, N'617 Josefina Route', N'', N'03', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-08-24T04:00:09.000' AS DateTime), 21214, 0)
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (15, 2, CAST(N'2024-09-19T10:00:42.567' AS DateTime), N'04', N'Gislason Locks 87', N'Suite 624', N'', N'Brannontown', N'Nevada', N'EH', N'20180-0250', N'(949) 802-3107', 0, N'66735 Clementine Streets', N'', N'04', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-08-24T04:00:09.000' AS DateTime), 21215, 0)
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (16, 2, CAST(N'2024-09-19T10:00:42.567' AS DateTime), N'05', N'Effertz Hollow 28', N'Suite 084', N'', N'Rutherfordchester', N'Indiana', N'CZ', N'97587', N'1-743-898-9156', 0, N'355 Meredith Dale Apt. 929', N'', N'05', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-08-24T04:00:09.000' AS DateTime), 21216, 0)
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (17, 2, CAST(N'2024-09-19T10:00:42.570' AS DateTime), N'06', N'Sauer Haven 29', N'Apt. 941', N'', N'South Anissa', N'Iowa', N'EE', N'25952', N'(810) 772-1589', 0, N'73208 Kemmer Hollow', N'', N'06', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-08-24T04:00:09.000' AS DateTime), 21217, 0)
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (18, 2, CAST(N'2024-09-19T10:00:42.573' AS DateTime), N'07', N'Eldora Island 85', N'Suite 516', N'', N'Kiehnberg', N'Wisconsin', N'RS', N'29134', N'1-586-816-8944', 0, N'7912 Schroeder Valley Suite 872', N'', N'07', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-08-24T04:00:09.000' AS DateTime), 21218, 0)
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (19, 2, CAST(N'2024-09-19T10:00:42.577' AS DateTime), N'08', N'Oscar Plains 82', N'Suite 557', N'', N'East Adrianfort', N'Missouri', N'VC', N'83486', N'(386) 459-4892', 0, N'8649 Senger Trace Apt. 610', N'', N'08', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-08-24T04:00:09.000' AS DateTime), 21219, 0)
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (20, 2, CAST(N'2024-09-19T10:00:42.577' AS DateTime), N'09', N'Madaline Corners 67', N'Apt. 437', N'', N'Lake Emmanuelle', N'Missouri', N'IM', N'70444', N'1-440-445-5195', 0, N'3394 Prosacco Terrace', N'', N'09', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-08-24T04:00:09.000' AS DateTime), 21220, 0)
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (21, 3, CAST(N'2024-09-19T10:00:42.580' AS DateTime), N'00 - 2 - 2', N'1141 Alexander St', N'', N'', N'Houston', N'TX', N'US', N'77008', N'+17135555555', 0, N'ABC Materials', N'123456', N'00---2---2', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-12-18T10:45:06.000' AS DateTime), 21221, 1)
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (22, 3, CAST(N'2024-09-19T10:00:42.583' AS DateTime), N'01', N'Olson Route 78', N'Suite 463', N'', N'Indianapolis', N'Indiana', N'US', N'63020-2435', N'+16693046881', 0, N'57173 Emiliano Falls Suite 024', N'123456', N'01', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-09-19T14:56:18.000' AS DateTime), 21222, 3)
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (23, 3, CAST(N'2024-09-19T10:00:42.587' AS DateTime), N'02', N'Monahan Port 33', N'Suite 884', N'', N'South Monamouth', N'Wisconsin', N'VU', N'28378-0433', N'1-323-371-8491', 0, N'2412 Reinger Harbors', N'', N'02', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-08-24T04:00:09.000' AS DateTime), 21223, 0)
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (24, 3, CAST(N'2024-09-19T10:00:42.590' AS DateTime), N'03', N'Arne Spring 59', N'Apt. 191', N'', N'North Austin', N'Louisiana', N'SS', N'33310', N'+17577181944', 0, N'527 Mariah Parkways', N'', N'03', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-08-24T04:00:09.000' AS DateTime), 21224, 0)
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (25, 3, CAST(N'2024-09-19T10:00:42.590' AS DateTime), N'04', N'Manuel Village 88', N'Apt. 856', N'', N'Eichmannport', N'Colorado', N'LV', N'42643-4742', N'(937) 214-0113', 0, N'3777 Trent Manor Apt. 029', N'', N'04', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-08-24T04:00:09.000' AS DateTime), 21225, 0)
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (26, 3, CAST(N'2024-09-19T10:00:42.593' AS DateTime), N'05', N'Balistreri Mall 86', N'Apt. 935', N'', N'Barbaraberg', N'Kentucky', N'RO', N'92697', N'+15623304702', 0, N'45197 Hagenes Turnpike', N'', N'05', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-08-24T04:00:09.000' AS DateTime), 21226, 0)
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (27, 3, CAST(N'2024-09-19T10:00:42.597' AS DateTime), N'06', N'Weimann Course 63', N'Apt. 889', N'', N'Zboncakbury', N'Tennessee', N'JE', N'65032', N'+1-754-479-0664', 0, N'899 Willms Ville', N'', N'06', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-08-24T04:00:09.000' AS DateTime), 21227, 0)
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (28, 3, CAST(N'2024-09-19T10:00:42.600' AS DateTime), N'07', N'Cedrick Extension 40', N'Apt. 554', N'', N'Ahmadtown', N'Texas', N'CY', N'83268', N'(415) 677-5110', 0, N'56781 Jewel Springs Suite 181', N'', N'07', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-08-24T04:00:09.000' AS DateTime), 21228, 0)
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (29, 3, CAST(N'2024-09-19T10:00:42.600' AS DateTime), N'08', N'Dallas Vista 2', N'Suite 466', N'', N'Lake Brayanchester', N'Alaska', N'MN', N'22543-3311', N'1-713-325-2998', 0, N'97128 Darian Isle', N'', N'08', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-08-24T04:00:09.000' AS DateTime), 21229, 0)
GO
INSERT [dbo].[Customer_Location_Information] ([Customer_Location_Id], [Customer_Id], [DOB], [Location], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [Blind_Ship], [Name], [ShipViaAccount], [slug], [shipAttention], [HasConsolidatedShipments], [IsResidential], [CreatedAt], [UpdatedAt], [CustomerLocation_TranId], [Region_Id]) VALUES (30, 3, CAST(N'2024-09-19T10:00:42.603' AS DateTime), N'09', N'Brenda Port 17', N'Apt. 228', N'', N'Arnulfofort', N'Texas', N'TW', N'88063', N'(352) 391-2001', 0, N'630 Robel Coves Apt. 531', N'', N'09', N'', 0, 0, CAST(N'2023-08-24T04:00:09.000' AS DateTime), CAST(N'2023-08-24T04:00:09.000' AS DateTime), 21230, 0)
GO
SET IDENTITY_INSERT [dbo].[Customer_Location_Information] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer_Master] ON 
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (1, NULL, N'General Seal Supply', N'General Seal Supply', N'geneseal', N'+14058182021', NULL, N'joshua@generalseal.com', NULL, N'+14058182021', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2024-08-09T19:06:11.000' AS DateTime), 21021, 0, 1, 0, 1, 1, N'8000', N'joshua@generalseal.com', N'GENESEAL', N'', N'1-78-1081120-2', N'', 60, 0, 1, N'joshua@generalseal.com', N'joshua@generalseal.com', N'joshua@generalseal.com', N'joshua@generalseal.com', N'', N'add', N'add', 1, 0, 0, N'', 0, 1, 0, 1, 0, 0, N'', 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, 20, 0, 0, 0)
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (2, NULL, N'Standard Supply', N'Standard Supply', N'standard', N'+12146304379', NULL, N'daphneya@standard.com', NULL, N'+12146304379', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2024-06-28T00:07:39.000' AS DateTime), 21022, 0, 1, 0, 0, 1, N'10000', N'keeley@standard.com', N'STANDARD', N'', N'1-75-1907718-7', N'', 90, 0, 1, N'keeley@standard.com', N'daphney@standard.com', N'daphney@standard.com', N'daphney@standard.com', N'add', N'add', N'add', 1, 0, 0, N'', 0, 1, 0, 1, 0, 0, N'', 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, 20, 0, 1, 1)
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (3, NULL, N'ABC Materials', N'ABC Materials', N'abcmat', N'+12814014400', NULL, N'idella@abcmaterials.com', NULL, N'+12814014400', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2024-06-06T02:05:05.000' AS DateTime), 21023, 0, 1, 0, 1, 0, N'5000', N'idella@abcmaterials.com', N'ABCMAT', N'', N'', N'', 0, 0, 1, N'idella@abcmaterials.com', N'idella@abcmaterials.com', N'idella@abcmaterials.com', N'idella@abcmaterials.com', N'add', N'add', N'add', 0, 0, 0, N'', 0, 1, 0, 1, 0, 0, N'', 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, 20, 0, 0, 0)
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (4, NULL, N'Big H Supply', N'Big H Supply', N'bigh', N'+16403537194', NULL, N'melvina@bigh.com', NULL, N'+16403537194', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-09-05T22:12:26.000' AS DateTime), 21024, 0, 1, 0, 1, 0, N'12500', N'invoice@bigh.com', N'BIGH', N'', N'', N'', 60, 0, 1, N'statements@bigh.com', N'melvina@bigh.com', N'melvina@bigh.com', N'melvina@bigh.com', N'', N'', N'', 0, 0, 0, N'', 0, 1, 0, 1, 0, 0, N'', 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, 20, 0, 0, 0)
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (5, NULL, N'Metro Construction Supply', N'Metro Construction Supply', N'metro', N'+16788699879', NULL, N'valerie@metro.com', NULL, N'+16788699879', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2024-08-27T23:26:32.000' AS DateTime), 21025, 0, 1, 0, 1, 0, N'0', N'payables@metro.com', N'METRO', N'', N'', N'', 0, 0, 1, N'payables@metro.com', N'colten@metro.com', N'colten@metro.com', N'colten@metro.com', N'', N'', N'', 1, 0, 0, N'', 0, 1, 0, 1, 0, 0, N'', 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, 20, 0, 0, 2)
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (6, NULL, N'', N'', N'new-customer', N'', NULL, N'', NULL, N'', CAST(N'2023-09-20T00:33:04.000' AS DateTime), CAST(N'2023-09-20T00:42:25.000' AS DateTime), 21026, 0, 0, 0, 1, 0, N'2500', N'', N'NEW_CUSTOMER', N'', N'', N'', 0, 0, 1, N'', N'', N'', N'', N'', N'', N'', 0, 0, 0, N'', 0, 1, 0, 1, 0, 0, N'', 0, 0, 1, 0, NULL, NULL, NULL, NULL, NULL, 15, 0, 0, 0)
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (7, NULL, N'Customer ABC', N'Customer ABC', N'customerabc', N'+', NULL, N'jane@customerabc.com', NULL, N'+', CAST(N'2023-09-21T22:32:49.000' AS DateTime), CAST(N'2023-09-22T23:50:25.000' AS DateTime), 21027, 0, 0, 0, 1, 0, N'2500', N'invoices@customerabc.com', N'CustomerABC', N'', N'', N'', 0, 0, 1, N'statements@customerabc.com', N'', N'', N'', N'', N'', N'', 0, 0, 0, N'', 0, 1, 0, 1, 0, 0, N'', 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, 20, 0, 0, 0)
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (8, NULL, N'Customer 123', N'Customer 123', N'customer123', N'+17135555555', NULL, N'john@customer123.com', NULL, N'+17135555555', CAST(N'2023-09-21T22:35:28.000' AS DateTime), CAST(N'2024-09-11T20:49:04.000' AS DateTime), 21028, 0, 0, 0, 1, 0, N'10000', N'invoices@customer123.com', N'Customer123', N'', N'123456789', N'', 0, 0, 1, N'statements@customer123.com', N'', N'', N'', N'', N'', N'', 0, 0, 0, N'', 0, 1, 0, 1, 0, 0, N'', 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, 20, 0, 0, 0)
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (9, NULL, N'Big D Construction', N'Big D Construction', N'bigd', N'+19728978358', NULL, N'agnes@bigd.com', NULL, N'+19728978358', CAST(N'2023-10-20T01:57:17.000' AS DateTime), CAST(N'2024-06-25T01:49:01.000' AS DateTime), 21029, 0, 1, 0, 1, 0, N'2500', N'agnes@bigd.com; mike@10xerp.com', N'BIGD', N'', N'', N'', 0, 0, 1, N'', N'', N'', N'', N'', N'', N'', 0, 0, 0, N'', 0, 1, 0, 1, 0, 0, N'', 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, 20, 0, 0, 2)
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (10, NULL, N'Cash Customer', N'Cash Customer', N'cash-customer', N'+1', NULL, N'', NULL, N'+1', CAST(N'2023-11-16T19:59:30.000' AS DateTime), CAST(N'2024-06-22T01:54:49.000' AS DateTime), 21030, 0, 0, 0, 1, 0, N'0', N'david@eaglemetasll.com', N'Cash Customer', N'', N'', N'', 0, 0, 1, N'', N'', N'', N'', N'', N'', N'', 0, 0, 0, N'', 0, 1, 0, 0, 0, 0, N'', 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, 16, 0, 0, 0)
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (11, NULL, N'OC Fasteners', N'OC Fasteners', N'ocf211', N'', NULL, N'david@intercorpusa.com', NULL, N'', CAST(N'2023-11-17T23:09:58.000' AS DateTime), CAST(N'2023-11-28T00:42:52.000' AS DateTime), 21031, 0, 1, 0, 1, 1, N'5000', N'david@intercorpusa.com', N'OCF211', N'', N'', N'', 0, 0, 1, N'', N'', N'', N'', N'', N'', N'', 0, 0, 0, N'', 0, 1, 0, 1, 0, 0, N'', 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, 20, 0, 0, 2)
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (12, NULL, N'test', N'test', N'1', N'', NULL, N'', NULL, N'', CAST(N'2023-11-27T21:58:05.000' AS DateTime), CAST(N'2023-11-27T21:58:05.000' AS DateTime), 21032, 0, 0, 0, 1, 0, N'2500', N'', N'1', N'', N'', N'', 0, 0, 1, N'', N'', N'', N'', N'', N'', N'', 0, 0, 0, N'', 0, 1, 0, 1, 0, 0, N'', 0, 0, 1, 0, NULL, NULL, NULL, NULL, NULL, 15, 0, 0, 0)
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (13, NULL, N'Michael''s Supply', N'Michael''s Supply', N'2', N'', NULL, N'michael@supply.com', NULL, N'', CAST(N'2023-11-27T22:12:14.000' AS DateTime), CAST(N'2024-08-09T19:05:57.000' AS DateTime), 21033, 0, 1, 0, 1, 1, N'2500', N'', N'2', N'', N'', N'', 0, 0, 1, N'', N'', N'', N'', N'', N'', N'', 0, 0, 0, N'', 0, 1, 0, 1, 0, 0, N'', 0, 0, 1, 0, NULL, NULL, NULL, NULL, NULL, 15, 0, 0, 0)
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (14, NULL, N'Test Customer', N'Test Customer', N'3', N'', NULL, N'joe@test.com', NULL, N'', CAST(N'2023-11-27T22:13:27.000' AS DateTime), CAST(N'2024-07-30T00:30:25.000' AS DateTime), 21034, 0, 1, 0, 1, 1, N'2500', N'accounting@test.com', N'3', N'', N'', N'', 0, 0, 1, N'', N'', N'', N'', N'', N'', N'', 0, 0, 0, N'', 0, 1, 0, 1, 0, 0, N'', 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, 15, 0, 0, 0)
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (15, NULL, N'NEW', N'NEW', N'new-per', N'', NULL, N'john@new.com', NULL, N'', CAST(N'2023-11-28T00:29:09.000' AS DateTime), CAST(N'2023-11-28T00:29:09.000' AS DateTime), 21035, 0, 0, 0, 1, 0, N'2500', N'invoices@email.com', N'new per', N'', N'', N'', 0, 0, 1, N'', N'', N'', N'', N'', N'', N'', 0, 0, 0, N'', 0, 1, 0, 1, 0, 0, N'', 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, 15, 0, 0, 0)
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (16, NULL, N'Randall McCoy', N'Randall McCoy', N'randallm-primary', N'+17138599878', NULL, N'mccoy.rand@gmail.com', NULL, N'+17138599878', CAST(N'2023-12-08T21:02:11.000' AS DateTime), CAST(N'2023-12-08T21:20:31.000' AS DateTime), 21036, 0, 1, 0, 1, 1, N'2500', N'accounting@test.com', N'randallm-primary', N'', N'', N'', 0, 0, 1, N'', N'', N'', N'', N'', N'', N'salesOnly', 0, 1, 0, N'', 0, 1, 0, 1, 0, 0, N'', 0, 0, 0, 0, N'#4a4a4a', N'#f5a623', N'#9b9b9b', NULL, NULL, 15, 1, 0, 2)
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (17, NULL, N'Randall McCoy', N'Randall McCoy', N'randallm', N'+17138599878', NULL, N'mccoy.rand@gmail.com', NULL, N'+17138599878', CAST(N'2023-12-08T21:18:24.000' AS DateTime), CAST(N'2023-12-08T21:19:17.000' AS DateTime), 21037, 0, 1, 0, 1, 1, N'2500', N'accounting@test.com', N'randallm', N'', N'', N'', 0, 0, 1, N'', N'', N'', N'', N'', N'', N'salesOnly', 0, 0, 1, N'', 0, 1, 0, 1, 0, 0, N'', 0, 0, 0, 0, N'#4a4a4a', N'#f5a623', N'#9b9b9b', NULL, NULL, 15, 0, 0, 2)
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (18, NULL, N'', N'', N'4', N'', NULL, N'', NULL, N'', CAST(N'2024-02-02T01:03:30.000' AS DateTime), CAST(N'2024-02-02T01:03:30.000' AS DateTime), 21038, 0, 1, 0, 1, 1, N'2500', N'', N'4', N'', N'', N'', 0, 0, 1, N'', N'', N'', N'', N'', N'', N'', 0, 0, 0, N'', 0, 1, 0, 1, 0, 0, N'', 0, 0, 1, 0, NULL, NULL, NULL, NULL, NULL, 15, 0, 0, 0)
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (19, NULL, N'IRPdemo', N'IRPdemo', N'2221111', N'', NULL, N'', NULL, N'', CAST(N'2024-02-26T05:29:35.000' AS DateTime), CAST(N'2024-05-22T23:46:32.000' AS DateTime), 21039, 0, 1, 0, 1, 1, N'2500', N'john@10xerp.com', N'2221111', N'', N'', N'', 0, 0, 1, N'', N'', N'', N'', N'', N'', N'', 0, 0, 0, N'', 0, 1, 0, 1, 0, 0, N'', 0, 0, 1, 0, NULL, NULL, NULL, N'', NULL, 11, 0, 0, 0)
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (20, NULL, N'Prospective Customer', N'Prospective Customer', N'prospective-customer', N'', NULL, N'', NULL, N'', CAST(N'2024-04-08T22:28:29.000' AS DateTime), CAST(N'2024-05-31T01:11:54.000' AS DateTime), 21040, 0, 1, 0, 1, 1, N'2500', N'', N'Prospective Customer', N'', N'', N'', 0, 0, 1, N'', N'', N'', N'', N'', N'', N'', 0, 0, 0, N'', 0, 0, 0, 1, 0, 0, N'', 0, 0, 0, 0, NULL, NULL, NULL, N'', NULL, 15, 0, 0, 0)
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (21, NULL, N'NEW CUSTOMER', N'NEW CUSTOMER', N'new-customer-1', N'', NULL, N'', NULL, N'', CAST(N'2024-04-08T22:31:53.000' AS DateTime), CAST(N'2024-04-08T22:31:53.000' AS DateTime), 21041, 0, 0, 0, 1, 0, N'2500', N'', N'NEW CUSTOMER', N'', N'', N'', 0, 0, 1, N'', N'', N'', N'', N'', N'', N'', 0, 0, 0, N'', 0, 0, 0, 1, 0, 0, N'', 0, 0, 0, 0, NULL, NULL, NULL, N'', NULL, 15, 0, 0, 0)
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (22, NULL, N'Standard Supply', N'Standard Supply', N'standard-copy', N'+12146304379', NULL, N'daphneya@standard.com', NULL, N'+12146304379', CAST(N'2024-05-04T02:07:27.000' AS DateTime), CAST(N'2024-05-04T02:07:27.000' AS DateTime), 21042, 0, 1, 0, 1, 1, N'10000', N'keeley@standard.com', N'STANDARD COPY', N'', N'1-75-1907718-7', N'', 90, 0, 1, N'keeley@standard.com', N'daphney@standard.com', N'daphney@standard.com', N'daphney@standard.com', N'add', N'add', N'add', 1, 0, 0, N'', 0, 1, 0, 1, 0, 0, N'', 0, 0, 1, 0, NULL, NULL, NULL, NULL, NULL, 20, 0, 0, 1)
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (23, NULL, N'Customer ABC', N'Customer ABC', N'customerabc-copy', N'+', NULL, N'jane@customerabc.com', NULL, N'+', CAST(N'2024-05-04T02:07:57.000' AS DateTime), CAST(N'2024-05-04T02:07:57.000' AS DateTime), 21043, 0, 0, 0, 1, 0, N'2500', N'invoices@customerabc.com', N'CustomerABC COPY', N'', N'', N'', 0, 0, 1, N'statements@customerabc.com', N'', N'', N'', N'', N'', N'', 0, 0, 0, N'', 0, 1, 0, 1, 0, 0, N'', 0, 0, 1, 0, NULL, NULL, NULL, NULL, NULL, 20, 0, 0, 0)
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (24, NULL, N'Gopher Industrial', N'Gopher Industrial', N'gopher-industrial', N'+15552369599', NULL, N'john@10xerp.com', NULL, N'+15552369599', CAST(N'2024-05-21T19:17:32.000' AS DateTime), CAST(N'2024-07-08T19:45:30.000' AS DateTime), 21044, 0, 1, 0, 0, 0, N'2500', N'john@10xerp.com', N'Gopher Industrial', N'', N'', N'', 0, 0, 1, N'john@10xerp.com', N'john@10xerp.com', N'', N'', N'', N'', N'', 1, 0, 0, N'', 0, 1, 0, 1, 0, 0, N'', 0, 0, 0, 0, NULL, NULL, NULL, N'', NULL, 7, 0, 2, 0)
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (25, NULL, N'Black Swan Mechanical', N'Black Swan Mechanical', N'5', N'+15553021569', NULL, N'tommy@blackswan.net', NULL, N'+15553021569', CAST(N'2024-05-24T18:48:12.000' AS DateTime), CAST(N'2024-05-31T04:01:10.000' AS DateTime), 21045, 0, 1, 0, 0, 0, N'10000', N'john@10xerp.com', N'5', N'', N'', N'', 10, 0, 1, N'', N'', N'', N'', N'', N'', N'', 0, 0, 0, N'', 0, 1, 0, 0, 0, 0, N'', 0, 0, 0, 0, NULL, NULL, NULL, N'', NULL, 7, 0, 0, 2)
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (26, NULL, N'Test Customer', N'Test Customer', N'a', N'', NULL, N'joe@test.com', NULL, N'', CAST(N'2024-05-30T20:06:55.000' AS DateTime), CAST(N'2024-05-30T20:08:55.000' AS DateTime), 21046, 0, 1, 0, 1, 1, N'10000', N'', N'A', N'', N'', N'', 0, 0, 1, N'', N'', N'', N'', N'', N'', N'', 0, 0, 0, N'', 0, 0, 0, 1, 0, 0, N'', 0, 0, 0, 0, NULL, NULL, NULL, N'', NULL, 20, 0, 0, 0)
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (27, NULL, N'Cash JR', N'Cash JR', N'cashjr', N'', NULL, N'', NULL, N'', CAST(N'2024-06-22T01:55:35.000' AS DateTime), CAST(N'2024-06-27T00:26:29.000' AS DateTime), 21047, 0, 0, 0, 0, 0, N'0', N'', N'CashJR', N'', N'', N'', 0, 0, 1, N'', N'', N'', N'', N'disabled', N'disabled', N'disabled', 1, 0, 0, N'', 0, 0, 1, 0, 0, 0, N'', 0, 0, 0, 0, NULL, NULL, NULL, N'', N'', 16, 0, 3, 0)
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (28, NULL, N'TrailerCo.', N'TrailerCo.', N'6', N'', NULL, N'', NULL, N'', CAST(N'2024-06-26T22:48:18.000' AS DateTime), CAST(N'2024-06-26T22:50:31.000' AS DateTime), 21048, 0, 1, 0, 1, 1, N'2500', N'', N'6', N'', N'', N'', 0, 0, 1, N'', N'', N'', N'', N'', N'', N'', 0, 0, 0, N'', 0, 1, 0, 1, 0, 0, N'', 0, 0, 1, 0, NULL, NULL, NULL, N'', N'', 15, 0, 0, 1)
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (29, NULL, N'Pat Tank', N'Pat Tank', N'pat-tank', N'', NULL, N'joe@aol.com', NULL, N'', CAST(N'2024-07-02T20:49:16.000' AS DateTime), CAST(N'2024-07-11T01:15:53.000' AS DateTime), 21049, 0, 0, 0, 0, 0, N'2500', N'john@10xerp.com', N'Pat Tank', N'', N'', N'', 0, 0, 1, N'', N'', N'', N'', N'', N'', N'', 0, 0, 0, N'', 0, 1, 0, 0, 0, 0, N'', 0, 0, 0, 0, NULL, NULL, NULL, N'', N'', 16, 0, 0, 0)
GO
INSERT [dbo].[Customer_Master] ([Customer_Id], [Customer_Code], [First_Name], [Last_Name], [Slug], [Phone_Extension], [Titled], [Email], [Contact], [Phone], [CreatedAt], [UpdatedAt], [CustomerTranId], [AveragePayDays], [BoFlag], [AlwaysShipCompleteFlag], [PoRequiredFlag], [CcfFlag], [CrLimit], [InvoiceEmail], [Customer], [SicCode], [TaxId], [TaxExempt], [GraceDays], [HasConsolidatedInvoices], [IsAssessFinanceCharges], [StatementDestinationEmail], [OrderAcknowledgementEmail], [ShippingConfirmationEmail], [PickupConfirmationEmail], [OrderAcknowledgementEmailSelect], [ShippingConfirmationEmailSelect], [PickupConfirmationEmailSelect], [IsAlwaysPassCreditCheck], [IsPreferFullLots], [IsRequireFullLots], [ExternalDocparserParserId], [LocationToBlind], [InvoiceOptionEmail], [InvoiceOptionPrint], [CooRequiredFlag], [IsStateTaxExempt], [IsSyncToHubSpot], [Website], [PrintPriceOnPickingSlip], [PrintPriceOnPackingSlip], [IsDraft], [QualityCheckTarget], [FontColor], [BorderColor], [ShadingColor], [LabelQuantity], [PackingSlipPdfTemplate], [PaymentTerm_Id], [Logo_Master_Id], [OrderSource_Master_Id], [CustomerGroup_Id]) VALUES (30, NULL, N'Will-Call template', N'Will-Call template', N'7', N'+12033225597', NULL, N'', NULL, N'+12033225597', CAST(N'2024-07-03T19:45:23.000' AS DateTime), CAST(N'2024-07-03T19:48:12.000' AS DateTime), 21050, 0, 1, 0, 1, 1, N'2500', N'', N'7', N'', N'', N'', 0, 0, 1, N'', N'', N'', N'', N'', N'', N'', 1, 0, 0, N'', 0, 0, 1, 1, 0, 0, N'', 0, 0, 0, 0, NULL, NULL, NULL, N'', N'', 16, 0, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[Customer_Master] OFF
GO
SET IDENTITY_INSERT [dbo].[CustomerGroup] ON 
GO
INSERT [dbo].[CustomerGroup] ([Id], [Value], [Description], [CreatedAt], [UpdatedAt], [CustomerGroup_TranId]) VALUES (1, N'End User + CC', N'End User Paying with CC', CAST(N'2024-03-13T01:35:44.000' AS DateTime), CAST(N'2024-03-13T01:35:44.000' AS DateTime), 2)
GO
INSERT [dbo].[CustomerGroup] ([Id], [Value], [Description], [CreatedAt], [UpdatedAt], [CustomerGroup_TranId]) VALUES (2, N'CS', N'Construction Supply', CAST(N'2023-11-14T03:41:40.000' AS DateTime), CAST(N'2023-11-14T03:41:40.000' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[CustomerGroup] OFF
GO
SET IDENTITY_INSERT [dbo].[EasyPostMethod] ON 
GO
INSERT [dbo].[EasyPostMethod] ([Id], [Name], [EsyPostMethod_TranId]) VALUES (1, N'GroundAdvantage', 31)
GO
INSERT [dbo].[EasyPostMethod] ([Id], [Name], [EsyPostMethod_TranId]) VALUES (2, N'Priority', 30)
GO
INSERT [dbo].[EasyPostMethod] ([Id], [Name], [EsyPostMethod_TranId]) VALUES (3, N'NextDayAir', 46)
GO
INSERT [dbo].[EasyPostMethod] ([Id], [Name], [EsyPostMethod_TranId]) VALUES (4, N'Ground', 45)
GO
INSERT [dbo].[EasyPostMethod] ([Id], [Name], [EsyPostMethod_TranId]) VALUES (5, N'FEDEX_GROUND', 41)
GO
INSERT [dbo].[EasyPostMethod] ([Id], [Name], [EsyPostMethod_TranId]) VALUES (6, N'FIRST_OVERNIGHT', 35)
GO
SET IDENTITY_INSERT [dbo].[EasyPostMethod] OFF
GO
SET IDENTITY_INSERT [dbo].[Item_Master] ON 
GO
INSERT [dbo].[Item_Master] ([Item_Id], [Item_Name], [Item_Code], [SKU], [Category_Id], [Item_Description], [Web_Description], [Item_Price], [Weight], [Ship_Width], [Ship_Height], [Ship_Length], [Commodity_Code], [Default_Country_of_Origin], [Custom_Attributes], [Primary_Vendor_Id], [Main_Image_File_Id], [Product_Line], [Unit_Id], [Display_Unit_Id], [Files], [ItemTranId]) VALUES (1, N'N70210', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, 21071)
GO
INSERT [dbo].[Item_Master] ([Item_Id], [Item_Name], [Item_Code], [SKU], [Category_Id], [Item_Description], [Web_Description], [Item_Price], [Weight], [Ship_Width], [Ship_Height], [Ship_Length], [Commodity_Code], [Default_Country_of_Origin], [Custom_Attributes], [Primary_Vendor_Id], [Main_Image_File_Id], [Product_Line], [Unit_Id], [Display_Unit_Id], [Files], [ItemTranId]) VALUES (2, N'N90210', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, 21072)
GO
SET IDENTITY_INSERT [dbo].[Item_Master] OFF
GO
SET IDENTITY_INSERT [dbo].[Item_Stock_Details] ON 
GO
INSERT [dbo].[Item_Stock_Details] ([Stock_Id], [Item_Id], [Warehouse_Id], [Purchase_Orders], [Quantity_On_Purchase_Order], [Quantity_On_Hand], [Quantity_Committed], [Quantity_Available], [Unit_Id], [Display_Unit_Id]) VALUES (1, 21071, 1, NULL, 0, 9915, 1140, 8775, 1, 141)
GO
INSERT [dbo].[Item_Stock_Details] ([Stock_Id], [Item_Id], [Warehouse_Id], [Purchase_Orders], [Quantity_On_Purchase_Order], [Quantity_On_Hand], [Quantity_Committed], [Quantity_Available], [Unit_Id], [Display_Unit_Id]) VALUES (2, 21072, 1, NULL, 0, 40918, 8325, 32593, 1, 141)
GO
SET IDENTITY_INSERT [dbo].[Item_Stock_Details] OFF
GO
SET IDENTITY_INSERT [dbo].[Logo_Master] ON 
GO
INSERT [dbo].[Logo_Master] ([Id], [Size], [eTag], [contentType], [FileName], [Key], [Description], [FileOrder], [CreatedAt], [UpdatedAt], [Logo_TranId]) VALUES (1, N'5553', N'"7f5a70be10590ac4b704edc2ddc5a9e5"', N'image/jpeg', N'10XERP-logo.jpeg', N'10XERP-logo-65733a169e36a.jpeg', N'', 0, CAST(N'2023-12-08T21:15:26.000' AS DateTime), CAST(N'2023-12-08T21:15:26.000' AS DateTime), 97)
GO
SET IDENTITY_INSERT [dbo].[Logo_Master] OFF
GO
SET IDENTITY_INSERT [dbo].[MigrationConfig] ON 
GO
INSERT [dbo].[MigrationConfig] ([Id], [Company_Id], [APIDetails], [APITokan], [Tokan_Type], [CreateAT], [UpdateAt], [Description]) VALUES (1, 1, N'https://sandbox.10xerp.com/api/item_stock_information?items%5B%5D=N90210&items%5B%5D=N70210&warehouses%5B%5D=00', N'1a2849a62a1bc2f6b07583840c20ba3187b3423d9215fa1f31a0c387baf74e48', N'X-AUTH-TOKEN', CAST(N'2024-09-14T16:23:20.337' AS DateTime), CAST(N'2024-09-14T16:23:20.337' AS DateTime), N'Item_Stock')
GO
INSERT [dbo].[MigrationConfig] ([Id], [Company_Id], [APIDetails], [APITokan], [Tokan_Type], [CreateAT], [UpdateAt], [Description]) VALUES (2, 1, N'https://sandbox.10xerp.com/api/customers?page=1&itemsPerPage=30', N'1a2849a62a1bc2f6b07583840c20ba3187b3423d9215fa1f31a0c387baf74e48', N'X-AUTH-TOKEN', CAST(N'2024-09-14T16:23:49.160' AS DateTime), CAST(N'2024-09-14T16:23:49.160' AS DateTime), N'Customer')
GO
INSERT [dbo].[MigrationConfig] ([Id], [Company_Id], [APIDetails], [APITokan], [Tokan_Type], [CreateAT], [UpdateAt], [Description]) VALUES (3, 1, N'https://sandbox.10xerp.com/api/add_on_for_orders?page=1&itemsPerPage=30', N'1a2849a62a1bc2f6b07583840c20ba3187b3423d9215fa1f31a0c387baf74e48', N'X-AUTH-TOKEN', CAST(N'2024-09-15T16:03:11.610' AS DateTime), CAST(N'2024-09-15T16:03:11.610' AS DateTime), N'Add_ON')
GO
INSERT [dbo].[MigrationConfig] ([Id], [Company_Id], [APIDetails], [APITokan], [Tokan_Type], [CreateAT], [UpdateAt], [Description]) VALUES (4, 1, N'https://sandbox.10xerp.com/api/billing_options?page=1&itemsPerPage=30', N'1a2849a62a1bc2f6b07583840c20ba3187b3423d9215fa1f31a0c387baf74e48', N'X-AUTH-TOKEN', CAST(N'2024-09-16T11:41:42.973' AS DateTime), CAST(N'2024-09-16T11:41:42.973' AS DateTime), N'Billing_Option')
GO
INSERT [dbo].[MigrationConfig] ([Id], [Company_Id], [APIDetails], [APITokan], [Tokan_Type], [CreateAT], [UpdateAt], [Description]) VALUES (5, 1, N'https://sandbox.10xerp.com/api/customer_locations?page=1&itemsPerPage=30', N'1a2849a62a1bc2f6b07583840c20ba3187b3423d9215fa1f31a0c387baf74e48', N'X-AUTH-TOKEN', CAST(N'2024-09-16T12:57:28.447' AS DateTime), CAST(N'2024-09-16T12:57:28.447' AS DateTime), N'Customer_Location')
GO
INSERT [dbo].[MigrationConfig] ([Id], [Company_Id], [APIDetails], [APITokan], [Tokan_Type], [CreateAT], [UpdateAt], [Description]) VALUES (6, 1, N'https://sandbox.10xerp.com/api/warehouses?page=1&itemsPerPage=30', N'1a2849a62a1bc2f6b07583840c20ba3187b3423d9215fa1f31a0c387baf74e48', N'X-AUTH-TOKEN', CAST(N'2024-09-16T19:30:47.733' AS DateTime), CAST(N'2024-09-16T19:30:47.733' AS DateTime), N'Warehouses')
GO
INSERT [dbo].[MigrationConfig] ([Id], [Company_Id], [APIDetails], [APITokan], [Tokan_Type], [CreateAT], [UpdateAt], [Description]) VALUES (7, 1, N'https://sandbox.10xerp.com/api/contacts?page=1&itemsPerPage=30', N'1a2849a62a1bc2f6b07583840c20ba3187b3423d9215fa1f31a0c387baf74e48', N'X-AUTH-TOKEN', CAST(N'2024-09-17T12:57:58.327' AS DateTime), CAST(N'2024-09-17T12:57:58.327' AS DateTime), N'Contact')
GO
INSERT [dbo].[MigrationConfig] ([Id], [Company_Id], [APIDetails], [APITokan], [Tokan_Type], [CreateAT], [UpdateAt], [Description]) VALUES (8, 1, N'https://sandbox.10xerp.com/api/notes?page=1&itemsPerPage=30', N'1a2849a62a1bc2f6b07583840c20ba3187b3423d9215fa1f31a0c387baf74e48', N'X-AUTH-TOKEN', CAST(N'2024-09-17T15:17:51.533' AS DateTime), CAST(N'2024-09-17T15:17:51.533' AS DateTime), N'Notes')
GO
INSERT [dbo].[MigrationConfig] ([Id], [Company_Id], [APIDetails], [APITokan], [Tokan_Type], [CreateAT], [UpdateAt], [Description]) VALUES (9, 1, N'https://sandbox.10xerp.com/api/payment_terms?page=1&itemsPerPage=30', N'1a2849a62a1bc2f6b07583840c20ba3187b3423d9215fa1f31a0c387baf74e48', N'X-AUTH-TOKEN', CAST(N'2024-09-17T18:57:06.820' AS DateTime), CAST(N'2024-09-17T18:57:06.820' AS DateTime), N'payment_terms')
GO
INSERT [dbo].[MigrationConfig] ([Id], [Company_Id], [APIDetails], [APITokan], [Tokan_Type], [CreateAT], [UpdateAt], [Description]) VALUES (10, 1, N'https://sandbox.10xerp.com/api/system_ship_vias?page=1&itemsPerPage=30', N'1a2849a62a1bc2f6b07583840c20ba3187b3423d9215fa1f31a0c387baf74e48', N'X-AUTH-TOKEN', CAST(N'2024-09-18T12:20:26.837' AS DateTime), CAST(N'2024-09-18T12:20:26.837' AS DateTime), N'System_ship_vias')
GO
INSERT [dbo].[MigrationConfig] ([Id], [Company_Id], [APIDetails], [APITokan], [Tokan_Type], [CreateAT], [UpdateAt], [Description]) VALUES (11, 1, N'https://sandbox.10xerp.com/api/order_sources?page=1&itemsPerPage=30', N'1a2849a62a1bc2f6b07583840c20ba3187b3423d9215fa1f31a0c387baf74e48', N'X-AUTH-TOKEN', CAST(N'2024-09-20T10:22:17.930' AS DateTime), CAST(N'2024-09-20T10:22:17.930' AS DateTime), N'order_sources')
GO
SET IDENTITY_INSERT [dbo].[MigrationConfig] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderSource_Master] ON 
GO
INSERT [dbo].[OrderSource_Master] ([Id], [Slug], [Code], [CreatedAt], [UpdatedAt], [OrderSource_TranId]) VALUES (1, N'phone', N'Phone', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-08-24T14:30:05.000' AS DateTime), 18)
GO
INSERT [dbo].[OrderSource_Master] ([Id], [Slug], [Code], [CreatedAt], [UpdatedAt], [OrderSource_TranId]) VALUES (2, N'email', N'Email', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-08-24T14:30:05.000' AS DateTime), 17)
GO
INSERT [dbo].[OrderSource_Master] ([Id], [Slug], [Code], [CreatedAt], [UpdatedAt], [OrderSource_TranId]) VALUES (3, N'walk-in', N'Walk In', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-08-24T14:30:05.000' AS DateTime), 19)
GO
INSERT [dbo].[OrderSource_Master] ([Id], [Slug], [Code], [CreatedAt], [UpdatedAt], [OrderSource_TranId]) VALUES (4, N'web', N'Web', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-08-24T14:30:05.000' AS DateTime), 20)
GO
INSERT [dbo].[OrderSource_Master] ([Id], [Slug], [Code], [CreatedAt], [UpdatedAt], [OrderSource_TranId]) VALUES (5, N'docparser', N'Docparser', CAST(N'2024-09-20T10:46:18.300' AS DateTime), CAST(N'2024-09-20T10:46:18.257' AS DateTime), 21)
GO
SET IDENTITY_INSERT [dbo].[OrderSource_Master] OFF
GO
SET IDENTITY_INSERT [dbo].[Payment_terms] ON 
GO
INSERT [dbo].[Payment_terms] ([Id], [Slug], [Description], [DiscountDays], [DueDays], [TotalDiscountPercent], [TermsCode], [CreatedAt], [UpdatedAt], [PaymentTerms_TranId]) VALUES (1, N'generic', N'NON-STRIPE', 0, 0, CAST(0.00 AS Numeric(18, 2)), N'GENERIC', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2024-07-11T22:18:13.000' AS DateTime), 649)
GO
INSERT [dbo].[Payment_terms] ([Id], [Slug], [Description], [DiscountDays], [DueDays], [TotalDiscountPercent], [TermsCode], [CreatedAt], [UpdatedAt], [PaymentTerms_TranId]) VALUES (2, N'wt', N'WIRE TRANSFER', 0, 0, CAST(0.00 AS Numeric(18, 2)), N'WT', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-08-24T14:30:05.000' AS DateTime), 650)
GO
INSERT [dbo].[Payment_terms] ([Id], [Slug], [Description], [DiscountDays], [DueDays], [TotalDiscountPercent], [TermsCode], [CreatedAt], [UpdatedAt], [PaymentTerms_TranId]) VALUES (3, N'idco', N'3% 10 DAYS, NET 30', 10, 30, CAST(3.00 AS Numeric(18, 2)), N'IDCO', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-08-24T14:30:05.000' AS DateTime), 651)
GO
INSERT [dbo].[Payment_terms] ([Id], [Slug], [Description], [DiscountDays], [DueDays], [TotalDiscountPercent], [TermsCode], [CreatedAt], [UpdatedAt], [PaymentTerms_TranId]) VALUES (4, N'2-30n60', N'2% 30 DAYS, NET 60', 30, 60, CAST(2.00 AS Numeric(18, 2)), N'2%30N60', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-08-24T14:30:05.000' AS DateTime), 652)
GO
INSERT [dbo].[Payment_terms] ([Id], [Slug], [Description], [DiscountDays], [DueDays], [TotalDiscountPercent], [TermsCode], [CreatedAt], [UpdatedAt], [PaymentTerms_TranId]) VALUES (5, N'amazon', N'2% 60 DAYS, NET 90', 60, 90, CAST(2.00 AS Numeric(18, 2)), N'AMAZON', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-08-24T14:30:05.000' AS DateTime), 653)
GO
INSERT [dbo].[Payment_terms] ([Id], [Slug], [Description], [DiscountDays], [DueDays], [TotalDiscountPercent], [TermsCode], [CreatedAt], [UpdatedAt], [PaymentTerms_TranId]) VALUES (6, N'1-10n00', N'1% 1 DAYS, NET 00', 0, 1, CAST(1.00 AS Numeric(18, 2)), N'1%10N00', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-08-24T14:30:05.000' AS DateTime), 654)
GO
INSERT [dbo].[Payment_terms] ([Id], [Slug], [Description], [DiscountDays], [DueDays], [TotalDiscountPercent], [TermsCode], [CreatedAt], [UpdatedAt], [PaymentTerms_TranId]) VALUES (7, N'1-15n30', N'1% 15 DAYS NET 30', 15, 30, CAST(1.00 AS Numeric(18, 2)), N'1%15N30', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-08-24T14:30:05.000' AS DateTime), 655)
GO
INSERT [dbo].[Payment_terms] ([Id], [Slug], [Description], [DiscountDays], [DueDays], [TotalDiscountPercent], [TermsCode], [CreatedAt], [UpdatedAt], [PaymentTerms_TranId]) VALUES (8, N'2-15n30', N'2% 15 DAYS NET 30', 15, 30, CAST(2.00 AS Numeric(18, 2)), N'2%15N30', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-08-24T14:30:05.000' AS DateTime), 656)
GO
INSERT [dbo].[Payment_terms] ([Id], [Slug], [Description], [DiscountDays], [DueDays], [TotalDiscountPercent], [TermsCode], [CreatedAt], [UpdatedAt], [PaymentTerms_TranId]) VALUES (9, N'2-20n45', N'2% 20 DAYS NET 45', 20, 45, CAST(2.00 AS Numeric(18, 2)), N'2%20N45', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-08-24T14:30:05.000' AS DateTime), 657)
GO
INSERT [dbo].[Payment_terms] ([Id], [Slug], [Description], [DiscountDays], [DueDays], [TotalDiscountPercent], [TermsCode], [CreatedAt], [UpdatedAt], [PaymentTerms_TranId]) VALUES (10, N'2-60n90', N'2% 60 DAYS, NET 90', 60, 90, CAST(2.00 AS Numeric(18, 2)), N'2%60N90', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-08-24T14:30:05.000' AS DateTime), 658)
GO
INSERT [dbo].[Payment_terms] ([Id], [Slug], [Description], [DiscountDays], [DueDays], [TotalDiscountPercent], [TermsCode], [CreatedAt], [UpdatedAt], [PaymentTerms_TranId]) VALUES (11, N'1-10n30', N'1% 10 DAYS, NET 30', 10, 30, CAST(1.00 AS Numeric(18, 2)), N'1%10N30', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-08-24T14:30:05.000' AS DateTime), 659)
GO
INSERT [dbo].[Payment_terms] ([Id], [Slug], [Description], [DiscountDays], [DueDays], [TotalDiscountPercent], [TermsCode], [CreatedAt], [UpdatedAt], [PaymentTerms_TranId]) VALUES (12, N'1-10n45', N'1% 10 DAYS, NET 45', 10, 45, CAST(1.00 AS Numeric(18, 2)), N'1%10N45', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-08-24T14:30:05.000' AS DateTime), 660)
GO
INSERT [dbo].[Payment_terms] ([Id], [Slug], [Description], [DiscountDays], [DueDays], [TotalDiscountPercent], [TermsCode], [CreatedAt], [UpdatedAt], [PaymentTerms_TranId]) VALUES (13, N'2-10n30', N'2% 10 DAYS NET 30', 10, 30, CAST(2.00 AS Numeric(18, 2)), N'2%10N30', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-08-24T14:30:05.000' AS DateTime), 661)
GO
INSERT [dbo].[Payment_terms] ([Id], [Slug], [Description], [DiscountDays], [DueDays], [TotalDiscountPercent], [TermsCode], [CreatedAt], [UpdatedAt], [PaymentTerms_TranId]) VALUES (14, N'2-10n60', N'2% 10 DAYS NET 60', 10, 60, CAST(2.00 AS Numeric(18, 2)), N'2%10N60', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-08-24T14:30:05.000' AS DateTime), 662)
GO
INSERT [dbo].[Payment_terms] ([Id], [Slug], [Description], [DiscountDays], [DueDays], [TotalDiscountPercent], [TermsCode], [CreatedAt], [UpdatedAt], [PaymentTerms_TranId]) VALUES (15, N'cc', N'CREDIT CARD', 0, 0, CAST(0.00 AS Numeric(18, 2)), N'CC', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-08-24T14:30:05.000' AS DateTime), 663)
GO
INSERT [dbo].[Payment_terms] ([Id], [Slug], [Description], [DiscountDays], [DueDays], [TotalDiscountPercent], [TermsCode], [CreatedAt], [UpdatedAt], [PaymentTerms_TranId]) VALUES (16, N'dur', N'DUE UPON RECEIPT', 0, 0, CAST(0.00 AS Numeric(18, 2)), N'DUR', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-08-24T14:30:05.000' AS DateTime), 664)
GO
INSERT [dbo].[Payment_terms] ([Id], [Slug], [Description], [DiscountDays], [DueDays], [TotalDiscountPercent], [TermsCode], [CreatedAt], [UpdatedAt], [PaymentTerms_TranId]) VALUES (17, N'n10', N'NET 10 DAYS', 0, 10, CAST(0.00 AS Numeric(18, 2)), N'N10', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-08-24T14:30:05.000' AS DateTime), 665)
GO
INSERT [dbo].[Payment_terms] ([Id], [Slug], [Description], [DiscountDays], [DueDays], [TotalDiscountPercent], [TermsCode], [CreatedAt], [UpdatedAt], [PaymentTerms_TranId]) VALUES (18, N'n120', N'NET 120 DAYS', 0, 120, CAST(0.00 AS Numeric(18, 2)), N'N120', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-08-24T14:30:05.000' AS DateTime), 666)
GO
INSERT [dbo].[Payment_terms] ([Id], [Slug], [Description], [DiscountDays], [DueDays], [TotalDiscountPercent], [TermsCode], [CreatedAt], [UpdatedAt], [PaymentTerms_TranId]) VALUES (19, N'n15', N'NET 15 DAYS', 0, 15, CAST(0.00 AS Numeric(18, 2)), N'N15', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-08-24T14:30:05.000' AS DateTime), 667)
GO
INSERT [dbo].[Payment_terms] ([Id], [Slug], [Description], [DiscountDays], [DueDays], [TotalDiscountPercent], [TermsCode], [CreatedAt], [UpdatedAt], [PaymentTerms_TranId]) VALUES (20, N'n30', N'NET 30 DAYS', 0, 30, CAST(0.00 AS Numeric(18, 2)), N'N30', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-08-24T14:30:05.000' AS DateTime), 668)
GO
INSERT [dbo].[Payment_terms] ([Id], [Slug], [Description], [DiscountDays], [DueDays], [TotalDiscountPercent], [TermsCode], [CreatedAt], [UpdatedAt], [PaymentTerms_TranId]) VALUES (21, N'n45', N'NET 45 DAYS', 0, 45, CAST(0.00 AS Numeric(18, 2)), N'N45', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-08-24T14:30:05.000' AS DateTime), 669)
GO
INSERT [dbo].[Payment_terms] ([Id], [Slug], [Description], [DiscountDays], [DueDays], [TotalDiscountPercent], [TermsCode], [CreatedAt], [UpdatedAt], [PaymentTerms_TranId]) VALUES (22, N'n60', N'NET 60 DAYS', 0, 60, CAST(0.00 AS Numeric(18, 2)), N'N60', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-08-24T14:30:05.000' AS DateTime), 670)
GO
INSERT [dbo].[Payment_terms] ([Id], [Slug], [Description], [DiscountDays], [DueDays], [TotalDiscountPercent], [TermsCode], [CreatedAt], [UpdatedAt], [PaymentTerms_TranId]) VALUES (23, N'n90', N'NET 90 DAYS', 0, 90, CAST(0.00 AS Numeric(18, 2)), N'N90', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-08-24T14:30:05.000' AS DateTime), 671)
GO
INSERT [dbo].[Payment_terms] ([Id], [Slug], [Description], [DiscountDays], [DueDays], [TotalDiscountPercent], [TermsCode], [CreatedAt], [UpdatedAt], [PaymentTerms_TranId]) VALUES (24, N'paypal', N'PAYPAL', 0, 0, CAST(0.00 AS Numeric(18, 2)), N'PAYPAL', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-08-24T14:30:05.000' AS DateTime), 672)
GO
SET IDENTITY_INSERT [dbo].[Payment_terms] OFF
GO
SET IDENTITY_INSERT [dbo].[Region_Master] ON 
GO
INSERT [dbo].[Region_Master] ([Id], [Slug], [CountryName], [Region], [States], [CreatedAt], [UpdatedAt], [Region_TranId]) VALUES (1, N'southwest', N'US', N'Southwest', N'AR,LA,OK,TX', CAST(N'2023-08-24T04:00:05.000' AS DateTime), CAST(N'2023-08-24T04:00:05.000' AS DateTime), 4)
GO
INSERT [dbo].[Region_Master] ([Id], [Slug], [CountryName], [Region], [States], [CreatedAt], [UpdatedAt], [Region_TranId]) VALUES (2, N'southeast', N'US', N'Southeast', N'AL,DC,DE,FL,GA,KY,MD,MS,NC,SC,TN,VA,WV', CAST(N'2023-08-24T04:00:05.000' AS DateTime), CAST(N'2023-08-24T04:00:05.000' AS DateTime), 3)
GO
INSERT [dbo].[Region_Master] ([Id], [Slug], [CountryName], [Region], [States], [CreatedAt], [UpdatedAt], [Region_TranId]) VALUES (3, N'international', N'', N'International', N'', CAST(N'2023-08-24T04:00:05.000' AS DateTime), CAST(N'2023-08-24T04:00:05.000' AS DateTime), 8)
GO
SET IDENTITY_INSERT [dbo].[Region_Master] OFF
GO
SET IDENTITY_INSERT [dbo].[SystemShipVia] ON 
GO
INSERT [dbo].[SystemShipVia] ([Id], [Slug], [ShipViaCode], [Description], [PackageType], [WebDescription], [SaturdayDeliveryOption], [CreditCardPreAuthOption], [FreeShip], [Web], [EasyPostMethod_Id], [Expedite], [FreeFreightAllowed], [International], [Collect], [Carrier_Id], [IsReturnMethod], [billingOptions], [HandlingChargeAmount], [HandlingChargePercent], [IsPickup], [IsDelivery], [EdiServiceLevelCode], [CreatedAt], [UpdatedAt], [SystemShipVia_TranId]) VALUES (1, N'usps-first', N'USPS-FIRST', N'USPS First Class', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, N'109,112', N'0.0000', N'0.0000', 0, 0, N'', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-12-21T14:39:46.000' AS DateTime), 25)
GO
INSERT [dbo].[SystemShipVia] ([Id], [Slug], [ShipViaCode], [Description], [PackageType], [WebDescription], [SaturdayDeliveryOption], [CreditCardPreAuthOption], [FreeShip], [Web], [EasyPostMethod_Id], [Expedite], [FreeFreightAllowed], [International], [Collect], [Carrier_Id], [IsReturnMethod], [billingOptions], [HandlingChargeAmount], [HandlingChargePercent], [IsPickup], [IsDelivery], [EdiServiceLevelCode], [CreatedAt], [UpdatedAt], [SystemShipVia_TranId]) VALUES (2, N'usps-prio', N'USPS-PRIO', N'USPS Priority', N'', N'', 0, 0, 0, 0, 2, 0, 0, 0, 0, 1, 0, N'109,112', N'0.0000', N'0.0000', 0, 0, N'', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-12-21T14:39:55.000' AS DateTime), 26)
GO
INSERT [dbo].[SystemShipVia] ([Id], [Slug], [ShipViaCode], [Description], [PackageType], [WebDescription], [SaturdayDeliveryOption], [CreditCardPreAuthOption], [FreeShip], [Web], [EasyPostMethod_Id], [Expedite], [FreeFreightAllowed], [International], [Collect], [Carrier_Id], [IsReturnMethod], [billingOptions], [HandlingChargeAmount], [HandlingChargePercent], [IsPickup], [IsDelivery], [EdiServiceLevelCode], [CreatedAt], [UpdatedAt], [SystemShipVia_TranId]) VALUES (3, N'ups-1', N'UPS-1', N'UPS Overnight', N'', N'', 1, 1, 0, 0, 3, 0, 0, 0, 0, 2, 1, N'', N'0.0000', N'0.0000', 0, 0, N'', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2024-06-25T00:38:18.000' AS DateTime), 27)
GO
INSERT [dbo].[SystemShipVia] ([Id], [Slug], [ShipViaCode], [Description], [PackageType], [WebDescription], [SaturdayDeliveryOption], [CreditCardPreAuthOption], [FreeShip], [Web], [EasyPostMethod_Id], [Expedite], [FreeFreightAllowed], [International], [Collect], [Carrier_Id], [IsReturnMethod], [billingOptions], [HandlingChargeAmount], [HandlingChargePercent], [IsPickup], [IsDelivery], [EdiServiceLevelCode], [CreatedAt], [UpdatedAt], [SystemShipVia_TranId]) VALUES (4, N'ups-ground', N'UPS-Ground', N'UPS Ground', N'', N'', 0, 1, 0, 0, 4, 0, 0, 0, 0, 2, 1, N'109,110,112', N'0.0000', N'0.0000', 0, 0, N'', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-12-21T14:41:07.000' AS DateTime), 28)
GO
INSERT [dbo].[SystemShipVia] ([Id], [Slug], [ShipViaCode], [Description], [PackageType], [WebDescription], [SaturdayDeliveryOption], [CreditCardPreAuthOption], [FreeShip], [Web], [EasyPostMethod_Id], [Expedite], [FreeFreightAllowed], [International], [Collect], [Carrier_Id], [IsReturnMethod], [billingOptions], [HandlingChargeAmount], [HandlingChargePercent], [IsPickup], [IsDelivery], [EdiServiceLevelCode], [CreatedAt], [UpdatedAt], [SystemShipVia_TranId]) VALUES (5, N'fedex-ground', N'FED-Ground', N'FedEx Ground', N'', N'', 0, 0, 0, 0, 5, 0, 0, 0, 0, 3, 0, N'110', N'0.0000', N'0.0000', 0, 0, N'', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2024-03-11T23:38:03.000' AS DateTime), 29)
GO
INSERT [dbo].[SystemShipVia] ([Id], [Slug], [ShipViaCode], [Description], [PackageType], [WebDescription], [SaturdayDeliveryOption], [CreditCardPreAuthOption], [FreeShip], [Web], [EasyPostMethod_Id], [Expedite], [FreeFreightAllowed], [International], [Collect], [Carrier_Id], [IsReturnMethod], [billingOptions], [HandlingChargeAmount], [HandlingChargePercent], [IsPickup], [IsDelivery], [EdiServiceLevelCode], [CreatedAt], [UpdatedAt], [SystemShipVia_TranId]) VALUES (6, N'fedex-ground-1', N'FED-1', N'FedEx Overnight', N'', N'', 0, 0, 0, 0, 6, 0, 0, 0, 0, 3, 0, N'109,110', N'0.0000', N'0.0000', 0, 0, N'', CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-12-21T14:41:46.000' AS DateTime), 30)
GO
INSERT [dbo].[SystemShipVia] ([Id], [Slug], [ShipViaCode], [Description], [PackageType], [WebDescription], [SaturdayDeliveryOption], [CreditCardPreAuthOption], [FreeShip], [Web], [EasyPostMethod_Id], [Expedite], [FreeFreightAllowed], [International], [Collect], [Carrier_Id], [IsReturnMethod], [billingOptions], [HandlingChargeAmount], [HandlingChargePercent], [IsPickup], [IsDelivery], [EdiServiceLevelCode], [CreatedAt], [UpdatedAt], [SystemShipVia_TranId]) VALUES (7, N'ot', N'OT', N'Our Delivery', N'', N'', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, N'', N'0.0000', N'0.0000', 0, 1, N'', CAST(N'2024-04-05T20:49:22.000' AS DateTime), CAST(N'2024-06-25T00:44:16.000' AS DateTime), 31)
GO
INSERT [dbo].[SystemShipVia] ([Id], [Slug], [ShipViaCode], [Description], [PackageType], [WebDescription], [SaturdayDeliveryOption], [CreditCardPreAuthOption], [FreeShip], [Web], [EasyPostMethod_Id], [Expedite], [FreeFreightAllowed], [International], [Collect], [Carrier_Id], [IsReturnMethod], [billingOptions], [HandlingChargeAmount], [HandlingChargePercent], [IsPickup], [IsDelivery], [EdiServiceLevelCode], [CreatedAt], [UpdatedAt], [SystemShipVia_TranId]) VALUES (8, N'wc', N'WC', N'Will Call/Pickup', N'', N'', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N'', N'0.0000', N'0.0000', 1, 0, N'', CAST(N'2024-05-23T19:14:08.000' AS DateTime), CAST(N'2024-06-27T00:24:27.000' AS DateTime), 32)
GO
SET IDENTITY_INSERT [dbo].[SystemShipVia] OFF
GO
SET IDENTITY_INSERT [dbo].[Unit_Master] ON 
GO
INSERT [dbo].[Unit_Master] ([Unit_Id], [Unit_Name], [Unit_Symbol], [UnitTranId]) VALUES (1, N'ea', N'ea', 141)
GO
SET IDENTITY_INSERT [dbo].[Unit_Master] OFF
GO
SET IDENTITY_INSERT [dbo].[Warehouse_Master] ON 
GO
INSERT [dbo].[Warehouse_Master] ([Warehouse_Id], [Warehouse_Trans_Id], [Warehouse_Name], [Warehouse_Code], [Attention], [IsExternal], [IsWeb], [Slug], [Email], [Transfer_Ship_Via_Account], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [IsResidential], [CreatedAt], [UpdatedAt], [UpdatedBy], [WarehouseTranId]) VALUES (1, NULL, N'Houston', N'00', N'John Doe', NULL, 0, N'00', N'', N'', N'14450 John F Kennedy Blvd', N'', N'', N'Houston', N'TX', N'US', N'77032', N'1234567890', 0, CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2023-09-13T23:29:29.000' AS DateTime), NULL, 66)
GO
INSERT [dbo].[Warehouse_Master] ([Warehouse_Id], [Warehouse_Trans_Id], [Warehouse_Name], [Warehouse_Code], [Attention], [IsExternal], [IsWeb], [Slug], [Email], [Transfer_Ship_Via_Account], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [IsResidential], [CreatedAt], [UpdatedAt], [UpdatedBy], [WarehouseTranId]) VALUES (2, NULL, N'External Vendor 100', N'EV100', N'Jane Doe', NULL, 0, N'ev100', N'', N'', N'14450 John F Kennedy Blvd', N'', N'', N'Houston', N'TX', N'US', N'77032', N'1234567890', 0, CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2024-05-03T22:16:44.000' AS DateTime), NULL, 67)
GO
INSERT [dbo].[Warehouse_Master] ([Warehouse_Id], [Warehouse_Trans_Id], [Warehouse_Name], [Warehouse_Code], [Attention], [IsExternal], [IsWeb], [Slug], [Email], [Transfer_Ship_Via_Account], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [IsResidential], [CreatedAt], [UpdatedAt], [UpdatedBy], [WarehouseTranId]) VALUES (3, NULL, N'External Vendor 200', N'EV200', N'Jane Doe', NULL, 0, N'ev200', N'', N'', N'14450 John F Kennedy Blvd', N'', N'', N'Houston', N'TX', N'US', N'77032', N'1234567890', 0, CAST(N'2023-08-24T14:30:05.000' AS DateTime), CAST(N'2024-05-03T22:16:49.000' AS DateTime), NULL, 68)
GO
INSERT [dbo].[Warehouse_Master] ([Warehouse_Id], [Warehouse_Trans_Id], [Warehouse_Name], [Warehouse_Code], [Attention], [IsExternal], [IsWeb], [Slug], [Email], [Transfer_Ship_Via_Account], [Address1], [Address2], [Address3], [City], [State], [Country], [Postal], [Phone], [IsResidential], [CreatedAt], [UpdatedAt], [UpdatedBy], [WarehouseTranId]) VALUES (4, NULL, N'LA', N'01', N'', NULL, 0, N'01', N'', N'', N'1040 Watson Center Road', N'', N'', N'Carson', N'CA', N'US', N'90220', N'+13109422210', 0, CAST(N'2023-08-29T21:46:30.000' AS DateTime), CAST(N'2023-08-29T21:46:30.000' AS DateTime), NULL, 69)
GO
SET IDENTITY_INSERT [dbo].[Warehouse_Master] OFF
GO
ALTER TABLE [dbo].[AspNetRoles] ADD  DEFAULT (char((10))) FOR [Role_Name]
GO
ALTER TABLE [dbo].[AspNetRoles] ADD  DEFAULT (getdate()) FOR [CreateAt]
GO
ALTER TABLE [dbo].[AspNetRoles] ADD  DEFAULT (getdate()) FOR [UpdateAt]
GO
ALTER TABLE [dbo].[AspNetUserRoles] ADD  DEFAULT ((0)) FOR [AspNetUser_Id]
GO
ALTER TABLE [dbo].[AspNetUserRoles] ADD  DEFAULT ((0)) FOR [AspNetRole_Id]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (char((10))) FOR [EmailId]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (char((10))) FOR [PasswordHas]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT ((0)) FOR [Customer_Id]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT ((0)) FOR [Company_Id]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (getdate()) FOR [CreateAt]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (getdate()) FOR [UpdateAt]
GO
ALTER TABLE [dbo].[Carrier] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Carrier] ADD  DEFAULT (getdate()) FOR [UpdatedAt]
GO
ALTER TABLE [dbo].[Company] ADD  DEFAULT (char((10))) FOR [Company_Name]
GO
ALTER TABLE [dbo].[Company] ADD  DEFAULT (char((10))) FOR [Company_Code]
GO
ALTER TABLE [dbo].[Company] ADD  DEFAULT (char((10))) FOR [Logo]
GO
ALTER TABLE [dbo].[Company] ADD  DEFAULT (getdate()) FOR [CreateAt]
GO
ALTER TABLE [dbo].[Company] ADD  DEFAULT (getdate()) FOR [UpdateAt]
GO
ALTER TABLE [dbo].[Customer_Location_Information] ADD  DEFAULT ((0)) FOR [Region_Id]
GO
ALTER TABLE [dbo].[Customer_Master] ADD  DEFAULT ((0)) FOR [CustomerTranId]
GO
ALTER TABLE [dbo].[Customer_Master] ADD  DEFAULT ((0)) FOR [AveragePayDays]
GO
ALTER TABLE [dbo].[Customer_Master] ADD  DEFAULT ((0)) FOR [BoFlag]
GO
ALTER TABLE [dbo].[Customer_Master] ADD  DEFAULT ((0)) FOR [AlwaysShipCompleteFlag]
GO
ALTER TABLE [dbo].[Customer_Master] ADD  DEFAULT ((0)) FOR [PoRequiredFlag]
GO
ALTER TABLE [dbo].[Customer_Master] ADD  DEFAULT ((0)) FOR [CcfFlag]
GO
ALTER TABLE [dbo].[Customer_Master] ADD  DEFAULT (char((10))) FOR [CrLimit]
GO
ALTER TABLE [dbo].[Customer_Master] ADD  DEFAULT ((0)) FOR [PaymentTerm_Id]
GO
ALTER TABLE [dbo].[Customer_Master] ADD  DEFAULT ((0)) FOR [Logo_Master_Id]
GO
ALTER TABLE [dbo].[Customer_Master] ADD  DEFAULT ((0)) FOR [OrderSource_Master_Id]
GO
ALTER TABLE [dbo].[Customer_Master] ADD  DEFAULT ((0)) FOR [CustomerGroup_Id]
GO
ALTER TABLE [dbo].[Item_Master] ADD  DEFAULT ((0)) FOR [ItemTranId]
GO
ALTER TABLE [dbo].[MigrationConfig] ADD  DEFAULT (getdate()) FOR [CreateAT]
GO
ALTER TABLE [dbo].[MigrationConfig] ADD  DEFAULT (getdate()) FOR [UpdateAt]
GO
ALTER TABLE [dbo].[Payment_terms] ADD  DEFAULT ((0)) FOR [DiscountDays]
GO
ALTER TABLE [dbo].[Payment_terms] ADD  DEFAULT ((0)) FOR [DueDays]
GO
ALTER TABLE [dbo].[Payment_terms] ADD  DEFAULT ((0.0)) FOR [TotalDiscountPercent]
GO
ALTER TABLE [dbo].[Payment_terms] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Payment_terms] ADD  DEFAULT (getdate()) FOR [UpdatedAt]
GO
ALTER TABLE [dbo].[Region_Master] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Region_Master] ADD  DEFAULT (getdate()) FOR [UpdatedAt]
GO
ALTER TABLE [dbo].[SystemShipVia] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Unit_Master] ADD  DEFAULT ((0)) FOR [UnitTranId]
GO
ALTER TABLE [dbo].[Warehouse_Master] ADD  DEFAULT ((0)) FOR [WarehouseTranId]
GO
/****** Object:  StoredProcedure [dbo].[INSERT_ADDON]    Script Date: 20/09/2024 7:01:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERT_ADDON]  
(  
@Id INT,  
@Amount NUMERIC(18,0),  
@OrderInvoice NVARCHAR(MAX),  
@TaxFlag BIT,  
@TaxOverride BIT,  
@TaxCode VARCHAR(100),  
@TaxRate NUMERIC(18,2),  
@TaxAmount NUMERIC(18,2),  
@PurchaseOrderBill VARCHAR(100)  
)  
AS  
BEGIN  
  
 DECLARE @returnValue INT  
  
 IF EXISTS(SELECT * FROM AddOn WHERE AddOnTranId = @Id)  
 BEGIN  
  UPDATE AddOn  
  SET Amount = @Amount,  
   OrderInvoice = @OrderInvoice,  
   TaxFlag = @TaxFlag,  
   TaxOverride = @TaxOverride,  
   TaxCode = @TaxCode,  
   TaxRate = @TaxRate,  
   TaxAmount = @TaxAmount,  
   PurchaseOrderBill = @PurchaseOrderBill  
  WHERE AddOnTranId = @Id   
  
 END  
  
 IF NOT EXISTS (SELECT * FROM AddOn WHERE AddOnTranId = @Id)  
 BEGIN  
  INSERT INTO AddOn (Amount,OrderInvoice,TaxFlag,TaxOverride,TaxCode,  
       TaxRate,TaxAmount,PurchaseOrderBill,AddOnTranId)  
     VALUES ( @Amount,@OrderInvoice,@TaxFlag,@TaxOverride,@TaxCode,  
       @TaxRate,@TaxAmount,@PurchaseOrderBill,@Id)  
 END  
END
GO
/****** Object:  StoredProcedure [dbo].[INSERT_AddOnDetail]    Script Date: 20/09/2024 7:01:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERT_AddOnDetail]  
(  
@Id INT,  
@Addon_Id INT,  
@TotCd VARCHAR(100),  
@Name VARCHAR(100),  
@Description VARCHAR(100)  
)  
AS  
BEGIN  
 
 DECLARE @AddMstId INT
 SELECT @AddMstId = Id FROM AddOn WHERE AddOnTranId = @Addon_Id

	 IF EXISTS(SELECT * FROM AddOnDetail WHERE AddOnDetail_tranId = @Id AND Addon_Id = @AddMstId)  
	 BEGIN  
	  UPDATE AddOnDetail  
	  SET TotCd = @TotCd,  
	   Name=@Name,  
	   Description = @Description  
	  WHERE AddOnDetail_tranId = @Id AND Addon_Id = @Addon_Id  
	 END  
  
	 IF NOT EXISTS(SELECT * FROM AddOnDetail WHERE AddOnDetail_tranId = @Id AND Addon_Id = @AddMstId)  
	 BEGIN  
	  INSERT INTO AddOnDetail (Addon_Id,TotCd,Name,Description,AddOnDetail_tranId)  
		VALUES(@Addon_Id,@TotCd,@Name,@Description,@Id)  
	 END  
END  
GO
/****** Object:  Table [dbo].[DbLog]    Script Date: 16/09/2024 4:00:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DbLog](
	[Con_Log_Id] [int] IDENTITY(1,1) NOT NULL,
	[Log_Date] [datetime] NULL,
	[Details] [varchar](max) NULL,
	[Response_Details] [nvarchar](max) NULL,
	[Response_DateTime] [datetime] NULL,
 CONSTRAINT [PK_DbLog] PRIMARY KEY CLUSTERED 
(
	[Con_Log_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


/****** Object:  StoredProcedure [dbo].[INSERT_CUSTOMERMASTER]    Script Date: 20/09/2024 7:01:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERT_CUSTOMERMASTER](
	@id			INT			,
	@name		VARCHAR(100),
	@slug		VARCHAR(50)	,
	@email		VARCHAR(50)	,
	@phone		VARCHAR(40),
	@createdAt	DATETIME	,
	@updatedAt	DATETIME	
)
AS
BEGIN

IF EXISTS (SELECT * FROM Customer_Master WHERE CustomerTranId = @id)
BEGIN
	UPDATE Customer_Master 
	SET First_Name	=	@name		,
		Slug		=	@slug		,
		Email		=	@email		,
		Phone		=	@phone		,
		CreatedAt	=	@createdAt	,
		UpdatedAt	=	@updatedAt
	WHERE CustomerTranId = @id
END

IF NOT EXISTS(SELECT * FROM Customer_Master WHERE CustomerTranId = @id)
BEGIN
	INSERT INTO Customer_Master (First_Name,Slug,Email,Phone,CreatedAt,UpdatedAt,CustomerTranId) 
	VALUES (@name,@slug,@email,@phone,@createdAt,@updatedAt,@id) 
END

END
GO
/****** Object:  StoredProcedure [dbo].[INSERT_DBLOG]    Script Date: 20/09/2024 7:01:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERT_DBLOG](
@logDate DATETIME,
@Details VARCHAR(MAX),
@Response_Details NVARCHAR(MAX),
@Response_DateTime DATETIME
)
AS
BEGIN
	
	INSERT INTO DbLog (Log_Date,Details,Response_Details,Response_DateTime) 
	VALUES (@logDate,@Details,@Response_Details,@Response_DateTime)

END
GO
/****** Object:  StoredProcedure [dbo].[INSERT_ITEM_MASTER]    Script Date: 20/09/2024 7:01:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERT_ITEM_MASTER]  
(  
@item_id INT,  
@warehouse_id INT,  
@purchase_orders VARCHAR(MAX),  
@quantity_on_purchase_order INT,  
@quantity_on_hand INT,  
@quantity_committed INT,  
@quantity_available INT,  
@item_name VARCHAR(100),  
@warehouse_code VARCHAR(10),  
@unit_id INT,  
@unit_symbol varchar(50),  
@display_unit_id INT,  
@display_unit_symbol VARCHAR(50)  
)  
AS  
BEGIN  
  
DECLARE @NewUnitId AS INT,  
@Newwarehouse_id AS INT  
  
 ---Unit Master Check   
 IF EXISTS (SELECT * FROM Unit_Master WHERe UnitTranId= @unit_Id)  
 BEGIN  
  SELECT @NewUnitId=Unit_Id FROM Unit_Master WHERE UnitTranId = @unit_Id  
 END  
  
 IF NOT EXISTS(SELECT * FROM Unit_Master WHERE UnitTranId = @unit_Id)  
 BEGIN  
  INSERT INTO Unit_Master (Unit_Name,Unit_Symbol,UnitTranId) VALUES(@unit_symbol,@display_unit_symbol,@unit_id)  
  SELECT @NewUnitId = SCOPE_IDENTITY()  
 END  
  
 ---Warehouse Master Check  
 IF EXISTS (SELECT * FROM Warehouse_Master WHERe WarehouseTranId= @warehouse_id)  
 BEGIN  
  SELECT @Newwarehouse_id=Warehouse_Id FROM Warehouse_Master WHERE WarehouseTranId = @warehouse_id  
 END  
  
 IF NOT EXISTS(SELECT * FROM Warehouse_Master WHERE WarehouseTranId = @warehouse_id)  
 BEGIN  
  INSERT INTO Warehouse_Master (Warehouse_Code,WarehouseTranId) VALUES(@warehouse_code,@warehouse_id)  
  SELECT @Newwarehouse_id = SCOPE_IDENTITY()  
 END  
  
 ---Check Item Master  
 IF EXISTS(SELECT * FROM ITEM_MASTER WHERE ItemTranId = @item_id)  
 BEGIN  
  UPDATE ITEM_MASTER SET   
   Item_Name = @item_name,  
   Unit_Id = @NewUnitId,  
   Display_Unit_Id = @NewUnitId  
   WHERE ItemTranId = @item_id  
 END  
  
 IF NOT EXISTS (SELECT * FROM ITEM_MASTER WHERE ItemTranId = @item_id)  
 BEGIN  
  INSERT INTO ITEM_MASTER (Item_Name,Unit_Id,Display_Unit_Id,ItemTranId) VALUES (@item_name,@NewUnitId,@NewUnitId,@item_id)   
  SELECT @Item_Id = SCOPE_IDENTITY()
 END  

 ---CHECK Stock Master Tabel
 IF EXISTS(SELECT * FROM Item_Stock_Details WHERE Item_Id = @item_id AND Warehouse_Id = @Newwarehouse_id)
 BEGIN
	UPDATE Item_Stock_Details
	SET Quantity_On_Purchase_Order = @quantity_on_purchase_order,
		Quantity_On_Hand = @quantity_on_hand,
		Quantity_Committed = @quantity_committed,
		Quantity_Available = @quantity_available,
		Unit_Id = @NewUnitId,
		Display_Unit_Id = @display_unit_id
	WHERE Item_Id = @item_id AND Warehouse_Id = @Newwarehouse_id
 END
 IF NOT EXISTS(SELECT * FROM Item_Stock_Details WHERE Item_Id = @item_id AND Warehouse_Id = @Newwarehouse_id)
 BEGIN
	INSERT INTO Item_Stock_Details (Item_Id,Warehouse_Id,Quantity_On_Purchase_Order,Quantity_On_Hand,Quantity_Committed,Quantity_Available,Unit_Id,Display_Unit_Id) 
		VALUES(@item_id,@Newwarehouse_id,@quantity_on_purchase_order,@quantity_on_hand,@quantity_committed,@quantity_available,@NewUnitId,@display_unit_id)
 END
  
END
GO
INSERT INTO MigrationConfig VALUES(1,'https://sandbox.10xerp.com/api/item_stock_information?items%5B%5D=N90210&items%5B%5D=N70210&warehouses%5B%5D=00','1a2849a62a1bc2f6b07583840c20ba3187b3423d9215fa1f31a0c387baf74e48','X-AUTH-TOKEN',GETDATE(),GETDATE(),'Item_Stock')
GO
INSERT INTO MigrationConfig VALUES(1,'https://sandbox.10xerp.com/api/customers?page=1&itemsPerPage=30','1a2849a62a1bc2f6b07583840c20ba3187b3423d9215fa1f31a0c387baf74e48','X-AUTH-TOKEN',GETDATE(),GETDATE(),'Customer')
GO
INSERT INTO MigrationConfig VALUES(1,'https://sandbox.10xerp.com/api/add_on_for_orders?page=1&itemsPerPage=30','1a2849a62a1bc2f6b07583840c20ba3187b3423d9215fa1f31a0c387baf74e48','X-AUTH-TOKEN',GETDATE(),GETDATE(),'Add_ON')
GO
INSERT INTO MigrationConfig VALUES(1,'https://sandbox.10xerp.com/api/billing_options?page=1&itemsPerPage=30','1a2849a62a1bc2f6b07583840c20ba3187b3423d9215fa1f31a0c387baf74e48','X-AUTH-TOKEN',GETDATE(),GETDATE(),'Billing_Option')
GO
INSERT INTO MigrationConfig VALUES(1,'https://sandbox.10xerp.com/api/customer_locations?page=1&itemsPerPage=30','1a2849a62a1bc2f6b07583840c20ba3187b3423d9215fa1f31a0c387baf74e48','X-AUTH-TOKEN',GETDATE(),GETDATE(),'Customer_Location')
GO
INSERT INTO MigrationConfig VALUES(1,'https://sandbox.10xerp.com/api/warehouses?page=1&itemsPerPage=30','1a2849a62a1bc2f6b07583840c20ba3187b3423d9215fa1f31a0c387baf74e48','X-AUTH-TOKEN',GETDATE(),GETDATE(),'Warehouses')
GO
INSERT INTO MigrationConfig VALUES(1,'https://sandbox.10xerp.com/api/contacts?page=1&itemsPerPage=30','1a2849a62a1bc2f6b07583840c20ba3187b3423d9215fa1f31a0c387baf74e48','X-AUTH-TOKEN',GETDATE(),GETDATE(),'Contact')
GO
INSERT INTO MigrationConfig VALUES(1,'https://sandbox.10xerp.com/api/notes?page=1&itemsPerPage=30','1a2849a62a1bc2f6b07583840c20ba3187b3423d9215fa1f31a0c387baf74e48','X-AUTH-TOKEN',GETDATE(),GETDATE(),'Notes')
GO
INSERT INTO MigrationConfig VALUES(1,'https://sandbox.10xerp.com/api/payment_terms?page=1&itemsPerPage=30','1a2849a62a1bc2f6b07583840c20ba3187b3423d9215fa1f31a0c387baf74e48','X-AUTH-TOKEN',GETDATE(),GETDATE(),'payment_terms')
GO
INSERT INTO MigrationConfig VALUES(1,'https://sandbox.10xerp.com/api/system_ship_vias?page=1&itemsPerPage=30','1a2849a62a1bc2f6b07583840c20ba3187b3423d9215fa1f31a0c387baf74e48','X-AUTH-TOKEN',GETDATE(),GETDATE(),'System_ship_vias')
GO
INSERT INTO MigrationConfig VALUES(1,'https://sandbox.10xerp.com/api/order_sources?page=1&itemsPerPage=30','1a2849a62a1bc2f6b07583840c20ba3187b3423d9215fa1f31a0c387baf74e48','X-AUTH-TOKEN',GETDATE(),GETDATE(),'order_sources')
GO