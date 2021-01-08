using System;

namespace RealEstateData.Models
{
    public class RentalKPIModel
    {
        public string PropertyId { get; set; }
        public string ListingId { get; set; }
        public string Address { get; set; }
        public string PropertyType { get; set; }
        public DateTime LastUpdated { get; set; }
        public double MonthlyRent { get; set; }
        public float Beds { get; set; }
        public float Baths { get; set; }
        public int Sqft { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }

        public double PricePerSqFt
        {
            get
            {
                return MonthlyRent / Sqft;
            }

            set { }
        }

        public double NormalPricePerSqFt
        {
            get
            {
                return PricePerSqFt * (Baths / Beds);
            }

            set { }
        }
    }
}