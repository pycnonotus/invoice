using Application.Dtos.Invoices;

namespace Application.Interfaces;

public interface IInvoiceDtoService
{
	Task<InvoiceSearchDto?> GetById(Guid id);

	Task<ICollection<InvoiceSearchDto>> Search(InvoiceSearchDto invoiceSearchDto);

	Task<Guid> Add(NewInvoiceDto invoiceDto);

	Task Remove(Guid id);

	Task AddProduct(Guid invoiceId, AddProductDto addProductDto);

	Task RemoveProduct(Guid invoiceId, string ProductName);
}
