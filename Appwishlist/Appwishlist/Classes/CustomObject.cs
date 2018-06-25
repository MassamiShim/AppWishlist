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
    public class CustomObject
    {

        private String prop1;
        private String prop2;

        public CustomObject(String prop1, String prop2)
        {
            this.prop1 = prop1;
            this.prop2 = prop2;
        }

        public String getProp1()
        {
            return prop1;
        }

        public String getProp2()
        {
            return prop2;
        }
    }
}