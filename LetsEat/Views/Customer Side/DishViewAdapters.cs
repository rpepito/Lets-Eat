using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


namespace LetsEat
{
    public class DishViewAdapters : BaseAdapter<Dishes>
    {
        List<Dishes> users;

        public DishViewAdapters(List<Dishes> users)
        {
            this.users = users;
        }

        public override Dishes this[int position]
        {
            get
            {
                return users[position];
            }
        }

        public override int Count
        {
            get
            {
                return users.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if (view == null)
            {
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.userRow, parent, false);

                //var photo = view.FindViewById<ImageView>(Resource.Id.photoImageView);
                var name = view.FindViewById<TextView>(Resource.Id.nameTextView);
                var price = view.FindViewById<TextView>(Resource.Id.cuisineTextView);

                view.Tag = new Dishes() {Name = name, Description = description, Ingredients = ingredients, Price = price };
            }

            var holder = (Dishes)view.Tag;

            holder.Name.Text = users[position].Name;
            holder.Description.Text = users[position].Description;
            holder.Ingredients.Text = users[position].Ingredients;
            holder.Price.Text = users[position].Price;

            return view;

        }
    }
}