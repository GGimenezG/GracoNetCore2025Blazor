using Core.Entities;
using Data.Models;
namespace BlazorApp1.Data.Services
{
    public class AuthService
    {
        const string url = "User";
        public async Task<Response<string>> Login(User usuario)
        {
            Response<string> response = new Response<string>();

            try
            {
                response = await
                    Consumer
                    .Execute<string, User>(
                        $"{url}/Login",
                        methodHttp.POST,
                        usuario)
                    ;

                return response;
            }
            catch (Exception ex)
            {
            }
            return response;
        }
    }
}
