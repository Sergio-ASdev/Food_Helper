using Food_helper.Base;
using Food_helper.Services;
using Food_helper.Views;
using NuGetFoodHelper.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Food_helper.ViewModels
{
    public class ConsejosViewModel:ViewModelBase
    {
        public ServiceRecetas service;
        public ConsejosViewModel(ServiceRecetas service)
        {
            this.service = service;
            Task.Run(async () =>
            {
                List<Consejo> consejos = await service.GetConsejos();
                this.Consejos = new ObservableCollection<Consejo>(consejos);
            });
        }



        private ObservableCollection<Consejo> _Consejos;
        public ObservableCollection<Consejo> Consejos
        {
            get { return this._Consejos; }
            set
            {
                this._Consejos = value;
                OnPropertyChanged("Consejos");
            }
        }




        public Command MostrarConsejo
        {
            get
            {
                return new Command(async (cons) => {
                    Consejo consejo = cons as Consejo;
                    DetalleConsejoViewModel viewmodel =
                    App.ServiceLocator.DetalleConsejoViewModel;
                    DetalleConsejoView view = new DetalleConsejoView();
                    viewmodel.Consejo = consejo;
                    view.BindingContext = viewmodel;
                    await Application.Current.MainPage.Navigation.PushModalAsync(view);
                });
            }
        }
    }
}
