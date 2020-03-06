using System;
using System.Security.Cryptography;
using System.Text;

namespace Binance
{
    class Utilities : Variables
    {
        public static string GenerateSignature(string apiSecret, string message)
        {
            var key = Encoding.UTF8.GetBytes(apiSecret);
            string stringHash;
            using (var hmac = new HMACSHA256(key))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
                stringHash = BitConverter.ToString(hash).Replace("-", "");
            }

            return stringHash;
        }

        public static string GenerateTimeStamp(DateTime baseDateTime)
        {
            var dtOffset = new DateTimeOffset(baseDateTime);
            return dtOffset.ToUnixTimeMilliseconds().ToString();
        }
        
        public static void SplitArray()
        {
            btc = prices[Array.IndexOf(symbols, "BTCUSDT")];
            eth = prices[Array.IndexOf(symbols, "ETHUSDT")];
            bnb = prices[Array.IndexOf(symbols, "BNBUSDT")];
            int btcsayac = 0;
            int ethsayac = 0;
            int bnbsayac = 0;
            int usdtsayac = 0;
            for (int i = 0; i < symbols.Length; i++)
            {
                if (symbols[i].EndsWith("BTC"))
                {
                    Array.Resize(ref btcsymbols, btcsayac + 1);
                    Array.Resize(ref btcprices, btcsayac + 1);
                    btcsymbols[btcsayac] = symbols[i].Replace("BTC", "");
                    btcprices[btcsayac] = prices[i];
                    btcsayac++;
                }
                if (symbols[i].EndsWith("ETH"))
                {
                    Array.Resize(ref ethsymbols, ethsayac + 1);
                    Array.Resize(ref ethprices, ethsayac + 1);
                    ethsymbols[ethsayac] = symbols[i].Replace("ETH", "");
                    ethprices[ethsayac] = prices[i];
                    ethsayac++;
                }
                if (symbols[i].EndsWith("BNB"))
                {
                    Array.Resize(ref bnbsymbols, bnbsayac + 1);
                    Array.Resize(ref bnbprices, bnbsayac + 1);
                    bnbsymbols[bnbsayac] = symbols[i].Replace("BNB", "");
                    bnbprices[bnbsayac] = prices[i];
                    bnbsayac++;
                }
                if (symbols[i].EndsWith("USDT"))
                {
                    Array.Resize(ref usdtsymbols, usdtsayac + 1);
                    Array.Resize(ref usdtprices, usdtsayac + 1);
                    usdtsymbols[usdtsayac] = symbols[i].Replace("USDT", "");
                    usdtprices[usdtsayac] = prices[i];
                    usdtsayac++;
                }
            }
        }
        public static void SplitArray2()
        {
            for (int i = 0; i < symbols.Length; i++)
            {
                if (symbols[i].EndsWith("BTC"))
                {
                }
                if (symbols[i].EndsWith("ETH"))
                {
                }
                if (symbols[i].EndsWith("BNB"))
                {
                }
                if (symbols[i].EndsWith("USDT"))
                {
                }
            }
        }
    }
}
