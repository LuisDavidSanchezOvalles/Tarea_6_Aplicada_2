using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrdenesDetalle.Models
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public int Inventario { get; set; }

        public Productos()
        {
            ProductoId = 0;
            Descripcion = string.Empty;
            Costo = 0;
            Inventario = 0;
        }
    }
}
