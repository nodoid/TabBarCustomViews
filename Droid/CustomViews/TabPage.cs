using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Graphics.Drawables;
using Android.Widget;
using tabbar;
using tabbar.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TopTabPage), typeof(TabPage))]
namespace tabbar.Droid
{
    public class TabPage : TabbedRenderer
    {
        Activity activity;
        List<string> filenames;

        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            base.OnElementChanged(e);
            filenames = e.NewElement.Children.Select(t => t.Icon.File).ToList();
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            activity = this.Context as Activity;
        }

        protected override void OnWindowVisibilityChanged(Android.Views.ViewStates visibility)
        {
            base.OnWindowVisibilityChanged(visibility);
            var actionBar = activity.ActionBar;
            var colorDrawable = new ColorDrawable(Android.Graphics.Color.Red);
            actionBar.SetStackedBackgroundDrawable(colorDrawable);
            ActionBarTabsSetup(actionBar);
        }

        void ActionBarTabsSetup(ActionBar actionBar)
        {
            for (var i = 0; i < actionBar.NavigationItemCount; ++i)
            {
                var tab = actionBar.GetTabAt(i);
                var id = GetImageFromFilename(i);
                if (id != 0)
                    TabSetup(tab, id);
            }
        }

        void TabSetup(ActionBar.Tab tab, int resID)
        {
            var linLay = new LinearLayout(activity)
            {
                LayoutParameters = new LayoutParams(LayoutParams.WrapContent, 180),
                Orientation = Orientation.Vertical,
            };
            linLay.SetHorizontalGravity(Android.Views.GravityFlags.Center);
            var imageView = new ImageView(activity);
            imageView.SetImageResource(resID);
            imageView.SetPadding(-35, 4, -35, 0);
            imageView.SetMinimumWidth(60);

            var textView = new TextView(activity)
            {
                Text = tab.Text
            };
            linLay.AddView(imageView);
            linLay.AddView(textView);
            tab.SetCustomView(linLay);
        }

        int GetImageFromFilename(int n)
        {
            var filename = filenames[n].Split('.');
            var id = Resources.GetIdentifier(filename[0], "drawable", activity.PackageName);
            return id;
        }
    }
}

