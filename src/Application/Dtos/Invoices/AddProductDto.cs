namespace Application.Dtos;

public class AddProductDto
{
	//TODO add unit tests
	//TODO add validation
	public string Name { get; set; }
	public uint Amount { get; set; }
	//TODO add cehk
	public decimal PricePerItem{ get; set; }
}
