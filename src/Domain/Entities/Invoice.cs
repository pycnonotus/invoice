using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Entities;

public class Invoice
{
	private string? _paymentId;
	private List<Product>? _products;
	
	public Invoice(Guid customerId)
	{
		if (customerId == Guid.Empty) throw new AggregateException($"{nameof(customerId)} can't be the Empty Guid");

		CustomerId = customerId;
	}


	public Guid Id { get; private set; }
	public Guid CustomerId { get; }
	public DateTime Creation { get; } = DateTime.UtcNow;
	public Status Status { get; private set; } = Status.Unpaid;
	public DateTime? PaymentDate { get; private set; }

	public string? PaymentId
	{
		get => _paymentId;
		set
		{
			if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(PaymentId));
			if (Status is Status.Paid) throw new AlreadyPaidException();

			_paymentId = value;
			Status = Status.Paid;
			PaymentDate = DateTime.UtcNow;
		}
	}

	public IReadOnlyCollection<Product> Products
	{
		get => _products ?? new List<Product>();
	}


	public void AddProduct(Product product)
	{
		_products ??= new List<Product>();

		if (_products.Any(x => x.Name == product.Name)) throw new ProductAlreadyExistsException();

		_products.Add(product);
	}

	/// <summary>
	///     remove and product from products by name
	/// </summary>
	/// <param name="name">name of the prdout we want to remove</param>
	/// <returns>true if product is removed<br />false if not product matched the name</returns>
	public bool RemoveProductByName(string name)
	{

		var itemIndex = _products?.FindIndex(x => x.Name == name) ?? -1;
		if (itemIndex == -1) return false;

		_products!.RemoveAt(itemIndex);
		return true;
	}
}
