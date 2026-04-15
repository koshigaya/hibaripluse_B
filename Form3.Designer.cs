namespace hibari151201
{
    partial class Form3
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbxAPG = new System.Windows.Forms.PictureBox();
            this.cmbCOM = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbl1A = new System.Windows.Forms.Label();
            this.lbl2A = new System.Windows.Forms.Label();
            this.lbl3A = new System.Windows.Forms.Label();
            this.lbl4A = new System.Windows.Forms.Label();
            this.lbl5A = new System.Windows.Forms.Label();
            this.lbl5B = new System.Windows.Forms.Label();
            this.lbl4B = new System.Windows.Forms.Label();
            this.lbl3B = new System.Windows.Forms.Label();
            this.lbl2B = new System.Windows.Forms.Label();
            this.lbl1B = new System.Windows.Forms.Label();
            this.lbl5C = new System.Windows.Forms.Label();
            this.lbl4C = new System.Windows.Forms.Label();
            this.lbl3C = new System.Windows.Forms.Label();
            this.lbl2C = new System.Windows.Forms.Label();
            this.lbl1C = new System.Windows.Forms.Label();
            this.lbl5D = new System.Windows.Forms.Label();
            this.lbl4D = new System.Windows.Forms.Label();
            this.lbl3D = new System.Windows.Forms.Label();
            this.lbl2D = new System.Windows.Forms.Label();
            this.lbl1D = new System.Windows.Forms.Label();
            this.lblAPG_AG = new System.Windows.Forms.Label();
            this.lblpulse = new System.Windows.Forms.Label();
            this.lbl1wave = new System.Windows.Forms.Label();
            this.lbl2wave = new System.Windows.Forms.Label();
            this.lbl3wave = new System.Windows.Forms.Label();
            this.lbl4wave = new System.Windows.Forms.Label();
            this.lbl5wave = new System.Windows.Forms.Label();
            this.lblTwave = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblStart = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.tsslconnect = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslVGA = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslWave22 = new System.Windows.Forms.ToolStripStatusLabel();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.btnPrint = new System.Windows.Forms.Button();
            this.menuVersion = new System.Windows.Forms.MenuStrip();
            this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWrite = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFunction = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuVasAGE = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuWave22 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblTW = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblJudge = new System.Windows.Forms.Label();
            this.lblVasAGE = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAPG)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuVersion.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbxAPG
            // 
            this.pbxAPG.BackColor = System.Drawing.Color.White;
            this.pbxAPG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxAPG.Location = new System.Drawing.Point(33, 45);
            this.pbxAPG.Name = "pbxAPG";
            this.pbxAPG.Size = new System.Drawing.Size(752, 119);
            this.pbxAPG.TabIndex = 0;
            this.pbxAPG.TabStop = false;
            // 
            // cmbCOM
            // 
            this.cmbCOM.FormattingEnabled = true;
            this.cmbCOM.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16",
            "COM17",
            "COM18",
            "COM19",
            "COM20"});
            this.cmbCOM.Location = new System.Drawing.Point(816, 45);
            this.cmbCOM.Name = "cmbCOM";
            this.cmbCOM.Size = new System.Drawing.Size(82, 20);
            this.cmbCOM.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(9, 18);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "測定";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(9, 96);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbl1A
            // 
            this.lbl1A.AutoSize = true;
            this.lbl1A.BackColor = System.Drawing.Color.White;
            this.lbl1A.Location = new System.Drawing.Point(60, 190);
            this.lbl1A.Name = "lbl1A";
            this.lbl1A.Size = new System.Drawing.Size(19, 12);
            this.lbl1A.TabIndex = 6;
            this.lbl1A.Text = "1A";
            // 
            // lbl2A
            // 
            this.lbl2A.AutoSize = true;
            this.lbl2A.BackColor = System.Drawing.Color.White;
            this.lbl2A.Location = new System.Drawing.Point(113, 190);
            this.lbl2A.Name = "lbl2A";
            this.lbl2A.Size = new System.Drawing.Size(19, 12);
            this.lbl2A.TabIndex = 7;
            this.lbl2A.Text = "2A";
            // 
            // lbl3A
            // 
            this.lbl3A.AutoSize = true;
            this.lbl3A.BackColor = System.Drawing.Color.White;
            this.lbl3A.Location = new System.Drawing.Point(171, 190);
            this.lbl3A.Name = "lbl3A";
            this.lbl3A.Size = new System.Drawing.Size(19, 12);
            this.lbl3A.TabIndex = 8;
            this.lbl3A.Text = "3A";
            // 
            // lbl4A
            // 
            this.lbl4A.AutoSize = true;
            this.lbl4A.BackColor = System.Drawing.Color.White;
            this.lbl4A.Location = new System.Drawing.Point(221, 190);
            this.lbl4A.Name = "lbl4A";
            this.lbl4A.Size = new System.Drawing.Size(19, 12);
            this.lbl4A.TabIndex = 9;
            this.lbl4A.Text = "4A";
            // 
            // lbl5A
            // 
            this.lbl5A.AutoSize = true;
            this.lbl5A.BackColor = System.Drawing.Color.White;
            this.lbl5A.Location = new System.Drawing.Point(267, 190);
            this.lbl5A.Name = "lbl5A";
            this.lbl5A.Size = new System.Drawing.Size(19, 12);
            this.lbl5A.TabIndex = 10;
            this.lbl5A.Text = "5A";
            // 
            // lbl5B
            // 
            this.lbl5B.AutoSize = true;
            this.lbl5B.BackColor = System.Drawing.Color.White;
            this.lbl5B.Location = new System.Drawing.Point(267, 216);
            this.lbl5B.Name = "lbl5B";
            this.lbl5B.Size = new System.Drawing.Size(19, 12);
            this.lbl5B.TabIndex = 15;
            this.lbl5B.Text = "5B";
            // 
            // lbl4B
            // 
            this.lbl4B.AutoSize = true;
            this.lbl4B.BackColor = System.Drawing.Color.White;
            this.lbl4B.Location = new System.Drawing.Point(221, 216);
            this.lbl4B.Name = "lbl4B";
            this.lbl4B.Size = new System.Drawing.Size(19, 12);
            this.lbl4B.TabIndex = 14;
            this.lbl4B.Text = "4B";
            // 
            // lbl3B
            // 
            this.lbl3B.AutoSize = true;
            this.lbl3B.BackColor = System.Drawing.Color.White;
            this.lbl3B.Location = new System.Drawing.Point(171, 216);
            this.lbl3B.Name = "lbl3B";
            this.lbl3B.Size = new System.Drawing.Size(19, 12);
            this.lbl3B.TabIndex = 13;
            this.lbl3B.Text = "3B";
            // 
            // lbl2B
            // 
            this.lbl2B.AutoSize = true;
            this.lbl2B.BackColor = System.Drawing.Color.White;
            this.lbl2B.Location = new System.Drawing.Point(113, 216);
            this.lbl2B.Name = "lbl2B";
            this.lbl2B.Size = new System.Drawing.Size(19, 12);
            this.lbl2B.TabIndex = 12;
            this.lbl2B.Text = "2B";
            // 
            // lbl1B
            // 
            this.lbl1B.AutoSize = true;
            this.lbl1B.BackColor = System.Drawing.Color.White;
            this.lbl1B.Location = new System.Drawing.Point(60, 216);
            this.lbl1B.Name = "lbl1B";
            this.lbl1B.Size = new System.Drawing.Size(19, 12);
            this.lbl1B.TabIndex = 11;
            this.lbl1B.Text = "1B";
            // 
            // lbl5C
            // 
            this.lbl5C.AutoSize = true;
            this.lbl5C.BackColor = System.Drawing.Color.White;
            this.lbl5C.Location = new System.Drawing.Point(267, 240);
            this.lbl5C.Name = "lbl5C";
            this.lbl5C.Size = new System.Drawing.Size(19, 12);
            this.lbl5C.TabIndex = 20;
            this.lbl5C.Text = "5C";
            // 
            // lbl4C
            // 
            this.lbl4C.AutoSize = true;
            this.lbl4C.BackColor = System.Drawing.Color.White;
            this.lbl4C.Location = new System.Drawing.Point(221, 240);
            this.lbl4C.Name = "lbl4C";
            this.lbl4C.Size = new System.Drawing.Size(19, 12);
            this.lbl4C.TabIndex = 19;
            this.lbl4C.Text = "4C";
            // 
            // lbl3C
            // 
            this.lbl3C.AutoSize = true;
            this.lbl3C.BackColor = System.Drawing.Color.White;
            this.lbl3C.Location = new System.Drawing.Point(171, 240);
            this.lbl3C.Name = "lbl3C";
            this.lbl3C.Size = new System.Drawing.Size(19, 12);
            this.lbl3C.TabIndex = 18;
            this.lbl3C.Text = "3C";
            // 
            // lbl2C
            // 
            this.lbl2C.AutoSize = true;
            this.lbl2C.BackColor = System.Drawing.Color.White;
            this.lbl2C.Location = new System.Drawing.Point(113, 240);
            this.lbl2C.Name = "lbl2C";
            this.lbl2C.Size = new System.Drawing.Size(19, 12);
            this.lbl2C.TabIndex = 17;
            this.lbl2C.Text = "2C";
            // 
            // lbl1C
            // 
            this.lbl1C.AutoSize = true;
            this.lbl1C.BackColor = System.Drawing.Color.White;
            this.lbl1C.Location = new System.Drawing.Point(60, 240);
            this.lbl1C.Name = "lbl1C";
            this.lbl1C.Size = new System.Drawing.Size(19, 12);
            this.lbl1C.TabIndex = 16;
            this.lbl1C.Text = "1C";
            // 
            // lbl5D
            // 
            this.lbl5D.AutoSize = true;
            this.lbl5D.BackColor = System.Drawing.Color.White;
            this.lbl5D.Location = new System.Drawing.Point(267, 270);
            this.lbl5D.Name = "lbl5D";
            this.lbl5D.Size = new System.Drawing.Size(19, 12);
            this.lbl5D.TabIndex = 25;
            this.lbl5D.Text = "5D";
            // 
            // lbl4D
            // 
            this.lbl4D.AutoSize = true;
            this.lbl4D.BackColor = System.Drawing.Color.White;
            this.lbl4D.Location = new System.Drawing.Point(221, 270);
            this.lbl4D.Name = "lbl4D";
            this.lbl4D.Size = new System.Drawing.Size(19, 12);
            this.lbl4D.TabIndex = 24;
            this.lbl4D.Text = "4D";
            // 
            // lbl3D
            // 
            this.lbl3D.AutoSize = true;
            this.lbl3D.BackColor = System.Drawing.Color.White;
            this.lbl3D.Location = new System.Drawing.Point(171, 270);
            this.lbl3D.Name = "lbl3D";
            this.lbl3D.Size = new System.Drawing.Size(19, 12);
            this.lbl3D.TabIndex = 23;
            this.lbl3D.Text = "3D";
            // 
            // lbl2D
            // 
            this.lbl2D.AutoSize = true;
            this.lbl2D.BackColor = System.Drawing.Color.White;
            this.lbl2D.Location = new System.Drawing.Point(113, 270);
            this.lbl2D.Name = "lbl2D";
            this.lbl2D.Size = new System.Drawing.Size(19, 12);
            this.lbl2D.TabIndex = 22;
            this.lbl2D.Text = "2D";
            // 
            // lbl1D
            // 
            this.lbl1D.AutoSize = true;
            this.lbl1D.BackColor = System.Drawing.Color.White;
            this.lbl1D.Location = new System.Drawing.Point(60, 270);
            this.lbl1D.Name = "lbl1D";
            this.lbl1D.Size = new System.Drawing.Size(19, 12);
            this.lbl1D.TabIndex = 21;
            this.lbl1D.Text = "1D";
            // 
            // lblAPG_AG
            // 
            this.lblAPG_AG.AutoSize = true;
            this.lblAPG_AG.BackColor = System.Drawing.Color.White;
            this.lblAPG_AG.Location = new System.Drawing.Point(350, 190);
            this.lblAPG_AG.Name = "lblAPG_AG";
            this.lblAPG_AG.Size = new System.Drawing.Size(28, 12);
            this.lblAPG_AG.TabIndex = 26;
            this.lblAPG_AG.Text = "APG";
            // 
            // lblpulse
            // 
            this.lblpulse.AutoSize = true;
            this.lblpulse.BackColor = System.Drawing.Color.White;
            this.lblpulse.Location = new System.Drawing.Point(350, 216);
            this.lblpulse.Name = "lblpulse";
            this.lblpulse.Size = new System.Drawing.Size(40, 12);
            this.lblpulse.TabIndex = 27;
            this.lblpulse.Text = "PULSE";
            // 
            // lbl1wave
            // 
            this.lbl1wave.AutoSize = true;
            this.lbl1wave.BackColor = System.Drawing.Color.White;
            this.lbl1wave.Location = new System.Drawing.Point(60, 302);
            this.lbl1wave.Name = "lbl1wave";
            this.lbl1wave.Size = new System.Drawing.Size(20, 12);
            this.lbl1wave.TabIndex = 28;
            this.lbl1wave.Text = "1W";
            // 
            // lbl2wave
            // 
            this.lbl2wave.AutoSize = true;
            this.lbl2wave.BackColor = System.Drawing.Color.White;
            this.lbl2wave.Location = new System.Drawing.Point(113, 302);
            this.lbl2wave.Name = "lbl2wave";
            this.lbl2wave.Size = new System.Drawing.Size(20, 12);
            this.lbl2wave.TabIndex = 29;
            this.lbl2wave.Text = "2W";
            // 
            // lbl3wave
            // 
            this.lbl3wave.AutoSize = true;
            this.lbl3wave.BackColor = System.Drawing.Color.White;
            this.lbl3wave.Location = new System.Drawing.Point(171, 302);
            this.lbl3wave.Name = "lbl3wave";
            this.lbl3wave.Size = new System.Drawing.Size(20, 12);
            this.lbl3wave.TabIndex = 30;
            this.lbl3wave.Text = "3W";
            // 
            // lbl4wave
            // 
            this.lbl4wave.AutoSize = true;
            this.lbl4wave.BackColor = System.Drawing.Color.White;
            this.lbl4wave.Location = new System.Drawing.Point(221, 302);
            this.lbl4wave.Name = "lbl4wave";
            this.lbl4wave.Size = new System.Drawing.Size(20, 12);
            this.lbl4wave.TabIndex = 31;
            this.lbl4wave.Text = "4W";
            // 
            // lbl5wave
            // 
            this.lbl5wave.AutoSize = true;
            this.lbl5wave.BackColor = System.Drawing.Color.White;
            this.lbl5wave.Location = new System.Drawing.Point(267, 302);
            this.lbl5wave.Name = "lbl5wave";
            this.lbl5wave.Size = new System.Drawing.Size(20, 12);
            this.lbl5wave.TabIndex = 32;
            this.lbl5wave.Text = "5W";
            // 
            // lblTwave
            // 
            this.lblTwave.AutoSize = true;
            this.lblTwave.BackColor = System.Drawing.Color.White;
            this.lblTwave.Location = new System.Drawing.Point(350, 240);
            this.lblTwave.Name = "lblTwave";
            this.lblTwave.Size = new System.Drawing.Size(21, 12);
            this.lblTwave.TabIndex = 33;
            this.lblTwave.Text = "TW";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblStart.Location = new System.Drawing.Point(59, 80);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(17, 16);
            this.lblStart.TabIndex = 34;
            this.lblStart.Text = "a";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.tsslconnect,
            this.tsslVGA,
            this.tsslWave22});
            this.statusStrip1.Location = new System.Drawing.Point(0, 351);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(937, 23);
            this.statusStrip1.TabIndex = 36;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 17);
            // 
            // tsslconnect
            // 
            this.tsslconnect.ActiveLinkColor = System.Drawing.Color.Red;
            this.tsslconnect.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tsslconnect.ForeColor = System.Drawing.Color.Blue;
            this.tsslconnect.Name = "tsslconnect";
            this.tsslconnect.Size = new System.Drawing.Size(59, 18);
            this.tsslconnect.Text = "Connect";
            this.tsslconnect.Visible = false;
            // 
            // tsslVGA
            // 
            this.tsslVGA.ForeColor = System.Drawing.Color.Red;
            this.tsslVGA.Name = "tsslVGA";
            this.tsslVGA.Size = new System.Drawing.Size(80, 18);
            this.tsslVGA.Text = "血管年齢表示";
            this.tsslVGA.Visible = false;
            // 
            // tsslWave22
            // 
            this.tsslWave22.Name = "tsslWave22";
            this.tsslWave22.Size = new System.Drawing.Size(70, 18);
            this.tsslWave22.Text = "22波形分類";
            this.tsslWave22.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(9, 56);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 37;
            this.btnPrint.Text = "印刷";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // menuVersion
            // 
            this.menuVersion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem,
            this.menuFunction,
            this.tsVersion});
            this.menuVersion.Location = new System.Drawing.Point(0, 0);
            this.menuVersion.Name = "menuVersion";
            this.menuVersion.Size = new System.Drawing.Size(937, 26);
            this.menuVersion.TabIndex = 39;
            this.menuVersion.Text = "バージョン";
            // 
            // ファイルFToolStripMenuItem
            // 
            this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuWrite,
            this.toolStripSeparator1,
            this.menuPrint,
            this.toolStripSeparator2,
            this.menuClose});
            this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(85, 22);
            this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // menuWrite
            // 
            this.menuWrite.Name = "menuWrite";
            this.menuWrite.Size = new System.Drawing.Size(182, 22);
            this.menuWrite.Text = "データ書き込み(&W)";
            this.menuWrite.Click += new System.EventHandler(this.menuWrite_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // menuPrint
            // 
            this.menuPrint.Name = "menuPrint";
            this.menuPrint.Size = new System.Drawing.Size(182, 22);
            this.menuPrint.Text = "印刷(&P)";
            this.menuPrint.Click += new System.EventHandler(this.menuPrint_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(179, 6);
            // 
            // menuClose
            // 
            this.menuClose.Name = "menuClose";
            this.menuClose.Size = new System.Drawing.Size(182, 22);
            this.menuClose.Text = "閉じる(&C)";
            this.menuClose.Click += new System.EventHandler(this.menuClose_Click);
            // 
            // menuFunction
            // 
            this.menuFunction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuConnect,
            this.toolStripSeparator3,
            this.menuVasAGE,
            this.toolStripSeparator4,
            this.menuWave22});
            this.menuFunction.Name = "menuFunction";
            this.menuFunction.Size = new System.Drawing.Size(62, 22);
            this.menuFunction.Text = "機能(&K)";
            // 
            // menuConnect
            // 
            this.menuConnect.Name = "menuConnect";
            this.menuConnect.Size = new System.Drawing.Size(227, 22);
            this.menuConnect.Text = "測定/中断(&C)";
            this.menuConnect.Click += new System.EventHandler(this.menuConnect_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(224, 6);
            // 
            // menuVasAGE
            // 
            this.menuVasAGE.Enabled = false;
            this.menuVasAGE.Name = "menuVasAGE";
            this.menuVasAGE.Size = new System.Drawing.Size(227, 22);
            this.menuVasAGE.Text = "血管年齢の表示/非表示(&V)";
            this.menuVasAGE.Click += new System.EventHandler(this.menuVasAGE_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(224, 6);
            // 
            // menuWave22
            // 
            this.menuWave22.Name = "menuWave22";
            this.menuWave22.Size = new System.Drawing.Size(227, 22);
            this.menuWave22.Text = "22波形分類／7波形分類(&W)";
            this.menuWave22.Click += new System.EventHandler(this.menuWave22_Click);
            // 
            // tsVersion
            // 
            this.tsVersion.Name = "tsVersion";
            this.tsVersion.Size = new System.Drawing.Size(98, 22);
            this.tsVersion.Text = "バージョン(&V)";
            this.tsVersion.Click += new System.EventHandler(this.tsVersion_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Location = new System.Drawing.Point(814, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(94, 131);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("ＭＳ 明朝", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblAge.Location = new System.Drawing.Point(494, 190);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(16, 15);
            this.lblAge.TabIndex = 41;
            this.lblAge.Text = "a";
            // 
            // lblTW
            // 
            this.lblTW.AutoSize = true;
            this.lblTW.Font = new System.Drawing.Font("ＭＳ 明朝", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTW.Location = new System.Drawing.Point(494, 223);
            this.lblTW.Name = "lblTW";
            this.lblTW.Size = new System.Drawing.Size(16, 15);
            this.lblTW.TabIndex = 42;
            this.lblTW.Text = "a";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("ＭＳ 明朝", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblScore.Location = new System.Drawing.Point(476, 251);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(16, 15);
            this.lblScore.TabIndex = 43;
            this.lblScore.Text = "a";
            // 
            // lblJudge
            // 
            this.lblJudge.AutoSize = true;
            this.lblJudge.Font = new System.Drawing.Font("ＭＳ 明朝", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblJudge.Location = new System.Drawing.Point(494, 281);
            this.lblJudge.Name = "lblJudge";
            this.lblJudge.Size = new System.Drawing.Size(16, 15);
            this.lblJudge.TabIndex = 44;
            this.lblJudge.Text = "a";
            // 
            // lblVasAGE
            // 
            this.lblVasAGE.AutoSize = true;
            this.lblVasAGE.Font = new System.Drawing.Font("ＭＳ 明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblVasAGE.ForeColor = System.Drawing.Color.Red;
            this.lblVasAGE.Location = new System.Drawing.Point(349, 298);
            this.lblVasAGE.Name = "lblVasAGE";
            this.lblVasAGE.Size = new System.Drawing.Size(17, 16);
            this.lblVasAGE.TabIndex = 45;
            this.lblVasAGE.Text = "a";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 374);
            this.Controls.Add(this.lblVasAGE);
            this.Controls.Add(this.lblJudge);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblTW);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuVersion);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lblTwave);
            this.Controls.Add(this.lbl5wave);
            this.Controls.Add(this.lbl4wave);
            this.Controls.Add(this.lbl3wave);
            this.Controls.Add(this.lbl2wave);
            this.Controls.Add(this.lbl1wave);
            this.Controls.Add(this.lblpulse);
            this.Controls.Add(this.lblAPG_AG);
            this.Controls.Add(this.lbl5D);
            this.Controls.Add(this.lbl4D);
            this.Controls.Add(this.lbl3D);
            this.Controls.Add(this.lbl2D);
            this.Controls.Add(this.lbl1D);
            this.Controls.Add(this.lbl5C);
            this.Controls.Add(this.lbl4C);
            this.Controls.Add(this.lbl3C);
            this.Controls.Add(this.lbl2C);
            this.Controls.Add(this.lbl1C);
            this.Controls.Add(this.lbl5B);
            this.Controls.Add(this.lbl4B);
            this.Controls.Add(this.lbl3B);
            this.Controls.Add(this.lbl2B);
            this.Controls.Add(this.lbl1B);
            this.Controls.Add(this.lbl5A);
            this.Controls.Add(this.lbl4A);
            this.Controls.Add(this.lbl3A);
            this.Controls.Add(this.lbl2A);
            this.Controls.Add(this.lbl1A);
            this.Controls.Add(this.cmbCOM);
            this.Controls.Add(this.pbxAPG);
            this.MainMenuStrip = this.menuVersion;
            this.Name = "Form3";
            this.Text = "ひばりパルス";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxAPG)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuVersion.ResumeLayout(false);
            this.menuVersion.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxAPG;
        private System.Windows.Forms.ComboBox cmbCOM;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbl1A;
        private System.Windows.Forms.Label lbl2A;
        private System.Windows.Forms.Label lbl3A;
        private System.Windows.Forms.Label lbl4A;
        private System.Windows.Forms.Label lbl5A;
        private System.Windows.Forms.Label lbl5B;
        private System.Windows.Forms.Label lbl4B;
        private System.Windows.Forms.Label lbl3B;
        private System.Windows.Forms.Label lbl2B;
        private System.Windows.Forms.Label lbl1B;
        private System.Windows.Forms.Label lbl5C;
        private System.Windows.Forms.Label lbl4C;
        private System.Windows.Forms.Label lbl3C;
        private System.Windows.Forms.Label lbl2C;
        private System.Windows.Forms.Label lbl1C;
        private System.Windows.Forms.Label lbl5D;
        private System.Windows.Forms.Label lbl4D;
        private System.Windows.Forms.Label lbl3D;
        private System.Windows.Forms.Label lbl2D;
        private System.Windows.Forms.Label lbl1D;
        private System.Windows.Forms.Label lblAPG_AG;
        private System.Windows.Forms.Label lblpulse;
        private System.Windows.Forms.Label lbl1wave;
        private System.Windows.Forms.Label lbl2wave;
        private System.Windows.Forms.Label lbl3wave;
        private System.Windows.Forms.Label lbl4wave;
        private System.Windows.Forms.Label lbl5wave;
        private System.Windows.Forms.Label lblTwave;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.MenuStrip menuVersion;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuWrite;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripStatusLabel tsslconnect;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblTW;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblJudge;
        private System.Windows.Forms.Label lblVasAGE;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuPrint;
        private System.Windows.Forms.ToolStripMenuItem menuClose;
        private System.Windows.Forms.ToolStripMenuItem menuFunction;
        private System.Windows.Forms.ToolStripMenuItem menuConnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuVasAGE;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripStatusLabel tsslVGA;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.ToolStripMenuItem tsVersion;
        private System.Windows.Forms.ToolStripStatusLabel tsslWave22;
        private System.Windows.Forms.ToolStripMenuItem menuWave22;
    }
}