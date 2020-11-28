using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SterlingePOSMerchant.ViewModels
{
    public class IndexViewModel : BaseViewModel
    {

        public ICommand ResetCmd { get; set; }
        public IndexViewModel()
        {
            ResetCmd = new Command(GetToken);
        }


        public async void GetToken()
        {
            using (Acr.UserDialogs.UserDialogs.Instance.Loading(""))
            {
                var response = await Reset();

            }
        }
    }
}
