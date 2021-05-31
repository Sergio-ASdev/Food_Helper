using Food_helper.Services;
using Food_helper.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Food_helper
{
    public partial class App : Application
    {
        private static ServiceIoC _ServiceLocator;
        public static ServiceIoC ServiceLocator
        {
            get
            {
                return _ServiceLocator = _ServiceLocator
                    ?? new ServiceIoC();
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new MasterdetailView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
