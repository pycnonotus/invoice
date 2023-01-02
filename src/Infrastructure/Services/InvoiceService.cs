

using Application.Dtos.Invoices;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.services;

public class InvoiceService : IInvoiceService
{
	private readonly InvoiceDbContext _invoiceDbContext;
	private readonly IMapper _mapper;

	public InvoiceService(InvoiceDbContext invoiceDbContext, IMapper mapper)
	{
		_invoiceDbContext = invoiceDbContext ?? throw new ArgumentNullException(nameof(invoiceDbContext));
		_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
	}
	
	public async Task<InvoiceSearchDto?> GetById(Guid id)
	{
		var invoice = await _invoiceDbContext.Invoices
			// .Include(i => i.Products)
			.FirstOrDefaultAsync(i => i.Id == id);
		
		return invoice == null ? null : _mapper.Map<InvoiceSearchDto>(invoice);

	}
	
	public async Task<ICollection<InvoiceDto>> Search(InvoiceSearchDto invoiceSearchDto)
	{
		var query = _invoiceDbContext
			.Invoices
			// .Include(i => i.Products)
			.AsQueryable();

		if (invoiceSearchDto.CustomerName != null)
		{
			query = query.Where(i =>
				(i.Customer.FirstName + i.Customer.LastName)
				.ToLower()
				.Contains(invoiceSearchDto.CustomerName.ToLower()) ||
				(i.Customer.LastName + i.Customer.FirstName)
				.ToLower()
				.Contains(invoiceSearchDto.CustomerName.ToLower())
			);
		}
		
		// query = query.Where(i => i.Creation >= invoiceSearchDto.DateRange.From);
		// query = query.Where(i => i.Creation <= invoiceSearchDto.DateRange.Too);


		if (invoiceSearchDto.Status != null)
		{
			query = query.Where(i => i.Status == invoiceSearchDto.Status);
		}

		return await query.ProjectTo<InvoiceDto>(_mapper.ConfigurationProvider).ToListAsync();
	}
	
	public async Task<InvoiceDto> Add(NewInvoiceDto invoiceDto)
	{
		var invoice = new Invoice(invoiceDto.CustomerId);
		_invoiceDbContext.Invoices.Add(invoice);
		await _invoiceDbContext.SaveChangesAsync();
		invoice.Customer = (await _invoiceDbContext.Customers.FindAsync(invoice.CustomerId))!;
		return _mapper.Map<InvoiceDto>(invoice);
	}

	public async Task Remove(Guid id)
	{
		var invoice = await _invoiceDbContext.Invoices.FindAsync(id);
		if (invoice == null)
		{
			return;
		}

		_invoiceDbContext.Invoices.Remove(invoice);
		await _invoiceDbContext.SaveChangesAsync();
	}

	public async Task Update(Guid id, InvoiceUpdateDto updateDto)
	{
		var invoice = await _invoiceDbContext.Invoices.FindAsync(id);
		if (invoice == null)
		{
			throw new NotFoundException($"Invoice with ID {id} not found");
		}

		invoice.Amount = updateDto.Amount;
		invoice.Status = updateDto.Status;

		await _invoiceDbContext.SaveChangesAsync();
	}


	// public async Task RemoveProduct(Guid invoiceId, string productName)
	// {
	// 	var invoice = await _invoiceDbContext.Invoices.Include(i => i.Products).FirstOrDefaultAsync(i => i.Id == invoiceId);
	// 	if (invoice == null)
	// 	{
	// 		return;
	// 	}
	//
	// 	var product = invoice.Products.FirstOrDefault(p => p.Name == productName);
	// 	if (product == null)
	// 	{
	// 		return;
	// 	}
	//
	// 	invoice.RemoveProductByName(productName);
	// 	await _invoiceDbContext.SaveChangesAsync();
	// }
	//
	// public async Task AddProduct(Guid invoiceId, AddProductDto addProductDto)
	// {
	// 	var invoice = await _invoiceDbContext.Invoices.Include(i => i.Products).FirstOrDefaultAsync(i => i.Id == invoiceId);
	// 	if (invoice == null)
	// 	{
	// 		return;
	// 	}
	//
	// 	var product = new Product(addProductDto.Name, addProductDto.Amount, addProductDto.PricePerItem);
	// 	invoice.AddProduct(product);
	// 	await _invoiceDbContext.SaveChangesAsync();
	// }
}

public class NotFoundException : Exception
{
	public NotFoundException(string s)
	{
		throw new NotImplementedException();
	}
}

