using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaTecnica.Models
{
    public class SucursalModel
    {
        public int sucursalID { get; set; }
        public int empresaID { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
    }
}