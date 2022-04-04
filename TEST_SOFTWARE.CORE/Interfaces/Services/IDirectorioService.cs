using System.Collections.Generic;
using System.Threading.Tasks;
using TEST_SOFTWARE.CORE.Entities;

namespace TEST_SOFTWARE.CORE.Interfaces.Services
{
    public interface IDirectorioService
    {
        Task<Person> FindPersonByIdentitificacion(string Identificacion);
        Task<List<Person>> FindPersons();
        bool DeletePersonByIdentificacion(string Identificacion);
        Task<Person> CreatePerson(Person person);
    }
}
