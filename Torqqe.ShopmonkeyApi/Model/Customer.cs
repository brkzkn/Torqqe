using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Torqqe.ShopmonkeyApi.Model
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Customer
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "shopmonkeyId")]
        public string ShopmonkeyId { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "emails")]
        public ICollection<string> Emails { get; set; }

        [JsonProperty(PropertyName = "address1")]
        public string Address1 { get; set; }

        [JsonProperty(PropertyName = "address2")]
        public object Address2 { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "zip")]
        public string Zip { get; set; }

        [JsonProperty(PropertyName = "creationDate")]
        public DateTime? CreationDate { get; set; }

        [JsonProperty(PropertyName = "phones")]
        public List<string> Phones { get; set; }

        [JsonProperty(PropertyName = "vehicles")]
        public List<Vehicle> Vehicles { get; set; }
    }
}
