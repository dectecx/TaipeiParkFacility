using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tpf.Library.Services
{
    public class OpdGovService : DbBaseService
    {
        /// <summary>
        /// 發出request要求,並取回response
        /// </summary>
        /// <param name="url">網址</param>
        /// <returns></returns>
        private async Task<string> HttpClient_GetAsync(string url)
        {
            string outputString = null;

            /***********
             * 建立 HttpClient
            ***********/
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                //指定 request 的 method 與 detail url
                using (HttpRequestMessage request = new HttpRequestMessage())
                {
                    request.Method = HttpMethod.Get;

                    /***********
                     * 發出並將回應內容存入response
                    ***********/
                    await client.SendAsync(request)
                                .ContinueWith(responseTask =>
                                {
                                    HttpResponseMessage response = responseTask.GetAwaiter().GetResult();
                                    /***********
                                     * 將回應結果內容取出並轉為 string 輸出
                                    ***********/
                                    response.Content.Headers.ContentType.CharSet = "UTF-8";
                                    outputString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                                });
                }
            }
            return outputString;
        }

        public async Task<bool> GetData()
        {
            string url = "https://quality.data.gov.tw/dq_download_json.php?nid=136476&md5_url=62f38dc1dbb089337559a65284128cf8";
            var result = await HttpClient_GetAsync(url);
            return true;
        }

        public async Task<string> GetDataStr()
        {
            string url = "https://quality.data.gov.tw/dq_download_json.php?nid=136476&md5_url=62f38dc1dbb089337559a65284128cf8";
            var result = await HttpClient_GetAsync(url);
            return result;
        }
    }
}
