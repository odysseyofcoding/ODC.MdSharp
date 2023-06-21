using System.Text.Json.Serialization;

namespace ODC.MdSharp.Types.GlobalExpressEntry.US_CAN
{
    /// <param name="AddressSuggestion"></param>
    public record ExpressAddressRecord(ExpressAddressRecord.Address AddressSuggestion)
    {
        /// <param name="FormattedAddress"></param>
        /// <param name="City"></param>
        /// <param name="CityAccepted"></param>
        /// <param name="CityNotAccepted"></param>
        /// <param name="State"></param>
        /// <param name="PostalCode"></param>
        /// <param name="CountrySubdivisionCode"></param>
        /// <param name="AddressKey"></param>
        /// <param name="Suitename"></param>
        /// <param name="SuiteList"></param>
        /// <param name="PlusFour"></param>
        /// <param name="MAK"></param>
        /// <param name="BaseMAK"></param>
        public record Address
        (
            [property: JsonPropertyName("AddressLine1")] string FormattedAddress,
            string City,
            string CityAccepted,
            string CityNotAccepted,
            string State,
            string PostalCode,
            string CountrySubdivisionCode,
            string AddressKey,
            string Suitename,
            string SuiteList,
            string PlusFour,
            string MAK,
            string BaseMAK
        );
    };
}
