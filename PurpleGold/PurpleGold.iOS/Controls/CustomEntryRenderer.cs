using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using PurpleGold;
using PurpleGold.iOS;
using PurpleGold.Controls;
using System.ComponentModel;
using PurpleGold.iOS.Controls;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace PurpleGold.iOS.Controls
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            Control.Layer.BorderWidth = 0;
            Control.BorderStyle = UITextBorderStyle.None;
        }
    }
}