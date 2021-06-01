using Newtonsoft.Json;
using NuGetFoodHelper.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Food_helper.Services
{
    public class ServiceRecetas
    {
        private String url;
        public ServiceRecetas()
        {
            this.url = "https://apifoodhelper.azurewebsites.net/"; ;
        }
        private async Task<T> CallApi<T>(String request)
        {
            Uri uri = new Uri(url + request);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    String json = await response.Content.ReadAsStringAsync();
                    T data = JsonConvert.DeserializeObject<T>(json);
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }
        public async Task<List<Categoria>> GetCategorias()
        {
            String request = "/api/Categorias/GetCategorias";
            List<Categoria> categorias = await CallApi<List<Categoria>>(request);
            return categorias;
        }
        public async Task<List<Receta>> GetRecetasCategoria(String tipo)
        {
            String request = "/api/Recetas/GetRecetasTipo/" + tipo;
            List<Receta> recetas = await CallApi<List<Receta>>(request);
            return recetas;
        }
        public async Task<List<IngredienteCantidad>> GetIngredientesIdReceta(int idReceta)
        {
            String request = "/api/Ingredientes/GetIngredientesIdReceta/"+idReceta;
            List<IngredienteCantidad> ingredientesCantidad = 
                await CallApi<List<IngredienteCantidad>>(request);
            return ingredientesCantidad;
        }
        public async Task<List<Receta>> GetRecetas()
        {
            String request = "/api/Recetas/GetRecetas";
            List<Receta> recetas = 
                await CallApi<List<Receta>>(request);
            return recetas;
        }
    }
}
