using System;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SterlingePOSMerchant.Services
{
    public class APIService
    {
        protected HttpClient client;

        public APIService()
        {
            client = new HttpClient(new HttpClientHandler
            {

                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
                {
                    //bypass
                    return true;
                },
            });

            System.Net.ServicePointManager.ServerCertificateValidationCallback =
          delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
          { return true; };

        }


        private void HashRequest(dynamic values, HttpRequestMessage request, bool isGet = false)
        {
            string clientkey = Settings.AppSettings.key;
            string clientIV = Settings.AppSettings.iv;

            if (isGet)
            {
                request.Headers.Add("ONB-CS", "");
                return;
            }

            string _values = JsonConvert.SerializeObject(values);
            var hash = Settings.Encryption.EncryptAES(_values, clientkey, clientIV);

            request.Headers.Add("ONB-CS", hash);

            //return (clientId, hash);
        }

        private void AppendAccessToken(dynamic values, HttpRequestMessage request, bool isGet = false)
        {
            if (string.IsNullOrEmpty(Settings.AppSettings.AccessToken))
            {
                return;
            }

            if (isGet)
            {
                request.Headers.Add("Authorization", Settings.AppSettings.AccessToken);
                return;
            }
            else
            {
                request.Headers.Add("Authorization", Settings.AppSettings.AccessToken);

            }





        }






        internal async Task<(bool isSuccess, T model)> SendHashRequest<T>(dynamic values, bool isGet, string endPoint, CancellationTokenSource cancellation = null)
        {
            try
            {
                var _uri = endPoint;

                HttpRequestMessage request;
                if (isGet)
                {
                    request = new HttpRequestMessage(new HttpMethod("GET"), _uri);
                    //HashRequest("", request, true);
                }
                else
                {
                    request = new HttpRequestMessage(new HttpMethod("POST"), _uri)
                    {
                        Content = Helper.StringifyAndEncrypt(values)
                    };
                    //HashRequest(values, request);
                    AppendAccessToken("", request, false);
                }

                HttpResponseMessage response;

                if (cancellation != null)
                    response = await client.SendAsync(request, cancellation.Token);
                else
                    response = await client.SendAsync(request);


                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return (true, JsonConvert.DeserializeObject<T>(content));
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine(content);

                    return (false, JsonConvert.DeserializeObject<T>(content));
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return (false, default);

            }
        }

        internal async Task<(bool isSuccess, T model)> SendRequest<T>(dynamic values, bool isGet, string endPoint, CancellationTokenSource cancellation = null)
        {
            try
            {
                var _uri = endPoint;

                HttpRequestMessage request;
                if (isGet)
                {
                    request = new HttpRequestMessage(new HttpMethod("GET"), _uri);
                    AppendAccessToken("", request, true);
                    //HashRequest("", request, true);
                }
                else
                {
                    request = new HttpRequestMessage(new HttpMethod("POST"), _uri)
                    {
                        Content = Helper.Stringify(values)
                    };
                    //HashRequest(values, request);
                    AppendAccessToken("", request, false);

                }

                HttpResponseMessage response;

                if (cancellation != null)
                    response = await client.SendAsync(request, cancellation.Token);
                else
                    response = await client.SendAsync(request);


                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine(content);
                    return (true, JsonConvert.DeserializeObject<T>(content));
                }

                else if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine(content);

                    return (false, JsonConvert.DeserializeObject<T>(content));
                }
                return (false, default);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return (false, default);

            }
        }




    }
}
