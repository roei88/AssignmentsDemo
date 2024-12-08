
using System.Collections.Generic;

namespace CommBox.Infra.Data
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerDto> GetAllCustomers();
        CustomerDto? GetCustomerById(int id);
        int CreateCustomer(string name, string preferredChannel);
    }
}
