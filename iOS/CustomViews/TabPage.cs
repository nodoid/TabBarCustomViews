using CoreGraphics;
using tabbar;
using tabbar.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.Linq;

[assembly: ExportRenderer(typeof(TopTabPage), typeof(TabPage))]
namespace tabbar.iOS
{
    public class TabPage : TabbedRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            TabBar.Frame = new CGRect(0, 20, 320, 70);
            TabBar.BackgroundColor = UIColor.Red;
        }
    }
}

