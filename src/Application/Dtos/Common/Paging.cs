namespace Application.Dtos.Common;

public struct Paging ///TODO add unit tests
{
	public Paging()
	{
	}

	public uint Take { get; set; } = 10;
	public uint Skip { get; set; } = 0;
}
