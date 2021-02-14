using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Torqqe.Functions.Model
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Data
    {
        [JsonProperty("isAuthorized")]
        public bool IsAuthorized;

        [JsonProperty("authorizerIPs")]
        public List<object> AuthorizerIPs;

        [JsonProperty("isPaid")]
        public bool IsPaid;

        [JsonProperty("totalCost")]
        public double TotalCost;

        [JsonProperty("paidCost")]
        public int PaidCost;

        [JsonProperty("remainingCost")]
        public double RemainingCost;

        [JsonProperty("requestedDeposit")]
        public int RequestedDeposit;

        [JsonProperty("isArchived")]
        public bool IsArchived;

        [JsonProperty("canCustomerAuthorize")]
        public bool CanCustomerAuthorize;

        [JsonProperty("canCustomerSeeActivity")]
        public bool CanCustomerSeeActivity;

        [JsonProperty("canCustomerSeeAuthorizations")]
        public bool CanCustomerSeeAuthorizations;

        [JsonProperty("canCollectPayment")]
        public bool CanCollectPayment;

        [JsonProperty("canCustomerSeeMessages")]
        public bool CanCustomerSeeMessages;

        [JsonProperty("tags")]
        public List<string> Tags;

        [JsonProperty("includeEpaOnLabor")]
        public bool IncludeEpaOnLabor;

        [JsonProperty("includeEpaOnParts")]
        public bool IncludeEpaOnParts;

        [JsonProperty("isEpaTaxable")]
        public bool IsEpaTaxable;

        [JsonProperty("isLaborTaxable")]
        public bool IsLaborTaxable;

        [JsonProperty("isPartShopSupplies")]
        public bool IsPartShopSupplies;

        [JsonProperty("isLaborShopSupplies")]
        public bool IsLaborShopSupplies;

        [JsonProperty("isShopSuppliesTaxable")]
        public bool IsShopSuppliesTaxable;

        [JsonProperty("useGstPstHst")]
        public bool UseGstPstHst;

        [JsonProperty("shouldTrackQBDepartment")]
        public bool ShouldTrackQBDepartment;

        [JsonProperty("isDemo")]
        public bool IsDemo;

        [JsonProperty("totalsFormulaVersion")]
        public int TotalsFormulaVersion;

        [JsonProperty("isInvoice")]
        public bool IsInvoice;

        [JsonProperty("poNumber")]
        public string PoNumber;

        [JsonProperty("partCommission")]
        public int PartCommission;

        [JsonProperty("tireCommission")]
        public int TireCommission;

        [JsonProperty("laborCommission")]
        public int LaborCommission;

        [JsonProperty("sentToCarfax")]
        public bool SentToCarfax;

        [JsonProperty("isWorkOrderWithPricing")]
        public bool IsWorkOrderWithPricing;

        [JsonProperty("isWorkOrderWithHours")]
        public bool IsWorkOrderWithHours;

        [JsonProperty("includeMessagesOnOrderPDF")]
        public bool IncludeMessagesOnOrderPDF;

        [JsonProperty("includeAuthorizationsOnOrderPDF")]
        public bool IncludeAuthorizationsOnOrderPDF;

        [JsonProperty("statusDate")]
        public DateTime StatusDate;

        [JsonProperty("creationDate")]
        public DateTime CreationDate;

        [JsonProperty("updateDate")]
        public DateTime UpdateDate;

        [JsonProperty("company")]
        public string Company;

        [JsonProperty("serviceWriter")]
        public string ServiceWriter;

        [JsonProperty("customerPhone")]
        public string CustomerPhone;

        [JsonProperty("workflow")]
        public string Workflow;

        [JsonProperty("jobNumber")]
        public int JobNumber;

        [JsonProperty("jobCardPosition")]
        public double JobCardPosition;

        [JsonProperty("publicId")]
        public string PublicId;

        [JsonProperty("invoicedDate")]
        public object InvoicedDate;

        [JsonProperty("paymentDueDate")]
        public object PaymentDueDate;

        [JsonProperty("paymentTermId")]
        public object PaymentTermId;

        [JsonProperty("customerEmail")]
        public string CustomerEmail;

        [JsonProperty("shopSupplies")]
        public int ShopSupplies;

        [JsonProperty("shopSuppliesValueType")]
        public string ShopSuppliesValueType;

        [JsonProperty("customer")]
        public string Customer;

        [JsonProperty("calculatedName")]
        public string CalculatedName;

        [JsonProperty("car")]
        public string Car;

        [JsonProperty("noteDate")]
        public DateTime NoteDate;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("authorizedDate")]
        public DateTime AuthorizedDate;

        [JsonProperty("id")]
        public string Id;
    }

    public class OrderWebhookModel
    {
        [JsonProperty("eventId")]
        public string EventId;

        [JsonProperty("apiVersion")]
        public string ApiVersion;

        [JsonProperty("webhookId")]
        public string WebhookId;

        [JsonProperty("companyId")]
        public string CompanyId;

        [JsonProperty("eventType")]
        public string EventType;

        [JsonProperty("entity")]
        public string Entity;

        [JsonProperty("documentId")]
        public string DocumentId;

        [JsonProperty("data")]
        public Data Data;
    }


}
