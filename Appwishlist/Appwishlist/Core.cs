using Appwishlist.Classes;
using System;
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
            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            if ((string)results[0]["sucess"] == "true")
            {
                Game game = new Game();
                game.Name = (string)results[0]["data"]["name"];
                game.Steam_appid = (string)results[0]["data"]["steam_appid"];
                game.Detailed_description = (string)results[0]["data"]["detailed_description"];
                game.Header_image = (string)results[0]["data"]["header_image"];
                game.Currency = (string)results[0]["data"]["price_overview"]["currency"];
                game.Initial = (string)results[0]["data"]["price_overview"]["initial"];
                game.Score = (string)results[0]["data"]["metacritic"]["score"];
                game.Categories_description = (string)results[0]["data"]["categories"][0]["description"];
                game.Genres = results[0]["data"]["genres"];


                return game;
            }
            else
                return null;
        }
    }
}