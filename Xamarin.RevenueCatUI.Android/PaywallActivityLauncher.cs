// using System;
// using Android.Runtime;
// using Java.Interop;
//
// namespace Com.Revenuecat.Purchases.UI.Revenuecatui.Activity
// {
//     public partial class PaywallActivityLauncher
//     {
//         // Metadata.xml XPath constructor reference: path="/api/package[@name='com.revenuecat.purchases.ui.revenuecatui.activity']/class[@name='PaywallActivityLauncher']/constructor[@name='PaywallActivityLauncher' and count(parameter)=2 and parameter[1][@type='androidx.activity.result.ActivityResultCaller'] and parameter[2][@type='com.revenuecat.purchases.ui.revenuecatui.activity.PaywallResultHandler']]"
//         [Register(".ctor",
//             "(Landroidx/activity/result/ActivityResultCaller;Lcom/revenuecat/purchases/ui/revenuecatui/activity/PaywallResultHandler;)V",
//             "")]
//         public unsafe PaywallActivityLauncher(global::AndroidX.Activity.Result.IActivityResultCaller resultCaller,
//             global::Com.Revenuecat.Purchases.UI.Revenuecatui.Activity.IPaywallResultHandler resultHandler) : base(
//             IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
//         {
//             const string __id =
//                 "(Landroidx/activity/result/ActivityResultCaller;Lcom/revenuecat/purchases/ui/revenuecatui/activity/PaywallResultHandler;)V";
//
//             if (((global::Java.Lang.Object)this).Handle != IntPtr.Zero)
//                 return;
//
//             try
//             {
//                 JniArgumentValue* __args = stackalloc JniArgumentValue[2];
//                 __args[0] = new JniArgumentValue((resultCaller == null)
//                     ? IntPtr.Zero
//                     : ((global::Java.Lang.Object)resultCaller).Handle);
//                 __args[1] = new JniArgumentValue((resultHandler == null)
//                     ? IntPtr.Zero
//                     : ((global::Java.Lang.Object)resultHandler).Handle);
//                 var __r = _members.InstanceMethods.StartCreateInstance(__id, ((object)this).GetType(), __args);
//                 SetHandle(__r.Handle, JniHandleOwnership.TransferLocalRef);
//                 _members.InstanceMethods.FinishCreateInstance(__id, this, __args);
//             }
//             finally
//             {
//                 global::System.GC.KeepAlive(resultCaller);
//                 global::System.GC.KeepAlive(resultHandler);
//             }
//         }
//     }
// }