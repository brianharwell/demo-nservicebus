using System;
using System.Linq;
using System.Threading.Tasks;
using NServiceBus;
using Shared;

namespace ConsoleApplication3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AsyncMain().GetAwaiter().GetResult();
        }

        static async Task AsyncMain()
        {
            Console.Title = "Billing";

            var endpointConfiguration = new EndpointConfiguration("Billing");
            var routing = endpointConfiguration.UseTransport<MsmqTransport>().Routing();
            endpointConfiguration.UseSerialization<JsonSerializer>();
            endpointConfiguration.UsePersistence<InMemoryPersistence>();
            endpointConfiguration.SendFailedMessagesTo("error");
            endpointConfiguration.EnableInstallers();

            routing.RegisterPublisher(typeof(OrderPlaced), "Sales");

            var endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);
            
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();

            await endpointInstance.Stop().ConfigureAwait(false);
        }
    }
}
