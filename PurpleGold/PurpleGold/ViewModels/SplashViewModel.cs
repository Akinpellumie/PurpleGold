using PurpleGold.Models;
using PurpleGold.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace PurpleGold.ViewModels
{
    public class SplashViewModel : BaseViewModel
    {
        public SplashViewModel(INavigation navigation)
        {

            Navigation = navigation;
            GetSplash();
        }

        #region Properties
        private ObservableCollection<Splash> carouselModelList;
        public ObservableCollection<Splash> CarouselModelList
        {
            get => carouselModelList;
            set
            {
                carouselModelList = value;
                OnPropertyChanged(nameof(CarouselModelList));

            }
        }
        #endregion

        #region Methods
        public void GetSplash()
        {
            carouselModelList = new ObservableCollection<Splash>();
            carouselModelList.Add(new Splash { SplashImage = "invest.svg", Title = "PurpleVest", Subtitle = "Meet your investment Goals on the Go!", Description= "Everything you need to make money while you sleep is all you just got now" });
            carouselModelList.Add(new Splash { SplashImage = "atm.svg", Title = "PurpleVest", Subtitle = "Fastest withdrawal with no delay!", Description= "Everything you need to make money while you sleep is all you just got now" });
            carouselModelList.Add(new Splash { SplashImage = "swap.svg", Title = "PurpleVest", Subtitle = "Swap Currencies at the click of your finger!", Description= "Yes! we have made that entirely simple and easier and its all yours to explore" });
            carouselModelList.Add(new Splash { SplashImage = "transfer.svg", Title = "PurpleVest", Subtitle = "Your more than ordinary app has come with a better way to transfer funds!", Description= "Need to  transfer funds? worry less because the PurpleGold solution has melted the stress." });

            CarouselModelList = carouselModelList;
        
        }
        #endregion
    }
    }
