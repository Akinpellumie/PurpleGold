using Newtonsoft.Json;
using PurpleGold.Helpers;
using PurpleGold.Models;
using PurpleGold.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace PurpleGold.ViewModels
{
    public class AssetViewModel : BaseViewModel
    {
        public AssetViewModel(INavigation navigation)
        {

            Navigation = navigation;
            GetAsset();
        }

        #region Properties
        private ObservableCollection<Asset> assetModelList;
        public ObservableCollection<Asset> AssetModelList
        {
            get => assetModelList;
            set
            {
                assetModelList = value;
                OnPropertyChanged(nameof(AssetModelList));

            }
        }

        private string formattedAmount;
        public string FormattedAmount
        {
            get => formattedAmount;
            set
            {
                formattedAmount = value;
                OnPropertyChanged(nameof(FormattedAmount));

            }
        }
        #endregion

        #region Methods
        public void GetAsset()
        {
            assetModelList = new ObservableCollection<Asset>();
            assetModelList.Add(new Asset { Id = "001", Count = "PORTFOLIO 1", RemDays = "3  DAYS REMAINING", Duration= "1 AUG  2020 - 30 AUG 2020", CurrentDate = "Today’s Opening", CurrentAmount= "N52,030.60", OpeningAmount= "N51,790.00", EndDate= "fri. 31, dec. 2020", StartDate= "tue. 01, dec. 2020" });
            assetModelList.Add(new Asset { Id = "002", Count = "PORTFOLIO 1", RemDays = "3  DAYS REMAINING", Duration = "1 JUL  2020 - 30 JUL 2020", CurrentDate = "Yesterday", CurrentAmount= "N51,790.00", OpeningAmount= "N43,687.00", EndDate= "fri. 31, dec. 2020", StartDate= "tue. 01, dec. 2020" });
            assetModelList.Add(new Asset { Id = "003", Count = "PORTFOLIO 1", RemDays = "3  DAYS REMAINING", Duration = "1 JUN  2020 - 30 JUN 2020", CurrentDate = "Tue. 15th Dec, 2020", CurrentAmount= "N43,687.00", OpeningAmount= "N40,221.00", EndDate= "fri. 31, dec. 2020", StartDate= "tue. 01, dec. 2020" });
            assetModelList.Add(new Asset { Id = "004", Count = "PORTFOLIO 1", RemDays = "3  DAYS REMAINING", Duration = "1 JUN  2020 - 30 JUN 2020", CurrentDate = "Mon. 14th Dec, 2020", CurrentAmount= "N40,221.00", OpeningAmount= "N39,674.00", EndDate= "fri. 31, dec. 2020", StartDate= "tue. 01, dec. 2020" });

            AssetModelList = assetModelList;
        }
        #endregion
    }
}
