using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Food_helper.Base;
using Food_helper.Services;
using NuGetFoodHelper.Models;

namespace Food_helper.ViewModels
{
    public class ListaRecetasCategoriaModel: ViewModelBase
    {
        public ServiceRecetas service;
        public ListaRecetasCategoriaModel()
        {
            this.service = new ServiceRecetas();
            
        }
        private ObservableCollection<Receta> _Recetas;
        public ObservableCollection<Receta> Recetas
        {
            get { return this._Recetas;  }
            set 
            {
                this._Recetas = value;
                OnPropertyChanged("Recetas");
            }
        }
      
        
    }
}
