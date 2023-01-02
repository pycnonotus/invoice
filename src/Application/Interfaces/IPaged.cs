using Application.Dtos.Common;

namespace Application.Interfaces;

public interface IPaged
{
	Paging Paging { get; }
}
