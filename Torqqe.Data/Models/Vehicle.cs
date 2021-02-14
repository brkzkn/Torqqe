using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Torqqe.Data.Models
{
    public class Vehicle : IEquatable<Vehicle>
    {
        public Vehicle()
        {
            Orders = new HashSet<Order>();
            VehicleOwners = new HashSet<VehicleOwner>();
        }

        public string ShopmonkeyId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public int? Mileage { get; set; }
        public string Vin { get; set; }
        public string LicensePlate { get; set; }
        public string UnitNumber { get; set; }
        public string Submodel { get; set; }
        public string EngineSize { get; set; }
        public string Transmission { get; set; }
        public string DriveTrain { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<VehicleOwner> VehicleOwners { get; set; }

        public bool Equals(Vehicle other)
        {
            return ShopmonkeyId.Equals(other.ShopmonkeyId);
        }
    }
}
