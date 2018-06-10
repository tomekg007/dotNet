using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdGenerator.Api;
using IdGenerator.Infrastructure.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace IdGenerator.Test.Integration.Controllers
{
    public class FactoryPartsControllerTests : IDisposable
    {

        private readonly TestServer _server;
        private readonly HttpClient _client;

        public FactoryPartsControllerTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());

            _client = _server.CreateClient();
        }


        [Fact]
        public async Task Should_Return_Id_When_Exist_In_The_System()
        {
            var response = await _client.GetAsync("api/FactoryParts/1111/2222/1");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<UniquePartDto>(responseString);

            Assert.Equal("1111-2222-1", result.Id);
        }




        private bool _disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue) return;

            if (disposing)
            {
                _server?.Dispose();
                _client?.Dispose();
            }

            _disposedValue = true;
        }

        
         ~FactoryPartsControllerTests()
         {
          Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
