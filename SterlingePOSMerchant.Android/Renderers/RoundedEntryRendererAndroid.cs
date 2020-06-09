using System;
using Android.Content;
using Android.Graphics.Drawables;
using SterlingePOSMerchant.CustomControls;
using SterlingePOSMerchant.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(RoundedEntry), typeof(RoundedEntryRendererAndroid))]


namespace SterlingePOSMerchant.Droid.Renderers
{
    public class RoundedEntryRendererAndroid : EntryRenderer
    {



        public RoundedEntryRendererAndroid(Context context) : base(context)
        {

        }


        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                //Control.SetBackgroundResource(Resource.Layout.rounded_shape);
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetCornerRadius(10f);
                gradientDrawable.SetStroke(5, Android.Graphics.Color.LightGray);
                gradientDrawable.SetColor(Android.Graphics.Color.LightGray);
                Control.SetBackground(gradientDrawable);

                Control.SetPadding(50, Control.PaddingTop, Control.PaddingRight,
                    Control.PaddingBottom);
            }
        }

        //protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //    base.OnElementPropertyChanged(sender, e);
        //    //ToDo: Customize Button
        //}



    }
}
