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
