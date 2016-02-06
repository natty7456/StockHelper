using System.Text.RegularExpressions;

namespace StockHelper
{
    public class CommonFunc
    {
        //public string[] GetInfo(string code)
        //{
        //    if (code == "000001")
        //        code = "1A0001";

        //    string url = "http://tieba.baidu.com/f?kw=" + code;
        //    System.Net.WebRequest webRequest = System.Net.WebRequest.Create(url);
        //    System.Net.WebResponse webResponse = webRequest.GetResponse();
        //    System.IO.StreamReader sr = new System.IO.StreamReader(webResponse.GetResponseStream(), System.Text.Encoding.GetEncoding("gb2312"));
        //    string strHtml = sr.ReadToEnd();
        //    sr.Close();

        //    //股票名称
        //    string StockName = Regex.Match(strHtml, "(?<=<span class=\"stName\">).+(?=</span>)").Groups[0].Value;
        //    //现价
        //    string Price = Regex.Match(strHtml, "(?<=<span class=\"stPrice\">).+(?=</span>)").Groups[0].Value;
        //    //涨跌值
        //    string RiseValue = Regex.Match(strHtml, "[+-]\\d+\\.\\d+(?=<br/>)").Groups[0].Value;
        //    //涨跌比
        //    string RiseRate = Regex.Match(strHtml, "[+-]\\d+\\.\\d+%").Groups[0].Value;
        //    //昨收盘
        //    string OldPrice = Regex.Match(strHtml, "(?<=昨收盘：)\\d+\\.\\d+").Groups[0].Value;
        //    //成交量
        //    string Volume = Regex.Match(strHtml, "(?<=成交：)\\d+").Groups[0].Value;

        //    if (StockName.Trim() == "")
        //        StockName = "该股不存在";
        //    if (Price.Trim() == "")
        //        Price = "该股不存在";
        //    if (RiseValue.Trim() == "")
        //        RiseValue = "该股不存在";
        //    if (RiseRate.Trim() == "")
        //        RiseRate = "该股不存在";
        //    if (OldPrice.Trim() == "")
        //        OldPrice = "该股不存在";
        //    if (Volume.Trim() == "")
        //        Volume = "该股不存在";

        //    string[] info = new string[6];
        //    info[0] = StockName;
        //    info[1] = Price;
        //    info[2] = RiseValue;
        //    info[3] = RiseRate;
        //    info[4] = OldPrice;
        //    info[5] = Volume;
        //    return info;
        //}

        //证券之星
        //public string[] GetInfo(string code)
        //{
        //    if (code[0] != '6')
        //        code += "&market=2";

        //    string url = "http://wap.stockstar.com/rootnet/quoteStock.aspx?stockcode=" + code;

        //    System.Net.WebRequest webRequest = System.Net.WebRequest.Create(url);
        //    System.Net.WebResponse webResponse = webRequest.GetResponse();
        //    System.IO.StreamReader sr = new System.IO.StreamReader(webResponse.GetResponseStream());
        //    string strHtml = sr.ReadToEnd();
        //    sr.Close();

        //    //股票名称
        //    string StockName = Regex.Match(strHtml, "[\\u4e00-\\u9fa5]+(?=\\u0028)").Groups[0].Value;
        //    //现价
        //    string Price = Regex.Match(strHtml, "(?<=最新价: <span id=\"Label2\">).+(?=</span>)").Groups[0].Value;
        //    //涨跌值
        //    string RiseValue = Regex.Match(strHtml, "(?<=涨跌:<span id=\"Label3\">).+(?=</span>)").Groups[0].Value;
        //    //涨跌比
        //    string RiseRate = Regex.Match(strHtml, "(?<=涨幅: <span id=\"Label4\">).+(?=<img)").Groups[0].Value;
        //    //昨收盘
        //    string OldPrice = Regex.Match(strHtml, "(?<=昨收: <span id=\"Label5\">).+(?=</span>)").Groups[0].Value;
        //    //成交量
        //    string Volume = Regex.Match(strHtml, "(?<=成交量: <span id=\"Label9\">).+(?=</span>)").Groups[0].Value;

        //    if (!RiseValue.Contains("-"))
        //    {
        //        RiseValue = "+" + RiseValue;
        //        RiseRate = "+" + RiseRate;
        //    }

        //    string[] info = new string[6];
        //    //股票名称
        //    info[0] = StockName;
        //    //现价
        //    info[1] = Price;
        //    //涨跌值
        //    info[2] = RiseValue;
        //    //涨跌比
        //    info[3] = RiseRate;
        //    //昨收盘
        //    info[4] = OldPrice;
        //    //成交量
        //    info[5] = Volume;
        //    return info;
        //}

        public string[] GetInfo(string code)
        {
            if (code[0] == '6' || code == "000001")
                code = "sh" + code;
            else
                code = "sz" + code;

            string url = "http://hq.sinajs.cn/list=" + code;

            System.Net.WebRequest webRequest = System.Net.WebRequest.Create(url);
            System.Net.WebResponse webResponse = webRequest.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(webResponse.GetResponseStream(), System.Text.Encoding.GetEncoding("gb2312"));
            string strHtml = sr.ReadToEnd();
            sr.Close();

            strHtml = Regex.Match(strHtml, "(?<=\").+(?=\")").Groups[0].Value;

            string[] si = strHtml.Split(',');

            string[] info = new string[6];

            if (strHtml.Length == 0)
            {
                for (int i = 0; i < info.Length; i++)
                {
                    info[i] = "该股不存在";
                }
            }
            else
            {
                //股票名称
                info[0] = si[0];
                //现价
                info[1] = si[3];
                //涨跌值
                info[2] = (System.Math.Round(double.Parse(si[3]) - double.Parse(si[2]), 2)).ToString();

                bool plusflag = false;

                if (!info[2].Contains("-") && info[2] != "0")
                    plusflag = true;
                //涨跌比
                info[3] = (System.Math.Round(double.Parse(info[2]) / double.Parse(si[2]) * 100, 2)).ToString() + "%";

                if (plusflag)
                {
                    info[2] = "+" + info[2];
                    info[3] = "+" + info[3];
                }

                //昨收盘
                info[4] = si[2];
                //成交量
                info[5] = si[8];
            }
            return info;
        }
    }
}
