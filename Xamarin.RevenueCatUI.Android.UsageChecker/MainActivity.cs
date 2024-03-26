﻿using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Com.Revenuecat.Purchases.UI.Revenuecatui.Activity;
using Java.Interop;
using Object = Java.Lang.Object;

namespace Xamarin.RevenueCatUI.Android.UsageChecker
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IPaywallResultHandler
    {
        private PaywallActivityLauncher _paywallActivityLauncher;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Essentials.Platform.Init(this, savedInstanceState);

            _paywallActivityLauncher = new PaywallActivityLauncher(this, this);
            // _paywallActivityLauncher.Launch();
        }

        protected override void OnStart()
        {
            base.OnStart();
            _paywallActivityLauncher.Launch();
        }

        // public void OnActivityResult(Object result)
        // {
        //     if (result is PaywallResult)
        //     {
        //         Console.WriteLine(result.ToString());
        //     }
        //
        //     // var test = result.JavaCast<PaywallResult>();
        // }

        public void OnActivityResult(PaywallResult paywallResult)
        {
            Console.WriteLine(paywallResult);
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions,
            [GeneratedEnum] Permission[] grantResults)
        {
            Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}