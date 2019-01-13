using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryAPI.ApiClient
{
    public class HttpApiClient : IApiClient
    {
        public async Task<string> GetResultAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    return await client.GetStringAsync(url);
                }
                catch (Exception e)
                {
                    return string.Format("{{result: \"(連線錯誤: {0})\"}}", e.Message);
                }
            }
        }
    }
}
