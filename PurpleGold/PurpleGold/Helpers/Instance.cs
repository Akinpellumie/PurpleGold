using PurpleGold.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleGold.Helpers
{
    public class Instance : BaseViewModel
    {
        // Singleton for use throughout the app
        public static Instance Current = new Instance();

        //Don't allow creation of the class elsewhere in the app.
        private Instance()
        {

        }

        private string currentAmount;

        //property for whether a file is being played or not
        public string CurrentAmount
        {
            get
            {
                return currentAmount;
            }
            set
            {
                currentAmount = value;
                OnPropertyChanged(CurrentAmount);
            }
        }
    }
}
