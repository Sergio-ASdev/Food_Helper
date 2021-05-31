using Food_helper.Base;
using Food_helper.Services;
using FoodHelper.Model;
using NuGetFoodHelper.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Food_helper.ViewModels
{
    public class DetallesRecetaViewModel: ViewModelBase
    {
        ServiceRecetas service;
        public DetallesRecetaViewModel(ServiceRecetas service)
        {
            this.service = service;
        }
        private Receta _Receta;
        public Receta Receta
        {
            get { return this._Receta; }
            set {
                this._Receta = value;
                OnPropertyChanged("Receta");
            }
        }
        private ObservableCollection<IngredienteCantidad> _IngredientesCantidad;
        public ObservableCollection<IngredienteCantidad> IngredientesCantidad
        {
            get { return this._IngredientesCantidad; }
            set { this._IngredientesCantidad = value;
                OnPropertyChanged("IngredientesCantidad");
            }
        }
    }
}
