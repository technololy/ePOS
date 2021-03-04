using System;
using System.Collections.Generic;

using Xamarin.Forms;
using static SterlingePOSMerchant.Models.PayThruModels;

namespace KMN_Test.Custom
{
    public partial class MyToggleImageButton : ContentView
    {
        public MyToggleImageButton()
        {
            InitializeComponent();
        }

        public void SetItemSource(List<ImageAndText> itemSource)
        {
            if (itemSource != null && itemSource.Count > 0)
                BindableLayout.SetItemsSource(myStack, itemSource);
        }
        public void SetItemSource(List<string> itemSource)
        {
            if (itemSource != null && itemSource.Count > 0)
                BindableLayout.SetItemsSource(myStack, itemSource);
        }
        void DocTypeTap_Tapped(System.Object sender, System.EventArgs e)
        {
            var obj = (TappedEventArgs)e;
            var selected = (obj.Parameter as ImageAndText).Text;
            SelectedItem = selected;
            var selectedFrame = (Frame)sender;
            var parent = selectedFrame.Parent as StackLayout;
            foreach (var item in parent.Children)
            {
                var frm = item as Frame;


                VisualStateManager.GoToState(frm, "Normal");

            }
            VisualStateManager.GoToState((Frame)sender, "Selected");
        }


        public string SelectedItem
        {
            get => (string)GetValue(SelectedItemProperty) ?? "";
            set
            {
                SetValue(SelectedItemProperty, value);

                // txtText.Text = value;
            }
        }

        public static readonly BindableProperty SelectedItemProperty =
         BindableProperty.Create(propertyName: "SelectedItem", returnType: typeof(string), defaultBindingMode: BindingMode.TwoWay,
             declaringType: typeof(VisualElement), defaultValue: "", propertyChanged: IsSelectedItemChanged);



        private static void IsSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var obj = bindable as MyToggleButton;
            //obj.txtText.Text = (string)newValue;
        }
    }
}
