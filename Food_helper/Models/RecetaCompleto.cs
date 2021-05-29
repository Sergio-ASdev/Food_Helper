using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodHelper.Model
{
    public class RecetaCompleto
    {
        public String nombrereceta { get; set; }
        public String tipo { get; set; }
        public List<String> ingrediente { get; set; }
        public List<String> cantidad { get; set; }
        public List<String> nutrientes { get; set; }
        public String ficheroimagen { get; set; }
        public String preparacion { get; set; }
        public int id { get; set; }

    }
}
