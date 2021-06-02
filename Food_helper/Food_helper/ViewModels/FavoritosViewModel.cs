using Food_helper.Base;
using Food_helper.Repositories;
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
    public class FavoritosViewModel:ViewModelBase
    {
        ServiceRecetas service;
        RepositoryFavoritos repo;
        public FavoritosViewModel(ServiceRecetas service, RepositoryFavoritos repo)
        {
            this.service = service;
            this.repo = repo;
            Recetas = new ObservableCollection<Receta>(repo.GetRecetas());
            MessagingCenter.Subscribe<FavoritosViewModel>(this, "refresh", (sender) =>
            {
                Recetas = new ObservableCollection<Receta>(repo.GetRecetas());
            });
        }
        private ObservableCollection<Receta> _Recetas;
        public ObservableCollection<Receta> Recetas
        {
            get { return this._Recetas; }
            set
            {
                this._Recetas = value;
                OnPropertyChanged("Recetas");
            }
        }
        public Command MostrarReceta
        {
            get
            {
                return new Command(async (receta) => {
                    Receta rec = receta as Receta;
                    DetallesRecetaViewModel viewmodel =
                        App.ServiceLocator.DetallesRecetaViewModel;
                    DetallesRecetaView view = new DetallesRecetaView();
                    List<IngredienteCantidad> ingredientes =
                    await service.GetIngredientesIdReceta(rec.IdReceta);
                    viewmodel.IngredientesCantidad =
                        new ObservableCollection<IngredienteCantidad>(ingredientes);
                    viewmodel.Receta = rec;
                    view.BindingContext = viewmodel;
                    await Application.Current.MainPage.Navigation.PushModalAsync(view);
                });
            }
        }
        public Command Favorito
        {
            get
            {
                return new Command(async (receta) =>
                {
                    repo.InsertReceta(receta as Receta);
                });
            }
        }
        public Command DeleteFavorito
        {
            get
            {
                return new Command(async (receta) =>
                {
                    Receta r = receta as Receta;
                    repo.DeleteReceta(r.IdReceta);
                    Recetas = new ObservableCollection<Receta>(repo.GetRecetas());
                });
            }
        }

    }
}
