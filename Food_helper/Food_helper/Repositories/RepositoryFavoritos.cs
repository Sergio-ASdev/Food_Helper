

using Food_helper.Models;
using NuGetFoodHelper.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Food_helper.Repositories
{
    public class RepositoryFavoritos
    {
        SQLiteConnection cn;

        public RepositoryFavoritos()
        {
            this.cn =
            DependencyService.Get<IDataBase>().GetConnection();
            CrearBBDD();

        }
        public void CrearBBDD()
        {
            
            var tableinfo = this.cn.GetTableInfo("RECETAS");

            if(tableinfo.Count == 0)
            {
                this.cn.DropTable<RecetaFavorita>();
                this.cn.CreateTable<RecetaFavorita>();

            }
            
        }
        public RecetaFavorita ConvertToRecetaFavorita(Receta receta)
        {
            RecetaFavorita favorita = new RecetaFavorita()
            {
                IdReceta = receta.IdReceta,
                Imagen = receta.Imagen,
                NombreReceta = receta.NombreReceta,
                Nutrientes = receta.Nutrientes,
                Preparacion = receta.Preparacion,
                Tipo = receta.Tipo,
                Validada = receta.Validada
            };
            return favorita;
        }
        public Receta ConvertToReceta(RecetaFavorita receta)
        {
            Receta rec = new Receta()
            {
                IdReceta = receta.IdReceta,
                Imagen = receta.Imagen,
                NombreReceta = receta.NombreReceta,
                Nutrientes = receta.Nutrientes,
                Preparacion = receta.Preparacion,
                Tipo = receta.Tipo,
                Validada = receta.Validada
            };
            return rec;
        }
        public void InsertReceta(Receta receta)
        {
            cn.Insert(ConvertToRecetaFavorita(receta));
        }
        public void DeleteReceta(int id)
        {
            RecetaFavorita receta = ConvertToRecetaFavorita(GetReceta(id));
            cn.Delete(receta);
        }
        public Receta GetReceta(int id)
        {
            var query = from datos in this.cn.Table<RecetaFavorita>()
                        where datos.IdReceta == id
                        select datos;
            if (query.FirstOrDefault() != null)
            {
                return ConvertToReceta(query.FirstOrDefault());
            }
            else
            {
                return null;
            }
        }
        public List<Receta> GetRecetas()
        {
            var query = from datos in this.cn.Table<RecetaFavorita>()
                        select datos;
            List<Receta> recetas = new List<Receta>();
            foreach(RecetaFavorita r in query.ToList())
            {
                Receta receta = ConvertToReceta(r);
                recetas.Add(receta);
            }
            return recetas;
        }
    }
}
