using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampManage.MAUI.Services
{   
    //Learn more about connecting to local web services from Android emulators
    //https://learn.microsoft.com/en-us/dotnet/maui/data-cloud/local-web-services?view=net-maui-7.0
    public partial class HttpClientService
    {
        public HttpClient GetPlatformSpecificHttpClient()
        {
#if ANDROID
            var httpMessageHandler = GetAndroidHttpMessageHandler();
#else
            var httpMessageHandler = GetDefaultHttpMessageHandler();
#endif
            return new HttpClient(httpMessageHandler);
        }

#if ANDROID
        private HttpMessageHandler GetAndroidHttpMessageHandler()
        {
            var androidHttpHandler = new Xamarin.Android.Net.AndroidMessageHandler
            {
                ServerCertificateCustomValidationCallback = (httpRequestMessage, certificate, chain, sslPolicyErrors) =>
                {
                    if (certificate?.Issuer == "CN=localhost" || sslPolicyErrors == System.Net.Security.SslPolicyErrors.None)
                        return true;
                    return false;
                }
            };
            return androidHttpHandler;
        }
#endif

        private HttpMessageHandler GetDefaultHttpMessageHandler()
        {
            return new HttpClientHandler();
        }
    }
}

