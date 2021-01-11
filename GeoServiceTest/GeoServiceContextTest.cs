using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeoServiceTest
{
    public class GeoServiceContextTest : GeoServiceContext
    {
        public GeoServiceContextTest(bool keepExistingDB = false) : base("Test")
        {
            if(keepExistingDB)
            {
                Database.EnsureCreated();
            }
            else
            {
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }
    }
}
