namespace ODC.MdSharp.RequestModels.GlobalExpressEntry
{
    /// <summary>
    /// ToDo: Write descriptions
    /// </summary>
    public class ExpressRequest
    {
        /// <summary/>
        public class Endpoints
        {
            /// <summary/>
            public class Global
            {
                /// <summary/>
                public const string GlobalExpressCountry = nameof(GlobalExpressCountry);
                /// <summary/>
                public const string GlobalExpressAddress = nameof(GlobalExpressAddress);
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

        /// <summary/>
        public class GlobalRequestAddressModel
        {
            /// <summary/>
            public enum ValidFormats
            {
                /// <summary/>
                JSON,
                /// <summary/>
                XML_NotSupportetYetByMdSharp
            }
            /// <summary>required to avoid bad requests</summary>
            public string SearchTerm { get; set; } = string.Empty;
            /// <summary/>
            public string Format { get; set; } = string.Empty;
            /// <summary/>
            public string? Locality { get; set; } = string.Empty;
            /// <summary/>
            public string Country { get; set; } = string.Empty;
            /// <summary/>
            public string? AdministrativeArea { get; set; } = string.Empty;
            /// <summary/>
            public string? PostalCode { get; set; } = string.Empty;
            /// <summary/>
            public int Maxrecords { get; set; }
            /// <summary/>
            public bool? NativeCharset { get; set; }
            /// <summary/>
            public string? Opt { get; set; } = string.Empty;
            /// <summary/>
            public string? Cols { get; set; } = string.Empty;

            /// <summary>
            /// Dummy Ctor with must fields only
            /// </summary>
            /// <param name="country"></param>
            /// <param name="format"></param>
            /// <param name="searchTerm"></param>
            public GlobalRequestAddressModel(string country, ValidFormats format, string searchTerm)
            {
                Country = country;
                Format = format.ToString();
                SearchTerm = searchTerm;
            }
            /// <summary>
            /// Full Schema Ctor
            /// </summary>
            /// <param name="country"></param>
            /// <param name="format">JSON, XML</param>
            /// <param name="searchTerm"></param>
            /// <param name="locality"></param>
            /// <param name="administrativeArea"></param>
            /// <param name="postalCode"></param>
            /// <param name="maxrecords">default 10</param>
            /// <param name="nativeCharset"></param>
            /// <param name="opt"></param>
            /// <param name="cols"></param>
            public GlobalRequestAddressModel(string country, ValidFormats format, string searchTerm, string? locality = default, string? administrativeArea = default, string? postalCode = default, int maxrecords = 10, bool? nativeCharset = default, string? opt = default, string? cols = default)
            {
                Country = country;
                SearchTerm = searchTerm;
                Locality = locality;
                AdministrativeArea = administrativeArea;
                PostalCode = postalCode;
                Maxrecords = maxrecords;
                NativeCharset = nativeCharset;
                Opt = opt;
                Cols = cols;
                Format = format.ToString();
            }
        }
    }
}
