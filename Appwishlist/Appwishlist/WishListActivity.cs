using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

using System.Net.Http;
using Newtonsoft.Json.Linq;
using Android.Service.Autofill;

namespace Appwishlist
{
    [Activity(Label = "WishlistActivity")]
    public class WishListActivity : ListActivity
    {
        /*TEST
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            var teste = new string[2];
            teste[0] = "1";

            string retorno;

            //Chamando API para cadastrar o usuário na base 
            using (HttpClient client = new HttpClient())
            {
                //Setando endereço da API
                client.BaseAddress = new System.Uri("http://localhost:82/AlienTorpedo/api/sorteio");
                //Limpando header
                client.DefaultRequestHeaders.Accept.Clear();
                //Adicionando um novo header do tipo JSON
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                ////Transformando obj Usuario em uma string
                //string stringData = JsonConvert.SerializeObject(grupoEvento);

                ////Transformando string em um arquivo do tipo JSON
                //var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

                //Chamando API passando o arquivo JSON
                //HttpResponseMessage response = client.GetAsync("http://reddit.com").Result;
                //HttpResponseMessage response = client.GetAsync("http://api.steampowered.com/ISteamNews/GetNewsForApp/v0002/?appid=440&count=3&maxlength=300&format=json").Result;
                //HttpResponseMessage response = client.GetAsync("http://api.steampowered.com/ISteamUserStats/GetGlobalStatsForGame/v0001/?format=json&appid=17740&count=1&name%5B0%5D=global.map.emp_isle").Result;
                HttpResponseMessage response = client.GetAsync("https://store.steampowered.com/api/appdetails?appids=10").Result;

                //Passando retorno da API para uma string
                retorno = response.Content.ReadAsStringAsync().Result;
                dynamic resultado = JsonConvert.DeserializeObject(retorno);

                //dynamic lol = resultado["appnews"]["newsitems"][0]["contents"];
                dynamic lol = resultado["response"]["globalstats"]["global.map.emp_isle"]["total"];
                teste[0] = lol;

                //foreach (var obj in resultado)
                //{
                //    teste[0] = obj;
                //}

                //Fragmentando retorno do arquivo json 
                //dynamic resultado = JsonConvert.DeserializeObject(retorno);
            }
            teste[1] = retorno;
            this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, teste);
        }
        */
        string[] items;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //SetContentView(Resource.Layout.wishlist_main);

            items = new string[] {"TESTE 0", "TESTE 1", "TESTE 2" };

            //ListView list = FindViewById<ListView>(Resource.Id.list);
            this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items);
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            var t = items[position];
            //Android.Widget.Toast.MakeText(this, t, Android.Widget.ToastLength.Short).Show();

            var intent = new Intent(this, typeof(GameActivity));
            //intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
            intent.PutExtra("gameId", position*10);
            StartActivity(intent);
        }
    }
}