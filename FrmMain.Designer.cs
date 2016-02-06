namespace StockHelper
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.btnStart = new System.Windows.Forms.Button();
            this.gbSet = new System.Windows.Forms.GroupBox();
            this.lblRiseValue = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnUpd = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblNowPrice = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblStockName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWarn = new System.Windows.Forms.TextBox();
            this.txtLow = new System.Windows.Forms.TextBox();
            this.txtHigh = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvDetails = new System.Windows.Forms.ListView();
            this.mainMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.关注此股ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看分时图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeDo = new System.Windows.Forms.Timer(this.components);
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbSet.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.menuTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.ForeColor = System.Drawing.Color.Red;
            this.btnStart.Location = new System.Drawing.Point(236, 89);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "启动";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // gbSet
            // 
            this.gbSet.Controls.Add(this.lblRiseValue);
            this.gbSet.Controls.Add(this.btnDel);
            this.gbSet.Controls.Add(this.btnUpd);
            this.gbSet.Controls.Add(this.btnAdd);
            this.gbSet.Controls.Add(this.btnStart);
            this.gbSet.Controls.Add(this.lblNowPrice);
            this.gbSet.Controls.Add(this.label5);
            this.gbSet.Controls.Add(this.lblStockName);
            this.gbSet.Controls.Add(this.label4);
            this.gbSet.Controls.Add(this.label3);
            this.gbSet.Controls.Add(this.label2);
            this.gbSet.Controls.Add(this.txtWarn);
            this.gbSet.Controls.Add(this.txtLow);
            this.gbSet.Controls.Add(this.txtHigh);
            this.gbSet.Controls.Add(this.txtCode);
            this.gbSet.Controls.Add(this.label1);
            this.gbSet.Location = new System.Drawing.Point(12, 12);
            this.gbSet.Name = "gbSet";
            this.gbSet.Size = new System.Drawing.Size(360, 130);
            this.gbSet.TabIndex = 1;
            this.gbSet.TabStop = false;
            this.gbSet.Text = "设定";
            // 
            // lblRiseValue
            // 
            this.lblRiseValue.AutoSize = true;
            this.lblRiseValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRiseValue.Location = new System.Drawing.Point(267, 26);
            this.lblRiseValue.Name = "lblRiseValue";
            this.lblRiseValue.Size = new System.Drawing.Size(65, 12);
            this.lblRiseValue.TabIndex = 14;
            this.lblRiseValue.Text = "+50(+1.5%)";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(154, 89);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(50, 23);
            this.btnDel.TabIndex = 13;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnUpd
            // 
            this.btnUpd.Location = new System.Drawing.Point(88, 89);
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(50, 23);
            this.btnUpd.TabIndex = 12;
            this.btnUpd.Text = "修改";
            this.btnUpd.UseVisualStyleBackColor = true;
            this.btnUpd.Click += new System.EventHandler(this.btnUpd_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(21, 89);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(50, 23);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblNowPrice
            // 
            this.lblNowPrice.AutoSize = true;
            this.lblNowPrice.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNowPrice.Location = new System.Drawing.Point(218, 26);
            this.lblNowPrice.Name = "lblNowPrice";
            this.lblNowPrice.Size = new System.Drawing.Size(29, 12);
            this.lblNowPrice.TabIndex = 10;
            this.lblNowPrice.Text = "3000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(178, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "现价";
            // 
            // lblStockName
            // 
            this.lblStockName.AutoSize = true;
            this.lblStockName.Location = new System.Drawing.Point(119, 26);
            this.lblStockName.Name = "lblStockName";
            this.lblStockName.Size = new System.Drawing.Size(53, 12);
            this.lblStockName.TabIndex = 8;
            this.lblStockName.Text = "上证指数";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "提醒";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "下破";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "上穿";
            // 
            // txtWarn
            // 
            this.txtWarn.Location = new System.Drawing.Point(269, 56);
            this.txtWarn.MaxLength = 6;
            this.txtWarn.Multiline = true;
            this.txtWarn.Name = "txtWarn";
            this.txtWarn.Size = new System.Drawing.Size(60, 18);
            this.txtWarn.TabIndex = 4;
            this.txtWarn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWarn_KeyPress);
            // 
            // txtLow
            // 
            this.txtLow.Location = new System.Drawing.Point(154, 56);
            this.txtLow.MaxLength = 6;
            this.txtLow.Multiline = true;
            this.txtLow.Name = "txtLow";
            this.txtLow.Size = new System.Drawing.Size(60, 18);
            this.txtLow.TabIndex = 3;
            this.txtLow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLow_KeyPress);
            // 
            // txtHigh
            // 
            this.txtHigh.Location = new System.Drawing.Point(52, 56);
            this.txtHigh.MaxLength = 6;
            this.txtHigh.Multiline = true;
            this.txtHigh.Name = "txtHigh";
            this.txtHigh.Size = new System.Drawing.Size(60, 18);
            this.txtHigh.TabIndex = 2;
            this.txtHigh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHigh_KeyPress);
            // 
            // txtCode
            // 
            this.txtCode.Font = new System.Drawing.Font("宋体", 9F);
            this.txtCode.Location = new System.Drawing.Point(52, 22);
            this.txtCode.MaxLength = 6;
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(60, 18);
            this.txtCode.TabIndex = 1;
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            this.txtCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "代码";
            // 
            // lvDetails
            // 
            this.lvDetails.Location = new System.Drawing.Point(0, 149);
            this.lvDetails.Name = "lvDetails";
            this.lvDetails.Size = new System.Drawing.Size(384, 219);
            this.lvDetails.TabIndex = 2;
            this.lvDetails.UseCompatibleStateImageBehavior = false;
            this.lvDetails.SelectedIndexChanged += new System.EventHandler(this.lvDetails_SelectedIndexChanged);
            this.lvDetails.Click += new System.EventHandler(this.lvDetails_Click);
            this.lvDetails.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvDetails_MouseDoubleClick);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关注此股ToolStripMenuItem,
            this.查看分时图ToolStripMenuItem});
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(131, 48);
            // 
            // 关注此股ToolStripMenuItem
            // 
            this.关注此股ToolStripMenuItem.Name = "关注此股ToolStripMenuItem";
            this.关注此股ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.关注此股ToolStripMenuItem.Text = "关注此股";
            this.关注此股ToolStripMenuItem.Click += new System.EventHandler(this.关注此股ToolStripMenuItem_Click);
            // 
            // 查看分时图ToolStripMenuItem
            // 
            this.查看分时图ToolStripMenuItem.Name = "查看分时图ToolStripMenuItem";
            this.查看分时图ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.查看分时图ToolStripMenuItem.Text = "查看分时图";
            this.查看分时图ToolStripMenuItem.Click += new System.EventHandler(this.查看分时图ToolStripMenuItem_Click);
            // 
            // timeDo
            // 
            this.timeDo.Interval = 10000;
            this.timeDo.Tick += new System.EventHandler(this.timeDo_Tick);
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.menuTray;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "炒股好帮手";
            this.trayIcon.Visible = true;
            this.trayIcon.Click += new System.EventHandler(this.trayIcon_Click);
            // 
            // menuTray
            // 
            this.menuTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.menuTray.Name = "menuTray";
            this.menuTray.Size = new System.Drawing.Size(95, 26);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightYellow;
            this.ClientSize = new System.Drawing.Size(384, 380);
            this.Controls.Add(this.lvDetails);
            this.Controls.Add(this.gbSet);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.Text = "炒股好帮手";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.gbSet.ResumeLayout(false);
            this.gbSet.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.menuTray.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox gbSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWarn;
        private System.Windows.Forms.TextBox txtLow;
        private System.Windows.Forms.TextBox txtHigh;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnUpd;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblNowPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblStockName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvDetails;
        private System.Windows.Forms.Timer timeDo;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip menuTray;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Label lblRiseValue;
        private System.Windows.Forms.ContextMenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem 关注此股ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看分时图ToolStripMenuItem;
    }
}

