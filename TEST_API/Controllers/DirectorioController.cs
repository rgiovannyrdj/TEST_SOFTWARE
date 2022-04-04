using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TEST_SOFTWARE.CORE.Entities;
using TEST_SOFTWARE.CORE.Interfaces.Services;
using TEST_SOFTWARE.CORE.Response;

namespace TEST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorioController : ControllerBase
    {
        private readonly IDirectorioService _service;
        public DirectorioController(IDirectorioService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePerson(Person person)
        {
            ApiResponse<Person> apiResponse = new ApiResponse<Person>();
            try
            {
                person = await _service.CreatePerson(person);
                apiResponse.Data = person;
                apiResponse.SetSuccess();
            }
            catch (Exception ex)
            {
                apiResponse.SetException(ex);
            }
            return Ok(apiResponse);
        }
        [HttpDelete("{Identificacion}")]
        public IActionResult DeletePersonByIdentificacion(string Identificacion)
        {
            ApiResponse<bool> apiResponse = new ApiResponse<bool>();
            try
            {
                apiResponse.Data = _service.DeletePersonByIdentificacion(Identificacion);
                apiResponse.SetSuccess();
            }
            catch (Exception ex)
            {
                apiResponse.SetException(ex);
            }
            return Ok(apiResponse);
        }
        [HttpGet("{Identificacion}")]
        public async Task<IActionResult> FindPersonByIdentitificacion(string Identificacion)
        {
            ApiResponse<Person> apiResponse = new ApiResponse<Person>();
            try
            {
                apiResponse.Data = await _service.FindPersonByIdentitificacion(Identificacion);
                apiResponse.SetSuccess();
            }
            catch (Exception ex)
            {
                apiResponse.SetException(ex);
            }

            return Ok(apiResponse);
        }
        [HttpGet]
        public async Task<IActionResult> FindPersons()
        {
            ApiResponse<List<Person>> apiResponse = new ApiResponse<List<Person>>();

            try
            {
                apiResponse.Data = await _service.FindPersons();
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
