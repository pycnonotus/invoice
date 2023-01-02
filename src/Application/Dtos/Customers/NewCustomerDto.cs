using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Customers;

public class NewCustomerDto //TODO add unit tests
{
	[Required]
	[MinLength(1)]
	[MaxLength(50)]
	public string? FirstName { get; set; }
	
	[Required]
	[MinLength(1)]
	[MaxLength(50)]
	public string? LastName { get; set; }
}