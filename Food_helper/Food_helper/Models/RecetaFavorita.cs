using NuGetFoodHelper.Models;
using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Food_helper.Models
{
    public class RecetaFavorita:RealmObject
    {
        public int IdReceta { get; set; }
        public string NombreReceta { get; set; }
        public string Tipo { get; set; }
        public string Nutrientes { get; set; }
        public string Imagen { get; set; }
        public string Preparacion { get; set; }
        public string Validada { get; set; }
    }
}
