using System;
using Android.Runtime;
using Kotlinx.Serialization.Encoding;
using Object = Java.Lang.Object;

namespace Com.Revenuecat.Purchases.Paywalls
{
    public partial class PaywallColor
    {
        public partial class Serializer
        {
            public Object Deserialize(IDecoder decoder)
            {
                var result = DeserializeInternal(decoder);
                return result;
            }

            public void Serialize(IEncoder encoder, Object value)
            {
                var paywallColor = value as PaywallColor ?? value.JavaCast<PaywallColor>();
                if (paywallColor != null)
                {
                    SerializeInternal(encoder, paywallColor);
                }
                else
                {
                    throw new ArgumentException("Value parameter should be a PaywallColor instance");
                }
            }
        }
    }
}