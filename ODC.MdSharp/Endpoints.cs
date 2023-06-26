using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ODC.MdSharp
{
    public partial class MdClientService
    {

        /// <summary>
        /// ToDo: Remember to add NoFallBacKserverRoute when processing in EU for GDPR reasons
        /// </summary>
        public class MdEnpoints
        {
            /// <summary/>
            public class GlobalCloudServices
            {
                /// <summary/>
                public class ExpressEntry
                {
                    /// <summary/>
                    public class Global
                    {
                        /// <summary/>
                        public const string GlobalExpressCountry = nameof(GlobalExpressCountry);
                        /// <summary/>
                        public const string Address = "GlobalExpressAddress";
                        /// <summary/>
                        public const string GlobalExpressFreeForm = nameof(GlobalExpressFreeForm);
                        /// <summary/>
                        public const string GlobalExpressPostalCode = nameof(GlobalExpressPostalCode);
                        /// <summary/>
                        public const string GlobalExpressThoroughfare = nameof(GlobalExpressThoroughfare);
                        /// <summary/>
                        public const string GlobalExpressLocalityAdministrativeArea = nameof(GlobalExpressLocalityAdministrativeArea);
                    }
                    /// <summary/>
                    public class US_CAN
                    {
                        /// <summary/>
                        public const string ExpressAddress = nameof(ExpressAddress);
                        /// <summary/>
                        public const string ExpressCityState = nameof(ExpressCityState);
                        /// <summary/>
                        public const string ExpressFreeForm = nameof(ExpressFreeForm);
                        /// <summary/>
                        public const string ExpressPostalCode = nameof(ExpressPostalCode);
                        /// <summary/>
                        public const string ExpressStreet = nameof(ExpressStreet);
                    }
                }
            }

        }
    }
}
