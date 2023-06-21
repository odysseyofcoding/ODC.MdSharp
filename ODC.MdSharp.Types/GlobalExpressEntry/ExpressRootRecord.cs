using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODC.MdSharp.Types.GlobalExpressEntry
{
    /// <summary>
    /// Root Object for every GlobalExpressEntry response
    /// </summary>
    public record ExpressRootRecord<T>
    (
        string Version,
        string ResultCode,
        string ErrorCode,
        List<T> Results
    );
}
