using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SignalRDemo.Android
{
    [Activity(Label = "GameActivity")]
    public class GameActivity : Activity, View.IOnClickListener
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
        }

        public void OnClick(View v)
        {
            switch (v.Id)
            {
                case Resource.Id.btn_c1_l1:
                    break;
                case Resource.Id.btn_c1_l2:
                    break;
                case Resource.Id.btn_c1_l3:
                    break;
                case Resource.Id.btn_c2_l1:
                    break;
                case Resource.Id.btn_c2_l2:
                    break;
                case Resource.Id.btn_c2_l3:
                    break;
                case Resource.Id.btn_c3_l1:
                    break;
                case Resource.Id.btn_c3_l2:
                    break;
                case Resource.Id.btn_c3_l3:
                    break;
            }
        }
    }
}