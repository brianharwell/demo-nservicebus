using System;
using System.Linq;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using Shared;

namespace ConsoleApplication4
{
    //public class OrderPlacedHandler : IHandleMessages<OrderPlaced>
    //{
    //    private static ILog _Logger = LogManager.GetLogger<OrderPlacedHandler>();

    //    public Task Handle(OrderPlaced message, IMessageHandlerContext context)
    //    {
    //        _Logger.Info($"Order Placed, OrderId = {message.OrderId} - Should we ship?");

    //        return Task.CompletedTask;
    //    }
    //}
}
