using System.ComponentModel.DataAnnotations;

namespace TEST_SOFTWARE.CORE.Entities
{
    public class Person: BaseEntity
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        [Required]
        public string Identificacion { get; set; }
    }
}
