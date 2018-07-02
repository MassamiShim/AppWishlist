using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Android.Graphics;
using System.Net;
using System;

namespace Appwishlist
{
    public class DataService
    {
        public static async Task<dynamic> getDataFromService(string queryString)
        {
            HttpClient client = new HttpClient();
            //Limpando header
            client.DefaultRequestHeaders.Accept.Clear();
            //Adicionando um novo header do tipo JSON
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response = client.GetAsync(queryString).Result;
            var response = await client.GetAsync(queryString);

            dynamic data = null;
            if (response != null)
            {
                //string json = response.Content.ReadAsStringAsync().Result;
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject(json);
            }

            return data;
        }

        public static Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }

        public static async Task<dynamic> postDataToService(string queryString, string stringData)
        {
            HttpClient client = new HttpClient();
            //Limpando header
            client.DefaultRequestHeaders.Accept.Clear();
            //Adicionando um novo header do tipo JSON
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            //HttpResponseMessage response = client.GetAsync(queryString).Result;
            var response = await client.PostAsync(queryString, contentData);

            dynamic data = null;
            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject(json);
            }

            return data;
        }

        public static async Task<dynamic> putDataToService(string queryString, string stringData)
        {
            HttpClient client = new HttpClient();
            //Limpando header
            client.DefaultRequestHeaders.Accept.Clear();
            //Adicionando um novo header do tipo JSON
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            //HttpResponseMessage response = client.GetAsync(queryString).Result;
            var response = await client.PutAsync(queryString, contentData);

            dynamic data = null;
            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject(json);
            }

            return data;
        }
    }
}