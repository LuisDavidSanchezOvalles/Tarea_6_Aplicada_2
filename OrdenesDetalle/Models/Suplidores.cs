using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrdenesDetalle.Models
{
    public class Suplidores
    {
        [Key]
        public int SuplidorId { get; set; }
        public string Nombres { get; set; }

        public Suplidores()
        {
            SuplidorId = 0;
            Nombres = string.Empty;
        }
    }
}
