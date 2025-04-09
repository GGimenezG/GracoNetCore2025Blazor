using Core.Entities;
using Data.Models;

namespace BlazorApp1.Data.Services
{
    public class PersonajeService
    {
        const string url = "Personaje";
        public async Task<Response<Personaje>> CrearPersonaje(PersonajeDTO personaje)
        {
            Response<Personaje> response = new Response<Personaje>();

            try
            {
                response = await
                    Consumer
                    .Execute<Personaje, PersonajeDTO>(
                        url,
                        methodHttp.POST,
                        personaje)
                    ;

                return response;
            }
            catch (Exception ex)
            {

            }
            return response;
        }

        public async Task<Response<Personaje>> ActualizarPersonaje(PersonajeDTO personaje)
        {
            Response<Personaje> response = new Response<Personaje>();

            try
            {
                response = (await
                    Consumer
                    .Execute<Personaje, PersonajeDTO>(
                        url,
                        methodHttp.PUT,
                        personaje)
                    );

                return response;
            }
            catch (Exception ex)
            {

            }
            return response;
        }

        public async Task<Response<List<Personaje>>> GetAll()
        {
            Response<List<Personaje>> response = new Response<List<Personaje>>();
            List<Personaje> lstPersonajes = new List<Personaje>();
            try
            {

                response = await Consumer
                    .Execute<List<Personaje>>(
                        url,
                        methodHttp.GET,
                        lstPersonajes
                    );

            }
            catch (Exception ex)
            {

            }
            return response;
        }

        public async Task<Response<Personaje>> Get(int id)
        {
            Response<Personaje> response = new Response<Personaje>();
            try
            {

                response = await Consumer
                    .Execute<Personaje>(
                        $"{url}/{id}",
                        methodHttp.GET,
                        null
                    );

            }
            catch (Exception ex)
            {

            }
            return response;
        }

        public async Task<Response<Personaje>> Delete(int id)
        {
            Response<Personaje> response = new Response<Personaje>();
            try
            {

                response = await Consumer
                    .Execute<Personaje>(
                        $"{url}/{id}",
                        methodHttp.DELETE,
                        null
                    );

            }
            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
