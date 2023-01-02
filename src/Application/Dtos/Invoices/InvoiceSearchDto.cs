using Application.Dtos.Common;
using Application.Interfaces;
using Domain.Enums;

namespace Application.Dtos.Invoices;

public class InvoiceSearchDto : IPaged
{
	public string? CustomerName { get; set; }
	public DateRange DateRange { get; set; }

	public Paging Paging { get; set; }
	
	public Status? Status { get; set; }
}
