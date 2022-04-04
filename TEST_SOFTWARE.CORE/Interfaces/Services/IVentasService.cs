using System.Collections.Generic;
using System.Threading.Tasks;
using TEST_SOFTWARE.CORE.Entities;

namespace TEST_SOFTWARE.CORE.Interfaces.Services
{
    public interface IVentasService
    {
        Task<List<Invoice>> FindInvoicesByPerson(string Identificacion);
        Task<Invoice> CreateInvoice(Invoice invoice, string Identificacion);
    }
}
