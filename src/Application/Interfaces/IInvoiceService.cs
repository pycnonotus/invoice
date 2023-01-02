using Application.Dtos.Invoices;

namespace Application.Interfaces;

public interface IInvoiceService
{
	Task<InvoiceSearchDto?> GetById(Guid id);

	Task<ICollection<InvoiceDto>> Search(InvoiceSearchDto invoiceSearchDto);

	Task<InvoiceDto> Add(NewInvoiceDto invoiceDto);

	Task Remove(Guid id);

	// Task AddProduct(Guid invoiceId, AddProductDto addProductDto);
	//
	// Task RemoveProduct(Guid invoiceId, string ProductName);
	Task Update(Guid id, InvoiceUpdateDto updateDto);
}
