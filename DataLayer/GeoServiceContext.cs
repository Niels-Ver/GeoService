
using DomainLayer.DomainLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
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
                    connectionString = @"Data Source=DESKTOP-RHUF3RT\SQLEXPRESS;Initial Catalog=GeoServiceDB;Integrated Security=True";
                    break;
                case "Test":
                    connectionString = @"Data Source=DESKTOP-RHUF3RT\SQLEXPRESS;Initial Catalog=GeoServiceDB;Integrated Security=True";
                    break;
            }
        }

        public DbSet<Continent> Continents { get; set; }
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
