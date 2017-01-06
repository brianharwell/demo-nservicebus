using NServiceBus;

namespace ConsoleApplication4
{
    public class OrderSagaData : ContainSagaData
    {
        public string OrderId { get; set; }
    }
}