using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TEST_SOFTWARE.CORE.Entities;
using TEST_SOFTWARE.CORE.Interfaces.Services;
using TEST_SOFTWARE.CORE.Response;

namespace TEST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IVentasService _service;
        public FacturaController(IVentasService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> CreateInvoice(Invoice invoice, string Identificacion)
        {
            ApiResponse<Invoice> apiResponse = new ApiResponse<Invoice>();
            try
            {
                invoice = await _service.CreateInvoice(invoice, Identificacion);

                apiResponse.Data = invoice;
                apiResponse.SetSuccess();

            }
            catch (Exception ex)
            {
                apiResponse.SetException(ex);
            }
            return Ok(apiResponse);
        }
        [HttpGet]
        public async Task<IActionResult> FindInvoicesByPerson(string Identificacion)
        {
            ApiResponse<List<Invoice>> apiResponse = new ApiResponse<List<Invoice>>();
            try
            {
                List<Invoice> invoices = await _service.FindInvoicesByPerson(Identificacion);
                apiResponse.Data = invoices;
                apiResponse.SetSuccess();
            }
            catch (Exception ex)
            {
                apiResponse.SetException(ex);
            }
            return Ok(apiResponse);
        }
    }
}
