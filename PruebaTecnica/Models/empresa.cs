using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaTecnica.Models
{

    public class empresa
    {        
        [JsonProperty("empresa")]
        public Dictionary<string, object> Singles { get; set; }       

    }

    public class sucursal
    {
        [JsonProperty("sucursales")]
        public Dictionary<string, object> Singles { get; set; }

    }
}