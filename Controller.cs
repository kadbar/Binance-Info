using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Net;

namespace Binance
{
    class Controller : Variables
    {
        /*
        
        Console.WriteLine(client.DownloadString(apiUrl + "/api/v3/openOrders") + "?timestamp=" + Utilities.GenerateTimeStamp(DateTime.Now) + " &signature=" + Utilities.GenerateSignature(apiSecret, dataQueryString));
            
        public static void GetApiData2()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            json = client.DownloadString(apiUrl + EndPoints.AllPrices);
            var symbols = new List<string>();
            var prices = new List<float>();
            node = JsonConvert.DeserializeXNode(json);
            xml.LoadXml(node.ToString());
            list = xml.SelectNodes("Ticker/Prices");
            foreach (XmlNode item in list)
            {
                symbol = item["symbol"].InnerText;
                price = item["price"].InnerText;
                symbols.Add(symbol);
                prices.Add(float.Parse(price, CultureInfo.InvariantCulture.NumberFormat));
            }
            stopwatch.Stop();
            Console.WriteLine("GetApiData2 : " + stopwatch.Elapsed);
        }
        public static void GetApiData3()
        {
            json = client.DownloadString(apiUrl + EndPoints.AllPrices);
            //List<Dictionary<string, string>> ValueList = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);
            //var result = JsonConvert.DeserializeObject<objectName>(json);
            //Console.WriteLine(result);
        }
        
        public static void userDataStream()
        {
            json = client.DownloadString(apiUrl + "/api/v1/ping");
            Console.WriteLine(json);
            request = (HttpWebRequest)WebRequest.Create(apiUrl + "/api/v1/userDataStream");
            response = (HttpWebResponse)request.GetResponse();
            responseStream = response.GetResponseStream();
            readerStream = new StreamReader(responseStream);
            Console.WriteLine("\n- - - Request successful - - -\n");
            Console.WriteLine(readerStream.ReadLine() + "\n");
        }*/

        public static void GetApiData()
        {
            int sayac = 0;
            json = client.DownloadString(apiUrl + EndPoints.AllPrices);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var json2 = JsonConvert.DeserializeObject<List<details>>(json);
            foreach (var item in json2)
            {
                symbols[sayac]= item.symbol;
                prices[sayac] = float.Parse(item.price, CultureInfo.InvariantCulture.NumberFormat);
                sayac++;
            }
            Utilities.SplitArray2();
            stopwatch.Stop();
            Console.WriteLine("GetApiData(Controller) : " + stopwatch.Elapsed);
        }


        class details
        {
            public string symbol { get; set; }
            public string price { get; set; }
        }
    }
}
