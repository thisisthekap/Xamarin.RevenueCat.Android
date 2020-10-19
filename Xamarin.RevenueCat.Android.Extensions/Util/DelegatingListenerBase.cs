using System;
using System.Threading;
using System.Threading.Tasks;

namespace Xamarin.RevenueCat.Android.Extensions.Util
{
    public abstract class DelegatingListenerBase<TResult> : Java.Lang.Object
    {
        private readonly TaskCompletionSource<TResult> _taskCompletionSource;

        public DelegatingListenerBase(CancellationToken cancellationToken)
        {
            _taskCompletionSource = new TaskCompletionSource<TResult>();
            cancellationToken.Register(() => _taskCompletionSource.TrySetCanceled());
        }

        public Task<TResult> Task => _taskCompletionSource.Task;

        protected void ReportSuccess(TResult result)
        {
            _taskCompletionSource.SetResult(result);
        }

        protected void ReportException(Exception exception)
        {
            _taskCompletionSource.TrySetException(exception);
        }
    }
}