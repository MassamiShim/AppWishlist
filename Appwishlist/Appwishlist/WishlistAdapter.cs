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
    class WishlistAdapter : BaseAdapter<Game>
    {

        Game[] items;
        List<Wishlist> items2;
        Context context;

        public WishlistAdapter(Context context)
        {
            this.context = context;
        }

        public WishlistAdapter(Activity context, Game[] items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public WishlistAdapter(Activity context, List<Wishlist> items) : base()
        {
            this.context = context;
            this.items2 = items;
        }

        public override Game this[int position]
        {
            get { return items[position]; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override int Count
        {
            //get { return items.Length; }
            get { return items2.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            WishlistAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as WishlistAdapterViewHolder;

            if (holder == null)
            {
                holder = new WishlistAdapterViewHolder();
                var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                //replace with your item and your holder items
                //comment back in
                //view = inflater.Inflate(Resource.Layout.item, parent, false);
                //holder.Title = view.FindViewById<TextView>(Resource.Id.text);

                view = inflater.Inflate(Android.Resource.Layout.TwoLineListItem, null);
                //view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = items[position].Name;
                //view.FindViewById<TextView>(Android.Resource.Id.Text1).Id = Int32.Parse(items[position].Steam_appid);
                view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = items2[position].NmProduct;
                view.FindViewById<TextView>(Android.Resource.Id.Text1).Id = Convert.ToInt32(items2[position].idItem);

                string NmStatus = "";
                switch (items2[position].CdStatus)
                {
                    case 1:
                        NmStatus = "Finished";
                        break;
                    case 2:
                        NmStatus = "To Do";
                        break;
                    case 3:
                        NmStatus = "Wishlist";
                        break;
                }

                view.FindViewById<TextView>(Android.Resource.Id.Text2).Text = NmStatus;

                view.Tag = holder;
            }


            //fill in your items
            //holder.Title.Text = "new text here";

            return view;
        }
    }

    class WishlistAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}