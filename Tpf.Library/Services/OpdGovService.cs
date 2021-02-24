using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;
using Tpf.Library.ViewModels;

namespace Tpf.Library.Services
{
    public class OpdGovService : BaseService
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

        /// <summary>
        /// 取得資料列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<OpdGovRawVModel>> GetData()
        {
            var url = "https://quality.data.gov.tw/dq_download_json.php?nid=136476&md5_url=62f38dc1dbb089337559a65284128cf8";
            var result = await HttpClient_GetAsync(url);
            var dataTable = JsonConvert.DeserializeObject<DataTable>(result, 
                new JsonSerializerSettings { StringEscapeHandling = StringEscapeHandling.EscapeNonAscii });
            var list = new List<OpdGovRawVModel>();
            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(new OpdGovRawVModel
                {
                    ParkName = row["公園名稱"].ToString(),
                    Dict = row["行政區"].ToString(),
                    ManagementUnit = row["管理單位"].ToString(),
                    CombinedPlayEquipment = row["組合遊具"].ToString(),
                    MillstoneSlide = row["磨石滑梯"].ToString(),
                    Swing = row["鞦韆"].ToString(),
                    Seesaw = row["翹翹板"].ToString(),
                    Shake = row["搖搖樂"].ToString(),
                    Climbing = row["攀爬組"].ToString(),
                    Sandpit = row["戲沙坑"].ToString(),
                    SwingBoat = row["擺盪船索"].ToString(),
                    Other = row["其他"].ToString(),
                });
            }
            return list;
        }
    }
}
