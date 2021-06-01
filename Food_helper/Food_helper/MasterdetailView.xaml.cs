using Food_helper.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Food_helper
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterdetailView : MasterDetailPage
    {
        public MasterdetailView()
        {
            InitializeComponent();
            ObservableCollection<MasterDetailItem> items = 
                new ObservableCollection<MasterDetailItem>();

            var paginaPrincipal= new MasterDetailItem()
            {
                TipoPagina = typeof(MainCategoriasView),
                Titulo = "Inicio"
            };
            var searchrecetas= new MasterDetailItem()
            {
                TipoPagina = typeof(SearchRecetasView),
                Titulo = "Busca tu receta"
            };
            
            items.Add(paginaPrincipal);
            items.Add(searchrecetas);
            this.lisviewMenu.ItemsSource = items;
            this.Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MainCategoriasView)));
            this.lisviewMenu.ItemSelected += LisviewMenu_ItemSelected;
        }

        private void LisviewMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var page = (MasterDetailItem)e.SelectedItem;
            Type tipo = page.TipoPagina;
            this.Detail = new NavigationPage((Page)Activator.CreateInstance(tipo));
            this.IsPresented = false;
        }
    }
}