using Food_helper.Base;
using Food_helper.Services;
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
        public SearchRecetasViewModel(ServiceRecetas service)
        {
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
    }
}
