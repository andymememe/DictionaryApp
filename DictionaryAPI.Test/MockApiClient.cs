using DictionaryAPI.ApiClient;
using DictionaryAPI.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryAPI.Test
{
    class MockApiClient : IApiClient
    {
        public enum Type {
            OkNotChsPhrase,
            OkChsPhrase,
            OkNotChsMeaning,
            OkChsMeaning,
            NullTranslatePhrase,
            ZeroMeaning,
            EmptyMeaning,
            ConnError,
            ZeroResult,
            NullResult,
            NotJson
        };

        private Type _type;

        public MockApiClient()
        {
            _type = Type.OkNotChsPhrase;
        }

        public void SetType(Type type)
        {
            _type = type;
        }

        public async Task<string> GetResultAsync(string url)
        {
            Translate mockResult = new Translate();
            mockResult.result = "ok";

            switch (_type)
            {
                case Type.OkNotChsPhrase:
                    mockResult.tuc = new TranslateResult[1]
                    {
                        new TranslateResult()
                        {
                            phrase = new Phrase() { text = "English" }
                        }
                    };
                    break;
                case Type.OkChsPhrase:
                    mockResult.tuc = new TranslateResult[1]
                    {
                        new TranslateResult()
                        {
                            phrase = new Phrase() { text = "简化字" }
                        }
                    };
                    break;
                case Type.OkNotChsMeaning:
                    mockResult.tuc = new TranslateResult[1]
                    {
                        new TranslateResult()
                        {
                            meanings = new Meaning[1] {
                                new Meaning() { text = "English meaning" }
                            }
                        }
                    };
                    break;
                case Type.OkChsMeaning:
                    mockResult.tuc = new TranslateResult[1]
                    {
                        new TranslateResult()
                        {
                            meanings = new Meaning[1] {
                                new Meaning() { text = "简化字" }
                            }
                        }
                    };
                    break;
                case Type.NullTranslatePhrase:
                    mockResult.tuc = new TranslateResult[1]
                    {
                        new TranslateResult()
                        {
                            phrase = null
                        }
                    };
                    break;
                case Type.ZeroMeaning:
                    mockResult.tuc = new TranslateResult[1] {
                        new TranslateResult() {
                            meanings = new Meaning[0]
                        }
                    };
                    break;
                case Type.EmptyMeaning:
                    mockResult.tuc = new TranslateResult[1] {
                        new TranslateResult() {
                            meanings = null
                        }
                    };
                    break;
                case Type.ConnError:
                    mockResult.result = "(連線錯誤)";
                    break;
                case Type.ZeroResult:
                    mockResult.tuc = new TranslateResult[0];
                    break;
                case Type.NullResult:
                    mockResult.tuc = null;
                    break;
                case Type.NotJson:
                default:
                    return await Task.Run(() => "Not Json");
            }

            return await Task.Run(() => JsonConvert.SerializeObject(mockResult));
        }
    }
}
