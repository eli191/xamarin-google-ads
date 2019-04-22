using System;
using Android.Content;
using Android.Gms.Ads;
using Android.Widget;
using TestAds.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AdBanner), typeof(TestAds.Droid.Renderers.AdRenderer))]
namespace TestAds.Droid.Renderers
{
    public class AdRenderer : ViewRenderer
    {
        public AdRenderer(Context _context) : base(_context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null && Control == null)
                SetNativeControl(CreateAdView((Element as AdBanner).Size));
        }

        private AdView CreateAdView(AdBanner.Sizes size)
        {
            var adView = new AdView(Context)
            {
                AdUnitId = //"ca-app-pub-3940256099942544/6300978111"  //dummy google test ad
                "YOUR AD UNIT ID HERE"
            };
            switch ((Element as AdBanner).Size)
            {
                case AdBanner.Sizes.Standardbanner:
                    adView.AdSize = AdSize.Banner;
                    break;
                case AdBanner.Sizes.LargeBanner:
                    adView.AdSize = AdSize.LargeBanner;
                    break;
                case AdBanner.Sizes.MediumRectangle:
                    adView.AdSize = AdSize.MediumRectangle;
                    break;
                case AdBanner.Sizes.FullBanner:
                    adView.AdSize = AdSize.FullBanner;
                    break;
                case AdBanner.Sizes.Leaderboard:
                    adView.AdSize = AdSize.Leaderboard;
                    break;
                case AdBanner.Sizes.SmartBannerPortrait:
                    adView.AdSize = AdSize.SmartBanner;
                    break;
                default:
                    adView.AdSize = AdSize.Banner;
                    break;
            }


            //adView.LayoutParameters = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);

            var requestbuilder = new AdRequest.Builder();
            requestbuilder.AddTestDevice("YOUR TEST DEVICE ID HERE");
            adView.LoadAd(requestbuilder.Build());

            return adView;
        }
    }
}
