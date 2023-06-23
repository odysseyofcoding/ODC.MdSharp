namespace ODC.MdSharp.Types.GlobalExpressEntry
{
    /// <summary>
    ///         <para>
    ///             Visit <seealso href="https://www.melissa.com/quickstart-guides/express-entry">MelissaWiki Express Entry</seealso> for updates.
    ///         </para>
    ///         <para>
    ///             Note: Responses are Encoded in UTF-8
    ///         </para>
    ///         <para>
    ///             Returns 3 result codes to indicate Success level
    ///         </para>
    ///         <list type="bullet"><item>XS01 = Complete result set returned - Good</item><item>XS02 = Partial result set returned - Increase maxrecords</item><item>XS03 = No results returned - Have user to correct input</item></list>
    ///         <typeparamref name="T"/> Any of ExpressEntry Types
    /// </summary>
    public record ExpressRootRecord<T>
    (
        string Version,
        string ResultCode,
        string ErrorCode,
        List<T> Results
    );
}
