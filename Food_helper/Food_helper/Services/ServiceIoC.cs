using Autofac;
using Food_helper.ViewModels;
using Food_helper.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Food_helper.Services
{
    public class ServiceIoC
    {
        // IContainer using de Autofac
        private IContainer container;

        public ServiceIoC()
        {
            this.RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            ContainerBuilder builder = new ContainerBuilder();
            //REGISTRAMOS TODAS LAS CLASES QUE TENGAN
            //INYECCION DE DEPENDENCIAS
            // builder.RegisterType<RepositoryListaRecetas>();
            builder.RegisterType<ListaRecetasPorCategoria>();
            //CREAMOS EL CONTENEDOR
            this.container = builder.Build();
        }

        public ListaRecetasCategoriaModel ListaRecetasModel
        {
            get
            {
                return
                    this.container.Resolve<ListaRecetasCategoriaModel>();
            }
        }
    }
}
