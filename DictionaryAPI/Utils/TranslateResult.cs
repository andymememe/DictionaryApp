using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryAPI.Utils
{
    public class TranslateResult
    {
        public Phrase phrase { get; set; }
        public Meaning[] meanings { get; set; }
    }
}
