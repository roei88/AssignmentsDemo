using System.Net;
using System.Net.Http.Json;
using CommBox.Infra.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore; // Add this
using Microsoft.EntityFrameworkCore.Infrastructure; // Add this
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CommBox.Tests
{
    public class CustomersTests : IClassFixture<WebApplicationFactory<CommBox.Infra.Api.Program>>
    {
        private readonly WebApplicationFactory<CommBox.Infra.Api.Program> _factory;

        public CustomersTests(WebApplicationFactory<CommBox.Infra.Api.Program> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var descriptor = services.SingleOrDefault(
                        d => d.ServiceType == typeof(DbContextOptions<CustomerDbContext>));

                    if (descriptor != null)
                        services.Remove(descriptor);

                    services.AddDbContext<CustomerDbContext>(options =>
                        options.UseInMemoryDatabase("TestCustomerDb"));
                });
            });
        }

        [Fact]
        public async Task GetCustomers_ReturnsCachedData()
        {
            using var scope = _factory.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<CustomerDbContext>();

            context.Customers.Add(new CustomerDto { Id = 1, Name = "John Doe", PreferredChannel = "Email" });
            context.Customers.Add(new CustomerDto { Id = 2, Name = "Jane Smith", PreferredChannel = "WhatsApp" });
            context.SaveChanges();

            var client = _factory.CreateClient();

            var response = await client.GetAsync("/api/customers");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var data = await response.Content.ReadFromJsonAsync<List<CustomerDto>>();
            Assert.NotNull(data);
            Assert.Equal(2, data.Count);
        }

        [Fact]
        public async Task CreateCustomer_RequiresAuthentication()
        {
            var client = _factory.CreateClient();

            var response = await client.PostAsJsonAsync("/api/customers", new CustomerDto { Name = "New Customer" });
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task CreateCustomer_AdminRoleCanCreate()
        {
            using var scope = _factory.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<CustomerDbContext>();

            var client = _factory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "valid-admin-token");

            var response = await client.PostAsJsonAsync("/api/customers", new CustomerDto { Name = "New Customer", PreferredChannel = "SMS" });
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var created = context.Customers.FirstOrDefault(c => c.Name == "New Customer");
            Assert.NotNull(created);
        }
    }
}
