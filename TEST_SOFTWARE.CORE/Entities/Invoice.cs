using System;
using System.ComponentModel.DataAnnotations;

namespace TEST_SOFTWARE.CORE.Entities
{
    public class Invoice: BaseEntity
    {
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public double Monto { get; set; }
    }
}
