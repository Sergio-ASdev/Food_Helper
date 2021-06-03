using Food_helper.Base;
using Food_helper.Services;
using NuGetFoodHelper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Food_helper.ViewModels
{
    public class DetalleConsejoViewModel:ViewModelBase
    {
        ServiceRecetas service;
        public DetalleConsejoViewModel(ServiceRecetas service)
        {
            this.service = service;
        }
        private Consejo _Consejo;
        public Consejo Consejo
        {
            get { return this._Consejo; }
            set
            {
                this._Consejo = value;
                OnPropertyChanged("Consejo");
            }
        }
    }
}
