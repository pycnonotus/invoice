using Application.Dtos.Customers;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Maps;

public class CustomerMap : Profile
{
	public CustomerMap()
	{
		CreateMap<NewCustomerDto, Customer>();
		CreateMap<Customer,CustomerDto>();
	}
}
