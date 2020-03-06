using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Xml;

namespace Binance
{
    class Request : Variables
    {
        public class Item
        {
            public string symbol { get; set; }
            public string origClientOrderId { get; set; }
            public string orderId { get; set; }
            public string orderListId { get; set; }
            public string clientOrderId { get; set; }
            public string transactTime { get; set; }
            public string price { get; set; }
            public string origQty { get; set; }
            public string executedQty { get; set; }
            public string cummulativeQuoteQty { get; set; }
            public string status { get; set; }
            public string timeInForce { get; set; }
            public string type { get; set; }
            public string side { get; set; }
            public string stopPrice { get; set; }
            public string icebergQty { get; set; }
            public string time { get; set; }
            public string updateTime { get; set; }
            public string isWorking { get; set; }
        }
        public static void Send()
        {
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                responseStream = response.GetResponseStream();
                readerStream = new StreamReader(responseStream);
                var data = readerStream.ReadToEnd();
                Console.Beep(2000, 200);
                Console.WriteLine("\n- - - Request successful - - -\n");
                Console.WriteLine(data + "\n");
                List<Item> items = JsonConvert.DeserializeObject<List<Item>>(data);
                foreach (var item in items)
                {
                    Console.WriteLine("Symbol              : " + item.symbol);
                    Console.WriteLine("OrigClientOrderId   : " + item.origClientOrderId);
                    Console.WriteLine("OrderId             : " + item.orderId);
                    Console.WriteLine("OrderListId         : " + item.orderListId);
                    Console.WriteLine("ClientOrderId       : " + item.clientOrderId);
                    Console.WriteLine("TransactTime        : " + item.transactTime);
                    Console.WriteLine("Price               : " + item.price);
                    Console.WriteLine("OrigQty             : " + item.origQty);
                    Console.WriteLine("ExecutedQty         : " + item.executedQty);
                    Console.WriteLine("CummulativeQuoteQty : " + item.cummulativeQuoteQty);
                    Console.WriteLine("Status              : " + item.status);
                    Console.WriteLine("TimeInForce         : " + item.timeInForce);
                    Console.WriteLine("Type                : " + item.type);
                    Console.WriteLine("Side                : " + item.side);
                    Console.WriteLine("StopPrice           : " + item.stopPrice);
                    Console.WriteLine("IcebergQty          : " + item.icebergQty);
                    Console.WriteLine("Time                : " + item.time);
                    Console.WriteLine("UpdateTime          : " + item.updateTime);
                    Console.WriteLine("IsWorking           : " + item.isWorking);
                    Console.WriteLine();
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("\n- - - Request unsuccessful - - -\n");
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd()+"\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n- - - Request unsuccessful - - -\n");
                Console.WriteLine(ex.Message + "\n");
            }
        }

        public static void GetApiData()
        {
            Stopwatch stopwatch = new Stopwatch();
            int sayac = 0;
            json = client.DownloadString(apiUrl + EndPoints.AllPrices);
            stopwatch.Start();
            json = json.Replace("{", "'Prices':{");
            json = json.Replace("[", "{'Ticker':{");
            json = json.Replace("]", "}");
            node = JsonConvert.DeserializeXNode(json);
            xml.LoadXml(node.ToString());
            list = xml.SelectNodes("Ticker/Prices");
            foreach (XmlNode item in list)
            {
                Array.Resize(ref symbols, sayac + 1);
                Array.Resize(ref prices, sayac + 1);
                symbol = item["symbol"].InnerText;
                price = item["price"].InnerText;
                symbols[sayac] = symbol;
                prices[sayac] = float.Parse(price, CultureInfo.InvariantCulture.NumberFormat);
                sayac++;
            }
            Utilities.SplitArray();
            stopwatch.Stop();
            Console.WriteLine("GetApiData(Request) : " + stopwatch.Elapsed);
        }
        public static void New_Order(string symbol, string side, string type, string quantity, string price, string method)
        {
            dataQueryString = "symbol=" + symbol + "&side=" + side + "&type=" + type + "&timeInForce=GTC" + "&quantity=" + quantity + "&price=" + price + "&timestamp=" + Utilities.GenerateTimeStamp(DateTime.Now);
            signature = Utilities.GenerateSignature(apiSecret, dataQueryString);
            url = apiUrl + EndPoints.NewOrder + "?" + dataQueryString + "&signature=" + signature;
            request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            request.Headers.Add("X-MBX-APIKEY", apiKey);
            Send();
        }
        public static void Delete_Order(string symbol, string orderId, string method)
        {
            dataQueryString = "symbol=" + symbol + "&orderId=" + orderId + "&timestamp=" + Utilities.GenerateTimeStamp(DateTime.Now);
            signature = Utilities.GenerateSignature(apiSecret, dataQueryString);
            url = apiUrl + EndPoints.CancelOrder + "?" + dataQueryString + "&signature=" + signature;
            request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            request.Headers.Add("X-MBX-APIKEY", apiKey);
            Send();
        }
        public static void Open_Orders(string method)
        {
            dataQueryString = "&timestamp=" + Utilities.GenerateTimeStamp(DateTime.Now);
            signature = Utilities.GenerateSignature(apiSecret, dataQueryString);
            url = apiUrl + EndPoints.CurrentOpenOrders + "?" + dataQueryString + "&signature=" + signature;
            request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            request.Headers.Add("X-MBX-APIKEY", apiKey);
            Send();
        }
        public static void Account_Info(string method)
        {
            dataQueryString = "&timestamp=" + Utilities.GenerateTimeStamp(DateTime.Now);
            signature = Utilities.GenerateSignature(apiSecret, dataQueryString);
            url = apiUrl + EndPoints.AccountInformation + "?" + dataQueryString + "&signature=" + signature;
            request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            request.Headers.Add("X-MBX-APIKEY", apiKey);
            Send();
        }
    }
}
