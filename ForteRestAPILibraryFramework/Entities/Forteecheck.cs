using Newtonsoft.Json;

namespace Forte
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ForteEcheck
    {
        [JsonProperty("account_holder")]
        public string account_holder
        {
            get;
            set;
        }

        [JsonProperty("account_number")]
        public string account_number
        {
            get;
            set;
        }

        [JsonProperty("masked_account_number")]
        public string masked_account_number
        {
            get;
            set;
        }

        [JsonProperty("last_4_account_number")]
        public string last_4_account_number
        {
            get;
            set;
        }

        [JsonProperty("encrypted_account_number")]
        public string encrypted_account_number
        {
            get;
            set;
        }

        [JsonProperty("routing_number")]
        public string routing_number
        {
            get;
            set;
        }

        [JsonProperty("account_type")]
        public string account_type
        {
            get;
            set;
        }

        [JsonProperty("item_description")]
        public string item_description
        {
            get;
            set;
        }

        [JsonProperty("sec_code")]
        public string sec_code
        {
            get;
            set;
        }
    }
}
