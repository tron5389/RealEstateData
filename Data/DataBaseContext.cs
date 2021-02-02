using Microsoft.EntityFrameworkCore;
using RealEstateData.Models;

namespace RealEstateData.Data
{
    public class DataBaseContext : DbContext
    {
        public DbSet<RentalKPIModel> KPIModels { get; set; }
        public DbSet<SearchZipCodes> Search_ZipCodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=RealtyData.db");
    }
}