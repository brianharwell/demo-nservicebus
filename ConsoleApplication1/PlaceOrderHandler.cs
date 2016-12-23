using System;
using System.Linq;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using Shared;

namespace ConsoleApplication1
{
    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        private static ILog _Logger = LogManager.GetLogger<PlaceOrderHandler>();

        public Task Handle(PlaceOrder message, IMessageHandlerContext context)
        {
            _Logger.Info($"Received PlaceOrder, OrderId = {message.OrderId}");

            return Task.CompletedTask;
        }
    }
}
