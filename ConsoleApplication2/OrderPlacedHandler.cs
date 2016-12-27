using System.Linq;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using Shared;

namespace ConsoleApplication2
{
    public class OrderPlacedHandler : IHandleMessages<OrderPlaced>
    {
        private static ILog _Logger = LogManager.GetLogger<PlaceOrderHandler>();
        
        public Task Handle(OrderPlaced message, IMessageHandlerContext context)
        {
            _Logger.Info($"Order Placed, OrderId = {message.OrderId}");
            
            return Task.CompletedTask;
        }
    }
}
