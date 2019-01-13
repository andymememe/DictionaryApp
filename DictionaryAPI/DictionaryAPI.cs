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

namespace DictionaryAPI
{
    public class DictionaryAPIConnection
    {
        public static readonly string URLString = "https://glosbe.com/gapi/translate?from={0}&dest={1}&format=json&phrase={2}&pretty=true";

        internal const int LOCALE_SYSTEM_DEFAULT = 0x0800;
        internal const int LCMAP_SIMPLIFIED_CHINESE = 0x02000000;
        internal const int LCMAP_TRADITIONAL_CHINESE = 0x04000000;

        // Simplified Chinese to Tradional Chinese
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int LCMapString(int Locale, int dwMapFlags, string lpSrcStr, int cchSrc, [Out] string lpDestStr, int cchDest);

        public async static Task<string> GetResult(string fromCode, string toCode, string input)
        {
            string jsonText = "";
            string connUrl = string.Format(URLString, fromCode, toCode, input);
            try
            {
                WebResponse httpResult = await WebRequest.Create(connUrl).GetResponseAsync();
                Stream textStream = httpResult.GetResponseStream();
                StreamReader textReader = new StreamReader(textStream);
                jsonText = await textReader.ReadToEndAsync();
            }
            catch (Exception e)
            {
                return string.Format("(連線錯誤: {0})", e.Message);
            }

            return ParseResult(fromCode, toCode, jsonText);
        }

        private static string ParseResult(string fromCode, string toCode, string jsonText)
        {
            try
            {
                Translate result = JsonConvert.DeserializeObject<Translate>(jsonText);
                string translateResult = "";
                string resultToZHTW = "";

                if (!fromCode.Equals(toCode)) // Translate
                {
                    if (result.result == "ok" &&
                        result.tuc != null &&
                        result.tuc.Length > 0 &&
                        result.tuc[0].phrase != null)
                    {
                        translateResult = result.tuc[0].phrase.text;
                    }
                    else
                    {
                        translateResult = "(查無結果)";
                    }
                }
                else // Meaning
                {
                    if (result.result == "ok" &&
                        result.tuc != null &&
                        result.tuc.Length > 0 &&
                        result.tuc[0].meanings != null &&
                        result.tuc[0].meanings.Length > 0)
                    {
                        translateResult = result.tuc[0].meanings[0].text;
                    }
                    else
                    {
                        translateResult = "(查無結果)";
                    }
                }

                if (toCode != "zho")
                {
                    return translateResult;
                }

                resultToZHTW = new string(' ', translateResult.Length);
                LCMapString(LOCALE_SYSTEM_DEFAULT,
                            LCMAP_TRADITIONAL_CHINESE,
                            translateResult,
                            translateResult.Length,
                            resultToZHTW,
                            translateResult.Length); // Translating Chinese Result (Simp. -> Trad.)
                return resultToZHTW;
            }
            catch (Exception e)
            {
                return string.Format("(剖析錯誤: {0})", e.Message);
            }
        }
    }
}
