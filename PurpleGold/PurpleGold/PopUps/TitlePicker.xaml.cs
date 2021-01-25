using PurpleGold.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurpleGold.PopUps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TitlePicker
    {
        GenderViewModel genderViewModel;
        public TitlePicker()
        {
            genderViewModel = new GenderViewModel(Navigation);
            InitializeComponent();
            this.BindingContext = genderViewModel;
        }
    }
}