namespace Domain.Entities;

public class Product
{
	public Guid ID { get; set; }
	
	private int _amount;
	private decimal _pricePerItem;

	public Product(string name, int amount, decimal pricePerItem)
	{
		if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

		Name = name;
		Amount = amount;
		PricePerItem = pricePerItem;
	}

	public string Name { get; set; }

	public int Amount
	{
		get => _amount;
		set
		{
			if (value <= 0) throw new ArgumentException("Value cannot be negative or zero.", nameof(Amount));

			_amount = value;
		}
	}

	public decimal PricePerItem
	{
		get => _pricePerItem;
		set
		{
			if (value < 0) throw new ArgumentException("Value cannot be negative.", nameof(PricePerItem));

			_pricePerItem = value;
		}
	}
}
