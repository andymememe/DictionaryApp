using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DictionaryAPI.Utils;
using DictionaryAPI.ApiClient;

namespace DictionaryAPI
{
    public class DictionaryAPIConnection
    {
        public static readonly string URLString = "https://glosbe.com/gapi/translate?from={0}&dest={1}&format=json&phrase={2}&pretty=true";

        internal const int LOCALE_SYSTEM_DEFAULT = 0x0800;
        internal const int LCMAP_TRADITIONAL_CHINESE = 0x04000000;

        // Simplified Chinese to Tradional Chinese
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int LCMapString(int Locale, int dwMapFlags, string lpSrcStr, int cchSrc, [Out] string lpDestStr, int cchDest);

        public async static Task<string> GetResult(IApiClient client, string fromCode, string toCode, string input)
        {
            string connUrl = string.Format(URLString, fromCode, toCode, input);
            string jsonText = await client.GetResultAsync(connUrl);

            return ParseResult(fromCode, toCode, jsonText);
        }

        private static string ParseResult(string fromCode, string toCode, string jsonText)
        {
            try
            {
                Translate result = JsonConvert.DeserializeObject<Translate>(jsonText);
                string translateResult = "(查無結果)";

                if (result.result != "ok")
                {
                    translateResult = result.result;
                }
                else if (result.tuc != null &&
                         result.tuc.Length > 0)
                {
                    if (!fromCode.Equals(toCode) &&
                        result.tuc[0].phrase != null) // Translate
                    {
                        translateResult = result.tuc[0].phrase.text;
                    }
                    else if (fromCode.Equals(toCode) &&
                             result.tuc[0].meanings != null &&
                             result.tuc[0].meanings.Length > 0)// Meaning
                    {
                        translateResult = result.tuc[0].meanings[0].text;
                    }
                }

                if (toCode != "zho")
                {
                    return translateResult;
                }

                return ToTraditionalChinese(translateResult);
            }
            catch (Exception e)
            {
                return string.Format("(剖析錯誤: {0})", e.Message);
            }
        }

        private static string ToTraditionalChinese(string input)
        {
            string resultToHanT = new string(' ', input.Length);
            LCMapString(LOCALE_SYSTEM_DEFAULT,
                        LCMAP_TRADITIONAL_CHINESE,
                        input,
                        input.Length,
                        resultToHanT,
                        input.Length); // Translating Chinese Result (Simp. -> Trad.)
            return resultToHanT;
        }
    }
}
