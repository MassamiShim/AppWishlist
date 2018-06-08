using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Appwishlist.Classes;

namespace Appwishlist
{
    [Activity(Label = "Sample Weather App", Theme = "@style/AppTheme.NoActionBar",  MainLauncher = true)]//, Icon = "@drawable/icon")]
    public class WeatherActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.weatherBtn);

            button.Click += Button_Click;
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            EditText zipCodeEntry = FindViewById<EditText>(Resource.Id.zipCodeEntry);

            if (!String.IsNullOrEmpty(zipCodeEntry.Text))
            {
                //Weather weather = await Core.GetWeather(zipCodeEntry.Text);
                //FindViewById<TextView>(Resource.Id.locationText).Text = weather.Title;
                //FindViewById<TextView>(Resource.Id.tempText).Text = weather.Temperature;
                //FindViewById<TextView>(Resource.Id.windText).Text = weather.Wind;
                //FindViewById<TextView>(Resource.Id.visibilityText).Text = weather.Visibility;
                //FindViewById<TextView>(Resource.Id.humidityText).Text = weather.Humidity;
                //FindViewById<TextView>(Resource.Id.sunriseText).Text = weather.Sunrise;
                //FindViewById<TextView>(Resource.Id.sunsetText).Text = weather.Sunset;
                Game game = await Core.GetGame(zipCodeEntry.Text);
                FindViewById<TextView>(Resource.Id.locationText).Text = game.Name;
                FindViewById<TextView>(Resource.Id.tempText).Text = game.Steam_appid;
                FindViewById<TextView>(Resource.Id.windText).Text = game.Detailed_description;
                FindViewById<TextView>(Resource.Id.visibilityText).Text = game.Header_image;
                FindViewById<TextView>(Resource.Id.humidityText).Text = game.Currency;
                FindViewById<TextView>(Resource.Id.sunriseText).Text = game.Initial;
                FindViewById<TextView>(Resource.Id.sunsetText).Text = game.Score;
            }
        }
    }
}