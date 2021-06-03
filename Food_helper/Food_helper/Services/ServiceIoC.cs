using Autofac;
using Food_helper.Repositories;
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

            builder.RegisterType<ServiceRecetas>();
            builder.RegisterType<RepositoryFavoritos>();
            builder.RegisterType<MainCategoriasViewModel>();
            builder.RegisterType<RecetasCategoriaViewModel>();
            builder.RegisterType<DetallesRecetaViewModel>();
            builder.RegisterType<SearchRecetasViewModel>();
            builder.RegisterType<FavoritosViewModel>();
            builder.RegisterType<ConsejosViewModel>();
            builder.RegisterType<DetalleConsejoViewModel>();


            this.container = builder.Build();
        }

        public MainCategoriasViewModel MainCategoriasViewModel
        {
            get
            {
                return
                    this.container.Resolve<MainCategoriasViewModel>();
            }
        }
        public DetalleConsejoViewModel DetalleConsejoViewModel
        {
            get
            {
                return
                    this.container.Resolve<DetalleConsejoViewModel>();
            }
        }
        public ConsejosViewModel ConsejosViewModel
        {
            get
            {
                return
                    this.container.Resolve<ConsejosViewModel>();
            }
        }
        public FavoritosViewModel FavoritosViewModel
        {
            get
            {
                return
                    this.container.Resolve<FavoritosViewModel>();
            }
        }
        public RecetasCategoriaViewModel RecetasCategoriaViewModel
        {
            get
            {
                return
                    this.container.Resolve<RecetasCategoriaViewModel>();
            }
        }
        public DetallesRecetaViewModel DetallesRecetaViewModel
        {
            get
            {
                return
                    this.container.Resolve<DetallesRecetaViewModel>();
            }
        }
        public SearchRecetasViewModel SearchRecetasViewModel
        {
            get
            {
                return
                    this.container.Resolve<SearchRecetasViewModel>();
            }
        }
    }
}
