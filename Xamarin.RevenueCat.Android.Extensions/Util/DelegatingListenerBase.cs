using System;
using System.Threading;
using System.Threading.Tasks;
using NLog;

namespace Xamarin.RevenueCat.Android.Extensions.Util
{
    public abstract class DelegatingListenerBase<TResult> : Java.Lang.Object
    {
        private enum CompletionAction
        {
            Resolve,
            Cancel,
            Exception,
        }
        
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly TaskCompletionSource<TResult> _taskCompletionSource;

        public DelegatingListenerBase(CancellationToken cancellationToken)
        {
            _taskCompletionSource = new TaskCompletionSource<TResult>();
            cancellationToken.Register(() =>
            {
                if (!_taskCompletionSource.TrySetCanceled())
                {
                    ReportRepeatedExecution(CompletionAction.Cancel);
                }
            });
        }

        public Task<TResult> Task => _taskCompletionSource.Task;

        protected void ReportSuccess(TResult result)
        {
            if (_taskCompletionSource.TrySetResult(result))
            {
                ReportRepeatedExecution(CompletionAction.Resolve);
            }
        }

        protected void ReportException(Exception exception)
        {
            if (!_taskCompletionSource.TrySetException(exception))
            {
                ReportRepeatedExecution(CompletionAction.Exception);
            }
        }

        private  void ReportRepeatedExecution(CompletionAction action)
        {
            if (!_logger.IsWarnEnabled)
            {
                return;
            }

            var actionStr = action switch
            {
                CompletionAction.Resolve => "resolved",
                CompletionAction.Cancel => "cancelled",
                CompletionAction.Exception => "set error",
                _ => "<unknown action>",
            };
            _logger.Warn("{0} {1} multiple times", _taskCompletionSource?.GetType().FullName, actionStr);
        }
    }
}
