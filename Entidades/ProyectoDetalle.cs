using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segundo_Parcial.Entidades
{
    public class ProyectoDetalle
    {
        [Key]
        public int TipoId { get; set; }
        public string TipoTarea { get; set; }
        public string Requerimentos { get; set; }
        public int Tiempo { get; set; }
    }
}
