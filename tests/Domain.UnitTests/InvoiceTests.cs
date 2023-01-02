namespace Domain.UnitTests;

public class InvoiceTests
{
	[Fact]
	public void Constructor_WithValidCustomerId_InitializesProperties()
	{
		var customerId = Guid.NewGuid();

		var invoice = new Invoice(customerId);

		Assert.Equal(customerId, invoice.CustomerId);
		Assert.Equal(Status.Unpaid, invoice.Status);
		// Assert.Null(invoice.PaymentDate);
	}

	[Fact]
	public void Constructor_WithEmptyCustomerId_ThrowsAggregateException()
	{
		var customerId = Guid.Empty;

		void Action()
		{
			new Invoice(customerId);
		}

		var exception = Assert.Throws<AggregateException>((Action)Action);
		Assert.Equal("customerId can't be the Empty Guid", exception.Message);
	}
}
