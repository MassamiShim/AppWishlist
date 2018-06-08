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
    public class Game
    {
        public string Name{ get; set; }
        public string Steam_appid { get; set; }
        public string Detailed_description { get; set; }
        public string Header_image { get; set; }
        public string Currency { get; set; }
        public string Initial { get; set; }
        public string Score { get; set; }
        public string Categories_description { get; set; }
        public List<Genre> Genres { get; set; }

        public Game()
        {
            //Because labels bind to these values, set them to an empty string to  
            //ensure that the label appears on all platforms by default.  
            this.Name = " ";
            this.Steam_appid = " ";
            this.Detailed_description = " ";
            this.Header_image = " ";
            this.Currency = " ";
            this.Initial = " ";
            this.Score = " ";
            this.Categories_description = " ";
            this.Genres = new List<Genre>();
        }
    }
}