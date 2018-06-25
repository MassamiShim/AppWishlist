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

namespace Appwishlist.Classes
{
    public class Product
    {
        public string NmProduct { get; set; }
        public short IdTypeProduct { get; set; }
        public long IdItem { get; set; }
    }
}