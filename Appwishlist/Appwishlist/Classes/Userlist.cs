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
    public class Userlist
    {
        public int IdList { get; set; }
        public string NmList { get; set; }
        public int IdProduct { get; set; }
        public string NmProduct { get; set; }
        public short CdStatus { get; set; }
        public string NmStatus { get; set; }
    }
}