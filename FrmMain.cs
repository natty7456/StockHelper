using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.ComponentModel;

namespace StockHelper
{
    public partial class FrmMain : Form
    {
        #region 成员变量定义

        //实例化通用方法类
        CommonFunc cf = new CommonFunc();

        private int times = 0;

        private delegate void MyDelegate();

        #endregion

        public FrmMain()
        {
            InitializeComponent();
            //初始化ListView
            InitListView();
            //读取XML
            LoadXML();
            //防止线程报错，不检查跨线程访问的合法性
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        #region 自定义方法

        private void InitListView()
        {
            lvDetails.View = View.Details;//定义列表显示的方式
            lvDetails.GridLines = true;//显示各个记录的分隔线
            lvDetails.FullRowSelect = true;//要选择就是一行
            lvDetails.Scrollable = true;//需要时候显示滚动条
            lvDetails.MultiSelect = false;// 不可以多行选择
            lvDetails.HeaderStyle = ColumnHeaderStyle.Nonclickable;//列标头不可点击
            lvDetails.HideSelection = false;

            //添加列名
            lvDetails.Columns.Add("股票", 100, HorizontalAlignment.Center);
            lvDetails.Columns.Add("现价", 70, HorizontalAlignment.Center);
            lvDetails.Columns.Add("上穿", 70, HorizontalAlignment.Center);
            lvDetails.Columns.Add("下破", 70, HorizontalAlignment.Center);
            lvDetails.Columns.Add("提醒", 70, HorizontalAlignment.Center);
        }

        private void AddDetail(string[] detail)
        {
            lvDetails.Items.Add(detail[0]);

            int AddIndex = lvDetails.Items.Count-1;

            lvDetails.Items[AddIndex].SubItems.Add(detail[1]);
            lvDetails.Items[AddIndex].SubItems.Add(detail[2]);
            lvDetails.Items[AddIndex].SubItems.Add(detail[3]);
            lvDetails.Items[AddIndex].SubItems.Add(detail[4]);
        }

        private void SaveXML()
        {
            //存储数据二维数组(从ListView上获取)
            string[,] data = new string[lvDetails.Items.Count, lvDetails.Columns.Count];

            //获取二维数组(从ListView上获取)
            for (int i = 0; i < lvDetails.Items.Count; i++)
            {
                for (int j = 0; j < lvDetails.Columns.Count; j++)
                    data[i, j] = lvDetails.Items[i].SubItems[j].Text;
            }

            //写XML文件
            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\config.xml");
            sw.WriteLine("<?xml version=\"1.0\" encoding=\"gb2312\"?>");
            sw.WriteLine("<root>");
            for (int i = 0; i < lvDetails.Items.Count; i++)
            {
                sw.WriteLine("<stock code=\"" + data[i,0].ToString().Split('.')[0] + "\" high=\"" + data[i,2] + "\" low=\"" + data[i,3] + "\" warn=\"" + data[i,4] + "\"></stock>");
            }
            sw.WriteLine("</root>");
            sw.Close();
        }

        private void Delegate_LoadXML()
        {
            string[] record = new string[5];

            XmlTextReader xmlReader = new XmlTextReader(new FileStream(Application.StartupPath + "\\config.xml", FileMode.Open));
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "stock")
                {
                    xmlReader.MoveToAttribute("code");
                    record[0] = xmlReader.Value;
                    xmlReader.MoveToAttribute("high");
                    record[2] = xmlReader.Value;
                    xmlReader.MoveToAttribute("low");
                    record[3] = xmlReader.Value;
                    xmlReader.MoveToAttribute("warn");
                    record[4] = xmlReader.Value;

                    string[] info = cf.GetInfo(record[0]);
                    record[0] = record[0] + "." + info[0];
                    record[1] = info[1];

                    AddDetail(record);
                }
            }
            xmlReader.Close();
        }

