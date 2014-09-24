using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using SignalRDemo.Android.Models;
using SignalRDemo.Android.ViewHolders;

namespace SignalRDemo.Android.Adapters
{
    public class MessagesAdapter : ArrayAdapter<String>
    {
        private readonly Context context;
        private readonly int row;
        private String currentItem;
        private List<String> dataSource;

        public MessagesAdapter(Context context, int resource, List<String> arrayList)
            : base(context, resource, arrayList)
        {
            this.context = context;
            row = resource;
            dataSource = arrayList;
        }

        public override int Count
        {
            get { return dataSource.Count; }
        }

        public List<String> GetDataSource()
        {
            return dataSource;
        }

        public void SetDataSource(List<String> dataSource)
        {
            this.dataSource = dataSource;
        }

        public void AddItem(String message)
        {
            if (dataSource == null)
            {
                dataSource = new List<String>();
            }
            dataSource.Add(message);
            NotifyDataSetChanged();
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            MessagesViewHolder holder;
            if (view == null)
            {
                var inflater = (LayoutInflater) context.GetSystemService(Context.LayoutInflaterService);
                view = inflater.Inflate(row, null);
                holder = new MessagesViewHolder();
                view.Tag = holder;
            }
            else
            {
                holder = (MessagesViewHolder) view.Tag;
            }
            try
            {
                if ((dataSource == null) || ((position + 1) > dataSource.Count))
                    return view;

                currentItem = dataSource[position];
                if (currentItem != null)
                {
                    holder.Tv_Message = view.FindViewById<TextView>(Resource.Id.tv_message);
                    holder.Tv_Message.Text = currentItem;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return view;
        }
    }
}