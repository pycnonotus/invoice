using Application.Dtos.Prodcuts;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Maps;

public class ProductMap : Profile
{
	public ProductMap()
	{
		CreateMap<Product, ProductDto>();
	}
}
