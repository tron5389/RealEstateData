using Newtonsoft.Json;
using RealEstateData.Converters;
using RealEstateData.Data;
using RealEstateData.Helpers;
using RealEstateData.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace RealEstateData
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AddToZipCode("30307");
            var data = new DataAccess("30307");
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
            rentalKPIList = rentalKPIList.Where(list => list.Beds > 0).ToList();
            var csvHelp = new CSV_Helpers();
            csvHelp.RightToCSV(rentalKPIList, "30307");
        }

        private static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return sqlite_conn;
        }

        private static void AddToZipCode(string ZipCode)
        {
            using (var db = new DataBaseContext())
            {
                Console.WriteLine("Inserting a new blog");
                db.Add(new SearchZipCodes { ZipCode = ZipCode, ResultFilePath = "filepath" });
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for a blog");
                var savedZipCodes = db.Search_ZipCodes
                    .First();
                Console.WriteLine(savedZipCodes);
            }
        }
    }
}