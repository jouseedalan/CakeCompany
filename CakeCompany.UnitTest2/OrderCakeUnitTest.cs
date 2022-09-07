using CakeCompany.Provider;
using CakeCompany.Models;
using CakeCompany.Provider.Interfaces;

namespace CakeCompany.UnitTest2
{
    public class OrderCakeUnitTest
    {
        private readonly ShipmentProvider _shipment;
        private readonly CakeProvider _cakeProvider;
        private readonly OrderProvider _orderProvider;
        private readonly PaymentProvider _paymentProvider;
        private readonly TransportProvider _transportProvider;

        public OrderCakeUnitTest()
        {
            _shipment = new ShipmentProvider();
        }

        [Fact]
        internal void Ship_All_Orders()
        {
            Order[] Orders =
            {
            new("CakeBox", DateTime.Now.AddMinutes(120), 1, Cake.RedVelvet, 120.25),
            new("ImportantCakeShop", DateTime.Now.AddMinutes(45), 1, Cake.Chocolate, 120.25)
            };

            var shipment = _shipment.GetShipment(Orders);
            List<Product> ProductsShipped = shipment.Item1;
            Assert.Equal(2, ProductsShipped.Count);

        }

        [Fact]
        internal void Ship_Nothing_When_EmptyOrders()
        {
            Order[] Orders =
            {
            
            };
            var shipment = _shipment.GetShipment(Orders);
            List<Product> ProductsShipped = shipment.Item1;
            Assert.Equal(0, ProductsShipped.Count);

        }

        [Fact]
        internal void Ship_none_When_CantBake()
        {
            Order[] Orders =
            {
              new("ImportantCakeShop", DateTime.Now, 1, Cake.RedVelvet, 120.25)
            };
            var shipment = _shipment.GetShipment(Orders);
            List<Product> ProductsShipped = shipment.Item1;
            Assert.Equal(0, ProductsShipped.Count);

        }


        [Fact]
        internal void TransportMode_ShouldbeVan_ForQuantityLessThan1000()
        {
            Order[] Orders =
            {
            new("CakeBox", DateTime.Now.AddMinutes(120), 1, Cake.RedVelvet, 120.25),
            new("ImportantCakeShop", DateTime.Now.AddMinutes(45), 1, Cake.Chocolate, 120.25)
            };

            var shipment = _shipment.GetShipment(Orders);
            string TranportMode = shipment.Item2;
            Assert.Equal("Van", TranportMode);

        }


        [Fact]
        internal void TransportMode_ShouldbeTruck_ForQuantityRange_1000_5000()
        {
            Order[] Orders =
            {
            new("CakeBox", DateTime.Now.AddMinutes(120), 1, Cake.RedVelvet, 1000),
            new("ImportantCakeShop", DateTime.Now.AddMinutes(45), 1, Cake.Chocolate, 1)
            };

            var shipment = _shipment.GetShipment(Orders);
            string TranportMode = shipment.Item2;
            Assert.Equal("Truck", TranportMode);

        }


        [Fact]
        internal void TransportMode_ShouldbeShip_ForQuantityGreaterThan5000()
        {
            Order[] Orders =
            {
            new("CakeBox", DateTime.Now.AddMinutes(120), 1, Cake.RedVelvet, 10000),
            new("ImportantCakeShop", DateTime.Now.AddMinutes(45), 1, Cake.Chocolate, 1)
            };

            var shipment = _shipment.GetShipment(Orders);
            string TranportMode = shipment.Item2;
            Assert.Equal("Ship", TranportMode);

        }
    }
}