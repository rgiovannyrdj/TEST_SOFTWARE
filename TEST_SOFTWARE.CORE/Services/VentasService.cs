using System.Collections.Generic;
using System.Threading.Tasks;
using TEST_SOFTWARE.CORE.Entities;
using TEST_SOFTWARE.CORE.Interfaces;
using TEST_SOFTWARE.CORE.Interfaces.Respositories;
using TEST_SOFTWARE.CORE.Interfaces.Services;

namespace TEST_SOFTWARE.CORE.Services
{
    public class VentasService : IVentasService
    {
        private readonly IVentas _ventas;
        public VentasService(IVentas ventas)
        {
            _ventas = ventas;
        }
        public async Task<Invoice> CreateInvoice(Invoice invoice, string Identificacion)
        {
            return await _ventas.CreateInvoice(invoice, Identificacion);
        }

        public async Task<List<Invoice>> FindInvoicesByPerson(string Identificacion)
        {
            return await _ventas.FindInvoicesByPerson(Identificacion);
        }
    }
}
