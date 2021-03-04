using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using SterlingePOSMerchant.Services;

namespace SterlingePOSMerchant.Views
{
    public partial class Menu : ContentPage
    {


        void myCV_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            try
            {

                if (!e.CurrentSelection.Any())
                {
                    return;
                }
                var title = (e.CurrentSelection.FirstOrDefault() as DashBoardTips).Key;

                // var type = Menu.MenuNavigator(title);

                if (title != null)
                {
                    title = title.ToLower();
                    if (title == ("createmerchant"))
                    {
                        Navigation.PushAsync(new Views.OnBoarding.RegNewSuperMerchant(false, "07"));//mervhant

                    }
                    else if (title == ("createsubmerchant"))//submerchabt
                    {
                        Navigation.PushAsync(new Views.OnBoarding.CreateNewSubMerchantProfile());

                    }
                }

                myCV.SelectedItem = null;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Views.OnBoarding.Landing());
        }


        public Menu()
        {
            InitializeComponent();
            LoadMenus();
            BindingContext = this;
        }
        public class DashBoardTips
        {
            public string Subject { get; set; }
            public string Body { get; set; }
            public string Action { get; set; }
            public string Image { get; set; }
            public string Key { get; set; }
        }

        public List<DashBoardTips> DashBoardTipsList { get; set; }
        public void LoadMenus()
        {
            DashBoardTipsList = new List<DashBoardTips>();
            // if (Services.DataWareHouse.LoggedInMerchantData?.userRole?.ToLower() == "merchant")
            // {
            //     var DashBoardTipsList__ = new List<DashBoardTips>()
            //{

            //    new DashBoardTips{Action="Go",Subject="Create merchant",Key="createmerchant",Body="Create merchant that will have submerchants under them",Image=IconFont.OfficeBuilding},
            //    new DashBoardTips{Action="Go",Subject="Create Sub Merchant",Key="createsubmerchant",Body="Create sub merchants that will function like tellers",Image=IconFont.ContactlessPayment},


            //};

            //    DashBoardTipsList.AddRange(DashBoardTipsList__);
            //}
            var DashBoardTipsList_ = new List<DashBoardTips>()
           {
                   new DashBoardTips{Action="Go",Subject="Create merchant",Key="createmerchant",Body="Create merchant that will have submerchants under them",Image=IconFont.OfficeBuilding},
               new DashBoardTips{Action="Go",Subject="Create Sub Merchant",Key="createsubmerchant",Body="Create sub merchants that will function like tellers",Image=IconFont.ContactlessPayment},
               new DashBoardTips{Action="Go",Subject="View profile",Body="View basic info here",Image=IconFont.ViewAgenda},
               //     new DashBoardTips{Action="Go",Subject="My Vehicles",Body="See all the vehicles saved to your profile. Add new vehicles and manage existing",Image=IconFont.CarConvertible},
               //new DashBoardTips{Action="Go",Subject="My wallet and Transaction",Body="Top up your wallet to pay for rides. See your transaction history too",Image=IconFont.Wallet},
               //new DashBoardTips{Action="Go",Subject="My profile",Body="See your profile. Edit it",Image=IconFont.FaceProfile},
               // new DashBoardTips{Action="Go",Subject="Visibility",Body="Be seen only by people you know",Image=IconFont.Eye},
               //  new DashBoardTips{Action="Go",Subject="Promos",Body="See what you can do to reduce what you pay as a passenger and earn more as a driver",Image=IconFont.Gift},
               //      new DashBoardTips{Action="Go",Subject="Ride emergency alert",Body="Add some emergency number, we will alert them whenever you are on a ride",Image=IconFont.Gift},
               //          new DashBoardTips{Action="Go",Subject="Report/Observations",Body="Report any member, trip, issues or give general suggestions",Image=IconFont.PoliceBadge},
               //                        new DashBoardTips{Action="Go",Subject="Delete account",Body="Delete your account. we are sorry to see you go",Image=IconFont.Delete},

               


           };

            DashBoardTipsList.AddRange(DashBoardTipsList_);
        }
    }
}
