using System.Threading;
using Com.Revenuecat.Purchases.Interfaces;
using Java.Lang;

namespace Xamarin.RevenueCat.Android.Extensions.Util
{
    public class DelegatingCallback<TResult> : DelegatingListenerBase<TResult>, ICallback
    {
        public DelegatingCallback(CancellationToken cancellationToken) : base(cancellationToken)
        {
        }

        public void OnReceived(Object resultObject)
        {
            if (resultObject is TResult result)
            {
                ReportSuccess(result);
            }
            else
            {
                ReportException(new Exception($"{resultObject?.GetType().Name} is not a {typeof(TResult).Name}"));
            }
        }
    }
}