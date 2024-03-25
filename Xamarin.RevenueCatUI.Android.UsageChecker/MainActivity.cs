using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Com.Revenuecat.Purchases.UI.Revenuecatui.Activity;
using Java.Interop;
using Java.Lang;

namespace Xamarin.RevenueCatUI.Android.UsageChecker
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public partial class MainActivity : Com.Revenuecatui.Helper.MainPaywallActivity
    {
        private PaywallActivityLauncher _paywallActivityLauncher;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Essentials.Platform.Init(this, savedInstanceState);

            _paywallActivityLauncher = new PaywallActivityLauncher(this, this);
            _paywallActivityLauncher.Launch();
        }

        
        
        // [Export]
        // public void onActivityResult(PaywallResult result)
        // {
        // }
        //
        // public void OnActivityResult(Object result)
        // {
        // }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions,
            [GeneratedEnum] Permission[] grantResults)
        {
            Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}