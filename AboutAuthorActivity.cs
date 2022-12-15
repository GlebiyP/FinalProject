using Android.App;
using Android.OS;
using Android.Widget;

namespace FinalProject
{
    [Activity(Label = "@string/aboutAuthor")]
    public class AboutAuthorActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.about_author_activity);

            TextView authorInfo = FindViewById<TextView>(Resource.Id.authorInfo);
            ImageView photo = FindViewById<ImageView>(Resource.Id.photo);
            Button goBackButton = FindViewById<Button>(Resource.Id.GoBackButton2);

            goBackButton.Click += (sender, e) =>
            {
                this.Finish();
            };
        }
    }
}