using CakeCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeCompany.Provider.Interfaces
{
    internal interface IShipmentProvider
    {
        public (List<Product> products, string TransportMode) GetShipment(Order[] orders);
    }
}
