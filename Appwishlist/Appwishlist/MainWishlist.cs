using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using System.Collections.Generic;
using Android.Content;

namespace Appwishlist
{
    [Activity(Label = "MainWishlist", Theme = "@style/AppTheme.NoActionBar", MainLauncher = false)]
    public class MainWishlist : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.wishlist_main);

            Button listGame = FindViewById<Button>(Resource.Id.btn_game);

            listGame.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(WishListActivity));
                //intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
                StartActivity(intent);
            };

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
        }
    }
}