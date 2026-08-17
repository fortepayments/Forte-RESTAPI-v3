using Newtonsoft.Json;

namespace Forte
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ForteTransaction : ForteResourceClass
    {
        [JsonProperty("organization_id")]
        public string organization_id
        {
            get;
            set;
        }

        [JsonProperty("location_id")]
        public string location_id
        {
            get;
            set;
        }

        [JsonProperty("action")]
        public string action
        {
            get;
            set;
        }

        [JsonProperty("customer_token")]
        public string customer_token
        {
            get;
            set;
        }

        [JsonProperty("customer_id")]
        public string customer_id
        {
            get;
            set;
        }

        [JsonProperty("paymethod_token")]
        public string paymethod_token
        {
            get;
            set;
        }

        [JsonProperty("reference_id")]
        public string reference_id
        {
            get;
            set;
        }

        [JsonProperty("authorization_amount")]
        public string authorization_amount
        {
            get;
            set;
        }

        [JsonProperty("order_number")]
        public string order_number
        {
            get;
            set;
        }

        [JsonProperty("original_transaction_id")]
        public string original_transaction_id
        {
            get;
            set;
        }

        [JsonProperty("transaction_id")]
        public string transaction_id
        {
            get;
            set;
        }

        [JsonProperty("authorization_code")]
        public string authorization_code
        {
            get;
            set;
        }

        [JsonProperty("entered_by")]
        public string entered_by
        {
            get;
            set;
        }

        [JsonProperty("received_date")]
        public string received_date
        {
            get;
            set;
        }

        [JsonProperty("origination_date")]
        public string origination_date
        {
            get;
            set;
        }

        [JsonProperty("sales_tax_amount")]
        public string sales_tax_amount
        {
            get;
            set;
        }

        [JsonProperty("service_fee_amount")]
        public string service_fee_amount
        {
            get;
            set;
        }

        [JsonProperty("subtotal_amount")]
        public string subtotal_amount
        {
            get;
            set;
        }

        [JsonProperty("freight_amount")]
        public string freight_amount
        {
            get;
            set;
        }

        [JsonProperty("status")]
        public string status
        {
            get;
            set;
        }

        [JsonProperty("billing_address")]
        public ForteAddress billing_address
        {
            get;
            set;
        }

        [JsonProperty("shipping_address")]
        public ForteAddress shipping_address
        {
            get;
            set;
        }

        [JsonProperty("card")]
        public ForteCard card
        {
            get;
            set;
        }

        [JsonProperty("echeck")]
        public ForteEcheck echeck
        {
            get;
            set;
        }

        [JsonProperty("line_items")]
        public ForteLineItems line_items
        {
            get;
            set;
        }

        [JsonProperty("xdata")]
        public ForteXData xdata
        {
            get;
            set;
        }

        public ForteTransaction()
        {
            line_items = new ForteLineItems();
            xdata = new ForteXData();
            links = new ForteLinks();
            response = new ForteResponse();
        }
    }
}