        private void LoadXML()
        {
            //异步调用Delegate_LoadXML()方法
            MyDelegate md = Delegate_LoadXML;//设置委托的方法
            IAsyncResult iasync = md.BeginInvoke(OnMethodCompletion, null); 
        }

        private void LimitInput(object sender, KeyPressEventArgs e)
        {
            string InputText = ((TextBox)sender).Text;
            //小数点不能在第1位，第5第位，不能有多个小数点
            if ((InputText == "" || InputText.Contains(".") || InputText.Length > 3) && e.KeyChar == '.')
                e.Handled = true;
            //禁止输入数字，小数点，退格以外的字符
            if (!(Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        //回调函数
        private void OnMethodCompletion(IAsyncResult async)
        {
            AsyncResult asyncResult = (AsyncResult)async;
            MyDelegate md = (MyDelegate)asyncResult.AsyncDelegate;
            md.EndInvoke(asyncResult);
        }

        #endregion

        #region 系统生成事件

        private void btnStart_Click(object sender, EventArgs e)
        {
            //cf.GetInfo("600321");

            //return;
            
            if (btnStart.Text == "启动")
            {
                timeDo.Enabled = true;

                btnStart.Text = "停止";
            }
            else
            {
                timeDo.Enabled = false;
                btnStart.Text = "启动";
            }
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar) || e.KeyChar == '\b'))
            {
                e.Handled = true;
            }
        }

        private void txtCodeKeyUp()
        {
            string code = txtCode.Text;
            if (txtCode.Text.Length == 6)
            {
                string[] info = cf.GetInfo(code);
                lblStockName.Text = info[0];
                lblNowPrice.Text = info[1];
                lblRiseValue.Text = info[2] + "(" + info[3] + ")";

                if (info[0] == "该股不存在")
                    return;

                //根据涨跌改变Label控件显示颜色
                if (Convert.ToDouble(info[1]) > Convert.ToDouble(info[4]))
                {
                    lblNowPrice.ForeColor = Color.Red;
                    lblRiseValue.ForeColor = Color.Red;
                }
                else if (Convert.ToDouble(info[1]) < Convert.ToDouble(info[4]))
                {
                    lblNowPrice.ForeColor = Color.Green;
                    lblRiseValue.ForeColor = Color.Green;
                }
                else
                {
                    lblNowPrice.ForeColor = Color.White;
                    lblRiseValue.ForeColor = Color.White;
                }
                txtHigh.Text = "";
                txtLow.Text = "";
                txtWarn.Text = "";
            }
        }

        private void txtCode_KeyUp(object sender, KeyEventArgs e)
        {
            //异步调用txtCodeKeyUp()方法
            MyDelegate md = txtCodeKeyUp; //设置委托的方法
            IAsyncResult iasync = md.BeginInvoke(OnMethodCompletion, null); 
        }

