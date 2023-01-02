namespace Domain.UnitTests;

public class CustomerTests
{
	private const string FirstName = "Anton";
	private const string LastName = "Golo";
	private const string Whitespace = "   ";

	[Fact]
	public void Constructor_AssignsFirstAndLastName()
	{
		var customer = new Customer(FirstName, LastName);

		Assert.Equal(FirstName, customer.FirstName);
		Assert.Equal(LastName, customer.LastName);
	}

	[Fact]
	public void Constructor_ThrowsExceptionWhenFirstNameIsNull()
	{
		Assert.Throws<ArgumentException>(() => new Customer(null!, LastName));
	}

	[Fact]
	public void Constructor_ThrowsExceptionWhenLastNameIsNull()
	{
		Assert.Throws<ArgumentException>(() => new Customer(FirstName, null!));
	}

	[Fact]
	public void Constructor_ThrowsExceptionWhenFirstNameIsWhitespace()
	{
		Assert.Throws<ArgumentException>(() => new Customer(Whitespace, LastName));
	}

	[Fact]
	public void Constructor_ThrowsExceptionWhenLastNameIsWhitespace()
	{
		Assert.Throws<ArgumentException>(() => new Customer(FirstName, Whitespace));
	}
}
