using System.Linq;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using Shared;

namespace ConsoleApplication5
{
    public class OrderPlacedHandler : IHandleMessages<OrderPlaced>
    {
        private static ILog _Logger = LogManager.GetLogger<OrderPlacedHandler>();
        
        public Task Handle(OrderPlaced message, IMessageHandlerContext context)
        {
            _Logger.Info($"Audit Order Placed, OrderId = {message.OrderId}");
            
            return Task.FromResult(0);
        }
    }
}
