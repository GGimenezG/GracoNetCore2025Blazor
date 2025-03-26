using BlazorApp1.Data;
using Core.Entities;
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
            PersonajeDTO personaje = new PersonajeDTO();
            personaje.agilidad = agilidad;
            personaje.salud = salud;

            personaje.nombre = nombre;
            personaje.tipoId = tipoId;

            string urlApi = "Personaje";
            var respuesta = await Consumer.Execute<PersonajeDTO>(urlApi, methodHttp.POST, personaje);
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
            string urlApi = $"Personaje";
            //var data = new StringContent(JsonConvert.SerializeObject(personaje), Encoding.UTF8, "application/json");
            var respuesta = await Consumer.Execute<List<Personaje>>(urlApi, methodHttp.GET, null);

            if (respuesta.Ok)
            {
                List<PersonajeDTO> lstPersonaje = respuesta.Data;

                PersonajeDTO personaje = lstPersonaje.FirstOrDefault(per => per.id == id);

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
            PersonajeDTO personaje = new PersonajeDTO();
            personaje.agilidad = agilidad;
            personaje.salud = salud;

            personaje.nombre = nombre;
            personaje.tipoId = tipoId;


            string urlApi = "Personaje";
            var respuesta = await Consumer.Execute<PersonajeDTO>(urlApi, methodHttp.PUT, personaje);
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


            string urlApi = $"/Personaje/{id}";

            var respuesta = await Consumer.Execute<PersonajeDTO>(urlApi,methodHttp.DELETE, null);
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
