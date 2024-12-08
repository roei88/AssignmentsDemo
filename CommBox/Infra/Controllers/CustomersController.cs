using CommBox.Infra.Common;
using CommBox.Infra.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CommBox.Infra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerDbContext _dbContext;
        private readonly IInMemoryCache _cache;

        public CustomersController(CustomerDbContext dbContext, IInMemoryCache cache)
        {
            _dbContext = dbContext;
            _cache = cache;
        }

        [HttpGet]
        public IActionResult GetCustomers([FromQuery] bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult CreateCustomer([FromBody] CustomerDto customer)
        {
            throw new NotImplementedException();
        }
    }
}
