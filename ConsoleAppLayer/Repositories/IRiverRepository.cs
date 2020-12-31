using ConsoleAppLayer.DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLayer.Repositories
{
    public interface IRiverRepository
    {
        River getRiver(int id);
        void AddRiver(River river);
        void UpdateRiver(River river);
        void RemoveRiver(River river);
    }
}
