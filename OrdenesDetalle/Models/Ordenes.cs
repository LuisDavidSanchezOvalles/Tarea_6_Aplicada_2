using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrdenesDetalle.Models
{
    public class Ordenes
    {
        [Key]
        [Required(ErrorMessage = "El campo OrdenId no puede estar vacío.")]
        public int OrdenId { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo Fecha no puede estar vacío.")]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        public DateTime Fecha { get; set; }

        [Range(1, 1000000, ErrorMessage = "Debe elegir un suplidor.")]
        public int SuplidorId { get; set; }

        [Required(ErrorMessage = "El campo Monto no puede estar vacio.")]
        public decimal Monto { get; set; }

        [ForeignKey("OrdenId")]
        public virtual List<OrdenesDetalle> OrdenDetalle { get; set; }

        public Ordenes()
        {
            OrdenId = 0;
            Fecha = DateTime.Now;
            SuplidorId = 0;
            Monto = 0;
            OrdenDetalle = new List<OrdenesDetalle>();
        }
    }
}
