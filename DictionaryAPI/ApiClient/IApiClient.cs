using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryAPI.ApiClient
{
    interface IApiClient
    {
        void GetResultAsync(string uri);
    }
}
