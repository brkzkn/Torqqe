using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Torqqe.ShopmonkeyApi.Model
{
    [JsonObject(Id = "vehicles", MemberSerialization = MemberSerialization.OptIn)]
    public class Vehicle
    {
        [JsonProperty("shopmonkeyId")]
        public string ShopmonkeyId { get; set; }

        [JsonProperty("make")]
        public string Make { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("year")]
        public string Year { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("mileage")]
        public int? Mileage { get; set; }

        [JsonProperty("vin")]
        public string Vin { get; set; }

        [JsonProperty("licensePlate")]
        public string LicensePlate { get; set; }

        [JsonProperty("unitNumber")]
        public string UnitNumber { get; set; }

        [JsonProperty("submodel")]
        public string Submodel { get; set; }

        [JsonProperty("engineSize")]
        public string EngineSize { get; set; }

        [JsonProperty("transmission")]
        public string Transmission { get; set; }

        [JsonProperty("drivetrain")]
        public string Drivetrain { get; set; }

        [JsonProperty("creationDate")]
        public DateTime CreationDate { get; set; }

        [JsonProperty("owners")]
        public List<Owner> Owners { get; set; }
    }

    public class Owner
    {
        [JsonProperty("shopmonkeyId")]
        public string ShopmonkeyId { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("emails")]
        public List<string> Emails { get; set; }

        [JsonProperty("phones")]
        public List<string> Phones { get; set; }
    }
}
