using System;
using System.ComponentModel;
using PurpleGold.Controls;
using PurpleGold.iOS.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(CustomDatePicker), typeof(CustomDatePickerRenderer))]
namespace PurpleGold.iOS.Controls
{
    public class CustomDatePickerRenderer : DatePickerRenderer
    {
        //protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    base.OnElementPropertyChanged(sender, e);

        //    Control.Layer.BorderWidth = 0;
        //    Control.BorderStyle = UITextBorderStyle.None;
        //}
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            if (this.Control == null)
                return;
            var element = e.NewElement as CustomDatePicker;
            if (!string.IsNullOrWhiteSpace(element.Placeholder))
            {
                Control.Text = element.Placeholder;
            }
            Control.BorderStyle = UITextBorderStyle.None;;
            Control.Layer.BorderWidth = 0;  

           Control.ShouldEndEditing += (textField) => {
               var seletedDate = (UITextField)textField;
               var text = seletedDate.Text;
               if (text == element.Placeholder)
               {
                   Control.Text = DateTime.Now.ToString("dd/MM/yyyy");
               }
               return true;
           };
        }
        private void OnCanceled(object sender, EventArgs e)
        {
            Control.ResignFirstResponder();
        }
        private void OnDone(object sender, EventArgs e)
        {
            Control.ResignFirstResponder();
        }
    }
}