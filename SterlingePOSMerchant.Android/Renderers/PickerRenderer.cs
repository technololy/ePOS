using System;
using Android.Content;
using Android.Graphics.Drawables;
using SterlingePOSMerchant.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(MyPicker), typeof(SterlingePOSMerchant.Droid.Renderers.MyPickerRenderer))]
namespace SterlingePOSMerchant.Droid.Renderers
{
    public class MyPickerRenderer : Xamarin.Forms.Platform.Android.AppCompat.PickerRenderer
    {
        public MyPickerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                Control.Background = null;
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetCornerRadius(20f);
                gradientDrawable.SetStroke(5, Android.Graphics.Color.LightGray);
                gradientDrawable.SetColor(Android.Graphics.Color.WhiteSmoke);
                Control.SetBackground(gradientDrawable);

                Control.SetPadding(50, Control.PaddingTop, Control.PaddingRight,
                    Control.PaddingBottom);
            }
        }
    }
}
