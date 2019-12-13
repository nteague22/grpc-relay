using System;
using System.IO;
using System.Threading.Tasks;
using Google.Protobuf;
using Grpc.Core;
using Grpc.Net.Client;
using MicroService.Protos;

namespace ConsoleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new MicroService.Protos.Manager.ManagerClient(GrpcChannel.ForAddress("https://localhost:5001"));

            var newEntry = await client.AddAsync(new NewCustomer()
            {
                Email = "sample@email.com",
                FirstName = "Joe",
                LastName = "Customer"
            });

            Console.WriteLine($"The new customer number is {newEntry.Id}");
            Console.ReadKey();
        }
    }
}
