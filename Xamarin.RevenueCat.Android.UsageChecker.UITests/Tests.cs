using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace Xamarin.RevenueCat.Android.UsageChecker.UITests
{
    [TestFixture]
    public class Tests
    {
        private AndroidApp _app;

        [SetUp]
        public void BeforeEachTest()
        {
            _app = ConfigureApp.Android.StartApp();
        }

        [Test]
        public void AppDidLaunch()
        {
            _app.WaitForElement(c => c.Id("content"));
            _app.Screenshot("App launched");
        }

        [Test]
        public void CheckRevenueCatVersion()
        {
            AppResult versionElement = _app.WaitForElement(c => c.Id("txtRevenueCatVersion")).First();
            Assert.Equals(versionElement.Text, Is.EqualTo("RevenueCat 7.7.2"));
            _app.Screenshot("RevenueCat Version");
        }

        [Test]
        public void CheckAdjustNetworkAttribution()
        {
            AppResult txtAdjustNetworkElement = _app.WaitForElement(c => c.Id("txtAdjustNetwork")).First();
            Assert.Equals(txtAdjustNetworkElement.Text, Is.EqualTo("$adjustId"));
            _app.Screenshot("Adjust Attribution Network");
        }
    }
}