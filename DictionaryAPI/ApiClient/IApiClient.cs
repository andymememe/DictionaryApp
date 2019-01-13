using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryAPI.ApiClient
{
    public interface IApiClient
    {
        Task<string> GetResultAsync(string url);
    }
}
