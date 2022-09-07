using CakeCompany.Models;
using CakeCompany.Models.Transport;
using CakeCompany.Provider;
using CakeCompany.Provider.Interfaces;
using CakeCompany.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeCompany.Service
{
    internal class DeliverShipmentService : IDeliverShipmentService
    {
        private readonly TransportProvider _transportProvider ;
        public DeliverShipmentService(TransportProvider transportProvider)
        {
            _transportProvider= transportProvider;

        }
        public string DeliverTheShipment(List<Product> products)
        {
            var transport = _transportProvider.CheckForAvailability(products);


            if (transport == "Van")
            {
                var van = new Van();
                van.Deliver(products);
            }

            if (transport == "Truck")
            {
                var truck = new Truck();
                truck.Deliver(products);
            }

            if (transport == "Ship")
            {
                var ship = new Ship();
                ship.Deliver(products);
            }

            return transport;

        }
    }
}
