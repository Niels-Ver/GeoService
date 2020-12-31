using DomainLayer.DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Repositories
{
    public interface IRiverRepository
    {
        River GetRiver(int id);
        //void AddRiver(River river);
        void UpdateRiver(River river);
        void RemoveRiver(River river);
    }
}
