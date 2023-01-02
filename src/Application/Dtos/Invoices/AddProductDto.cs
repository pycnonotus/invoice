namespace Application.Dtos.Invoices;

public class AddProductDto
{
	//TODO add unit tests
	//TODO add validation
	public string Name { get; set; }
	public int Amount { get; set; }
	//TODO add cehk
	public decimal PricePerItem { get; set; }
}
