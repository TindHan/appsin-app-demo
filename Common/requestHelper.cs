using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace app_act.Common
{
    public class requestHelper
    {
        public static string ApiDomain = (new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                            .AddEnvironmentVariables().Build())["setting:apiDomain"];
        public static async Task<string> postRequest(string url, string data)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(ApiDomain + url, content);
                    response.EnsureSuccessStatusCode(); // 确保HTTP成功状态值  
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseBody);
                    return responseBody;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return "{\"status\":\"fail\"}";
                }
            }
        }

        public static string genAukey()
        {
            string appSID = "52021156";
            string appSecret = "wGmt9o5ucmzLpszm";
            long timestamp = GetCurrentTimestampSeconds();
            string pubkey = "MEgCQQDOGE80bY9nK8Akxw+CXmsHqF7y/kPMbAim/M9hm3w0TN/h1cFONdo7OaWF3hBRAaTYwbdTTiTQjvgi7j31ExbdAgMBAAE=";
            string aukey = appSID + CryptRSA.RsaHelper.Encrypt(pubkey, appSID + ";" + appSecret + ";" + timestamp);
            return aukey;
        }

        public static long GetCurrentTimestampSeconds()
        {
            DateTime startTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime currentTime = DateTime.UtcNow;
            TimeSpan timeSpan = currentTime - startTime;
            return (long)timeSpan.TotalSeconds;
        }
    }
}
