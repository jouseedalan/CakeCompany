// See https://aka.ms/new-console-template for more information

using CakeCompany.Models;
using CakeCompany.Provider;

Order[] Orders =
            {
            new("CakeBox", DateTime.Now.AddMinutes(120), 1, Cake.RedVelvet, 100),
            new("ImportantCakeShop", DateTime.Now, 1, Cake.RedVelvet, 120.25),
            new("ImportantCakeShop", DateTime.Now.AddMinutes(45), 1, Cake.Chocolate, 120.25)
            };

var shipmentProvider = new ShipmentProvider();
var shipmentDetails= shipmentProvider.GetShipment(Orders);

Console.WriteLine("Shipment Details...");

foreach (Product product in shipmentDetails.Item1)
{
    Console.WriteLine("----------------------------------------------------------------");
    Console.WriteLine($"OrderID :  {product.OrderId}");
    Console.WriteLine($"Cake : {product.Cake} ");
    Console.WriteLine($"Quantity : {product.Quantity} ");
    Console.WriteLine($"Transport Mode : {shipmentDetails.Item2} ");
    Console.WriteLine();
   
}
    