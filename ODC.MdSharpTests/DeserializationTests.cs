using ODC.MdSharp.Types.GlobalExpressEntry;
using ODC.MdSharp.Types.GlobalExpressEntry.Global;
using System.Diagnostics;
using System.Text.Json;

namespace ODC.MdSharpTests
{
    public class DeserializationTests
    {
        /// <summary>
        /// Test a batch of 100 address suggestions
        /// </summary>
        //https://wiki.melissadata.com/index.php?title=Express_Entry:Global_JSON_Response
        [Fact]
        public void DeserializeGlobalExpressAddress()
        {
            var dummyResponse = JsonSerializer.Deserialize<ExpressRootRecord<GlobalExpressAddressRecord>>(DummyData.DummyGlobalExpressAddressResponse.dummyGlobalAddressResponseJson)!;

            Assert.True(dummyResponse.ResultCode == "XS02");
        }
    }
}