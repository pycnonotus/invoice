using Domain.Enums;

namespace Application.Dtos.Invoices;

public class InvoiceUpdateDto
{
	public Guid CustomerId { get; set; }
	public decimal Amount { get; set; }
	public Status Status { get; set; }
}