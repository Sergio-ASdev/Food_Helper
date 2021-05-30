using Food_helper.Base;
using FoodHelper.Model;
using NuGetFoodHelper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Food_helper.ViewModels
{
    public class DetallesRecetaViewModel:ViewModelBase
    {
        private Receta _Receta;
        public Receta Receta
        {
            get { return this._Receta; }
            set {
                this._Receta = value;
                OnPropertyChanged("Receta");
            }
        }
        private List<IngredienteCantidad> _IngredientesCantidad;
        public List<IngredienteCantidad> IngredientesCantidad
        {
            get { return this._IngredientesCantidad; }
            set { this._IngredientesCantidad = value;
                OnPropertyChanged("IngredientesCantidad");
            }
        }
    }
}
