using Newtonsoft.Json;
using RealEstateData.Converters;
using RealEstateData.Helpers;
using RealEstateData.Models;
using System;
using System.Collections.Generic;

namespace RealEstateData
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var data = new DataAccess();
            Console.WriteLine("Attempting Data retrieval");
            var stringContent = data.GetRentData().Result;
            var rentData = JsonConvert.DeserializeObject<RealtorResponse>(stringContent);
            var rentalKPIList = new List<RentalKPIModel>();
            var responseConverter = new ResponseConverters();
            foreach (var listing in rentData.listings)
            {
                rentalKPIList.Add(new RentalKPIModel
                {
                    PropertyId = listing.property_id,
                    ListingId = listing.listing_id,
                    Address = listing.address,
                    PropertyType = listing.prop_type,
                    LastUpdated = listing.last_update,
                    MonthlyRent = responseConverter.GetRent(listing),
                    Beds = responseConverter.GetBeds(listing),
                    Baths = responseConverter.GetBaths(listing),
                    Sqft = responseConverter.GetSqft(listing),
                    Lat = listing.lat,
                    Lon = listing.lon
                });
            }
            var csvHelp = new CSV_Helpers();
            csvHelp.RightToCSV(rentalKPIList);
        }
    }
}