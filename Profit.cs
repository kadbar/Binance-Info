using System;

namespace Binance
{
    class Profit : Variables
    {
        public static void Calculate()
        {
            for (int i = 0; i < btcprices.Length; i++)
            {
                for (int j = 0; j < ethprices.Length; j++)
                {
                    if (btcsymbols[i] == ethsymbols[j])
                    {
                        if (Math.Abs(btcprices[i] * btc) - (ethprices[j] * eth) > 0.08)
                        {
                            Console.WriteLine(btcsymbols[i] + " x " + btcprices[i] * btc + " - " + ethsymbols[j] + " x " + ethprices[j] * eth);
                            Console.WriteLine(Math.Abs((btcprices[i] * btc) - (ethprices[j] * eth)).ToString());
                            Console.WriteLine("Kârlı Coin : " + btcsymbols[i] + "\nFiyat : " + ethprices[j] * btc + "$\nKâr : " + (btcprices[i] * btc - (ethprices[j] * eth)) + "$");
                        }
                    }
                }
            }
        }
    }
}
