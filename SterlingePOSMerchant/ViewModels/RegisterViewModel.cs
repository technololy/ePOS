using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SterlingePOSMerchant.Models;
using SterlingePOSMerchant.Settings;
using Xamarin.Forms;
using static SterlingePOSMerchant.Models.PayThruModels;

namespace SterlingePOSMerchant.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private CreateMerchant _merchant;
        private List<BankInfo> banksList;

        public List<BankInfo> BanksList { get => banksList; set { SetProperty(ref banksList, value); } }
        public CreateMerchant Merchant { get => _merchant; set { SetProperty(ref _merchant, value); } }
        public OTP_Password GetOTP_Password { get; set; }
        public System.Windows.Input.ICommand RegisterCommand { get; set; }
        public System.Windows.Input.ICommand OTP_PasswordCmd { get; set; }
        public RegisterViewModel()
        {
            Merchant = new CreateMerchant();
            GetOTP_Password = new OTP_Password();
            BanksList = SterlingePOSMerchant.Services.Helper.GetbankInfo();
            //RegisterCommand = new Command(RegisterMerchant);
            //OTP_PasswordCmd = new Command(VerifyOTP_SetPassword);
#if DEBUG

#endif
        }
        public void DummyMerchantProfile()
        {
            string rdm = RandomString(4);
            string rdm2 = RandomDigits(9);
            Merchant = new CreateMerchant()
            {
                address1 = $"chris okafor {rdm}",
                Address2 = $"chris okafor {rdm}",

                firstName = $"ololade {rdm}",
                middleName = $"ahmed {rdm}",
                lastName = $"oyebanji {rdm}",
                emailAddress = $"loladeking{rdm}@gmail.com",

                userName = $"loladeking {rdm}",

                phone = rdm2,
                phone2 = rdm2

            };
            Merchant.phoneNumberPri = "+234" + Merchant.phoneNumberPri;
            BanksList = SterlingePOSMerchant.Services.Helper.GetbankInfo();

        }



        public void DummyNewcreateMerchant()
        {
            string rdm = RandomString(4);
            string rdm2 = RandomDigits(9);
            Merchant = new CreateMerchant()
            {
                address = "chris okafor",
                name = "ololade enterprise " + rdm,

                email = $"loladeking{rdm}@gmail.com",
                fee = "200.12",
                tin = RandomString(5),
                contact = rdm,
                phone = rdm2,
                createdBy = "1",
                state = "NA",
                accountName = "USE QR",
                accountNumber = "5050104057",
                bankCode = "999070",

            };
            Merchant.phoneNumberPri = "+234" + Merchant.phoneNumberPri;
            BanksList = SterlingePOSMerchant.Services.Helper.GetbankInfo();

        }


        public void DummyNewcreateSuperMerchant()
        {
            string rdm = RandomString(4);
            string rdm2 = RandomDigits(9);
            Merchant = new CreateMerchant()
            {
                address1 = "chris okafor",
                Address2 = "chris okafor",
                firstName = "ololade " + rdm,
                middleName = "ahmed " + rdm,
                lastName = "oyebanji " + rdm,
                phone = rdm2,
                phone2 = rdm2,
                emailAddress = $"loladeking{rdm}@gmail.com",
                userName = $"loladeking {rdm}",
                multiStore = true,
                fee = "50",
                accountName = "ololade " + rdm + " ahmed " + rdm + " oyebanji " + rdm,
                accountNumber = "0025769041",
                state = "Lagos"


            };
            Merchant.phoneNumberPri = "+234" + Merchant.phoneNumberPri;
            Merchant.phoneNumberSec = "+234" + Merchant.phoneNumberPri;
            BanksList = SterlingePOSMerchant.Services.Helper.GetbankInfo();

        }

        public void DummyNewCreateSubMerchantProfile()
        {
            string rdm = RandomString(4);
            string rdm2 = RandomDigits(9);
            Merchant = new CreateMerchant()
            {
                address1 = "chris okafor",
                Address2 = "chris okafor",
                firstName = "ololade " + rdm,
                middleName = "ahmed " + rdm,
                lastName = "oyebanji " + rdm,
                phone = rdm2,
                phone2 = rdm2,
                emailAddress = $"loladeking{rdm}@gmail.com",
                userName = $"loladeking {rdm}",
                multiStore = true,
                fee = "50",
                accountName = "ololade " + rdm + " ahmed " + rdm + " oyebanji " + rdm,
                accountNumber = "0025769041",
                state = "Lagos"


            };
            Merchant.phoneNumberPri = "+234" + Merchant.phoneNumberPri;
            Merchant.phoneNumberSec = "+234" + Merchant.phoneNumberPri;
            BanksList = SterlingePOSMerchant.Services.Helper.GetbankInfo();

        }


        // Generates a random string with a given size.
        private readonly Random _random = new Random();
        public string RandomDigits(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }
        public string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):   
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length = 26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
        public void DummyNewcreateSubMerchant()
        {
            string rdm = RandomString(3);
            string rdm2 = RandomDigits(7);
            Merchant = new CreateMerchant()
            {
                name = "ololade" + rdm,

                email = $"SubMerchant{rdm}@mail.com",
                phoneNumber = rdm2,
                subFixed = "1",
                subAmount = "100.12"
            };
            Merchant.phoneNumberPri = "+234" + Merchant.phoneNumberPri;
        }


        //public async Task<bool> RegisterSuperMerchantx(object x = null)
        //{
        //    string url;
        //    Merchant.userRole = getUserRoleValue(Merchant.userRoleText);
        //    if (Merchant.userRole.ToLower() == ("merchant"))
        //    {
        //        url = AppSettings.BaseURL + "admin/create-profile-m";
        //        var obj = new { Merchant };
        //        using (Acr.UserDialogs.UserDialogs.Instance.Loading(""))
        //        {
        //            var (isSuccess, model) = await APIServices.SendHashRequest<CreateMerchant>(obj, false, url);
        //            if (isSuccess)
        //            {
        //                Services.DataWareHouse.MerchantData = model;
        //                //MessagingCenter.Send(this, MessageKeys.Registeration, true);
        //                return isSuccess;

        //            }
        //            else
        //            {
        //                return isSuccess;

        //                // MessagingCenter.Send(this, MessageKeys.Registeration, false);

        //            }
        //        }
        //    }
        //    else
        //    {
        //        url = AppSettings.BaseURL + "processor/create-sub-merchant";
        //        Merchant.merchantNumber = Services.DataWareHouse.MerchantData.code;
        //        var subMerchantObj = new { merchantNumber = Merchant.merchantNumber, name = Merchant.firstName + " " + Merchant.lastName, phoneNumber = Merchant.phoneNumberPri, timestamp = DateTime.Now.Ticks.ToString(), email = Merchant.emailAddress, subAmount = "100", subFixed = "1" };
        //        var obj = new { subMerchantObj };
        //        using (Acr.UserDialogs.UserDialogs.Instance.Loading(""))
        //        {
        //            var (isSuccess, model) = await APIServices.SendHashRequest<CreateMerchant>(subMerchantObj, false, url);
        //            if (isSuccess)
        //            {
        //                Services.DataWareHouse.MerchantData = model;
        //                //MessagingCenter.Send(this, MessageKeys.Registeration, true);
        //                return isSuccess;

        //            }
        //            else
        //            {
        //                return isSuccess;

        //                // MessagingCenter.Send(this, MessageKeys.Registeration, false);

        //            }
        //        }
        //    }


        //}

        public async Task<(bool isSuccess, string Message)> CreateSuperMerchantProfile(object x = null, bool useHardCodedJson = false, bool afterLogin = false)
        {
            string url;
            // Merchant.userRole = getUserRoleValue(Merchant.userRoleText);
            //
            Merchant.userRole = "03";
            Merchant.multiStore = true;
            url = AppSettings.BaseURL + "admin/create-profile-m";

            var superMerchantObj = new
            {
                fullName = $"{Merchant.firstName} {Merchant.middleName} {Merchant.lastName}",
                firstName = Merchant.firstName,
                middleName = Merchant.middleName,
                lastName = Merchant.lastName,
                emailAddress = Merchant.emailAddress,
                phoneNumberPri = "+234" + Merchant.phone,
                phoneNumberSec = "+234" + Merchant.phone2,
                address1 = Merchant.address1,
                address2 = Merchant.Address2,
                timestamp = Merchant.timestamp,
                multiStore = Merchant.multiStore,
                userRole = "03",
                userName = Merchant.userName
            };
            using (Acr.UserDialogs.UserDialogs.Instance.Loading(""))
            {
                var (isSuccess, model) = await APIServices.SendHashRequest<CreateMerchant>(superMerchantObj, false, url);


                if (isSuccess)
                {
                    if (afterLogin)
                        Services.DataWareHouse.LoggedInMerchantData = model;
                    //MessagingCenter.Send(this, MessageKeys.Registeration, true);
                    return (isSuccess, "Success");

                }
                else
                {
                    return (isSuccess, model?.errorDesc ?? "Error");

                    // MessagingCenter.Send(this, MessageKeys.Registeration, false);

                }


            }




        }


        public async Task<(bool isSuccess, string Message)> CreateMerchantProfileAtOnboarding(object x = null, bool useHardCodedJson = false, bool afterLogin = false)
        {
            string url;
            // Merchant.userRole = getUserRoleValue(Merchant.userRoleText);
            //
            Merchant.userRole = "03";

            url = AppSettings.BaseURL + "admin/create-profile-m";

            var superMerchantObj = new
            {
                fullName = $"{Merchant.firstName} {Merchant.middleName} {Merchant.lastName}",
                firstName = Merchant.firstName,
                middleName = Merchant.middleName,
                lastName = Merchant.lastName,
                emailAddress = Merchant.emailAddress,
                phoneNumberPri = "+234" + Merchant.phone,
                phoneNumberSec = "+234" + Merchant.phone2,
                address1 = Merchant.address1,
                address2 = Merchant.Address2,
                timestamp = Merchant.timestamp,
                multiStore = Merchant.multiStore,
                userRole = "03",
                userName = Merchant.userName,
                state = Merchant.state,
                accountNumber = Merchant.accountNumber,
                accountName = Merchant.accountName,
                fee = Merchant.fee,
                bankCode = Merchant.bankCode

            };
            using (Acr.UserDialogs.UserDialogs.Instance.Loading(""))
            {
                var (isSuccess, model) = await APIServices.SendHashRequest<CreateMerchant>(superMerchantObj, false, url);


                if (isSuccess)
                {
                    if (afterLogin)//means creaion is done in-app
                        Services.DataWareHouse.LoggedInMerchantData = model;
                    else // means its onboarding
                        Services.DataWareHouse.UserNameDuringOnboarding = Merchant.userName;

                    //MessagingCenter.Send(this, MessageKeys.Registeration, true);
                    return (isSuccess, "Success");

                }
                else
                {
                    return (isSuccess, model?.errorDesc ?? "Error");

                    // MessagingCenter.Send(this, MessageKeys.Registeration, false);

                }


            }




        }


        public async Task<(bool isSuccess, string Message)> CreateSubMerchantProfile(object x = null)
        {
            string url;
            // Merchant.userRole = getUserRoleValue(Merchant.userRoleText);
            //
            Merchant.userRole = "05";
            Merchant.multiStore = false;
            url = AppSettings.BaseURL + "admin/create-profile-submerchant";

            var subMerchantObj = new
            {
                fullName = $"{Merchant.firstName} {Merchant.middleName} {Merchant.lastName}",
                firstName = Merchant.firstName,
                middleName = Merchant.middleName,
                lastName = Merchant.lastName,
                emailAddress = Merchant.emailAddress,
                phoneNumberPri = "+234" + Merchant.phone,
                phoneNumberSec = "+234" + Merchant.phone2,
                address1 = Merchant.address1,
                address2 = Merchant.Address2,
                timestamp = Merchant.timestamp,
                multiStore = Merchant.multiStore,
                userRole = "05",
                userName = Merchant.userName,
                code = Services.DataWareHouse.LoggedInMerchantData?.code,
                state = Merchant.state,
                accountNumber = Merchant.accountNumber,
                accountName = Merchant.accountName,
                fee = Merchant.fee,
                bankCode = Merchant.bankCode,
                subAmount = Merchant.subAmount,
                subFixed = Merchant.subFixed

            };
            using (Acr.UserDialogs.UserDialogs.Instance.Loading(""))
            {
                var (isSuccess, model) = await APIServices.SendHashRequest<CreateMerchant>(subMerchantObj, false, url, afterLogin: true);


                if (isSuccess)
                {
                    // Services.DataWareHouse.LoggedInMerchantData = model;
                    //MessagingCenter.Send(this, MessageKeys.Registeration, true);
                    return (isSuccess, "Success");

                }
                else
                {
                    return (isSuccess, model?.errorDesc ?? "Error");

                    // MessagingCenter.Send(this, MessageKeys.Registeration, false);

                }


            }




        }

        public async Task<(bool isSuccess, string Message)> CreateMerchant(object x = null)
        {
            string url;
            // Merchant.userRole = getUserRoleValue(Merchant.userRoleText);
            Merchant.userRole = "07";
            Merchant.channelId = "01";
            Merchant.code = Services.DataWareHouse.LoggedInMerchantData?.code ?? "0000000001";
            Merchant.userName = "+234" + Merchant.phone;

            url = AppSettings.BaseURL + "processor/create-merchant";
            var MerchantObj = new { tin = Merchant.tin, name = Merchant.name, address = Merchant.address, code = Merchant.code, phone = "+234" + Merchant.phone, timestamp = Merchant.timestamp, email = Merchant.email, fee = Merchant.fee, contact = Merchant.contact, accountNumber = Merchant.accountNumber, accountName = Merchant.accountName, bankCode = Merchant.bankCode, channelId = Merchant.channelId, username = "+234" + Merchant.phone };
            //var obj = new { Merchant };
            using (Acr.UserDialogs.UserDialogs.Instance.Loading(""))
            {
                var (isSuccess, model) = await APIServices.SendHashRequest<CreateMerchant>(MerchantObj, false, url);
                if (isSuccess)
                {
                    Services.DataWareHouse.LoggedInMerchantData = model;
                    //MessagingCenter.Send(this, MessageKeys.Registeration, true);
                    return (isSuccess, "Success");

                }
                else
                {
                    return (isSuccess, model.errorDesc);

                    // MessagingCenter.Send(this, MessageKeys.Registeration, false);

                }
            }



        }


        public async Task<(bool isSuccess, string Message)> CreateMerchantProfile(object x = null, bool useHardCodedJson = false, bool afterLogin = false)
        {
            string url;
            Merchant.userRole = "07";

            Merchant.code = Services.DataWareHouse.LoggedInMerchantData?.code ?? "NA";


            url = AppSettings.BaseURL + "admin/create-profile-merchant";
            var MerchantObj = new
            {
                fullName = $"{Merchant.firstName} {Merchant.middleName} {Merchant.lastName}",
                firstName = Merchant.firstName,
                middleName = Merchant.middleName,
                lastName = Merchant.lastName,
                emailAddress = Merchant.emailAddress,
                phoneNumberPri = "+234" + Merchant.phone,
                phoneNumberSec = "+234" + Merchant.phone2,
                address1 = Merchant.address1,
                address2 = Merchant.Address2,
                timestamp = Merchant.timestamp,
                multiStore = Merchant.multiStore,
                userRole = "07",
                userName = Merchant.userName,
                code = Services.DataWareHouse.LoggedInMerchantData?.code ?? "NA",
                state = Merchant.state,
                accountNumber = Merchant.accountNumber,
                accountName = Merchant.accountName,
                fee = Merchant.fee,
                bankCode = Merchant.bankCode
            };
            //var obj = new { Merchant };
            using (Acr.UserDialogs.UserDialogs.Instance.Loading(""))
            {
                var (isSuccess, model) = await APIServices.SendHashRequest<CreateMerchant>(MerchantObj, false, url, useHardCodedJson: useHardCodedJson, afterLogin: afterLogin);
                if (isSuccess)
                {
                    if (afterLogin)//means non-onboarding
                    {

                    }
                    else//means onboarding
                    {
                        Services.DataWareHouse.LoggedInMerchantData = model;

                    }
                    //MessagingCenter.Send(this, MessageKeys.Registeration, true);
                    return (isSuccess, "Success");

                }
                else
                {
                    return (isSuccess, model?.errorDesc ?? "error occured");

                    // MessagingCenter.Send(this, MessageKeys.Registeration, false);

                }
            }



        }


        public async Task<(bool isSuccess, string message)> CreateSubMerchant(object x = null)
        {
            string url;
            Merchant.userRole = "05";

            url = AppSettings.BaseURL + "processor/create-sub-merchant";
            Merchant.code = Services.DataWareHouse.LoggedInMerchantData.code;
            Merchant.userName = Merchant.email;
            var subMerchantObj = new { merchantNumber = Merchant.merchantNumber, name = Merchant.name, phoneNumber = "+234" + Merchant.phoneNumber, timestamp = Merchant.timestamp, code = Merchant.code, email = Merchant.email, subAmount = Merchant.subAmount, subFixed = Merchant.subFixed };
            var obj = new { subMerchantObj };
            using (Acr.UserDialogs.UserDialogs.Instance.Loading(""))
            {
                var (isSuccess, model) = await APIServices.SendHashRequest<CreateMerchant>(subMerchantObj, false, url);
                if (isSuccess)
                {
                    // Services.DataWareHouse.LoggedInMerchantData = model;
                    //MessagingCenter.Send(this, MessageKeys.Registeration, true);
                    return (isSuccess, "Success");

                }
                else
                {
                    return (isSuccess, model.errorDesc);

                    // MessagingCenter.Send(this, MessageKeys.Registeration, false);

                }
            }



        }




        public async Task<(bool status, string message)> VerifyOTP_SetPassword(object x, bool isOnboarding = false)
        {
            var obj = new { userName = Merchant.userName, otp = GetOTP_Password.OTP, password = GetOTP_Password.Password, verifyPassword = GetOTP_Password.VerifyPassword };

            if (GetOTP_Password.Password != GetOTP_Password.VerifyPassword)
            {
                return (false, "Password does not match");
            }

            string url = AppSettings.BaseURL + "admin/verify-otp";


            using (Acr.UserDialogs.UserDialogs.Instance.Loading(""))
            {
                var (isSuccess, model) = await APIServices.SendHashRequest<CreateMerchant>(obj, false, url);
                if (isSuccess)
                {
                    if (isOnboarding)
                    {
                        Services.DataWareHouse.LoggedInMerchantData = model;

                        Services.DataWareHouse.PassWordDuringOnboarding = GetOTP_Password.Password;
                    }


                    //  MessagingCenter.Send(this, MessageKeys.otp_password, true);
                    return (isSuccess, "success");

                }
                else
                {

                    //MessagingCenter.Send(this, MessageKeys.otp_password, false);
                    return (isSuccess, model?.errorDesc);

                }
            }

        }
        private string getUserRoleValue(string Role)
        {
            if (Role.ToLower() == "merchant")
            {
                return "07";
            }
            if (Role.ToLower() == "submerchant")
            {
                return "05";
            }
            return "05";
        }
    }
}
