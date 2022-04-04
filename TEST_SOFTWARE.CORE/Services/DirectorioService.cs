using System.Collections.Generic;
using System.Threading.Tasks;
using TEST_SOFTWARE.CORE.Entities;
using TEST_SOFTWARE.CORE.Interfaces.Respositories;
using TEST_SOFTWARE.CORE.Interfaces.Services;

namespace TEST_SOFTWARE.CORE.Services
{
    public class DirectorioService : IDirectorioService
    {
        private readonly IDirectorio _directorio;
        public DirectorioService(IDirectorio directorio)
        {
            _directorio = directorio;
        }
        public async Task<Person> CreatePerson(Person person)
        {
            return await _directorio.CreatePerson(person);
        }

        public bool DeletePersonByIdentificacion(string Identificacion)
        {
            return _directorio.DeletePersonByIdentificacion(Identificacion);
        }

        public async Task<Person> FindPersonByIdentitificacion(string Identificacion)
        {
            return await _directorio.FindPersonByIdentitificacion(Identificacion);
        }

        public async Task<List<Person>> FindPersons()
        {
            return await _directorio.FindPersons();
        }
    }
}
