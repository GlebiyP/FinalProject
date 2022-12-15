using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace FinalProject
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var arraySorterButton = FindViewById<Button>(Resource.Id.arraySorterButton);
            var UADemographicIndButton = FindViewById<Button>(Resource.Id.UADemographicIndButton);
            var aboutAuthorButton = FindViewById<Button>(Resource.Id.aboutAuthorButton);
            var userHelperButton = FindViewById<Button>(Resource.Id.userHelperButton);

            arraySorterButton.Click += (sender, e) =>
            {
                Intent nextActivity = new Intent(this, typeof(ArraySorterActivity));
                StartActivity(nextActivity);
            };

            UADemographicIndButton.Click += (sender, e) =>
            {
                Intent nextActivity = new Intent(this, typeof(UaActivity));
                StartActivity(nextActivity);
            };

            aboutAuthorButton.Click += (sender, e) =>
            {
                Intent nextActivity = new Intent(this, typeof(AboutAuthorActivity));
                StartActivity(nextActivity);
            };

            userHelperButton.Click += (sender, e) =>
            {
                Intent nextActivity = new Intent(this, typeof(UserHelperActivity));
                StartActivity(nextActivity);
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}