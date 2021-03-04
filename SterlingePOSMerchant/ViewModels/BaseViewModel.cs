using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using SterlingePOSMerchant.Models;
using SterlingePOSMerchant.Services;
using SterlingePOSMerchant.Settings;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SterlingePOSMerchant.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion




        private Services.APIService _APIServices;

        internal Services.APIService APIServices
        {
            get
            {
                if (_APIServices == null)
                {
                    _APIServices = new Services.APIService();
                    return DataWareHouse.APIServices = _APIServices;
                }

                return _APIServices;

            }

        }

        public async Task<bool> Reset()
        {

            string url = AppSettings.BaseURL + "admin/reset";
            var obj = new { ux = AppSettings.ClientId };
            var response = await APIServices.SendRequest<QuickType.ResetResponse>(obj, false, url);
            if (response.isSuccess)
            {
                Settings.AppSettings.iv = response.model.Iv;
                Settings.AppSettings.key = response.model.Key;
                await Xamarin.Essentials.SecureStorage.SetAsync("iv", Settings.AppSettings.iv);
                await Xamarin.Essentials.SecureStorage.SetAsync("key", Settings.AppSettings.key);
                return (true);

            }
            else
            {
                return (false);

            }


        }


        public async Task<bool> SysLogin()
        {

            string url = AppSettings.BaseURL + "admin/sys-login";
            var obj = new { ux = AppSettings.ClientId, AppSettings.iv, AppSettings.key };

            var response = await APIServices.SendRequest<PayThruModels.BearerClass>(obj, false, url);
            if (response.isSuccess)
            {
                Settings.AppSettings.AccessToken = response.model.Authorization;
                Debug.WriteLine($"token at sys login is {Settings.AppSettings.AccessToken}");
                return (true);

            }
            else
            {
                return (false);

            }


        }


        public async Task<bool> UserLogin(string username, string password)
        {

            string url = AppSettings.BaseURL + "admin/user-login";
            var obj = new { userName = username, password = password };

            var response = await APIServices.SendHashRequest<CreateMerchant>(obj, false, url);
            if (response.isSuccess)
            {

                // Settings.AppSettings.AccessToken = response.model.jwt;
                Settings.AppSettings.AccessTokenAfterLogin = response.model.jwt;
                Services.DataWareHouse.LoggedInMerchantData = response.model;
                Debug.WriteLine($"token at user login is {Settings.AppSettings.AccessToken}");

                return (true);

            }
            else
            {
                Services.DataWareHouse.ErrorLoggingInData = response.model;
                return (false);

            }


        }




    }
}
