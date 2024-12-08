// CommBox.Infra.Data/CustomerRepository.cs
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CommBox.Infra.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string _connectionString;

        public CustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<CustomerDto> GetAllCustomers()
        {
            var customers = new List<CustomerDto>();

            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();

                using var command = new SqlCommand("SELECT Id, Name, PreferredChannel FROM Customers", connection);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    customers.Add(new CustomerDto
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        PreferredChannel = reader.GetString(2)
                    });
                }
            }
            catch (Exception ex)
            {
                // Log error (placeholder for logging)
                Console.WriteLine($"Error fetching customers: {ex.Message}");
            }

            return customers;
        }

        public CustomerDto? GetCustomerById(int id)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();

                using var command = new SqlCommand("", connection);
                command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });

                using var reader = command.ExecuteReader();

            }
            catch (Exception ex)
            {
                // Log error (placeholder for logging)
                Console.WriteLine($"Error fetching customer by ID: {ex.Message}");
            }
            
            throw new NotImplementedException();
        }

        public int CreateCustomer(string name, string preferredChannel)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();

                using var command = new SqlCommand("INSERT INTO Customers (Name, PreferredChannel) OUTPUT INSERTED.Id VALUES (@Name, @PreferredChannel)", connection);
                command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar) { Value = name });
                command.Parameters.Add(new SqlParameter("@PreferredChannel", SqlDbType.NVarChar) { Value = preferredChannel });

                return (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                // Log error (placeholder for logging)
                Console.WriteLine($"Error creating customer: {ex.Message}");
            }

            return -1;
        }
    }
}
