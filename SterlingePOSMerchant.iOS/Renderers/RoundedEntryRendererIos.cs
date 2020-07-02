using System;
using CoreGraphics;
using SterlingePOSMerchant.CustomControls;
using SterlingePOSMerchant.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Material.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(RoundedEntry), typeof(RoundedEntryRendererIos))]

namespace SterlingePOSMerchant.iOS.Renderers
{

    public class RoundedEntryRendererIos : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                Control.Layer.CornerRadius = 25;
                Control.Layer.BorderWidth = 1f;

                Control.Layer.BorderColor = Color.LightGray.ToCGColor();
                Control.Layer.BackgroundColor = Color.White.ToCGColor();

                Control.LeftView = new UIKit.UIView(new CGRect(0, 0, 10, 0));
                Control.LeftViewMode = UIKit.UITextFieldViewMode.Always;

                //rounded

                // Transparent, set FromWhiteAlpha(1,1);

                //Control.BackgroundColor = UIColor.FromWhiteAlpha(0, 0);

                //Control.BorderStyle = UITextBorderStyle.None;
            }
        }
    }

}
