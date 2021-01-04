using Newtonsoft.Json;
using RealEstateData.Models;
using System;

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
            var rentData = JsonConvert.DeserializeObject<RentalModel>(stringContent);
        }
    }
}