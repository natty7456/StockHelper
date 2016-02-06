using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;

namespace StockHelper
{
    public partial class ShowChart : Form
    {
        public ShowChart()
        {
            InitializeComponent();
        }
        string sStockCode;

        public ShowChart(string code)
        {
            InitializeComponent();
            sStockCode = code;
        }

        private void ShowChart_Load(object sender, EventArgs e)
        {
            if (sStockCode[0] == '6')
            {
                sStockCode = "0" + sStockCode;
            }
            else
                sStockCode = "1" + sStockCode;
            string url = "http://img1.quotes.ws.126.net/chart/timechart/" + sStockCode + ".png";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            System.IO.Stream s = request.GetResponse().GetResponseStream();
            Image img = System.Drawing.Bitmap.FromStream(s);
            s.Close();
            this.pictureBox1.Image = img;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
