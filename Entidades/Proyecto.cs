using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segundo_Parcial.Entidades
{
    public class Proyecto
    {
        [Key]
        public int ProyectoId { get; set; }
        public DateTime Fecha { get; set; }
        public string DescripcionProyecto { get; set; }
        public int TiempoTotal { get; set; }

        [ForeignKey("ProyectoId")]
        public List<ProyectoDetalle> Detalle{ get; set; }
    }
}
