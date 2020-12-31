using ConsoleAppLayer.DomainLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLayer
{
    public class GeoServiceContext : DbContext
    {
        private string connectionString;

        public GeoServiceContext()
        {

        }

        public GeoServiceContext(string db = "Production") : base()
        {
            SetConnectionString(db);
        }

        private void SetConnectionString(string db = "Production")
        {
            switch (db)
            {
                case "Production":
                    connectionString = "";
                    break;
                case "Test":
                    connectionString = "";
                    break;
            }
        }

        public DbSet<Continent> Continenten { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<River> Rivers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (connectionString == null)
                SetConnectionString();
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
