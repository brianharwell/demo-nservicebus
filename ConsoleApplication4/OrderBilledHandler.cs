using System.Linq;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using Shared;

namespace ConsoleApplication4
{
    //public class OrderBilledHandler : IHandleMessages<OrderBilled>
    //{
    //    private static ILog _Logger = LogManager.GetLogger<OrderBilledHandler>();

    //    public Task Handle(OrderBilled message, IMessageHandlerContext context)
    //    {
    //        _Logger.Info($"Order Billed, OrderId = {message.OrderId} - Should we ship?");

    //        return Task.CompletedTask;
    //    }
    //}
}
