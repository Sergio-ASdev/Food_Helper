using Food_helper.Base;
using NuGetFoodHelper.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Food_helper.ViewModels
{
    public class CategoriaViewModel:ViewModelBase
    {
        private Categoria _Categoria;
        public Categoria Categoria
        {
            get
            {
                return this._Categoria;
            }
            set
            {
                this._Categoria = value;
                OnPropertyChanged("Categoria");
            }
        }
        public ObservableCollection<Receta> ListaRecetas { 
            get 
            {
                return this._ListaRecetas;
            }
            set {
                this._ListaRecetas = value;
                OnPropertyChanged("ListaRecetas");
            } 
        }
        private ObservableCollection<Receta> _ListaRecetas;
    }
}
