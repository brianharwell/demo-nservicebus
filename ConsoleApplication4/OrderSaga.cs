using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using Shared;

namespace ConsoleApplication4
{
    public class OrderSaga : Saga<OrderSagaData>, IAmStartedByMessages<PlaceOrder>, IHandleMessages<OrderBilled>, IHandleMessages<CompleteOrder>
    {
        private static ILog _Logger = LogManager.GetLogger<OrderSaga>();

        private bool _OrderPlaced;
        private bool _OrderBilled;

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<OrderSagaData> mapper)
        {
            mapper.ConfigureMapping<PlaceOrder>(x => x.OrderId).ToSaga(x => x.OrderId);
            mapper.ConfigureMapping<OrderBilled>(x => x.OrderId).ToSaga(x => x.OrderId);
            mapper.ConfigureMapping<CompleteOrder>(x => x.OrderId).ToSaga(x => x.OrderId);
        }

        public Task Handle(PlaceOrder message, IMessageHandlerContext context)
        {
            _Logger.Info($"Starting saga, Placing order, OrderId = {message.OrderId} - Should we ship?");

            _OrderPlaced = true;

            var orderCompleted = new CompleteOrder() { OrderId = message.OrderId };

            context.SendLocal(orderCompleted);

            return Task.CompletedTask;
        }

        public Task Handle(OrderBilled message, IMessageHandlerContext context)
        {
            _Logger.Info($"Order Billed, OrderId = {message.OrderId} - Should we ship?");

            _OrderBilled = true;

            var orderCompleted = new CompleteOrder() { OrderId = message.OrderId };

            context.SendLocal(orderCompleted);

            return Task.CompletedTask;
        }

        public Task Handle(CompleteOrder message, IMessageHandlerContext context)
        {
            if (!_OrderBilled || !_OrderBilled)
            {
                 _Logger.Info($"Order is not complete, OrderId = {message.OrderId}");

                return Task.CompletedTask;
            }

            _Logger.Info($"Order is complete ship it!, OrderId = {message.OrderId}");
            
            return Task.CompletedTask;
        }
    }
}