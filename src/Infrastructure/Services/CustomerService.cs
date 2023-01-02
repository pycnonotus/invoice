using Application.Dtos.Customers;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.services;

public class CustomerService : ICustomerService
{
	private readonly InvoiceDbContext _invoiceDbContext;
	private readonly IMapper _mapper;

	public CustomerService(InvoiceDbContext invoiceDbContext, IMapper mapper)
	{
		_invoiceDbContext = invoiceDbContext;
		_mapper = mapper;
	}

	public async Task<IEnumerable<CustomerDto>> GetCustomersAsync()
	{
		var customers = await _invoiceDbContext.Customers.ToListAsync();
		return _mapper.Map<List<CustomerDto>>(customers);
	}

	public async Task<CustomerDto?> GetCustomerAsync(Guid id)
	{
		var customer = await _invoiceDbContext.Customers.FindAsync(id);
		return customer == null ? null : _mapper.Map<CustomerDto>(customer);

	}

	public async Task<CustomerDto> CreateCustomerAsync(NewCustomerDto newCustomer)
	{
		var customer = _mapper.Map<Customer>(newCustomer);
		_invoiceDbContext.Customers.Add(customer);
		await _invoiceDbContext.SaveChangesAsync();
		return _mapper.Map<CustomerDto>(customer);
	}

	public async Task<bool> DeleteCustomerAsync(Guid id)
	{
		var customer = await _invoiceDbContext.Customers.FindAsync(id);
		if (customer == null)
		{
			return false;
		}

		_invoiceDbContext.Customers.Remove(customer);
		await _invoiceDbContext.SaveChangesAsync();
		return true;
	}
}
