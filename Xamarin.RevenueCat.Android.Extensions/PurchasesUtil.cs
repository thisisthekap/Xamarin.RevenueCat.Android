using System.Threading;
using System.Threading.Tasks;
using Android.Content;
using Com.Revenuecat.Purchases;
using Xamarin.RevenueCat.Android.Extensions.Util;

namespace Xamarin.RevenueCat.Android.Extensions
{
    public static class PurchasesUtil
    {
        public static async  Task<bool> IsBillingSupportedAsync(Context context, CancellationToken cancellationToken = default)
        {
            var delegatingCallback = new DelegatingCallback<Java.Lang.Boolean>(cancellationToken);
            Purchases.IsBillingSupported(context, delegatingCallback);
            return (await delegatingCallback.Task).BooleanValue();
        }
    }
}