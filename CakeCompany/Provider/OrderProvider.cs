using System.Reflection.Metadata.Ecma335;
using CakeCompany.Models;
using CakeCompany.Provider.Interfaces;

namespace CakeCompany.Provider;

internal class OrderProvider 
{
    public Order[] GetLatestOrders()
    {
        return new Order[]
        {
            new("CakeBox", DateTime.Now.AddMinutes(120), 1, Cake.RedVelvet, 120.25),
            new("ImportantCakeShop", DateTime.Now.AddMinutes(120), 1, Cake.RedVelvet, 120.25),
            new("ImportantClient2", DateTime.Now.AddMinutes(20), 1, Cake.Chocolate, 12000)
        };
    }

    public Order[] GetLatestOrders(Order[] orders)
    {
        return orders;
    }

    public void UpdateOrders(Order[] orders)
    {
    }
}


