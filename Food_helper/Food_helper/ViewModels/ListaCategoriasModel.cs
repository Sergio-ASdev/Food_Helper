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
    public class ListaCategoriasModel : ViewModelBase
    {
        public ServiceRecetas service;
        public ListaCategoriasModel()
        {
            this.service = new ServiceRecetas();
            Task.Run(async () =>
            {
                List<Categoria> categorias = await service.GetCategorias();
                this.Categorias = new ObservableCollection<Categoria>(categorias);
            });
        }
        private ObservableCollection<Categoria> _Categorias;
        public ObservableCollection<Categoria> Categorias
        {
            get { return this._Categorias; }
            set
            {
                this._Categorias = value;
                OnPropertyChanged("Categorias");
            }
        }
        private Categoria _CategoriaSeleccionada;
        public Categoria CategoriaSeleccionada
        {
            get { return this._CategoriaSeleccionada; }
            set
            {
                this._CategoriaSeleccionada = value;
                OnPropertyChanged("CategoriaSeleccionada");
            }
        }
        public Command ShowRecetasCategoria
        {
            get
            {
                return new Command(async () =>
                {
                    CategoriaViewModel viewmodel =
                    new CategoriaViewModel();
                    viewmodel.Categoria = this.CategoriaSeleccionada;
                    List<Receta> recetas = await service.GetRecetasCategoria(this.CategoriaSeleccionada.Nombre);
                    ObservableCollection<Receta> ocrecetas = new ObservableCollection<Receta>(recetas);
                    viewmodel.ListaRecetas = ocrecetas;
                    ListaRecetasPorCategoria view = new ListaRecetasPorCategoria();
                    view.BindingContext = viewmodel;
                    await Application.Current.MainPage.Navigation.PushModalAsync(view);
                });
            }
        }
    }
}



