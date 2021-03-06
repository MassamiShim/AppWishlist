﻿using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Appwishlist.Classes;


namespace Appwishlist
{
    [Activity(Label = "Sample Weather App", Theme = "@style/AppTheme.NoActionBar",  MainLauncher = false)]//, Icon = "@drawable/icon")]
    public class GameActivity : Activity
    {
        string gameId = "";

        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.game_main);

            Button button = FindViewById<Button>(Resource.Id.weatherBtn);

            button.Click += Button_Click;

            if (Intent.Extras != null)
            {
                gameId = Intent.GetSerializableExtra("gameId").ToString();
                if (gameId != "")
                {
                    Game game = await Core.GetGame(gameId.ToString());

                    if (game != null)
                    {
                        FindViewById<TextView>(Resource.Id.nameText).Text = game.Name;
                        FindViewById<TextView>(Resource.Id.idText).Text = game.Steam_appid;
                        FindViewById<TextView>(Resource.Id.descriptionText).Text = game.Detailed_description;
                        FindViewById<TextView>(Resource.Id.currencyText).Text = game.Currency;
                        FindViewById<TextView>(Resource.Id.priceText).Text = game.Initial;
                        FindViewById<TextView>(Resource.Id.scoreText).Text = game.Score;
                        FindViewById<TextView>(Resource.Id.categoriesText).Text = game.Categories_description;

                        ImageView imagem = FindViewById<ImageView>(Resource.Id.imageView);
                        var imageBitMap = DataService.GetImageBitmapFromUrl(game.Header_image);
                        imagem.SetImageBitmap(imageBitMap);
                    }
                }
            }
        }

        public async void Button_Click(object sender, EventArgs e)
        {
            EditText idGameEntry = FindViewById<EditText>(Resource.Id.idEntry);

            if (!String.IsNullOrEmpty(idGameEntry.Text))
            {
                Game game = await Core.GetGame(idGameEntry.Text);

                if (game != null)
                {
                    FindViewById<TextView>(Resource.Id.nameText).Text = game.Name;
                    FindViewById<TextView>(Resource.Id.idText).Text = game.Steam_appid;
                    FindViewById<TextView>(Resource.Id.descriptionText).Text = game.Detailed_description;
                    //FindViewById<TextView>(Resource.Id.imageText).Text = game.Header_image;
                    FindViewById<TextView>(Resource.Id.currencyText).Text = game.Currency;
                    FindViewById<TextView>(Resource.Id.priceText).Text = game.Initial;
                    FindViewById<TextView>(Resource.Id.scoreText).Text = game.Score;
                    FindViewById<TextView>(Resource.Id.categoriesText).Text = game.Categories_description;

                    ImageView imagem = FindViewById<ImageView>(Resource.Id.imageView);
                    var imageBitMap = DataService.GetImageBitmapFromUrl(game.Header_image);
                    imagem.SetImageBitmap(imageBitMap);
                }
                else
                {
                    FindViewById<TextView>(Resource.Id.nameText).Text = "Game Not Found!";
                    FindViewById<TextView>(Resource.Id.idText).Text = null;
                    FindViewById<TextView>(Resource.Id.descriptionText).Text = null;
                    //FindViewById<TextView>(Resource.Id.imageText).Text = null;
                    FindViewById<TextView>(Resource.Id.currencyText).Text = null;
                    FindViewById<TextView>(Resource.Id.priceText).Text = null;
                    FindViewById<TextView>(Resource.Id.scoreText).Text = null;
                    FindViewById<TextView>(Resource.Id.categoriesText).Text = null;
                    FindViewById<ImageView>(Resource.Id.imageView).SetImageDrawable(null);
                }
            }
        }

        //public async void LoadGame(object sender, EventArgs e)

    }
}