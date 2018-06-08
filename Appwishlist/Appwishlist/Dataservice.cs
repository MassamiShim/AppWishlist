using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace Appwishlist
{
    public class DataService
    {
        public static  Task<dynamic> getDataFromService(string queryString)
        {
            HttpClient client = new HttpClient();
            //Limpando header
            client.DefaultRequestHeaders.Accept.Clear();
            //Adicionando um novo header do tipo JSON
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(queryString).Result;
            //var response = await client.GetAsync(queryString);

            dynamic data = null;
            if (response != null)
            {
                //string json = response.Content.ReadAsStringAsync().Result;
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject(json);
            }

            return data;
        }
    }
}