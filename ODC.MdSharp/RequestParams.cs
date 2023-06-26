using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODC.MdSharp
{
    public partial class MdClientService
    {

        /// <summary/>
        public class CountryISO2
        {
            /// <summary/>
            public const string DE = "DE";
            /// <summary/>
            public const string EN = "EN";
            /// <summary/>
            public const string FR = "FR";
        }
        /// <summary>
        /// </summary>
        public enum NativeCharset
        {
            /// <summary/>
            Kanji,
            /// <summary/>
            Hebrew,
            /// <summary/>
            SimplifiedChinese,
            /// <summary/>
            Russian,
            /// <summary/>
            Greek,
            /// <summary/>
            Arabic,
        }
    }

}
