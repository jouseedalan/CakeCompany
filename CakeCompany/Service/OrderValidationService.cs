using CakeCompany.Models;
using CakeCompany.Provider;
using CakeCompany.Service.Interfaces;
using CakeCompany.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeCompany.Service
{
    internal class OrderValidationService : IOrderValidationService
    {
        private readonly CakeProvider _cakeProvider;
        private readonly OrderValidator _orderValidator = new OrderValidator();
        private readonly PaymentProvider _paymentProvider;
        public OrderValidationService(CakeProvider cakeProvider, PaymentProvider paymentProvider)
        {
            _cakeProvider = cakeProvider;
            _paymentProvider = paymentProvider;
        }
        public List<Product> GetProductsRedayForShipment(Order[] orders)
        {
            var products = new List<Product>();
            var cancelledOrders = new List<Order>();
            
            if (_orderValidator.IsOrderEmpty(orders))            
               return products;
            

            foreach (var order in orders)
            {
                
                if(!_orderValidator.CanBakeOntime(order, _cakeProvider))
                {
                    cancelledOrders.Add(order);
                    continue;
                }
                
                if(!_orderValidator.IsPaymentSuccess(_paymentProvider, order))
                {
                    cancelledOrders.Add(order);
                    continue;
                }
                                
                var product = _cakeProvider.Bake(order);
                products.Add(product);
            }
            return products;
        }
    }
}
