using DictionaryAPI.ApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryAPI.Test
{
    class MockApiClient : IApiClient
    {
        public enum Types { Ok, EmptyTranlate, EmptyMeaning, ConnError };

        private Types _type;

        public MockApiClient(Types type)
        {
            _type = type;
        }

        public Task<string> GetResultAsync(string url)
        {
            switch (_type)
            {
                case Types.Ok:
                    break;
                case Types.EmptyTranlate:
                    break;
                case Types.EmptyMeaning:
                    break;
                case Types.ConnError:
                default:
                    return new Task<string>(() => "(連線錯誤)");
            }
        }
    }
}
