using System.ComponentModel.DataAnnotations;

namespace Application.Dtos;

public class NewCustomerDto //TODO add unit tests
{
	[Required]
	[MinLength(1)]
	[MaxLength(50)]
	public string? Name { get; set; } 
	
	
}
