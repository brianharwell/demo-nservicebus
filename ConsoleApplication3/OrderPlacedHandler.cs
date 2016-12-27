using System.Linq;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using Shared;

namespace ConsoleApplication3
{
    public class OrderPlacedHandler : IHandleMessages<OrderPlaced>
    {
        private static ILog _Logger = LogManager.GetLogger<OrderPlacedHandler>();
        
        public Task Handle(OrderPlaced message, IMessageHandlerContext context)
        {
            _Logger.Info($"Order Placed, OrderId = {message.OrderId} - Charging credit card...");

            var orderBilled = new OrderBilled() { OrderId = message.OrderId };
            
            return context.Publish(orderBilled);
        }
    }
}
