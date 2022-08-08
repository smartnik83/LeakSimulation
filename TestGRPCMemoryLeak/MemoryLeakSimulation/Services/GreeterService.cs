using Grpc.Core;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryLeakSimulation
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }
        private static HelloReply reply = null;
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            if (reply==null)
            {
                reply = JsonConvert.DeserializeObject<HelloReply>(File.ReadAllText(@"Responsesize.json"));
            }
            
            return Task.FromResult(reply);
        }
    }
}
