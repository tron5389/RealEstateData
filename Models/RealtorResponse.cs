using RealEstateData.Models;

namespace RealEstateData
{
    public class RealtorResponse
    {
        public int returned_rows { get; set; }
        public int matching_rows { get; set; }
        public RentalModel[] listings { get; set; }
    }
}