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
    public class MainCategoriasViewModel : ViewModelBase
    {
        public ServiceRecetas service;
        public MainCategoriasViewModel(ServiceRecetas service)
        {
            this.service = service;
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
       
        public async void LoadCategorias()
        {
            List<Categoria> categorias = await service.GetCategorias();
            this.Categorias = new ObservableCollection<Categoria>(categorias);
        }
        public Command ShowRecetasCategoria
        {
            get
            {
                return new Command(async (categoria) =>
                {
                    Categoria cat = categoria as Categoria;
                    RecetasCategoriaViewModel viewmodel = 
                        App.ServiceLocator.RecetasCategoriaViewModel;
                    RecetasCategoriaView view = new RecetasCategoriaView();
                    List<Receta> recetas = await service.GetRecetasCategoria(cat.Nombre);
                    viewmodel.Recetas = new ObservableCollection<Receta>(recetas);
                    view.BindingContext = viewmodel;
                    await Application.Current.MainPage.Navigation.PushModalAsync(view);
                  
                });
            }
        }
    }
}



