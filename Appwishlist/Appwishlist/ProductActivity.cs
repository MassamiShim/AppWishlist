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
        //U: Updating an existing product
        string CdStatus = "A";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.product_main);

            if (Intent.Extras != null)
            {
                CdStatus = Intent.GetSerializableExtra("CdStatus").ToString();
            }

            Button saveButton = FindViewById<Button>(Resource.Id.saveBtn);

            saveButton.Click += Save_Click;

            Button searchButton = FindViewById<Button>(Resource.Id.searchBtn);

            searchButton.Click += Search_Click;

            Spinner dropdown = FindViewById<Spinner>(Resource.Id.typeSpinner);
            string[] items = new String[] { "Choose One!", "Book", "Game", "Movie" };

            //dropdown.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, items);

            dropdown.Adapter = adapter;
        }

        public async void Save_Click(object sender, EventArgs e)
        {
            string name = FindViewById<EditText>(Resource.Id.nameText).Text;
            long code = 0;
            if (FindViewById<EditText>(Resource.Id.codeText).Text != "")
            {
                code = Int64.Parse(FindViewById<EditText>(Resource.Id.codeText).Text);
            }
            short type = (Int16)FindViewById<Spinner>(Resource.Id.typeSpinner).SelectedItemId;

            if (name != "" && type != 0 && code != 0)
            {

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
            else
                Toast.MakeText(this, "Missing Field!", ToastLength.Long).Show();
        }

        public async void Search_Click(object sender, EventArgs e)
        {
            int code = 0;
            if (FindViewById<EditText>(Resource.Id.idText).Text != "")
            {
                code = Int32.Parse(FindViewById<EditText>(Resource.Id.idText).Text);
            }

            if (code != 0)
            {
                Product product = await Core.GetProduct(code);

                if (product.IdItem != 0)
                { 
                FindViewById<EditText>(Resource.Id.nameText).Text = product.NmProduct;
                FindViewById<EditText>(Resource.Id.codeText).Text = product.IdItem.ToString();
                FindViewById<Spinner>(Resource.Id.typeSpinner).SetSelection(product.IdTypeProduct);
                }
                else
                {
                    FindViewById<EditText>(Resource.Id.nameText).Text = "Product Not Found!";
                    FindViewById<EditText>(Resource.Id.codeText).Text = "404";
                    FindViewById<Spinner>(Resource.Id.typeSpinner).SetSelection(0);
                }
            }
        }
    }
}