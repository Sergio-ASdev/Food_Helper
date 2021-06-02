using Food_helper.Base;
using Food_helper.Repositories;
using Food_helper.Services;
using Food_helper.Views;
using NuGetFoodHelper.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Food_helper.ViewModels
{
    public class SearchRecetasViewModel:ViewModelBase
    {
        ServiceRecetas service;
        RepositoryFavoritos repo;
        public SearchRecetasViewModel(ServiceRecetas service,RepositoryFavoritos repo)
        {
            this.repo = repo;
            this.service = service;
            Task.Run(async ()=> {
                Recetas = await service.GetRecetas();
            });
        }
        private String _Busqueda;
        public String Busqueda
        {
            get
            {
                return this._Busqueda;
            }
            set
            {
                this._Busqueda = value;
                OnPropertyChanged("Busqueda");
            }
        }
        private ObservableCollection<Receta> _FilteredRecetas;
        public ObservableCollection<Receta> FilteredRecetas
        {
            get
            {
                return this._FilteredRecetas;
            }
            set
            {
                this._FilteredRecetas = value;
                OnPropertyChanged("FilteredRecetas");
            }
        }
        private List<Receta> _Recetas;
        public List<Receta> Recetas
        {
            get
            {
                return this._Recetas;
            }
            set
            {
                this._Recetas = value;
            }
        }

        public ICommand PerformSearch => new Command<string>((string query) =>
        {
            FilteredRecetas = new ObservableCollection<Receta>(
                Recetas.Where(o => o.NombreReceta.ToLower().Contains(query.ToLower())));
        });

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
                    Receta r = receta as Receta;
                    if (repo.GetReceta(r.IdReceta) != null)
                    {
                        await Application.Current.MainPage.DisplayAlert("Favoritos"
                            , r.NombreReceta + "ya se encuentra en tu lista de favoritos", "OK");
                    }
                    else
                    {
                        repo.InsertReceta(r);
                        MessagingCenter.Send(App.ServiceLocator.FavoritosViewModel
                        , "refresh");
                        await Application.Current.MainPage.DisplayAlert("Favoritos"
                        , r.NombreReceta + " añadido a tu lista de favoritos", "OK");

                    }
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
                    MessagingCenter.Send(App.ServiceLocator.FavoritosViewModel
                , "refresh");
                    await Application.Current.MainPage.DisplayAlert("Favoritos"
                        , r.NombreReceta + "eliminado de tu lista de favoritos", "OK");
                });
            }
        }

    }
}
