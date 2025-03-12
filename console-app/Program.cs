using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Confluent.Kafka;
class Program
{
    static async Task Main(string[] args)  // ✅ Change Main to async
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: dotnet run <produce|consume>|<surge>");
            return;
        }

        if (args[0] == "produce")
        {
            await Producer.Run();  // ✅ Await the async method
        }
        else if (args[0] == "consume")
        {
            Consumer.Run();
        }
        else if (args[0] == "surge")
        {
            await Surge.Run();  // ✅ Make sure to await this call
        }
        else
        {
            Console.WriteLine("Invalid argument. Use 'produce' or 'consume'.");
        }
    }
} 