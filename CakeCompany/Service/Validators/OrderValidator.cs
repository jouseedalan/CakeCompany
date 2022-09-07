using CakeCompany.Models;
using CakeCompany.Provider;
using CakeCompany.Provider.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeCompany.Service.Validators
{
    internal class OrderValidator
    {
       
        public bool IsOrderEmpty(Order[] orders)
        {
            return orders.Length<=0 ? true : false;

        }

        public bool CanBakeOntime(Order Order, CakeProvider cakeProvider)
        {
            var estimatedBakeTime = cakeProvider.Check(Order);

            if (estimatedBakeTime > Order.EstimatedDeliveryTime)
                return false;
            return true;

        }

        public bool IsPaymentSuccess(PaymentProvider paymentProvider, Order order)
        {
            return paymentProvider.Process(order).IsSuccessful ? true : false;
            
        }
    }
}
