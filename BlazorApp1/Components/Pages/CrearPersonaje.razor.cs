using BlazorApp1.Data;
using Core.Entities;
using Data.Models;
using Newtonsoft.Json;
using System.Text;

namespace BlazorApp1.Components.Pages
{
    public partial class CrearPersonaje
    {
        public PersonajeDTO personaje = new();
        public string mensaje { get; set; }
        public async void Enviar()
        {
            //validar lo que ya tengo en la entidad personaje

            string urlApi = "Personaje";
            var respuesta = await Consumer.Execute<Personaje, PersonajeDTO>(urlApi, methodHttp.POST, personaje);
            if (respuesta.Ok)
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
            try
            {

                string urlApi = $"Personaje";
                //var data = new StringContent(JsonConvert.SerializeObject(personaje), Encoding.UTF8, "application/json");
                var respuesta = await Consumer.Execute<List<Personaje>>(urlApi, methodHttp.GET, null);

                if (respuesta.Ok)
                {
                    List<Personaje> lstPersonaje = respuesta.Data;

                    Personaje personajeResponse = lstPersonaje.FirstOrDefault(per => per.id == personaje.id);

                    if (personajeResponse == null)
                        throw new Exception("Persoanje no existe");

                    if (!String.IsNullOrEmpty(personajeResponse.nombre))
                    {
                        personaje.nombre = personajeResponse.nombre;
                        personaje.salud = personajeResponse.salud.valor;
                        personaje.tipoId = personajeResponse.tipoId;
                    }

                    mensaje = ":) furula";

                }
                else
                {
                    mensaje = "): no furula";
                }
            }
            catch(Exception ex)
            {
                mensaje = ex.Message;
            }
            StateHasChanged();
        }

        public async void Actualizar()
        {
            

            string urlApi = "Personaje";
            var respuesta = await Consumer.Execute<Personaje,PersonajeDTO>(urlApi, methodHttp.PUT, personaje);
            if (respuesta.Ok)
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


            string urlApi = $"/Personaje/{personaje.id}";

            var respuesta = await Consumer.Execute<string>(urlApi,methodHttp.DELETE, null);
            if (respuesta.Ok)
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
