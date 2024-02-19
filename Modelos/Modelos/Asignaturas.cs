using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Modelos
{
    public class Asignaturas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDAsignatura { get; set; }

        [StringLength(80)]
        public string? AsigNombre { get; set; }

        [StringLength(150)]
        public string? AsigDescripcion { get; set; }

        public ICollection<Asignaciones>? Asignaciones { get; set; }
    }
}
