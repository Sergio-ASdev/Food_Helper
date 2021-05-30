using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Food_helper.Base;
using Food_helper.Services;
using Food_helper.Views;
using NuGetFoodHelper.Models;
using Xamarin.Forms;

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
        //private Receta _RecetaSeleccionada;
        //public Receta RecetaSeleccionada
        //{
        //    get { return this._RecetaSeleccionada; }
        //    set
        //    {
        //        this._RecetaSeleccionada = value;
        //        OnPropertyChanged("RecetaSeleccionada");
        //    }
        //}
        //public Command MostrarReceta
        //{
        //    get
        //    {
        //        return new Command( async ()=> {
        //            DetallesRecetaViewModel viewmodel =
        //            new DetallesRecetaViewModel();
        //            viewmodel.Receta = this.RecetaSeleccionada;
        //            List<IngredienteCantidad> ingredientesCantidad =
        //                await service.GetIngredientesIdReceta(RecetaSeleccionada.IdReceta);
        //            viewmodel.IngredientesCantidad = ingredientesCantidad;
        //            viewmodel.Receta = RecetaSeleccionada;
        //            DetallesRecetaView view = new DetallesRecetaView();
        //            view.BindingContext = viewmodel;
        //            await Application.Current.MainPage.Navigation.PushModalAsync(view);
        //        });
        //    }
        //}
      
        
    }
}
