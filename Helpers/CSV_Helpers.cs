using CsvHelper;
using RealEstateData.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RealEstateData.Helpers
{
    public class CSV_Helpers
    {
        public CSV_Helpers()
        {
        }

        public void RightToCSV(List<RentalKPIModel> listings)
        {
            using (var mem = new MemoryStream())
            using (TextWriter writer = new StreamWriter(mem))
            using (var csvWriter = new CsvWriter(writer, cultureInfo: System.Globalization.CultureInfo.CurrentCulture))
            {
                csvWriter.Configuration.Delimiter = ";";
                csvWriter.Configuration.AutoMap<RentalKPIModel>();

                csvWriter.WriteField("PropertyId");
                csvWriter.WriteField("ListingID");
                csvWriter.WriteField("Address");
                csvWriter.WriteField("PropertyType");
                csvWriter.WriteField("LastUpdated");
                csvWriter.WriteField("MonthlyRent");
                csvWriter.WriteField("Beds");
                csvWriter.WriteField("Baths");
                csvWriter.WriteField("SqFt");
                csvWriter.WriteField("Lat");
                csvWriter.WriteField("Lon");
                csvWriter.WriteField("PricePerSqft");
                csvWriter.WriteField("NormalPricePerSqft");
                csvWriter.NextRecord();
                foreach (var listing in listings)
                {
                    csvWriter.WriteField(listing.PropertyId);
                    csvWriter.WriteField(listing.ListingId);
                    csvWriter.WriteField(listing.Address);
                    csvWriter.WriteField(listing.PropertyType);
                    csvWriter.WriteField(listing.LastUpdated);
                    csvWriter.WriteField(listing.MonthlyRent);
                    csvWriter.WriteField(listing.Beds);
                    csvWriter.WriteField(listing.Baths);
                    csvWriter.WriteField(listing.Sqft);
                    csvWriter.WriteField(listing.Lat);
                    csvWriter.WriteField(listing.Lon);
                    csvWriter.WriteField(listing.PricePerSqFt);
                    csvWriter.WriteField(listing.NormalPricePerSqFt);
                    csvWriter.NextRecord();
                }
                writer.Flush();
                var result = Encoding.UTF8.GetString(mem.ToArray());
                File.WriteAllText("C:\\Users\\tomro\\OneDrive\\Documents\\RentalListings\\RentalsListTest_30312.csv", result);
                Console.WriteLine(result);
            }
        }

        public void WriteToCSV(RentalKPIModel[] listings)
        {
            using (var mem = new MemoryStream())
            using (TextWriter writer = new StreamWriter(mem))
            using (var csvWriter = new CsvWriter(writer, cultureInfo: System.Globalization.CultureInfo.CurrentCulture))
            {
                csvWriter.Configuration.Delimiter = ";";
                csvWriter.Configuration.HasHeaderRecord = false;
                csvWriter.Configuration.AutoMap<RentalKPIModel>();

                csvWriter.WriteHeader<RentalKPIModel>();
                csvWriter.WriteRecords(listings);

                writer.Flush();
                var result = Encoding.UTF8.GetString(mem.ToArray());
                File.WriteAllText("C:\\Users\\tomro\\OneDrive\\Documents\\RentalListings\\RentalsList_30312.csv", result);
                Console.WriteLine(result);
            }
        }
    }
}