using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using Microsoft.AspNet.SignalR.Client;
using SignalRDemo.Android.Adapters;

namespace SignalRDemo.Android
{
    [Activity(Label = "SimpleActivity", MainLauncher = true)]
    public class SimpleActivity : Activity
    {
        private IHubProxy loungeProxy;
        public ListView lv_messages;
        public EditText et_content;
        public Button btn_send;
        public MessagesAdapter adapter;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            try
            {
                SetContentView(Resource.Layout.Simple);
                InitializeUI();

                var hubConnection = new HubConnection("http://signalrmeetupdemo.azurewebsites.net/signalr");
                // create proxy
                loungeProxy = hubConnection.CreateHubProxy("Lounge");

                loungeProxy.On<string>("pongHello", data =>
                {
                    RunOnUiThread(() =>
                    {
                        AddMessageToList();
                    });
                });
                hubConnection.Start().Wait();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void AddMessageToList()
        {
            string message = et_content.Text;
            if (string.IsNullOrWhiteSpace(message) == false && adapter != null)
            {
                adapter.AddItem(message);
            }
        }
        private void InitializeUI()
        {
            try
            {
                lv_messages = FindViewById<ListView>(Resource.Id.lv_messages);
                List<string> items = new List<string>();
                items.Add("alo");
                items.Add("da");
                items.Add("ce faci?");
                adapter = new MessagesAdapter(this, Resource.Layout.Simple_Item_Template, items);
                lv_messages.Adapter = adapter;
                adapter.NotifyDataSetChanged();
                et_content = FindViewById<EditText>(Resource.Id.et_instruction);
                btn_send = FindViewById<Button>(Resource.Id.btn_send);
                btn_send.Click += (sender, args) =>
                {
                    string message = et_content.Text;
                    if (string.IsNullOrWhiteSpace(message) == false)
                    {
                        //loungeProxy.Invoke<string>("pingHello", message);
                        et_content.Text = "";
                        adapter.AddItem(message);
                    }
                };
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}