using System.IO;
using System.Net;
using System.Net.WebSockets;
using System.Xml;
using System.Xml.Linq;

namespace Binance
{
    class Variables
    {
        public readonly static string apiUrl = "https://api.binance.com";
        public static string apiKey = " Your API Key ";
        public static string apiSecret = " Your API Secret ";
        public static string symbol, side, type, quantity, price, method, dataQueryString, signature;
        public static string url;
        public static string json;

        #region Connection
        public static WebClient client = new WebClient();
        public static XmlDocument xml = new XmlDocument();
        public static WebSocket webSocket;
        #endregion

        #region Request
        public static WebRequest request;
        public static WebResponse response;
        public static Stream responseStream;
        public static StreamReader readerStream;
        #endregion

        public static XmlNodeList list;
        public static XNode node;
        public static string[] symbols;
        public static float[] prices;
        public static string[] btcsymbols;
        public static string[] ethsymbols;
        public static string[] bnbsymbols;
        public static string[] usdtsymbols;
        public static float[] btcprices;
        public static float[] ethprices;
        public static float[] bnbprices;
        public static float[] usdtprices;
        public static float usdt, btc, eth, bnb;

    }
}
