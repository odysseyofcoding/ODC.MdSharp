using System.Text.Json.Serialization;

namespace ODC.MdSharp.Types.GlobalExpressEntry.Global
{
    /// <summary>
    ///         <para>
    ///             Visit <seealso href="https://wiki.melissadata.com/index.php?title=Express_Entry:GlobalExpressAddress">MelissaWiki GlobalExpressAddress</seealso> for further Informations
    ///         </para>
    ///         <para>
    ///             Contains an Array of <see cref="Result.Address"/> records.<br/>
    ///             Please check Extras for null before accessing this property.<br/>
    ///         </para>
    ///     Note: Responses are Encoded in UTF-8
    /// </summary>
    public record GlobalExpressResponse(string Version, string ResultCode, string ErrorString, GlobalExpressResponse.Result[] Results) : IExpressResponse
    {
        /// <summary/>
        public record Result([property: JsonPropertyName("Address")] Result.Address AddressSuggestion)
        {
            /// <summary/>
            public record Address
            (
               [property: JsonPropertyName("Address")] string FormattedAddress,
                string Address1,
                string Address2,
                string Address3,
                string Address4,
                string Address5,
                string Address6,
                string Address7,
                string Address8,
                string Address9,
                string Address10,
                string Address11,
                string Address12,
                string DeliveryAddress,
                string DeliveryAddress1,
                string DeliveryAddress2,
                string DeliveryAddress3,
                string DeliveryAddress4,
                string DeliveryAddress5,
                string DeliveryAddress6,
                string DeliveryAddress7,
                string DeliveryAddress8,
                string DeliveryAddress9,
                string DeliveryAddress10,
                string DeliveryAddress11,
                string DeliveryAddress12,
                string CountryName,
                string ISO3166_2,
                string ISO3166_3,
                string ISO3166_N,
                string SuperAdministrativeArea,
                string AdministrativeArea,
                string SubAdministrativeArea,
                string Locality,
                string CityAccepted,
                string CityNotAccepted,
                string DependentLocality,
                string DoubleDependentLocality,
                string Thoroughfare,
                string DependentThoroughfare,
                string Building,
                string Premise,
                string SubBuilding,
                string PostalCode,
                string PostalCodePrimary,
                string PostalCodeSecondary,
                string Organization,
                string PostBox,
                string Unmatched,
                string GeneralDelivery,
                string DeliveryInstallation,
                string Route,
                string AddidtionalContent,
                string CountrySubdivisionCode,
                string MAK,
                string BaseMAK,
                float DistanceFromPoint,
                object Extras
            );

        };

    };
}
