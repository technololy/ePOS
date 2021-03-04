using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SterlingePOSMerchant.Models;

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

        private void AppendAccessToken(dynamic values, HttpRequestMessage request, bool isGet = false, bool AfterLogin = false)
        {
            if (string.IsNullOrEmpty(Settings.AppSettings.AccessToken))
            {
                return;
            }
            Debug.WriteLine($"Added authorization token  {Settings.AppSettings.AccessToken}");
            if (isGet)
            {
                if (AfterLogin)
                {
                    request.Headers.Add("USER_AUTHORIZATION", Settings.AppSettings.AccessTokenAfterLogin);
                    request.Headers.Add("Authorization", Settings.AppSettings.AccessToken);

                }
                else
                {
                    request.Headers.Add("Authorization", Settings.AppSettings.AccessToken);

                }

                // Debug.WriteLine("Added authorization token" + Settings.AppSettings.AccessToken);

            }
            else
            {
                if (AfterLogin)
                {
                    request.Headers.Add("USER_AUTHORIZATION", Settings.AppSettings.AccessTokenAfterLogin);
                    request.Headers.Add("Authorization", Settings.AppSettings.AccessToken);

                }
                else
                {
                    request.Headers.Add("Authorization", Settings.AppSettings.AccessToken);

                }

            }






        }






        internal async Task<(bool isSuccess, T model)> SendHashRequest<T>(dynamic values, bool isGet, string endPoint, CancellationTokenSource cancellation = null, bool useHardCodedJson = false, bool afterLogin = false)
        {
            try
            {
                var _uri = endPoint;
                Debug.WriteLine("URL being called >>>>>>>>>>>" + _uri);

                var cts = new CancellationTokenSource(Constants.MaximumConnection);
                HttpRequestMessage request;
                if (isGet)
                {
                    request = new HttpRequestMessage(new HttpMethod("GET"), _uri);
                    HashRequest("", request, true);
                }
                else
                {
                    request = new HttpRequestMessage(new HttpMethod("POST"), _uri)
                    {
                        Content = Helper.StringifyAndEncrypt(values, useHardCodedJson)
                    };
                    HashRequest(values, request);
                    AppendAccessToken("", request, false, AfterLogin: afterLogin);

                }

                HttpResponseMessage response;

                if (cancellation != null)
                    response = await client.SendAsync(request, cancellation.Token);
                else
                    response = await client.SendAsync(request, cts.Token);


                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("success>>>>>>>>>>>" + content + " and status code is" + response.StatusCode);
                    return (true, JsonConvert.DeserializeObject<T>(content));
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"failure>>>>>>>>>>>{content} and status code is ====>>>{response.StatusCode.ToString()}");

                    var deserialisedObj = JsonConvert.DeserializeObject<T>(content);
                    return (false, deserialisedObj);
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return (false, default);

            }
        }

        internal async Task<(bool isSuccess, T model)> SendHashRequestAfterLogin<T>(dynamic values, bool isGet, string endPoint, CancellationTokenSource cancellation = null, bool useHardCodedJson = false)
        {
            try
            {
                var _uri = endPoint;
                Debug.WriteLine("URL being called >>>>>>>>>>>" + _uri);

                var cts = new CancellationTokenSource(Constants.MaximumConnection);
                HttpRequestMessage request;
                if (isGet)
                {
                    request = new HttpRequestMessage(new HttpMethod("GET"), _uri);
                    HashRequest("", request, true);
                }
                else
                {
                    request = new HttpRequestMessage(new HttpMethod("POST"), _uri)
                    {
                        Content = Helper.StringifyAndEncrypt(values, useHardCodedJson)
                    };
                    HashRequest(values, request);
                    AppendAccessToken("", request, false);

                }

                HttpResponseMessage response;

                if (cancellation != null)
                    response = await client.SendAsync(request, cancellation.Token);
                else
                    response = await client.SendAsync(request, cts.Token);


                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("success>>>>>>>>>>>" + content);
                    return (true, JsonConvert.DeserializeObject<T>(content));
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"failure>>>>>>>>>>>{content} and status code is ====>>>{response.StatusCode.ToString()}");

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
                var cts = new CancellationTokenSource(Constants.MaximumConnection);
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
                    response = await client.SendAsync(request, cts.Token);


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
