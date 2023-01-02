namespace Domain.UnitTests;

public class ProductTests
{
	[Fact]
	public void Constructor_WithValidArguments_InitializesProperties()
	{

		const string name = "Product A";
		const int amount = 10;
		const decimal pricePerItem = 15.99m;

		var product = new Product(name, amount, pricePerItem);

		Assert.Equal(name, product.Name);
		Assert.Equal(amount, product.Amount);
		Assert.Equal(pricePerItem, product.PricePerItem);
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	[InlineData("   ")]
	public void Constructor_WithInvalidName_ThrowsArgumentException(string invalidNames)
	{
		const int amount = 10;
		const decimal pricePerItem = 15.99m;

		Assert.Throws<ArgumentException>(() => new Product(invalidNames, amount, pricePerItem));
	}

	[Theory]
	[InlineData(-1)]
	[InlineData(0)]
	public void Constructor_WithInvalidAmount_ThrowsArgumentException(int invalidAmount)
	{
		const string name = "Product A";
		const decimal pricePerItem = 15.99m;

		Assert.Throws<ArgumentException>(() => new Product(name, invalidAmount, pricePerItem));
	}

	[Fact]
	public void Constructor_WithNegativePrice_ThrowsArgumentException()
	{
		const string name = "Product A";
		const int amount = 1;
		const decimal invalidatePerItem = -15.99m;

		Assert.Throws<ArgumentException>(() => new Product(name, amount, invalidatePerItem));
	}


	[Fact]
	public void Amount_WithValidValue_UpdatesProperty()
	{
		var product = new Product("Product A", 10, 15.99m);
		product.Amount = 20;

		Assert.Equal(20, product.Amount);
	}

	[Theory]
	[InlineData(-1)]
	[InlineData(0)]
	public void Amount_WithInvalidValue_ThrowsArgumentException(int invalidAmount)
	{
		var product = new Product("Product A", 10, 15.99m);

		Assert.Throws<ArgumentException>(() => product.Amount = invalidAmount);
	}

	[Fact]
	public void PricePerItem_WithValidValue_UpdatesProperty()
	{
		var product = new Product("Product A", 10, 15.99m);
		var expectedPricePerItem = 19.99m;

		product.PricePerItem = expectedPricePerItem;

		Assert.Equal(expectedPricePerItem, product.PricePerItem);
	}

	[Fact]
	public void PricePerItem_WithNegativeValue_ThrowsArgumentException()
	{
		var product = new Product("Product A", 10, 15.99m);
		decimal invalidPricePerItem = -1;

		void Action() => product.PricePerItem = invalidPricePerItem;

		var exception = Assert.Throws<ArgumentException>(Action);
		Assert.Equal("Value cannot be negative. (Parameter 'PricePerItem')", exception.Message);
	}

	[Fact]
	public void PaymentId_WithValidValue_UpdatesProperties()
	{
		var invoice = new Invoice(Guid.NewGuid());
		var paymentId = "123456";

		invoice.PaymentId = paymentId;

		Assert.Equal(paymentId, invoice.PaymentId);
		Assert.Equal(Status.Paid, invoice.Status);
		Assert.NotNull(invoice.PaymentDate);
	}

	[Fact]
	public void PaymentId_WithNullOrWhitespace_ThrowsArgumentException()
	{
		var invoice = new Invoice(Guid.NewGuid());
		var invalidPaymentId = "   ";

		void Action()
		{
			invoice.PaymentId = invalidPaymentId;
		}

		var exception = Assert.Throws<ArgumentException>(Action);
		Assert.Equal("Value cannot be null or whitespace. (Parameter 'PaymentId')", exception.Message);
	}

	[Fact]
	public void PaymentId_WhenAlreadyPaid_ThrowsAlreadyPaidException()
	{
		var invoice = new Invoice(Guid.NewGuid());
		invoice.PaymentId = "123456";

		void Action() => invoice.PaymentId = "654321";

		Assert.Throws<AlreadyPaidException>(Action);
	}


	[Fact]
	public void Products_WhenListIsNull_ReturnsEmptyList()
	{
		var invoice = new Invoice(Guid.NewGuid());

		var products = invoice.Products;

		Assert.Empty(products);
	}

	[Fact]
	public void AddProduct_WithNewProduct_AddsProductToList()
	{
		var invoice = new Invoice(Guid.NewGuid());
		var product = new Product("Product A", 10, 15.99m);

		invoice.AddProduct(product);

		Assert.Contains(product, invoice.Products);
	}

	[Fact]
	public void AddProduct_WithExistingProduct_ThrowsProductAlreadyExistsException()
	{
		var invoice = new Invoice(Guid.NewGuid());
		var product = new Product("Product A", 10, 15.99m);
		invoice.AddProduct(product);

		void Action() => invoice.AddProduct(product);

		Assert.Throws<ProductAlreadyExistsException>(Action);
	}

	[Fact]
	public void RemoveProductByName_WithExistingProduct_RemovesProductFromList()
	{
		var invoice = new Invoice(Guid.NewGuid());
		var product = new Product("Product A", 10, 15.99m);
		invoice.AddProduct(product);

		var result = invoice.RemoveProductByName("Product A");

		Assert.True(result);
		Assert.DoesNotContain(product, invoice.Products);
	}

	[Fact]
	public void RemoveProductByName_WithNonExistingProduct_ReturnsFalse()
	{
		var invoice = new Invoice(Guid.NewGuid());
		var product = new Product("Product A", 10, 15.99m);
		invoice.AddProduct(product);

		var result = invoice.RemoveProductByName("Product B");

		Assert.False(result);
		Assert.Contains(product, invoice.Products);
	}
}
