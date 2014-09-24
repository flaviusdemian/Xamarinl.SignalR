using System;
using Android.App;
using Android.Widget;
using Android.OS;

namespace SignalRDemo.Android
{
    [Activity(Label = "SignalRDemo.Android", MainLauncher = false, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        public static ListView lv_players = null;
        public static TextView tv_username = null;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            try
            {
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.Main);
                InitializeUIElements();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Toast.MakeText(this, ex.ToString(), ToastLength.Long);
            }
        }

        private void InitializeUIElements()
        {
            try
            {
                lv_players = FindViewById<ListView>(Resource.Id.lv_players);
                if (lv_players != null)
                {
                    throw new Exception("ListView is not defined");
                }
                tv_username = FindViewById<TextView>(Resource.Id.tv_username);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Toast.MakeText(this, ex.ToString(), ToastLength.Long);
            }
        }
    }
}

