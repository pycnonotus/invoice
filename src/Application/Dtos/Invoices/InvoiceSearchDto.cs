using Application.Dtos.Common;

namespace Application.Dtos;

public class InvoiceSearchDto : IPaged
{

	public Paging Paging { get; set; }
	public string CustomerName { get; set; }
	public DateRange DateRange { get; set; } 
	
}
