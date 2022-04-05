using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Com.Revenuecat.Purchases;
using Com.Revenuecat.Purchases.Common.Subscriberattributes;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using static Android.Views.View;

namespace Xamarin.RevenueCat.Android.UsageChecker
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            AndroidX.AppCompat.Widget.Toolbar toolbar = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            Purchases.DebugLogsEnabled = true;
            Purchases.Configure(new PurchasesConfiguration.Builder(this, "apikey").Build());
            string revenueCatVersion = Purchases.FrameworkVersion;

            var txtRevenueCatVersion = FindViewById<TextView>(Resource.Id.txtRevenueCatVersion);

            var txtAdjustNetwork = FindViewById<TextView>(Resource.Id.txtAdjustNetwork);

            txtRevenueCatVersion.Text = $"RevenueCat {revenueCatVersion}";

            string adjustNetwork = SubscriberAttributeKey.AttributionIds.Adjust.Instance.BackendKey;
            txtAdjustNetwork.Text = adjustNetwork;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (IOnClickListener)null).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