        private void timeDoTick()
        {
            //代码编号
            string code = null;

            //提醒消息
            string message = null;

            //价格
            double NowPrice = 0;
            double HighPrice = 0;
            double LowPrice = 0;
            double WarnPrice = 0;
            double TempPrice = 0;

            //显示上证指数信息
            string[] info = cf.GetInfo("000001");

            lblStockName.Text = info[0];
            lblNowPrice.Text = info[1];
            lblRiseValue.Text = info[2] + "(" + info[3] + ")";

            //根据涨跌改变Label控件显示颜色
            if (Convert.ToDouble(info[1]) > Convert.ToDouble(info[4]))
            {
                lblNowPrice.ForeColor = Color.Red;
                lblRiseValue.ForeColor = Color.Red;
            }
            else if (Convert.ToDouble(info[1]) < Convert.ToDouble(info[4]))
            {
                lblNowPrice.ForeColor = Color.Green;
                lblRiseValue.ForeColor = Color.Green;
            }
            else
            {
                lblNowPrice.ForeColor = Color.White;
                lblRiseValue.ForeColor = Color.White;
            }


            //刷新最新价格
            if (lvDetails.Items.Count > 0)
            {
                for (int i = 0; i < lvDetails.Items.Count; i++)
                {
                    code = lvDetails.Items[i].Text.Split('.')[0];
                    info = cf.GetInfo(code);

                    //如果获取不到数据，直接跳出
                    if (info[0] == "该股不存在")
                        continue;

                    TempPrice = Convert.ToDouble(lvDetails.Items[i].SubItems[1].Text);
                    lvDetails.Items[i].SubItems[1].Text = info[1];


                    //根据涨跌改变ListView现价单元格内显示颜色
                    //使ListView中单元格风格可被设置
                    //lvDetails.Items[i].UseItemStyleForSubItems = false;
                    //if (Convert.ToDouble(info[1]) > Convert.ToDouble(info[4]))
                    //{
                    //    lvDetails.Items[i].SubItems[1].ForeColor = Color.Red;
                    //}
                    //else if (Convert.ToDouble(info[1]) < Convert.ToDouble(info[4]))
                    //{
                    //    lvDetails.Items[i].SubItems[1].ForeColor = Color.Green;
                    //}
                    //else
                    //{
                    //    lvDetails.Items[i].SubItems[1].ForeColor = Color.White;
                    //}

                    NowPrice = Convert.ToDouble(info[1]);

                    //获得到的现价如果为0，直接跳出
                    if (NowPrice == 0)
                        continue;

                    if (lvDetails.Items[i].SubItems[2].Text.Trim() != "")
                        HighPrice = Convert.ToDouble(lvDetails.Items[i].SubItems[2].Text);
                    if (lvDetails.Items[i].SubItems[3].Text.Trim() != "")
                        LowPrice = Convert.ToDouble(lvDetails.Items[i].SubItems[3].Text);
                    if (lvDetails.Items[i].SubItems[4].Text.Trim() != "")
                        WarnPrice = Convert.ToDouble(lvDetails.Items[i].SubItems[4].Text);
                    //价格判断
                    if (NowPrice >= HighPrice && HighPrice != 0)
                    {
                        lvDetails.Items[i].SubItems[2].Text = Convert.ToString(HighPrice + 0.05);
                        //定义提醒消息内容
                        message = info[0] + " 当前价格为 " + NowPrice + " 涨跌 " + info[2] + "(" + info[3] + ")" + " 已上穿 " + HighPrice;
                        this.trayIcon.ShowBalloonTip(1, "价格提醒", message, ToolTipIcon.Info);
                        MessageBox.Show(message);
                    }
                    if (NowPrice <= LowPrice && LowPrice != 0)
                    {
                        lvDetails.Items[i].SubItems[3].Text = Convert.ToString(LowPrice - 0.05);
                        //定义提醒消息内容
                        message = info[0] + " 当前价格为 " + NowPrice + " 涨跌 " + info[2] + "(" + info[3] + ")" + " 已下破 " + LowPrice;

                        this.trayIcon.ShowBalloonTip(1, "价格提醒", message, ToolTipIcon.Info);
                        MessageBox.Show(message);
                    }
                    if (WarnPrice >= Math.Min(TempPrice, NowPrice) && WarnPrice <= Math.Max(TempPrice, NowPrice) && WarnPrice != 0)
                    {
                        lvDetails.Items[i].SubItems[4].Text = "";

                        //定义提醒消息内容
                        message = info[0] + " 当前价格为 " + NowPrice + " 涨跌 " + info[2] + "(" + info[3] + ")" + " 已到达警告价 " + WarnPrice;

                        this.trayIcon.ShowBalloonTip(1, "价格提醒", message, ToolTipIcon.Info);
                        MessageBox.Show(message);
                    }

                    //临时的价格清零
                    HighPrice = 0;
                    LowPrice = 0;
                    WarnPrice = 0;
                }
            }

            //窗体名称刷新提示
            this.Text = "炒股好帮手 " + " 刷新：" + times.ToString() + "次   "+ DateTime.Now.ToString();
        }

        BackgroundWorker backgroundWorker1;

