using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Appwishlist.Classes;


namespace Appwishlist
{
    [Activity(Label = "Sample Weather App", Theme = "@style/AppTheme.NoActionBar",  MainLauncher = false)]//, Icon = "@drawable/icon")]
    public class GameActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.weatherBtn);

            button.Click += Button_Click;
        }

        public async void Button_Click(object sender, EventArgs e)
        {
            EditText idGameEntry = FindViewById<EditText>(Resource.Id.idEntry);

            if (!String.IsNullOrEmpty(idGameEntry.Text))
            {
                //Weather weather = await Core.GetWeather(zipCodeEntry.Text);
                //FindViewById<TextView>(Resource.Id.locationText).Text = weather.Title;
                //FindViewById<TextView>(Resource.Id.tempText).Text = weather.Temperature;
                //FindViewById<TextView>(Resource.Id.windText).Text = weather.Wind;
                //FindViewById<TextView>(Resource.Id.visibilityText).Text = weather.Visibility;
                //FindViewById<TextView>(Resource.Id.humidityText).Text = weather.Humidity;
                //FindViewById<TextView>(Resource.Id.sunriseText).Text = weather.Sunrise;
                //FindViewById<TextView>(Resource.Id.sunsetText).Text = weather.Sunset;
                Game game = await Core.GetGame(idGameEntry.Text);

                if (game != null)
                {
                    FindViewById<TextView>(Resource.Id.nameText).Text = game.Name;
                    FindViewById<TextView>(Resource.Id.idText).Text = game.Steam_appid;
                    FindViewById<TextView>(Resource.Id.descriptionText).Text = game.Detailed_description;
                    FindViewById<TextView>(Resource.Id.imageText).Text = game.Header_image;
                    FindViewById<TextView>(Resource.Id.currencyText).Text = game.Currency;
                    FindViewById<TextView>(Resource.Id.priceText).Text = game.Initial;
                    FindViewById<TextView>(Resource.Id.scoreText).Text = game.Score;

                    ImageView imagem = FindViewById<ImageView>(Resource.Id.imageView);
                    var imageBitMap = DataService.GetImageBitmapFromUrl(game.Header_image);
                    imagem.SetImageBitmap(imageBitMap);
                }
                else
                {
                    FindViewById<TextView>(Resource.Id.nameText).Text = "Game Not Found!";
                    FindViewById<TextView>(Resource.Id.idText).Text = null;
                    FindViewById<TextView>(Resource.Id.descriptionText).Text = null;
                    FindViewById<TextView>(Resource.Id.imageText).Text = null;
                    FindViewById<TextView>(Resource.Id.currencyText).Text = null;
                    FindViewById<TextView>(Resource.Id.priceText).Text = null;
                    FindViewById<TextView>(Resource.Id.scoreText).Text = null;
                    FindViewById<ImageView>(Resource.Id.imageView).SetImageDrawable(null);
                }
            }
        }
    }
}