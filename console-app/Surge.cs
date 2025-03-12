using System;
using System.Diagnostics;
using System.Threading.Tasks;  // Required for async
using Confluent.Kafka;

class Surge
{
    public static async Task Run()  // Change Run to async Task
    {
        Console.WriteLine("Starting Kafka Surger...");
        
        string bootstrapServers = Environment.GetEnvironmentVariable("KAFKA_BOOTSTRAP_SERVERS");
        if (string.IsNullOrEmpty(bootstrapServers))
            Console.WriteLine("KAFKA_BOOTSTRAP_SERVERS environment variable is not set.");
        else
            Console.WriteLine($"KAFKA_BOOTSTRAP_SERVERS: {bootstrapServers}");

        string topic = "test-topic";
        int messageCount = 1_000_000;

        var config = new ProducerConfig
        {
            BootstrapServers = bootstrapServers,
            BatchSize = 10 * 1024 * 1024,  // 10 MB batch size
            LingerMs = 10,  // Wait up to 10 ms before sending batch
            CompressionType = CompressionType.Gzip,  // Use compression
            Acks = Acks.All,  // Wait for all brokers to acknowledge the message
            MessageTimeoutMs = 10000  // Set a timeout of 10 seconds per message
        };

        using (var producer = new ProducerBuilder<string, string>(config).Build())
        {
            var stopwatch = Stopwatch.StartNew();
            var tasks = new Task[messageCount];
            for (int i = 0; i < messageCount; i++)
            {
                string key = $"key-{i}";
                string value = $"Message-{i} - {DateTime.UtcNow:O}";
                tasks[i] = producer.ProduceAsync(topic, new Message<string, string> { Key = key, Value = value });

                // Optimize for high throughput
                if (i % 1000 == 0) await Task.Delay(1);
            }

            await Task.WhenAll(tasks);
            stopwatch.Stop();

            Console.WriteLine($"✅ Sent {messageCount} messages in {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}