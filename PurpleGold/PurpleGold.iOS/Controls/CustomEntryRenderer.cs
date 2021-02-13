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
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				// do whatever you want to the UITextField here!
				//Control.BackgroundColor = UIColor.FromRGB(204, 153, 255);
				Control.BorderStyle = UITextBorderStyle.None;
				Control.Layer.BorderWidth = 0;
			}
		}
	}
}