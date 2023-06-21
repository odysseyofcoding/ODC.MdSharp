using System.Text.Json.Serialization;

namespace ODC.MdSharp.Types.GlobalExpressEntry.Global
{
    /// <summary>
    ///     <remarks>
    ///         <para>
    ///             Visit <seealso href="https://wiki.melissadata.com/index.php?title=Express_Entry:GlobalExpressAddress">MelissaWiki GlobalExpressAddress</seealso> for further Informations
    ///         </para>
    ///         <para>
    ///             Contains an Array of <see cref="Address"/> records which has the nullable Field <see cref="Extras"/>.<br/>
    ///             Please check Extras for null before accessing this property.<br/>
    ///         </para>
    ///     </remarks>
    ///     Note: Responses are Encoded in UTF-8
    /// </summary>
    public record GlobalExpressAddressRecord([property: JsonPropertyName("Address")] GlobalExpressAddressRecord.Address AddressSuggestion)
    {
        /// <param name="UDPRN">The Unique Delivery Point Reference Number issued by Royal Mail. This is an 8-digit unique number.</param>
        /// <param name="UPRN">The Unique Property Reference Number issued by Royal Mail. This is a number unique to each address in GB. This is a unique number up to 12-digits long.</param>
        /// <param name="AddrObjectResultCode">When set to results this will return the Address Object result codes for each address in the Extras field. For example, a USPS only address will return "AddrObjectResultCode": "AS01"</param>
        public record Extras(string? UDPRN, string? UPRN, string? AddrObjectResultCode);
        
        /// <summary>
        /// Single AddressSugestion
        /// </summary>
        /// <param name="FormattedAddress"></param>
        /// <param name="Address1"></param>
        /// <param name="Address2"></param>
        /// <param name="Address3"></param>
        /// <param name="Address4"></param>
        /// <param name="Address5"></param>
        /// <param name="Address6"></param>
        /// <param name="Address7"></param>
        /// <param name="Address8"></param>
        /// <param name="Address9"></param>
        /// <param name="Address10"></param>
        /// <param name="Address11"></param>
        /// <param name="Address12"></param>
        /// <param name="DeliveryAddress"></param>
        /// <param name="DeliveryAddress1"></param>
        /// <param name="DeliveryAddress2"></param>
        /// <param name="DeliveryAddress3"></param>
        /// <param name="DeliveryAddress4"></param>
        /// <param name="DeliveryAddress5"></param>
        /// <param name="DeliveryAddress6"></param>
        /// <param name="DeliveryAddress7"></param>
        /// <param name="DeliveryAddress8"></param>
        /// <param name="DeliveryAddress9"></param>
        /// <param name="DeliveryAddress10"></param>
        /// <param name="DeliveryAddress11"></param>
        /// <param name="DeliveryAddress12"></param>
        /// <param name="CountryName"></param>
        /// <param name="ISO3166_2"></param>
        /// <param name="ISO3166_3"></param>
        /// <param name="ISO3166_N"></param>
        /// <param name="SuperAdministrativeArea"></param>
        /// <param name="AdministrativeArea"></param>
        /// <param name="SubAdministrativeArea"></param>
        /// <param name="Locality"></param>
        /// <param name="CityAccepted"></param>
        /// <param name="CityNotAccepted"></param>
        /// <param name="DependentLocality"></param>
        /// <param name="DoubleDependentLocality"></param>
        /// <param name="Thoroughfare"></param>
        /// <param name="DependentThoroughfare"></param>
        /// <param name="Building"></param>
        /// <param name="Premise"></param>
        /// <param name="SubBuilding"></param>
        /// <param name="PostalCode"></param>
        /// <param name="PostalCodePrimary"></param>
        /// <param name="PostalCodeSecondary"></param>
        /// <param name="Organization"></param>
        /// <param name="PostBox"></param>
        /// <param name="Unmatched"></param>
        /// <param name="GeneralDelivery"></param>
        /// <param name="DeliveryInstallation"></param>
        /// <param name="Route"></param>
        /// <param name="AddidtionalContent"></param>
        /// <param name="CountrySubdivisionCode"></param>
        /// <param name="MAK"></param>
        /// <param name="BaseMAK"></param>
        /// <param name="DistanceFromPoint"></param>
        /// <param name="Extras"></param>
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
            Extras? Extras
        );
    }
}
