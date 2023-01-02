using Application.Dtos.Customers;
using Application.Dtos.Prodcuts;
using Domain.Entities;
using Domain.Enums;

namespace Application.Dtos.Invoices;

public class InvoiceDto
{
	public Guid Id { get; set; }
	public CustomerDto Customer { get; set; }
	// public List<ProductDto> Products { get; set; }
	public decimal Amount { get; set; }
	public DateTime Creation { get; set; } 
	public Status Status { get;  set; } 


}
