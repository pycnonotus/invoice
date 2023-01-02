using Domain.Enums;

namespace Application.Dtos;

public class InvoiceDto
{
	//TODO check not empty
	public Guid Id { get; set; }
	//TODO check not empty
	public Guid CustomerId { get; set; }
}