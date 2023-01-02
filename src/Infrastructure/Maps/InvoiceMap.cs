using Application.Dtos.Invoices;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Maps;

public class InvoiceMap : Profile
{
	public InvoiceMap()
	{
		CreateMap<Invoice, InvoiceDto>();
	}
}