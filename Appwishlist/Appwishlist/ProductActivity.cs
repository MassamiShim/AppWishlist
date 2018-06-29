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
using Appwishlist.Classes;

namespace Appwishlist
{
    [Activity(Label = "ProductActivity")]
    public class ProductActivity : Activity
    {
        //A: Adding a new product
        //U: Updatint an existing product
        string CdStatus = "A"; 

        protected  override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.product_main);

            if (Intent.Extras != null)
            {
                CdStatus = Intent.GetSerializableExtra("CdStatus").ToString();
            }

            Button saveButton = FindViewById<Button>(Resource.Id.saveBtn);

            saveButton.Click += Button_Click;

            Spinner dropdown = FindViewById<Spinner>(Resource.Id.typeSpinner);
            string[] items = new String[] { "Book", "Game", "Movie" };

            //dropdown.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, items);

            dropdown.Adapter = adapter;
        }

        public async void Button_Click(object sender, EventArgs e)
        {
            string name = FindViewById<EditText>(Resource.Id.nameText).Text;
            long code = Int64.Parse(FindViewById<EditText>(Resource.Id.codeText).Text);
            short type = (Int16)FindViewById<Spinner>(Resource.Id.typeSpinner).SelectedItemId;

            Product product = new Product();

            product.NmProduct = name;
            product.IdItem = code;
            product.IdTypeProduct = type;

            int result = await Core.AddProduct(product);
            string toast;

            if (result == 1)
                toast = string.Format("The product was successfully inserted!");
            else
                toast = string.Format("FAIL");

            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }
    }
}