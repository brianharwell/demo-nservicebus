using System.Linq;
using NServiceBus;

namespace Shared
{
    public class PlaceOrder : ICommand
    {
        public string OrderId { get; set; }
    }
}
