using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segundo_Parcial.Entidades
{
    public class Tarea
    {
        [Key]
        public int TareaId { get; set; }
        public string TipoTarea { get; set; }

        [ForeignKey("TareaId")]
        public virtual Tarea tarea{ get; set; }
    }
}