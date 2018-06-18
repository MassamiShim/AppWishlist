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
            get { return items.Length; }
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

                view = inflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
                view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = items[position].Name;
                view.FindViewById<TextView>(Android.Resource.Id.Text1).Id = Int32.Parse(items[position].Steam_appid);

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