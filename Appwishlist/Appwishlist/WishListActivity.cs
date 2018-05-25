﻿using System;
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

namespace Appwishlist
{
    [Activity(Label = "WishlistActivity")]
    public class WishListActivity : ListActivity
    {
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
                HttpResponseMessage response = client.GetAsync("http://api.steampowered.com/ISteamUserStats/GetGlobalStatsForGame/v0001/?format=json&appid=17740&count=1&name%5B0%5D=global.map.emp_isle").Result;

                //Passando retorno da API para uma string
                retorno = response.Content.ReadAsStringAsync().Result;
                dynamic resultado = (JObject)JsonConvert.DeserializeObject(retorno);
                dynamic data = JObject.Parse(retorno);

                //Fragmentando retorno do arquivo json 
                //dynamic resultado = JsonConvert.DeserializeObject(retorno);
            }
            teste[1] = retorno;
            this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, teste);
        }
    }
}