using CakeCompany.Models;
using CakeCompany.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeCompany.Service.Interfaces
{
    internal interface IDeliverShipmentService
    {
        public string DeliverTheShipment(List<Product> products);
    }
}
