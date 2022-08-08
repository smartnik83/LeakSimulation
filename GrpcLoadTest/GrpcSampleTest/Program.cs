using Grpc.Net.Client;
using MemoryLeakSimulation;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GrpcSampleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            GrpcChannelOptions options = new GrpcChannelOptions();

            //Console.WriteLine("Hello World!");
            //HelloRequest searchCriteria = JsonConvert.DeserializeObject<HelloRequest>(File.ReadAllText(@"C:\Abhi\POC\GRPC\GRPC_LoadTest\GrpcLoadTest\GrpcLoadTest\Request.json"));
            //HotelSearchCriteria searchCriteria = new HotelSearchCriteria();
            HelloRequest searchCriteria = new HelloRequest();
            var channel = GrpcChannel.ForAddress("http://localhost:5000");

            var client = new Greeter.GreeterClient(channel);

            //SendGrpcRequest(1, searchCriteria, client);


            for (int i = 0; i < 10000; i++)
            {
                //var channelInside = GrpcChannel.ForAddress("http://localhost:5010");

                //var clientInside = new Greeter.GreeterClient(channelInside);
                SendGrpcRequest(i, searchCriteria, client);
                //channel.Dispose();
            }

            //Parallel.For(0, 10000, i =>
            //{

            //    SendGrpcRequest(i, searchCriteria, client);

            //    //SendDummyGrpcRequest(i, client);
            //    //SendGetDataGrpcRequest(i, client);
            //});

        }

        private static void SendGrpcRequest(int attemptNo, HelloRequest searchCriteria, Greeter.GreeterClient client)
        {
            var reply = client.SayHello(searchCriteria);

            Console.WriteLine("Attempt No " + attemptNo + " HotelCount " + reply.BaseDavidGuttaRoad.Substring(2));
        }

    }
}
