namespace Domain.Entities;

public class Customer
{
	public Customer(string firstName, string lastName)
	{
		if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(firstName));
		if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(lastName));

		FirstName = firstName;
		LastName = lastName;
	}

	public Guid Id { get; private init; }
	public string FirstName { get; }
	public string LastName { get; }
}
