using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaTecnica.Models
{
    public class ColaboradorModel
    {
        public int colaboradorID { get; set; }
        public int sucursalID { get; set; }
        public string cui { get; set; }
        public string nombre { get; set; }
    }
}