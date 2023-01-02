namespace Application.Dtos.Common;

public struct DateRange //TODO add unit tests
{

	
	public DateRange()
	{
	}
	
	public DateRange(DateTime from,DateTime too)
	{
		From = from;
		Too = too;
	}

	public DateTime From { get; set; } = DateTime.MinValue;
	public DateTime Too { get; set; } = DateTime.MaxValue;
}
