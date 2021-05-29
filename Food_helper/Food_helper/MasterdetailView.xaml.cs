﻿using Food_helper.Views;
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
            var paginaRecetas = new MasterDetailItem()
            {
                TipoPagina = typeof(ListaRecetasPorCategoria),
                Titulo = "Descubre nuestras recetas"
            };
            var paginaPrincipal= new MasterDetailItem()
            {
                TipoPagina = typeof(Main),
                Titulo = "Inicio"
            };
            items.Add(paginaRecetas);
            items.Add(paginaPrincipal);
            this.lisviewMenu.ItemsSource = items;
            this.Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Main)));
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