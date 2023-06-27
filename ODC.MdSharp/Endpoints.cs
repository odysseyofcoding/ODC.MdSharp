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
                        public const string Country = "GlobalExpressCountry";
                        /// <summary/>
                        public const string Address = "GlobalExpressAddress";
                        /// <summary/>
                        public const string FreeForm = "GlobalExpressFreeForm";
                        /// <summary/>
                        public const string PostalCode = "GlobalExpressPostalCode";
                        /// <summary/>
                        public const string Thoroughfare = "GlobalExpressThoroughfare";
                        /// <summary/>
                        public const string LocalityAdministrativeArea = "GlobalExpressLocalityAdministrativeArea";
                    }
                    /// <summary/>
                    public class US_CAN
                    {
                        /// <summary/>
                        public const string Address = "ExpressAddress";
                        /// <summary/>
                        public const string CityState = "ExpressCityState";
                        /// <summary/>
                        public const string FreeForm = "ExpressFreeForm";
                        /// <summary/>
                        public const string PostalCode = "ExpressPostalCode";
                        /// <summary/>
                        public const string Street = "ExpressStreet";
                    }
                }
            }

        }
    }
}
