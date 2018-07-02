using Appwishlist.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appwishlist
{
    public class Core
    {
        public static async Task<Weather> GetWeather(string zipCode)
        {
            //Sign up for a free API key at http://openweathermap.org/appid  
            string key = "e47a8916649e524715bcfe315ecb4afa";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?zip="
                + zipCode + ",us&appid=" + key + "&units=imperial";

            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            if (results["weather"] != null)
            {
                Weather weather = new Weather();
                weather.Title = (string)results["name"];
                weather.Temperature = (string)results["main"]["temp"] + " F";
                weather.Wind = (string)results["wind"]["speed"] + " mph";
                weather.Humidity = (string)results["main"]["humidity"] + " %";
                weather.Visibility = (string)results["weather"][0]["main"];

                DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
                weather.Sunrise = sunrise.ToString() + " UTC";
                weather.Sunset = sunset.ToString() + " UTC";
                return weather;
            }
            else
            {
                return null;
            }
        }

        public static async Task<Game> GetGame(string idGame)
        {
            string queryString = "https://store.steampowered.com/api/appdetails?appids=" + idGame;

            //string key = "e47a8916649e524715bcfe315ecb4afa";
            //queryString = "http://api.openweathermap.org/data/2.5/weather?zip="
            //    + idGame + ",us&appid=" + key + "&units=imperial";
            //http://api.openweathermap.org/data/2.5/weather?zip=60610,us&appid=e47a8916649e524715bcfe315ecb4afa&units=imperial

            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            //if (results[idGame]["data"]["metacritic"] != null) { 
            //    Console.WriteLine("SUP!");
            //}

            if ((string)results[idGame]["success"] == "True")
            {
                if ((string)results[idGame]["data"]["type"] == "game")
                {

                    Game game = new Game();
                    game.Name = (string)results[idGame]["data"]["name"];
                    game.Steam_appid = (string)results[idGame]["data"]["steam_appid"];
                    game.Detailed_description = (string)results[idGame]["data"]["detailed_description"];
                    game.Header_image = (string)results[idGame]["data"]["header_image"];
                    game.Currency = (string)results[idGame]["data"]["price_overview"]["currency"];
                    game.Initial = (string)results[idGame]["data"]["price_overview"]["initial"];
                    //There's cases where the value does not exists
                    if (results[idGame]["data"]["metacritic"] != null)
                    {
                        game.Score = (string)results[idGame]["data"]["metacritic"]["score"];
                    }
                    else
                    {
                        game.Score = "N/A";
                    }
                    game.Categories_description = (string)results[idGame]["data"]["categories"][0]["description"];
                    //game.Genres = results[idGame]["data"]["genres"];

                    var teste = results[idGame]["data"]["genres"][0];
                    Genre genre = new Genre((string)teste["id"], (string)teste["description"]);

                    return game;
                }
                else
                {
                    return null;
                }
            }
            else
                return null;
        }

        public static async Task<List<Wishlist>> GetUserlist(string idList)
        {
            string queryString = "http://10.0.2.2:64146/api/userlists/Getlist/" + idList;
            List<Wishlist> wishlists = new List<Wishlist>();
            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);
            //results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            //TODO
            //Search an optimal way to convert the data to the list
            if (results != null)
            {
                foreach(object teste in results.data)
                {
                    wishlists.Add(JsonConvert.DeserializeObject<Wishlist>(teste.ToString()));
                }
                //Wishlist teste = JsonConvert.DeserializeObject<Wishlist>(results.data[0].ToString());
            }
                return wishlists;
        }

        public static async Task<int> AddProduct(Product product)
        {
            string queryString = "http://10.0.2.2:64146/api/Products/";

            string stringData = JsonConvert.SerializeObject(product);

            dynamic results = await DataService.postDataToService(queryString, stringData).ConfigureAwait(false);

            if (results != null)
                return 1;

            return 0;
        }

        public static async Task<Product> GetProduct(int id)
        {
            string queryString = "http://10.0.2.2:64146/api/Products/"+id.ToString();

            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            Product product = new Product();

            if (results != null)
                product = JsonConvert.DeserializeObject<Product>(results.ToString());

            return product;
        }

        public static async Task<int> UpdateProduct(Product product)
        {
            string queryString = "http://10.0.2.2:64146/api/Products/";

            string stringData = JsonConvert.SerializeObject(product);

            dynamic results = await DataService.postDataToService(queryString, stringData).ConfigureAwait(false);

            if (results != null)
                return 1;

            return 0;
        }
    }
}