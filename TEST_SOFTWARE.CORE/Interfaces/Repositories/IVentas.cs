using System.Collections.Generic;
using System.Threading.Tasks;
using TEST_SOFTWARE.CORE.Entities;

namespace TEST_SOFTWARE.CORE.Interfaces.Respositories
{
    public interface IVentas
    {
        Task<List<Invoice>> FindInvoicesByPerson(string Identificacion);
        Task<Invoice> CreateInvoice(Invoice invoice, string Identificacion);
    }
}
