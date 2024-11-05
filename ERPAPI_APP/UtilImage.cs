using ERPAPI_APP.DataBaseAccess;
using ERPAPI_APP.Models;
using Newtonsoft.Json;
using System.Drawing;
using System.Dynamic;

internal static class UtilImage
{
    internal static string APIUrl = "https://sandbox.10xerp.com/api/";
    internal static string TokanType = "X-AUTH-TOKEN";
    internal static string Apitokan = "1a2849a62a1bc2f6b07583840c20ba3187b3423d9215fa1f31a0c387baf74e48";
    internal static async Task putContact(SingUp newUser)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                DbLog log = new DbLog
                {
                    LogDate = DateTime.Now,
                    RequestApi = APIUrl,
                    RequestDate = DateTime.Now,
                };
                client.DefaultRequestHeaders.Add(TokanType, Apitokan);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, APIUrl + "files/contacts");
                var objCont = new
                {
                    slug = newUser.emailId,
                    dateAdded = DateTime.Now,
                    firstName = newUser.FirstName,
                    lastName = newUser.LastName,
                    phoneExtension = "+1",
                    titled = newUser.FirstName + " " + newUser.LastName,
                    contact = newUser.FirstName,
                    phone = newUser.Phone,
                    vendor = string.Empty,
                    customer = string.Empty,
                    email = newUser.emailId,
                    files = (string[])null,
                    notes = (string[])null,
                    customAttributes = (string[])null,
                    hubspotObjects = (string[])null,
                    deletedAt = (string[])null,
                    createdAt = DateTime.Now,
                    updatedAt = DateTime.Now,
                    hubspotObject = (string[])null,
                    crmLead = string.Empty
                };
                var content = new StringContent(objCont.ToString(), null, "application/json");
                request.Content = content;
                request.Headers.Add("accept", "application/json");
                HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                log.ResponseValue = responseBody;
                log.ResponseDate = DateTime.Now;

                await DALogDetails.InsertLog(log);

                dynamic dictionary = JsonConvert.DeserializeObject<ExpandoObject>(responseBody);

                //Create Return object put logic. When test then chek what object is come from the api.
            }
        }
        catch (Exception ex)
        {
            await DALogDetails.InsertLog(new DbLog { ErrorMsg = ex.Message, ErrorDateTime = DateTime.Now });
        }
    }


    internal static async Task putOrder(string paymenttranId, string orderId)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                DbLog log = new DbLog
                {
                    LogDate = DateTime.Now,
                    RequestApi = APIUrl,
                    RequestDate = DateTime.Now,
                };
                client.DefaultRequestHeaders.Add(TokanType, Apitokan);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, APIUrl + "orders");
                var currentorder = DaOrder.GetOrderDetail(orderId);
                
                var objCont = new
                {
                    Context = "string",
                    Id = "string",
                    Type = "string",
                    OrderId = 0,
                    OrderType = "order",
                    BlindShip = true,
                    BoFlag = true,
                    TotalGross = "string",
                    TotalQuantity = 0,
                    CustomerPurchaseOrder = "string",
                    EnteredBy = "string",
                    Expedite = true,
                    TotalLines = 0,
                    TotalOpenLines = 0,
                    GrossProfitPercentage = 0m, // decimal type for percentage
                    TotalLandedCost = "string",
                    LandedCostGrossProfitPercentage = 0m, // decimal type for percentage
                    Name = "string",
                    OrderTotalCost = "string",
                    OrderTotalPieces = 0,
                    TotalWeight = 0d, // double type for weight
                    Open = true,
                    OpenTotalGross = "string",
                    OrderDate = DateTime.Parse("2024-11-04T11:03:53.291Z"),
                    Reference = "string",
                    OrderNumber = 0,
                    ShipAttention = "string",
                    ShipCmpl = true,
                    ShipCmplt2ndPs = true,
                    ShipViaAccount = "string",
                    WantedDate = DateTime.Parse("2024-11-04T11:03:53.291Z"),
                    Customer = "string",
                    Status = "string",
                    OrderSource = "string",
                    PaymentTerm = "string",
                    CustomerLocation = "string",
                    OrderTotalTax = "string",
                    ConvertedFromQuote = "string",
                    ConvertedBy = "string",
                    ConvertedAt = DateTime.Parse("2024-11-04T11:03:53.291Z"),
                    StripePayments = new List<string>(),
                    AddOnForOrders = new List<string>(),
                    OrderedBy = "string",
                    IsCreditHold = true,
                    IsStatusHold = true,
                    CreditHoldReleasedBy = "string",
                    CreditHoldReleasedAt = DateTime.Parse("2024-11-04T11:03:53.291Z"),
                    IsReturnFor = "string",
                    Warehouse = "string",
                    WorkOrders = new List<string>(),
                    Files = new List<string>(),
                    SendToQualityCheck = true,
                    SystemShipVia = "string",
                    TaxFlag = true,
                    CommittedPrice = "string",
                    CommittedCost = "string",
                    EligibleForPrint = true,
                    EligibleForPrintReason = "string",
                    Email = "string",
                    Phone = "string",
                    IsCreditHoldCreditLimit = true,
                    IsCreditHoldDueDate = true,
                    ITotCodesAmount = "string",
                    CreatedBy = "string",
                    UpdatedBy = "string",
                    LegacyIsPlaceholderForCreditMemo = true,
                    SalesRepresentative = "string",
                    ScheduledRelease = true,
                    DropShipPurchaseOrders = new List<string>(),
                    TotalWithTax = 0m, // decimal type for amounts
                    TotalWithTaxAndAddOns = 0m, // decimal type for amounts
                    TaxCalculationFlag = true,
                    EdiStatus = "new",
                    HasOverriddenTaxEntries = true,
                    IsDraft = true,
                    Address1 = "string",
                    Address2 = "string",
                    Address3 = "string",
                    City = "string",
                    Country = "st",
                    Postal = "string",
                    State = "string",
                    IsResidential = true,
                    BillingOption = "string",
                    SaturdayDeliveryAvailable = true,
                    CreatedAt = DateTime.Parse("2024-11-04T11:03:53.291Z"),
                    UpdatedAt = DateTime.Parse("2024-11-04T11:03:53.291Z"),
                    DeletedAt = DateTime.Parse("2024-11-04T11:03:53.291Z")
                };
                var content = new StringContent(objCont.ToString(), null, "application/json");
                request.Content = content;
                request.Headers.Add("accept", "application/json");
                HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                log.ResponseValue = responseBody;
                log.ResponseDate = DateTime.Now;

                await DALogDetails.InsertLog(log);

                dynamic dictionary = JsonConvert.DeserializeObject<ExpandoObject>(responseBody);

                //Create Return object put logic. When test then chek what object is come from the api.
            }
        }
        catch (Exception ex)
        {
            await DALogDetails.InsertLog(new DbLog { ErrorMsg = ex.Message, ErrorDateTime = DateTime.Now });
        }
    }
    internal static async Task GetImageLinkFromItem(int itemId, string ItemCode)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                DbLog log = new DbLog
                {
                    LogDate = DateTime.Now,
                    RequestApi = APIUrl,
                    RequestDate = DateTime.Now,
                };
                client.DefaultRequestHeaders.Add(TokanType, Apitokan);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, APIUrl + "files/generate-link");
                var content = new StringContent("{\"fileId\":" + itemId + "}", null, "application/json");
                request.Content = content;
                request.Headers.Add("accept", "application/json");
                HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                log.ResponseValue = responseBody;
                log.ResponseDate = DateTime.Now;

                await DALogDetails.InsertLog(log);

                dynamic dictionary = JsonConvert.DeserializeObject<ExpandoObject>(responseBody);

                await DownloadImageFromLink(dictionary.downloadLink, itemId, ItemCode);
            }
        }
        catch (Exception ex)
        {
            await DALogDetails.InsertLog(new DbLog { ErrorMsg = ex.Message, ErrorDateTime = DateTime.Now });
        }
    }

    internal static async Task DownloadImageFromLink(string APIURL, int itemId, string ItemCode)
    {
        try
        {
            var TokanType = "X-AUTH-TOKEN";
            var Apitokan = "1a2849a62a1bc2f6b07583840c20ba3187b3423d9215fa1f31a0c387baf74e48";

            using (HttpClient client = new HttpClient())
            {
                DbLog log = new DbLog
                {
                    LogDate = DateTime.Now,
                    RequestApi = APIURL,
                    RequestDate = DateTime.Now,
                };
                client.DefaultRequestHeaders.Add(TokanType, Apitokan);
                var request = new HttpRequestMessage(HttpMethod.Get, APIURL);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                {
                    // Create an image from the stream
                    using (System.Drawing.Image image = Image.FromStream(responseStream))
                    {
                        // Save the image to a file
                        image.Save("./Images/" + ItemCode + ".jpg");
                    }
                }
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                log.ResponseValue = await response.Content.ReadAsStringAsync();
                log.ResponseDate = DateTime.Now;

                await DALogDetails.InsertLog(log);

            }

        }
        catch (Exception ex)
        {
            await DALogDetails.InsertLog(new DbLog { ErrorMsg = ex.Message, ErrorDateTime = DateTime.Now });
        }



     
    }
    internal static async Task putShipLocation(string customertranId)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                DbLog log = new DbLog
                {
                    LogDate = DateTime.Now,
                    RequestApi = APIUrl,
                    RequestDate = DateTime.Now,
                };
                client.DefaultRequestHeaders.Add(TokanType, Apitokan);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, APIUrl + "customers");
                var currentorder = DAPaymentTerms.GetPaymentTerms();

                var objCont = new
                {
                    @context = "string",
                    @id = "string",
                    @type = "string",
                    email = "user@example.com",
                    orderId = 0 ,
                    slug = "string",
                    averagePayDays = 0,
                    boFlag = true,
                    alwaysShipCompleteFlag = true,
                    poRequiredFlag = true,
                    ccfFlag = true,
                    crAttendee = "string",
                    crLimit = "string",
                    creditPhone = "string",
                    phone = "string",
                    invoiceEmail = "string",
                    customer = "string",
                    name = "string",
                    sicCode = "string",
                    taxId = "string",
                    taxExempt = "string",
                    primaryAttention = "string",
                    crAttention = "string",
                    salesRepresentative = "string",
                    customAttributes = new string[] { "string" },
                    paymentTerm = "string",
                    taxFlag = true,
                    fontColor = "string",
                    borderColor = "string",
                    shadingColor = "string",
                    logo = "string",
                    parentCustomer = "string",
                    graceDays = 0,
                    customerGroup = "string",
                    qualityCheckTarget = 100,
                    hasConsolidatedInvoices = true,
                    primaryCustomerLocation = "string",
                    primaryShippingLocation = "string",
                    isAssessFinanceCharges = true,
                    financeChargeGraceDays = 0,
                    financeChargeMinimumCharge = "string",
                    financeChargeFrequency = 0,
                    statementDestinationEmail = "string",
                    orderAcknowledgementEmail = "user@example.com",
                    shippingConfirmationEmail = "user@example.com",
                    pickupConfirmationEmail = "user@example.com",
                    orderAcknowledgementEmailSelect = "string",
                    shippingConfirmationEmailSelect = "string",
                    pickupConfirmationEmailSelect = "string",
                    isAlwaysPassCreditCheck = true,
                    isPreferFullLots = true,
                    isRequireFullLots = true,
                    externalDocparserParserId = "string",
                    quickParsePriceOverride = true,
                    locationToBlind = true,
                    labelTool = "string",
                    packingSlipItemLabelTemplate = "string",
                    transferPackingSlipItemLabelTemplate = "string",
                    packingSlipPdfTemplate = "string",
                    labelPrinter = "string",
                    labelQuantity = "string",
                    orderSource = "string",
                    invoiceOptionEmail = true,
                    invoiceOptionPrint = true,
                    cooRequiredFlag = true,
                    isStateTaxExempt = true,
                    isSyncToHubSpot = true,
                    website = "string",
                    printPriceOnPickingSlip = true,
                    printPriceOnPackingSlip = true,
                    crmLead = "string",
                    createdAt = DateTime.Parse("2024-11-04T10:59:47.811Z"),
                    updatedAt = DateTime.Parse("2024-11-04T10:59:47.811Z"),
                    createdBy = "string",
                    updatedBy = "string",
                    deletedAt = DateTime.Parse("2024-11-04T10:59:47.811Z"),
                    isDraft = true
                };
                var content = new StringContent(objCont.ToString(), null, "application/json");
                request.Content = content;
                request.Headers.Add("accept", "application/json");
                HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                log.ResponseValue = responseBody;
                log.ResponseDate = DateTime.Now;

                await DALogDetails.InsertLog(log);

                dynamic dictionary = JsonConvert.DeserializeObject<ExpandoObject>(responseBody);

                //Create Return object put logic. When test then chek what object is come from the api.
            }
        }
        catch (Exception ex)
        {
            await DALogDetails.InsertLog(new DbLog { ErrorMsg = ex.Message, ErrorDateTime = DateTime.Now });
        }
    }
}