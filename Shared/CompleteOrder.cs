using NServiceBus;

namespace Shared
{
    public class CompleteOrder : ICommand
    {
        public string OrderId { get; set; }
    }
}