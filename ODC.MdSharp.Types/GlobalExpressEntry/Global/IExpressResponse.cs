using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODC.MdSharp.Types.GlobalExpressEntry.Global
{
    /// <summary>
    /// Base Response
    /// </summary>
    public interface IExpressResponse
    {
        /// <summary/>
        public string Version { get; init; }
        /// <summary/>
        public string ResultCode { get; init; }
        /// <summary/>
        public string ErrorString { get; init; }

    }
}
