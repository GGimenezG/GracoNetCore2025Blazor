using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Data
{
    public class Consumer
    {
        public static HttpMethod MapearMetodo(methodHttp method)
        {
            switch (method)
            {
                case methodHttp.GET:
                    return HttpMethod.Get;
                case methodHttp.POST:
                    return HttpMethod.Post;
                case methodHttp.PUT:
                    return HttpMethod.Put;
                case methodHttp.DELETE:
                    return HttpMethod.Delete;
                default:
                    throw new NotImplementedException("Verbo http no implementado");
            }
        }
        public static async Task<Response<T>> Execute<T>(string endpoint, methodHttp methodHttp, T Data)
        {
            string urlBaseApi = "http://gracosoftnet2025.runasp.net/api/";
            Response<T> response = new();
            try
            {
                // Instancia de la clase HttpClient
                using (HttpClient client = new HttpClient())
                {
                    // URL
                    string url = @$"{urlBaseApi}{endpoint}";
                    //Data - informacion a mandar
                    string dataString = JsonConvert.SerializeObject(methodHttp != methodHttp.GET ? methodHttp != methodHttp.DELETE ? Data : "" : "");
                    var byteContent = new ByteArrayContent(Encoding.UTF8.GetBytes(dataString));
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    //var content = new StringContent(dataString, Encoding.UTF8, "application/json");
                    // Hacer la peticion

                    //el tipo de peticion 
                    var request = new HttpRequestMessage(MapearMetodo(methodHttp), url)
                    {
                        Content = methodHttp != methodHttp.GET ? methodHttp != methodHttp.DELETE ? byteContent : null : null
                    }; 
                    //request.Content = byteContent;

                    using(HttpResponseMessage responseApi = await client.SendAsync(request))
                    {
                        using(HttpContent content = responseApi.Content)
                        {
                            string dataResponse = await content.ReadAsStringAsync();
                            if (dataResponse != null)
                                response.Data = JsonConvert.DeserializeObject<T>(dataResponse);
                            response.StatusCode = responseApi.StatusCode.ToString();
                            response.Ok = true;
                        }

                    };
                }



            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
    }
}
