using PurpleGold.Controls;
using Xamarin.Forms;
using PurpleGold.iOS.Controls;
using Xamarin.Forms.Platform.iOS;
using System.Runtime.Remoting.Contexts;

[assembly: ExportRenderer(typeof(CustomSearchBar), typeof(CustomSearchRenderer))]
namespace PurpleGold.iOS.Controls
{
    public class CustomSearchRenderer : SearchBarRenderer
    {
        public CustomSearchRenderer(Context context)
        {
            AutoPackage = false;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.RemoveBackgroundLayer();
            }
        }
    }
}