using StackExchange.Redis;

ConnectionMultiplexer  redis = await ConnectionMultiplexer.ConnectAsync("localhost:1453");

ISubscriber subscriber = redis.GetSubscriber();

while (true)
{
    Console.WriteLine("Gönderilen Mesaj:");
    string message = Console.ReadLine();

   await subscriber.PublishAsync("mychannel",message);
}