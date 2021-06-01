

using Food_helper.Models;
using NuGetFoodHelper.Models;
using Realms;
using System.Collections.Generic;
using System.Linq;

namespace Food_helper.Repositories
{
    public class RepositoryFavoritos
    {
        private Realm connection;
        public RepositoryFavoritos()
        {
            this.connection = Realm.GetInstance();
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
            using (Transaction trans = this.connection.BeginWrite())
            {
                RecetaFavorita favorita = ConvertToRecetaFavorita(receta);
                connection.Add(favorita);
                trans.Commit();
            }
        }
        public void DeleteReceta(int id)
        {
            Receta receta = GetReceta(id);
            using (Transaction transaction =
                this.connection.BeginWrite())
            {
                this.connection.Remove(ConvertToRecetaFavorita(receta));
                transaction.Commit();
            }

        }
        public Receta GetReceta(int id)
        {
            Receta rec = GetRecetas().FirstOrDefault(x=>x.IdReceta==id);
            return rec;
        }
        public List<Receta> GetRecetas()
        {
            List<RecetaFavorita> recetasfavoritas = connection.All<RecetaFavorita>().ToList();
            List<Receta> recetas = new List<Receta>();
            foreach(RecetaFavorita receta in recetasfavoritas)
            {
                Receta r = ConvertToReceta(receta);
                recetas.Add(r);
            }
            return recetas;
        }
    }
}
