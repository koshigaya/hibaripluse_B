using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Drawing.Drawing2D;
using System.IO;
using MK_Library;


namespace hibari151201
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private SerialPort port;
        private byte[] readBuffer = new byte[1024];
        private delegate void ReadMainDelegate(string mes);
        private int[] numBuff = new int[800];
        private int[] numBuff2 = new int[800];
        private int[] numBuff3 = new int[800];
        private float[] numBuff2f = new float[800];
        private int len = 0;

        private Bitmap memoryImage;
        private bool ConnectFlag;

        //三上先生プログラム
        private int order_ = 100;
        private float[] xn_ = new float[800];
        private float[] yn_ = new float[800];
        private WindowingDesign fir_ = new WindowingDesign();

        private WindowingDesign.Type pb_;
        private float samplingFrq_ = 100.0f;
        private float fcL_ = 10.0f;
        private float fcH_ = 0.1f;
        //三上


        private void Form2_Load(object sender, EventArgs e)
        {
            ConnectFlag = false;
            pb_ = WindowingDesign.Type.BPF; //三上
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void method_ConnectOnOff()
        {
            if (ConnectFlag)            //接続していたら切断する
            {
                if (this.port.IsOpen)
                {
                    this.port.Close();
                    this.port.Dispose();
                    btnConnect.Text = "測定";
                    label1.Text = " ";
                    ConnectFlag = false;

                }
            }
            else                       //切断していたら接続する
            {
                string sc = comboBox1.Text;
                if (sc == "")
                {
                    try
                    {
                        string[] COMname = SerialPort.GetPortNames();
                        int i = SerialPort.GetPortNames().Length;
                        sc = COMname[i-1];
                        comboBox1.Text = sc;
                    }
                    catch
                    {

                    }

                }

              //method_Connect(ref sc);
                method_Connect(sc);
                Thread.Sleep(100);
                method_Measure();



            }


        }

       //private void method_Connect(ref string sCOM)
        private void method_Connect(string sCOM)
        {

            if (sCOM != "")
            {

                this.port = new SerialPort(sCOM, 9600, Parity.None, 8, StopBits.One);
                this.port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);


                if (!this.port.IsOpen)
                {

                    try
                    {
                        this.port.Open();
                        this.port.DtrEnable = true;
                        this.port.RtsEnable = true;
                        Thread.Sleep(500);
                        btnConnect.Text = "中断";
                        label1.Text = "Connect";
                        ConnectFlag = true;
                    }
                    catch
                    {
                        MessageBox.Show("接続できませんでした\nCOM番号またはUSBコードの接続を確認してください");
                    }
                }
            }
            else
            {
                MessageBox.Show("COM番号を指定してください");
            }

           
        }

       

        private void btnConnect_Click(object sender, EventArgs e)
        {
           
            method_ConnectOnOff();
            
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string str = this.port.ReadLine();
                this.BeginInvoke(new ReadMainDelegate(ReadMain), new object[] { str });
            }
            catch
            {

            }

        }

        private void ReadMain(string msg)
        {
            try
            {

                numBuff[len] = int.Parse(msg);
                xn_[len] = Single.Parse(msg); //三上
                fir_.Design(order_, pb_, samplingFrq_, fcL_, fcH_); //三上
                EvH_Processing(); //三上
                len++;

                if (len < 750)
                {
                    method_Picture();
                }
                else
                {
                    for (int i = 0; i < 750; i++)
                    {
                        numBuff[i] = numBuff[i+1];
                        xn_[i] = xn_[i + 1]; //三上
                    }

                    fir_.Design(order_, pb_, samplingFrq_, fcL_, fcH_); //三上
                    EvH_Processing(); //三上

                    method_Picture();
                    len = 750;
                }
            }
            catch
            {
              //  MessageBox.Show("測定情報を取り込めませんでした");
            }
        }

        private void method_Picture()
        {
            method_Picture1();
            method_Picture2();
            method_Picture3();

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

                if (this.port.IsOpen)
                {
                    this.port.Close();
                    this.port.Dispose();
                }
            }
            catch
            {

            }

        }


        private void method_Measure()
        {
            string s;
            s = "1";
            try
            {
                this.port.WriteLine(s);
            }
            catch
            {

            }


        }


        private void method_Picture1()
        {

            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.DrawLine(Pens.Red, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);


            for (int i = 0; i < (len - 1); i++)
            {

                int Ynow = 52 - (((int)yn_[i]) / 6);       //三上
                int Ynext = 52 - (((int)yn_[i + 1]) / 6);  //三上

                int j = 1 * i;
                g.DrawLine(Pens.Blue, new Point(j, Ynow), new Point((j + 1), Ynext));

            }

        }

        private void method_Picture2()
        {

            Bitmap bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            pictureBox2.Image = bmp;
            Graphics g = Graphics.FromImage(pictureBox2.Image);
            g.DrawLine(Pens.Red, 0, pictureBox2.Height / 2, pictureBox2.Width, pictureBox2.Height / 2);


            for (int i = 0; i < (len - 2); i++)
            {
                //numBuff2[i] = numBuff[i + 1] - numBuff[i];
                //numBuff2[i] = (int)(yn_[i+1] - yn_[i]); //三上
                numBuff2f[i] = yn_[i + 1] - yn_[i];
                numBuff2[i] = (int)numBuff2f[i];
            }

                for (int i = 0; i < (len - 2); i++)
                {

                    int Ynow = 52 - (numBuff2[i] * 2);
                    int Ynext = 52 - (numBuff2[i + 1] * 2);

                    int j = 1 * i;
                    g.DrawLine(Pens.Blue, new Point(j, Ynow), new Point((j + 1), Ynext));

                }

            }


        private void method_Picture3()
        {
            Bitmap bmp = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            pictureBox3.Image = bmp;
            Graphics g = Graphics.FromImage(pictureBox3.Image);
            g.DrawLine(Pens.Red, 0, pictureBox3.Height / 2, pictureBox3.Width, pictureBox3.Height / 2);


            for (int i = 0; i < (len - 3); i++)
            {
                numBuff3[i] = (int)((numBuff2f[i + 1] - numBuff2f[i])*100);
            }

            for (int i = 0; i < (len - 3); i++)
            {
                int Ynow = 52 - (numBuff3[i] /10);
                int Ynext = 52 - (numBuff3[i + 1] /10);


                int j = 1 * i;
                g.DrawLine(Pens.Blue, new Point(j, Ynow), new Point((j + 1), Ynext));

            }

        }

       



        private void btnSave_Click(object sender, EventArgs e)
        {
            CaptureScreen();

            saveFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog1.Filter = "BMP形式(*.Bmp)|*.Bmp|すべてのファイル(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                memoryImage.Save(filename);
                MessageBox.Show("保存しました");
            }         
        }

        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);

        }

        //デジタル信号処理
        //三上プログラム
        private void EvH_Processing()
        {
            int order2 = order_ / 2;
            float[] un = new float[order_ + 1];   // FIRフィルタの作業領域
            Console.WriteLine("窓直前");
            float[] hk = fir_.Coefficients;     // 設計されたフィルタ係数の取得
            Console.WriteLine("窓直後");

            //AudioPlatform.DisablePanelButtons();
            //MyProgressBar pBar = new MyProgressBar(xn_.Length);

            /* ============== 信号処理の開始 ============== */
            Array.Clear(un, 0, un.Length);  // FIR フィルタの初期化
            for (int n = 0; n < xn_.Length; n++)
            {
                un[0] = xn_[n];
                float acc = hk[0] * un[order2];
                for (int k = 1; k <= order2; k++)
                {
                    acc = acc + hk[k] * (un[order2 - k] + un[order2 + k]);
                    //Console.WriteLine("hk[k]"+hk[k]);
                }
                yn_[n] = acc;
                for (int k = order_; k > 0; k--) un[k] = un[k - 1];
                //Console.WriteLine("太田");




                //pBar.Update();              // プログレスバーの更新
            }
            /* ============== 信号処理の終了 ============== */

            //AudioPlatform.PostProcessing();
            //pBar.Close();
            //MessageBox.Show("FIR通った");
        }


       
    }
}