using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace FinalProject
{
    [Activity(Label = "@string/demographic_indicators")]
    public class UaActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.ua_activity);

            Button dbButton = FindViewById<Button>(Resource.Id.dbButton);
            Button contactsButton = FindViewById<Button>(Resource.Id.contactsButton);
            Button goBackButton = FindViewById<Button>(Resource.Id.GoBackButton3);

            dbButton.Click += (sender, e) =>
            {
                Intent nextActivity = new Intent(this, typeof(DBActivity));
                StartActivity(nextActivity);
            };

            contactsButton.Click += (sender, e) =>
            {
                Intent nextActivity = new Intent(this, typeof(ContactsAvtivity));
                StartActivity(nextActivity);
            };

            goBackButton.Click += (sender, e) =>
            {
                this.Finish();
            };
        }
    }
}