        private void timeDo_Tick(object sender, EventArgs e)
        {

            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerAsync();

            times++;
        }

        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            timeDoTick();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string[] detail = new string[5];
            string[] info = cf.GetInfo(txtCode.Text);

            detail[0] = txtCode.Text + "." + info[0];
            detail[1] = info[1];
            detail[2] = txtHigh.Text;
            detail[3] = txtLow.Text;
            detail[4] = txtWarn.Text;

            AddDetail(detail);

            txtHigh.Text = "";
            txtLow.Text = "";
            txtWarn.Text = "";
            txtCode.Focus();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int Index = 0;
            if (lvDetails.SelectedItems.Count > 0)
            {
                Index = lvDetails.SelectedItems[0].Index;
                lvDetails.Items.RemoveAt(Index);
            }
            txtCode.Text = "";
            txtHigh.Text = "";
            txtLow.Text = "";
            txtWarn.Text = "";
            txtCode.Focus();
        }

        private void lvDetails_Click(object sender, EventArgs e)
        {
            txtCode.Text = lvDetails.SelectedItems[0].SubItems[0].Text.Split('.')[0];
            txtHigh.Text = lvDetails.SelectedItems[0].SubItems[2].Text;
            txtLow.Text = lvDetails.SelectedItems[0].SubItems[3].Text;
            txtWarn.Text = lvDetails.SelectedItems[0].SubItems[4].Text;
        }

        private void lvDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDetails.SelectedItems.Count > 0)
            {
                txtCode.Text = lvDetails.SelectedItems[0].SubItems[0].Text.Split('.')[0];
                txtHigh.Text = lvDetails.SelectedItems[0].SubItems[2].Text;
                txtLow.Text = lvDetails.SelectedItems[0].SubItems[3].Text;
                txtWarn.Text = lvDetails.SelectedItems[0].SubItems[4].Text;
                this.lvDetails.ContextMenuStrip = this.mainMenu;
            }
            else
                lvDetails.ContextMenuStrip = null;
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            if (lvDetails.SelectedItems.Count > 0)
            {
                lvDetails.SelectedItems[0].SubItems[2].Text = txtHigh.Text;
                lvDetails.SelectedItems[0].SubItems[3].Text = txtLow.Text;
                lvDetails.SelectedItems[0].SubItems[4].Text = txtWarn.Text;
            }
        }

        #endregion

        private void trayIcon_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                this.Visible = true;
                this.Activate();//激活窗体 
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            this.Visible = false; 
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //保存ListView中的数据到XML
            SaveXML();
            Application.ExitThread(); 
        }

        private void txtHigh_KeyPress(object sender, KeyPressEventArgs e)
        {
            LimitInput(sender, e);
        }

        private void txtLow_KeyPress(object sender, KeyPressEventArgs e)
        {
            LimitInput(sender, e);
        }

        private void txtWarn_KeyPress(object sender, KeyPressEventArgs e)
        {
            LimitInput(sender, e);
        }

        private void 关注此股ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double dNowPrice = Convert.ToDouble(lvDetails.SelectedItems[0].SubItems[1].Text);

            double dHighPrice = ((double)(((int)(dNowPrice * 1000) + 1) / 50 + 1) * 50) / 1000;
            double dLowPrice = ((double)((int)(dNowPrice * 100 - 1) / 5) * 5) / 100;

            lvDetails.SelectedItems[0].SubItems[2].Text = dHighPrice.ToString("F2");
            lvDetails.SelectedItems[0].SubItems[3].Text = dLowPrice.ToString("F2");
        }

        private void 查看分时图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sStockCode = lvDetails.SelectedItems[0].Text.Split('.')[0];
            ShowChart sc = new ShowChart(sStockCode);
            sc.ShowDialog();
        }

        private void lvDetails_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string sStockCode = lvDetails.SelectedItems[0].Text.Split('.')[0];
            ShowChart sc = new ShowChart(sStockCode);
            sc.ShowDialog();
        }


    }
}