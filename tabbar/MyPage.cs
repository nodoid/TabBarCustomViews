using System;

using Xamarin.Forms;

namespace tabbar
{
    public class MyPage : TopTabPage
    {
        readonly Page Page1, Page2, Page3;

        public MyPage()
        {
            if (Device.OS == TargetPlatform.iOS)
                Padding = new Thickness(0, 20, 0, 0);

            CreateUI();
        }

        void CreateUI()
        {
            // the following won't show
            Title = "Tab pages";

            // create the links to the pages
            // Rather than use the ItemSource, we shall create Children to the page.
            // Remember, a tabbedpage is a container with each page associated with it
            // being a child from it

            Children.Add(new Page1() { Title = "Basic info", Icon = "cross.png" });
            Children.Add(new Page2() { Title = "Conditions", Icon = "weather.png" });

            // Current page is the tabbedpage property denoting which of the child pages you're on
            CurrentPage = Children[0];
        }

        public void SwitchToTab1()
        {
            CurrentPage = Page1;
        }

        public void SwitchToTab2()
        {
            CurrentPage = Page2;
        }
    }
}


