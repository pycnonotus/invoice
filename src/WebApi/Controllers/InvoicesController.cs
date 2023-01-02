using Application.Dtos.Invoices;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoicesController : ControllerBase
{
	private readonly IInvoiceService _invoiceService;

	public InvoicesController(IInvoiceService invoiceDtoService)
	{
		_invoiceService = invoiceDtoService ?? throw new ArgumentNullException(nameof(invoiceDtoService));
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<InvoiceSearchDto>> GetById(Guid id)
	{
		var invoice = await _invoiceService.GetById(id);
		if (invoice == null)
		{
			return NotFound();
		}

		return Ok(invoice);
	}

	[HttpGet]
	public async Task<ActionResult<ICollection<InvoiceSearchDto>>> Search([FromQuery]InvoiceSearchDto invoiceSearchDto)
	{
		var invoices = await _invoiceService.Search(invoiceSearchDto);
		return Ok(invoices);
	}

	[HttpPost]
	public async Task<ActionResult<InvoiceDto>> Add([FromBody]NewInvoiceDto newInvoiceDto)
	{
		var invoiceDto = await _invoiceService.Add(newInvoiceDto);
		return CreatedAtAction(nameof(GetById), new { id = invoiceDto }, invoiceDto);
	}
	[HttpPut("{id:guid}")]
	public async Task<IActionResult> UpdateInvoice(Guid id, [FromBody] InvoiceUpdateDto updateDto)
	{
		await _invoiceService.Update(id,updateDto);

		return NoContent();
	}
	[HttpDelete("{id:guid}")]
	public async Task<ActionResult> Remove(Guid id)
	{
		await _invoiceService.Remove(id);
		return NoContent();
	}

	// [HttpPost("{invoiceId:guid}/products")]
	// public async Task<ActionResult> AddProduct(Guid invoiceId, AddProductDto addProductDto)
	// {
	// 	await _invoiceService.AddProduct(invoiceId, addProductDto);
	// 	return NoContent();
	// }
	//
	// [HttpDelete("{invoiceId:guid}/products/{productName}")]
	// public async Task<ActionResult> RemoveProduct(Guid invoiceId, string productName)
	// {
	// 	await _invoiceService.RemoveProduct(invoiceId, productName);
	// 	return NoContent();
	// }
}
