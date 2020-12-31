using DomainLayer.DomainLayer;
using DomainLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repositories
{
    public class RiverRepository : IRiverRepository
    {

        GeoServiceContext context;

        public RiverRepository(GeoServiceContext context)
        {
            this.context = context;
        }

        public River GetRiver(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveRiver(River river)
        {
            throw new NotImplementedException();
        }

        public void UpdateRiver(River river)
        {
            throw new NotImplementedException();
        }
    }
}
