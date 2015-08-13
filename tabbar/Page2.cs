using System;

using Xamarin.Forms;

namespace tabbar
{
    public class Page2 : ContentPage
    {
        public Page2()
        {
            if (Device.OS == TargetPlatform.iOS)
                Padding = new Thickness(0, 80, 0, 0);
            
            Content = new StackLayout
            { 
                Children =
                {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}


