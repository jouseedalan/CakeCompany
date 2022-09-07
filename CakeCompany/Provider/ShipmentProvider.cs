using System.Diagnostics;
using CakeCompany.Models;
using CakeCompany.Provider.Interfaces;
using CakeCompany.Service;
namespace CakeCompany.Provider;
internal class ShipmentProvider : IShipmentProvider
{
    
   // private readonly OrderProvider _orderProvider;
    private readonly TransportProvider _transportProvider;    
    private readonly OrderValidationService _orderValidationService;
    private readonly DeliverShipmentService _deliverShipmentService;
    private readonly CakeProvider _cakeProvider;
    private readonly PaymentProvider _paymentProvider;
    
    public ShipmentProvider()
    {
        //_orderProvider = new OrderProvider();
        _paymentProvider = new PaymentProvider();
        _transportProvider = new TransportProvider();
        _cakeProvider = new CakeProvider();
       _orderValidationService = new OrderValidationService(_cakeProvider,_paymentProvider);
       _deliverShipmentService = new DeliverShipmentService(_transportProvider);
    }
    
    public (List<Product> products, string TransportMode) GetShipment(Order[] orders)
    {

        //Order[] orders = _orderProvider.GetLatestOrders();       
        var products = _orderValidationService.GetProductsRedayForShipment(orders);
        var TransportMode = _deliverShipmentService.DeliverTheShipment(products);      
        return (products, TransportMode);
    }

    }

    

    

