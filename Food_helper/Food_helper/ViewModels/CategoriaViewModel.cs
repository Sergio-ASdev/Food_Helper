using Food_helper.Base;
using Food_helper.Services;
using Food_helper.Views;
using NuGetFoodHelper.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Food_helper.ViewModels
{
    public class CategoriaViewModel:ViewModelBase
    {
        public ServiceRecetas service;
        public CategoriaViewModel()
        {
            service = new ServiceRecetas();
        }
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
        private Receta _RecetaSeleccionada;
        public Receta RecetaSeleccionada
        {
            get { return this._RecetaSeleccionada; }
            set
            {
                this._RecetaSeleccionada = value;
                OnPropertyChanged("RecetaSeleccionada");
            }
        }
        public Command MostrarReceta
        {
            get
            {
                return new Command(async () => {
                    DetallesRecetaViewModel viewmodel =
                    new DetallesRecetaViewModel();
                    viewmodel.Receta = this.RecetaSeleccionada;
                    List<IngredienteCantidad> ingredientesCantidad =
                        await service.GetIngredientesIdReceta(RecetaSeleccionada.IdReceta);
                    viewmodel.IngredientesCantidad = ingredientesCantidad;
                    viewmodel.Receta = RecetaSeleccionada;
                    DetallesRecetaView view = new DetallesRecetaView();
                    view.BindingContext = viewmodel;
                    await Application.Current.MainPage.Navigation.PushModalAsync(view);
                });
            }
        }
    }
}
