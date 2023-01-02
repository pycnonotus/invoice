using Application.Dtos.Customers;
using Domain.Entities;

namespace Application.Interfaces;

public interface ICustomerService
{
	Task<IEnumerable<CustomerDto>> GetCustomersAsync();
	Task<CustomerDto?> GetCustomerAsync(Guid id);
	Task<CustomerDto> CreateCustomerAsync(NewCustomerDto customer);
	Task<bool> DeleteCustomerAsync(Guid id);
}
