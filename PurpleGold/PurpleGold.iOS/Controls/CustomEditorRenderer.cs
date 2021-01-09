using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using PurpleGold;
using PurpleGold.iOS;
using PurpleGold.Controls;
using System.ComponentModel;
using System;
using PurpleGold.iOS.Controls;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace PurpleGold.iOS.Controls
{
    public class CustomEditorRenderer : EditorRenderer
    {
        private nfloat transparent;

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            Control.Layer.BorderWidth = 0;
            Control.Layer.RemoveBackgroundLayer();
        }
    }
}