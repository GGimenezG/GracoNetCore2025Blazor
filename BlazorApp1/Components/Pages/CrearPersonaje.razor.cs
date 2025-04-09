using BlazorApp1.Data;
using BlazorApp1.Data.Services;
using Core.Entities;

//using Core.Entities;
using Data.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Text;

namespace BlazorApp1.Components.Pages
{
    public partial class CrearPersonaje
    {
        public PersonajeDTO personaje = new();
        public string mensaje { get; set; }

        [Inject]
        public PersonajeService service { get; set; }

        public async void Enviar()
        {
           
            var respuesta = await service.CrearPersonaje(personaje);

           
            if (respuesta.Ok)
            {
                mensaje = respuesta.Message;
            }
            else
            {
                mensaje = respuesta.Message;
            }

        }

        public async void Buscar()
        {
            try
            {
                var respuesta = await service.Get(personaje.id);
                if (respuesta.Ok)
                {
                    if (respuesta.Data == null)
                        throw new Exception("Persoanje no existe");

                    if (!String.IsNullOrEmpty(respuesta.Data.nombre))
                    {
                        personaje.nombre = respuesta.Data.nombre;
                        personaje.salud = respuesta.Data.salud.valor;
                        personaje.tipoId = respuesta.Data.tipoId;
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

            var respuesta = await service.ActualizarPersonaje(personaje);
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

            var respuesta = await service.Delete(personaje.id);
            if (respuesta.Ok)
            {
                mensaje = ":) furula";

            }
            else
            {
                mensaje = respuesta.Message;
            }
            StateHasChanged();
        }
    }
}
