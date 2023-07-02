namespace ODC.MdSharp.RequestModels.GlobalExpressEntry
{
    /// <summary>
    /// ToDo: Write descriptions
    /// </summary>
    public class ExpressRequest
    {
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
            /// <summary/>
            public string Address1 { get; set; } = string.Empty;
            /// <summary/>
            public string Address2 { get; set; } = string.Empty;
            /// <summary/>
            public string Address3 { get; set; } = string.Empty;
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
            public int Maxrecords { get; set; } = 10;
            /// <summary/>
            public bool? NativeCharset { get; set; }
            /// <summary/>
            public string? Opt { get; set; } = string.Empty;
            /// <summary/>
            public string? Cols { get; set; } = string.Empty;

            /// <summary>
            /// Dummy Ctor with must fields only
            /// </summary>
            public GlobalRequestAddressModel(string country, ValidFormats format, string address1)
            {
                Country = country;
                Format = format.ToString();
                Address1 = address1;
            }
            /// <summary>
            /// Full Schema Ctor
            /// </summary>
            /// <param name="country"></param>
            /// <param name="format">JSON, XML</param>
            /// <param name="address1"></param>
            /// <param name="address2"></param>
            /// <param name="address3"></param>
            /// <param name="locality"></param>
            /// <param name="administrativeArea"></param>
            /// <param name="postalCode"></param>
            /// <param name="maxrecords">default 10</param>
            /// <param name="nativeCharset"></param>
            /// <param name="opt"></param>
            /// <param name="cols"></param>
            public GlobalRequestAddressModel(string country, ValidFormats format, string address1, string? address2 = default, string? address3 = default, string? locality = default, string? administrativeArea = default, string? postalCode = default, int maxrecords = 10, bool? nativeCharset = default, string? opt = default, string? cols = default)
            {
                Country = country; //?? throw new Exception("Please enter valid country"); EXAMPLE
                Format = format.ToString();
                Address1 = address1;
                Address2 = address2 ?? string.Empty;
                Address3 = address3 ?? string.Empty;
                Locality = locality ?? string.Empty;
                AdministrativeArea = administrativeArea ?? string.Empty;
                PostalCode = postalCode ?? string.Empty;
                Maxrecords = maxrecords;
                NativeCharset = nativeCharset;
                Opt = opt ?? string.Empty;
                Cols = cols ?? string.Empty;
            }
        }
        /// <summary/>
        public class GlobalRequestLocalityAdministrativeArea
        {
            /// <summary/>
            public enum ValidFormats
            {
                /// <summary/>
                JSON,
                /// <summary/>
                XML_NotSupportetYetByMdSharp
            }
            /// <summary/>
            public string Format { get; set; } = string.Empty;
            /// <summary/>
            public string? Locality { get; set; } = string.Empty;
            /// <summary/>
            public string? PostalCode { get; set; } = string.Empty;
            /// <summary/>
            public string Country { get; set; } = string.Empty;
            /// <summary/>
            public int Maxrecords { get; set; } = 10;
            /// <summary/>
            public bool? NativeCharset { get; set; }
            /// <summary/>
            public GlobalRequestLocalityAdministrativeArea(ValidFormats format, string locality, string country)
            {
                Format = format.ToString();
                Locality = locality;
                Country = country;
            }

        }
        /// <summary/>
        public class GlobalRequestAddressFreeFormModel : IRequestExpressFreeForm
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
            public int Maxrecords { get; set; } = 10;
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
            public GlobalRequestAddressFreeFormModel(string country, ValidFormats format, string searchTerm)
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
            public GlobalRequestAddressFreeFormModel(string country, ValidFormats format, string searchTerm, string? locality = default, string? administrativeArea = default, string? postalCode = default, int maxrecords = 10, bool? nativeCharset = default, string? opt = default, string? cols = default)
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
        /// <summary/>
        public class GlobalRequestPostalCode
        {
            /// <summary/>
            public enum ValidFormats
            {
                /// <summary/>
                JSON,
                /// <summary/>
                XML_NotSupportetYetByMdSharp
            }
            /// <summary/>
            public string Format { get; set; } = string.Empty;
            /// <summary/>
            public string PostalCode { get; set; } = string.Empty;
            /// <summary/>
            public string Country { get; set; } = string.Empty;
            /// <summary/>
            public int Maxrecords { get; set; } = 10;
            /// <summary/>
            public GlobalRequestPostalCode(ValidFormats format, string postalCode, string country, int maxRecords = 10)
            {
                Format = format.ToString();
                PostalCode = postalCode; 
                Country = country;
                Maxrecords = maxRecords;
            }
        }
        /// <summary/>
        public class GlobalRequestThoroughfare
        {
            /// <summary/>
            public enum ValidFormats
            {
                /// <summary/>
                JSON,
                /// <summary/>
                XML_NotSupportetYetByMdSharp
            }
            /// <summary/>
            public string Format { get; set; } = string.Empty;
            /// <summary/>
            public string Thoroughfare { get; set; } = string.Empty;
            /// <summary/>
            public string PostalCode { get; set; } = string.Empty;
            /// <summary/>
            public string Country { get; set; } = string.Empty;
            /// <summary/>
            public int Maxrecords { get; set; } = 10;
            /// <summary/>
            public GlobalRequestThoroughfare(ValidFormats format, string thoroughfare, string country, int maxRecords = 10)
            {
                Format = format.ToString();
                Thoroughfare = thoroughfare;
                Country = country;
                Maxrecords = maxRecords;
            }
            /// <summary/>
            public GlobalRequestThoroughfare(ValidFormats format,string thoroughfare, string postalCode, string country, int maxRecords = 10)
            {
                Format = format.ToString();
                Thoroughfare = thoroughfare;
                PostalCode = postalCode;
                Country = country;
                Maxrecords = maxRecords;
            }
        }
    }
}
