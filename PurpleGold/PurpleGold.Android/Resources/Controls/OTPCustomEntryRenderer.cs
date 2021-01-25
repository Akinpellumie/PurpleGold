using System;
using Android.Content;
using Android.Views;
using PurpleGold.Controls;
using PurpleGold.Droid.Resources.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(OTPCustomEntry), typeof(OTPCustomEntryRenderer))]
namespace PurpleGold.Droid.Resources.Controls
{
    [Obsolete]
    public class OTPCustomEntryRenderer : EntryRenderer
    {
        public OTPCustomEntryRenderer(Context context) : base(context)
        {
        }

        public override bool DispatchKeyEvent(KeyEvent e)
        {
            if (e.Action == KeyEventActions.Down)
            {
                if (e.KeyCode == Keycode.Del)
                {
                    if (string.IsNullOrWhiteSpace(Control.Text))
                    {
                        var entry = (OTPCustomEntry)Element;
                        entry.OnBackspacePressed();
                    }
                }
            }
            return base.DispatchKeyEvent(e);
        }

        protected override void
        OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
        }

    }
}