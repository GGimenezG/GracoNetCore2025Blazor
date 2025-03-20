using Data.Models;
using Newtonsoft.Json;
using System.Text;

namespace BlazorApp1.Components.Pages
{
    public partial class CrearPersonaje
    {
        public int id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public int salud { get; set; }
        public int energia { get; set; }
        public int fuerza { get; set; }
        public int inteligencia { get; set; }
        public int agilidad { get; set; }
        public int nivel { get; set; }
        public int defensa { get; set; }
        public int? tipoId { get; set; }
        public string mensaje { get; set; }
        public async void Enviar()
        {
            Personaje personaje = new Personaje();
            personaje.agilidad = agilidad;
            personaje.salud = salud;

            personaje.nombre = nombre;
            personaje.tipoId = tipoId;

            HttpClient httpClient = new HttpClient();
            string urlApi = "https://localhost:7215/api/Personaje";
            var data = new StringContent(JsonConvert.SerializeObject(personaje), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await httpClient.PostAsync(urlApi, data);
            if (httpResponse.IsSuccessStatusCode)
            {
                mensaje = ":) furula";
            }
            else
            {
                mensaje = "): no furula";
            }

        }

        public async void Buscar()
        {
            HttpClient httpClient = new HttpClient();
            string urlApi = $"https://localhost:7215/api/Personaje";
            //var data = new StringContent(JsonConvert.SerializeObject(personaje), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await httpClient.GetAsync(urlApi);
            if (httpResponse.IsSuccessStatusCode)
            {
                List<Personaje> lstPersonaje = new List<Personaje>();

                using (HttpContent content = httpResponse.Content)
                {
                    string data = await content.ReadAsStringAsync();
                    if(data != null)
                        lstPersonaje = JsonConvert.DeserializeObject<List<Personaje>>(data);
                }
                Personaje personaje = lstPersonaje.FirstOrDefault(per => per.id == id);

                if (!String.IsNullOrEmpty(personaje.nombre))
                {
                    nombre = personaje.nombre;
                    salud = personaje.salud;
                    tipoId = personaje.tipoId;
                }

                mensaje = ":) furula";

            }
            else
            {
                mensaje = "): no furula";
            }
        }

        public async void Actualizar()
        {
            Personaje personaje = new Personaje();
            personaje.agilidad = agilidad;
            personaje.salud = salud;

            personaje.nombre = nombre;
            personaje.tipoId = tipoId;

            HttpClient httpClient = new HttpClient();
            string urlApi = "https://localhost:7215/api/Personaje";
            var data = new StringContent(JsonConvert.SerializeObject(personaje), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await httpClient.PostAsync(urlApi, data);
            if (httpResponse.IsSuccessStatusCode)
            {
                mensaje = ":) furula";
            }
            else
            {
                mensaje = "): no furula";
            }

        }

        public async void Eliminar()
        {
            HttpClient httpClient = new HttpClient();
            string urlApi = $"https://localhost:7215/api/Personaje/{id}";
            //var data = new StringContent(JsonConvert.SerializeObject(personaje), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await httpClient.DeleteAsync(urlApi);
            if (httpResponse.IsSuccessStatusCode)
            {
                mensaje = ":) furula";

            }
            else
            {
                mensaje = "): no furula";
            }

        }
    }
}
