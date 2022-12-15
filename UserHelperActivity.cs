using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject
{
    [Activity(Label = "@string/app_name")]
    public class UserHelperActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.user_helper_activity);

            var goBackButton = FindViewById<Button>(Resource.Id.GoBackButton6);

            goBackButton.Click += (sender, e) =>
            {
                this.Finish();
            };
        }
    }
}