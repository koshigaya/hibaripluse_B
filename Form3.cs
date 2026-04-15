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
using System.Collections;
using System.IO;
using MK_Library;

namespace hibari151201
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public class myReverseClass : IComparer
        {
            int IComparer.Compare(Object X, Object Y)
            {
                return ((new CaseInsensitiveComparer()).Compare(Y, X));
            }
        }

        public Form1 Form1_Dummy;
        public bool ageflag = false;
        public int agedata = 0;

        private SerialPort port;
        private byte[] readBuffer = new byte[1024];
        private delegate void ReadMainDelegate(string mes);
       
        private int[] numBuff = new int[800];   //容積脈波のＹ軸データ
        private int[] numBuff2 = new int[800];  //速度脈波のＹ軸データ
        private int[] numBuff3 = new int[800];  //加速度脈波のＹ軸データ
        private int[] numBuff_X = new int[800]; //ソートするため、numBuff3の値の配列番号をここに格納
        private int[] numBuff_Y = new int[800]; //ソートするため、numBuff3の値をここに格納

        private float[] numBuff2f = new float[800]; //12-11-16 　挿入

        private int len = 0;

        private bool fDummy = false; //portのインスタンス作成で真になる。FormClosingで一度もシリアル接続せずフォームを閉じる場合の処理として
        private int pulseSum = 0;
        private int[, ,] ABCD_Buff = new int[7, 5, 3]; //第n回、A～D値、そのときのx座標

        private float[] apgIndex = new float[6];
        private float[] ba_Index = new float[6];
        private float[] ca_Index = new float[6];
        private float[] da_Index = new float[6];

        private float apgIndex_Average;
        private int pulseIndex;
        private string Typical_WaveForm;
        private string[] WaveForm = new string[6];

        private int timerCount = 0;
        private bool pulseCounted= false;  //脈数をすでにカウントしていたら真

        private Bitmap memoryImage;
        private bool ConnectFlag = false;　　//接続していたら真
        private string stScore = "";           //スコアの文字列情報
        private bool VA_flag =  false;       //血管年齢を表示する場合は真、初期値は偽
        private bool wave22_flag = false;    //デフォルトは7波形分類。フラグを真にすると22波形分類。
        private int waveHeight = 1;         //画面に表示する波形の大きさを調整する。今は使用していない。
        private int Saidai = 0;


        //三上先生プログラム
        private int order_ = 100;
        private float[] xn_ = new float[800];
        private float[] yn_ = new float[800];
        private WindowingDesign fir_ = new WindowingDesign();

        private WindowingDesign.Type pb_;
        private float samplingFrq_ = 100.0f;
        private float fcL_ = 10.0f;
        private float fcH_ = 0.1f;


        private void Form3_Load(object sender, EventArgs e)
        {
            lblStart.Text = "";
            lblAge.Text = "";
            lblTW.Text = "";
            lblScore.Text = "";
            lblJudge.Text = "";
            lblVasAGE.Text = "";

            ageflag = Form1_Dummy.ageInputFlag;
            
            if (ageflag)
           {
             
              agedata = Form1_Dummy.ageInputData;
              lblAge.Text = "年齢：" + agedata + "歳";
              menuVasAGE.Enabled = true;

           }

            pb_ = WindowingDesign.Type.BPF; //三上
        }

       


        private void btnConnect_Click(object sender, EventArgs e)
        {
            method_ConnectOnOff();
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
                    tsslconnect.Visible = false;
                    ConnectFlag = false;
                    toolStripProgressBar1.Value = 0;

                }
            }
            else                       //切断していたら接続する
            {
                string sc = cmbCOM.Text;

                if (sc == "")
                {
                    try
                    {
                        string[] COMname = SerialPort.GetPortNames();
                        int i = SerialPort.GetPortNames().Length;
                        sc = COMname[i-1];
                        cmbCOM.Text = sc;
                    }
                    catch
                    {

                    }

                }

                method_Connect(sc);
                Thread.Sleep(100);
                method_measure();


            }


        }

        private void method_Connect(string sCOM)
        {

            if (sCOM != "")
            {

                this.port = new SerialPort(sCOM, 9600, Parity.None, 8, StopBits.One);
                this.port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                fDummy = true; //portインスタンス作成後、真になる


                if (!this.port.IsOpen)
                {
                 try{
                        this.port.Open();
                        this.port.DtrEnable = true;
                        this.port.RtsEnable = true;
                        Thread.Sleep(500);
                        btnConnect.Text = "中断";
                        tsslconnect.Visible = true;
                        ConnectFlag = true;
                        menuWave22.Enabled = false;
                        menuVasAGE.Enabled = false;
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

        private void method_measure()
        {
            string s;

            s = "1";
            
            this.port.Write(s);
            timer1.Enabled = true;

            lblTW.Text = "";
            lblScore.Text = "";
            lblJudge.Text = "";
            lblVasAGE.Text = "";

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fDummy)
            {
                if (this.port.IsOpen)
                {
                    this.port.Close();
                    this.port.Dispose();

                }
            }
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
                MessageBox.Show("データを読み込めませんでした");
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
                    if (lblStart.Text == "") lblStart.Text = "測定を開始しました。しばらくお待ちください。";         
                    toolStripProgressBar1.Value = (len * 2) / 15;  //配列750で100になるよう調整　100/250=2/5
                    mtd_Picture();

                }
                else
                {
                    for (int i = 0; i < 750; i++)
                    {
                        numBuff[i] = numBuff[i + 1];
                        xn_[i] = xn_[i + 1]; //三上
                    }

                    fir_.Design(order_, pb_, samplingFrq_, fcL_, fcH_); //三上
                    EvH_Processing(); //三上

                    if (lblStart.Text != "") lblStart.Text = "";
                    mtd_Picture();
                    mtd_Analysis();
                    len = 750;
                }
            }
            catch
            {

            }
        }

        private void mtd_Picture()
        {
            Bitmap bmp = new Bitmap(pbxAPG.Width, pbxAPG.Height);
            pbxAPG.Image = bmp;
            Graphics g = Graphics.FromImage(pbxAPG.Image);
            g.DrawLine(Pens.Red, 0, pbxAPG.Height / 2, pbxAPG.Width, pbxAPG.Height / 2);

            for (int i = 0; i < (len - 1); i++)
            {

                numBuff2f[i] = yn_[i + 1] - yn_[i]; //三上

            }


            for (int i = 0; i < (len - 2); i++)
            {
               
                numBuff3[i] = (int)((numBuff2f[i+1] - numBuff2f[i])*100); //三上
                numBuff_Y[i] = numBuff3[i];
                numBuff_X[i] = i;
            }


            for (int i =0; i < (len - 2); i++)
            {
                int Ynow = 60 - (numBuff3[i] * waveHeight/8);       //15-11-24 波形を8倍の1にした。後で見直し
                int Ynext = 60 - (numBuff3[i + 1] * waveHeight/8);  //　　　　↑に同じ
              
                int j = 1 * (i);
                g.DrawLine(Pens.Blue, new Point(j, Ynow), new Point((j + 1), Ynext));
               
            }

        }

        private void mtd_Analysis()
        {
            int i = mtd_pulseSum();
            pulseSum = 0;
            if (i >= 6)
            {
                mtd_pointABCD(i);
                mtd_pointABCD2(); //13-6-5追記
                mtd_Calc(i);
                mtd_Judge();
            }
           
        }


        private int mtd_pulseSum()
        {
            for (int i = 0; i <= 750; i++)
            {
                if(!pulseCounted)
                {
                    if ((numBuff[i] < numBuff[i + 1]) && (numBuff[i + 1] < numBuff[i + 2]) 
                        && (numBuff[i + 2] < numBuff[i + 3]))
                    {
                        pulseSum++;
                        pulseCounted=true;
                    }
                }
                else if(numBuff[i] >= numBuff[i+1])
                {
                    pulseCounted = false;
                }

            }

            //最後にpulseCountedがfalseになっている必要がある。trueなら、脈拍数を一つ引く。
            if (pulseCounted)
            {
                pulseSum--;
                pulseCounted = false;
            }


            return pulseSum;

        }

        private void mtd_pointABCD(int integer)
        {

            IComparer myComparer = new myReverseClass();
            Array.Sort(numBuff_Y,numBuff_X,0,748,myComparer); //値の大きい順にソート　Ａ点を見つける
            Saidai = numBuff_Y[0];
            Array.Sort(numBuff_X, numBuff_Y, 0, integer*3);    //15-11-23追記　Ｘ座標の小さい順にＡ点とその前後点をソート



            //以下、15-11-23追記 A点確保

            for (int i = 0; i <= 5; i++)
            {

                int jY = numBuff_Y[3 * i + 2];
                int jX = numBuff_X[3 * i + 2]; 

                if (numBuff3[jX - 1] > numBuff3[jX])
                {
                    ABCD_Buff[i + 1, 0, 0] = numBuff3[jX - 1];
                    ABCD_Buff[i + 1, 0, 1] = jX - 1;
                }
                else if (numBuff3[jX] < numBuff3[jX+1])
                {
                    ABCD_Buff[i + 1, 0, 0] = numBuff3[jX + 1];
                    ABCD_Buff[i + 1, 0, 1] = jX + 1;
                
                }
                else
                {
                    ABCD_Buff[i + 1, 0, 0] = jY;
                    ABCD_Buff[i + 1, 0, 1] = jX;
                }

            }
          //以上、15-11-23追記



            //これ以降はB、Ｃ，Ｄ点確保
            int nkai = 1;  //測定回数を表す。
            while(nkai<=5)
            {
                int iA_X = ABCD_Buff[nkai, 0, 1];  //第nkai回のA点のX座標 
                int Suite = 1;  //Suits=1はBポイント、Suits=2はCポイント、Suits=3はDポイント

                for (int j = iA_X; j <= ABCD_Buff[nkai + 1, 0, 1]; j++)
                {
                    
                    if (((numBuff3[j] >= numBuff3[j + 1] && numBuff3[j + 1] <= numBuff3[j + 2]) ||    //15-11-25挿入　前の値と同じときは極点にならない
                        (numBuff3[j] <= numBuff3[j + 1] && numBuff3[j + 1] >= numBuff3[j + 2]))&&     //    
                        (ABCD_Buff[nkai,Suite-1,0]!=numBuff3[j+1]))
                    {
                        ABCD_Buff[nkai, Suite, 0] = numBuff3[j + 1]; //第nkai回のB,C,D点のY座標
                        ABCD_Buff[nkai, Suite, 1] = j + 1; //第nkai回のB,C,D点のX座標
                        Suite++; 
                    }

                    if (Suite >= 4) goto R1;
                }

            R1:
                nkai++; //次回の測定回へ

            }

        }



        //13-6-5追記
        private void mtd_pointABCD2()
        {
            try
            {

                int nkai = 1;

                while (nkai <= 5)
                {
                    if (ABCD_Buff[nkai, 2, 0] < 0) goto R2;

                    int b_index = ABCD_Buff[nkai, 1, 1];
                    int beforeB = 0;
                    int afterB = 0;

                    for (int i = (b_index - 1); numBuff3[i] <= 0; i--) beforeB++;
                    for (int i = (b_index + 1); numBuff3[i] <= 0; i++) afterB++;

                    if ((afterB - beforeB) >= 2) mtd_ReprocessAfter(nkai, b_index, afterB);
                    else if ((beforeB - afterB) >= 2) mtd_ReprocessBefore(nkai, b_index, beforeB);


                R2:
                    nkai++;
                }

            }
            catch
            {

            }

        }


        //13-6-8追記
        private void mtd_ReprocessBefore(int jnkai, int jb_index, int jbeforeB)
        {
            int[] tempBuff0 = new int[20];  //ｂ点から基準線までのＹ座標配列の1回微分
            int[] tempBuff1 = new int[20];  //ｂ点から基準線までのＹ座標配列の2回微分
            int[] tempBuff_X = new int[20];
            int[] tempBuff_Y = new int[20];

            for (int i = 0; i <=jbeforeB; i++)
                tempBuff0[i] = numBuff3[jb_index - i - 1] - numBuff3[jb_index - i];

            for (int i = 0; i <= (jbeforeB - 1); i++)
            {
                tempBuff1[i] = tempBuff0[i + 1] - tempBuff0[i];
                tempBuff_X[i] = i;
                tempBuff_Y[i] = tempBuff1[i];
            }

            Array.Sort(tempBuff_Y, tempBuff_X, 0,jbeforeB - 1);　//配列を二階微分した最小値が配列「0」に。これが負ならＣ点候補 最後のパラメータは要素数。配列の最後の要素はソートしない。

            if (tempBuff_Y[0] < 0)
            {
                int jC = tempBuff_X[0];
                int nB3_i = jb_index - jC - 1; //numBuff3の新Ｃ点のＸ座標。配列は0から始まるので-1
                
                for (int i = jC + 1; i <= (jbeforeB - 1); i++)
                {
                    if (tempBuff1[i] > 0)
                    {
                        ABCD_Buff[jnkai, 2, 0] = numBuff3[nB3_i]; //新ｃ点
                        ABCD_Buff[jnkai, 2, 1] = nB3_i;

                        ABCD_Buff[jnkai, 1, 0] = numBuff3[nB3_i - i + jC];　//新ｂ点
                        ABCD_Buff[jnkai, 1, 1] = nB3_i - i + jC;

                        ABCD_Buff[jnkai, 3, 0] = numBuff3[jb_index];　//新d点
                        ABCD_Buff[jnkai, 3, 1] = jb_index;

                        break;

                    
                    }

                }
                

            }



        }

      

        //13-6-5追記
        private void mtd_ReprocessAfter(int inkai, int ib_index, int iafterB)
        {
            int[] tempBuff0 = new int[20];  //ｂ点から基準線までのＹ座標配列の1回微分
            int[] tempBuff1 = new int[20];  //ｂ点から基準線までのＹ座標配列の2回微分
            int[] tempBuff_X = new int[20];
            int[] tempBuff_Y = new int[20];

            for (int i = 0; i <= iafterB; i++)
                tempBuff0[i] = numBuff3[ib_index + i + 1] - numBuff3[ib_index + i];

            for (int i = 0; i <= (iafterB - 1); i++)
            {
                tempBuff1[i] = tempBuff0[i + 1] - tempBuff0[i];
                tempBuff_X[i] = i;
                tempBuff_Y[i] = tempBuff1[i];
            }

            Array.Sort(tempBuff_Y, tempBuff_X, 0, iafterB - 1);　//配列を二階微分した最小値が配列「0」に。これが負ならＣ点候補 最後のパラメータは要素数。配列の最後の要素はソートしない。

            if (tempBuff_Y[0] < 0)
            {
                int jC = tempBuff_X[0];
                int nB3_i = jC + 1 + ib_index; //numBuff3のＸ座標。配列は0から始まるので+1
               
                for (int i = jC + 1; i <= (iafterB - 1); i++)
                {
                    if (tempBuff1[i] > 0)
                    {
                        ABCD_Buff[inkai, 2, 0] = numBuff3[nB3_i];
                        ABCD_Buff[inkai, 2, 1] = nB3_i;

                        ABCD_Buff[inkai, 3, 0] = numBuff3[nB3_i + i - jC];
                        ABCD_Buff[inkai, 3, 1] = nB3_i + i - jC;
                        
                        break;
                    
                    }

                }
                

            }



        }



        private void mtd_Calc(int integer)
        {           
            float apgIndex_Dummy = 0;
            int validityCount = 0;

            for (int i = 1; i <= 5; i++)
            {
                if (ABCD_Buff[i, 0, 0] != 0)
                {
                    ba_Index[i] = ((float)ABCD_Buff[i, 1, 0]) / ((float)ABCD_Buff[i, 0, 0]);
                    ca_Index[i] = ((float)ABCD_Buff[i, 2, 0]) / ((float)ABCD_Buff[i, 0, 0]);
                    da_Index[i] = ((float)ABCD_Buff[i, 3, 0]) / ((float)ABCD_Buff[i, 0, 0]);
                   
                    apgIndex[i] = ca_Index[i] + da_Index[i] - ba_Index[i];
                    apgIndex_Dummy += apgIndex[i];
                    validityCount++;

                }
              else
                {
                    ba_Index[i] = 0;
                    ca_Index[i] = 0;
                    da_Index[i] = 0;

                    apgIndex[i] = 0;
                }

            }

            if(validityCount !=0) apgIndex_Average = (apgIndex_Dummy / validityCount) * 100;
             pulseIndex = 8 * integer;    //arduinoでdelay(30)なので、配列250のときpulseSumは7.5秒間の脈数なので1分間の脈数はその8倍
            mtd_PatternMatching();  //波形のパターンマッチング

            
            //計算結果をフォームに出力
            for (int i = 1; i <= 5; i++)
            {
                float apg_Dummy = apgIndex[i] * 100;
                apgIndex[i] = transformFigure(apg_Dummy);
                
                float ba_Dummy = ba_Index[i] * 100;
                ba_Index[i] = transformFigure(ba_Dummy);

                float ca_Dummy = ca_Index[i] * 100;
                ca_Index[i] =  transformFigure(ca_Dummy);

                float da_Dummy = da_Index[i] * 100;
                da_Index[i] = transformFigure(da_Dummy);

            }


            lbl1A.Text = apgIndex[1].ToString();
            lbl1B.Text = ba_Index[1].ToString();
            lbl1C.Text = ca_Index[1].ToString();
            lbl1D.Text = da_Index[1].ToString();

            lbl2A.Text = apgIndex[2].ToString();
            lbl2B.Text = ba_Index[2].ToString();
            lbl2C.Text = ca_Index[2].ToString();
            lbl2D.Text = da_Index[2].ToString();

            lbl3A.Text = apgIndex[3].ToString();
            lbl3B.Text = ba_Index[3].ToString();
            lbl3C.Text = ca_Index[3].ToString();
            lbl3D.Text = da_Index[3].ToString();

            lbl4A.Text = apgIndex[4].ToString();
            lbl4B.Text = ba_Index[4].ToString();
            lbl4C.Text = ca_Index[4].ToString();
            lbl4D.Text = da_Index[4].ToString();

            lbl5A.Text = apgIndex[5].ToString();
            lbl5B.Text = ba_Index[5].ToString();
            lbl5C.Text = ca_Index[5].ToString();
            lbl5D.Text = da_Index[5].ToString();

            lbl1wave.Text = WaveForm[1];
            lbl2wave.Text = WaveForm[2];
            lbl3wave.Text = WaveForm[3];
            lbl4wave.Text = WaveForm[4];
            lbl5wave.Text = WaveForm[5];

            lblpulse.Text = pulseIndex.ToString();
            float Average_Dummy = apgIndex_Average;
            apgIndex_Average = transformFigure(Average_Dummy);
            lblAPG_AG.Text = apgIndex_Average.ToString();


           

        }


        private void mtd_PatternMatching()
        {
            for (int i = 1; i<= 5; i++)
            {
                float b = ba_Index[i]; 
                float d = da_Index[i]; 
                float c = ca_Index[i];

                float b1 = ba_Index[i] / 3;
                float b2 = 2 * ba_Index[i] / 3;
                float d1 = da_Index[i] / 3;
                float d2 = 2 * da_Index[i] / 3;


                if (wave22_flag)
                {
                    if (b >= 0) { WaveForm[i] = "X"; }  //デバッグにつき、書き加えた
                    else if ((c >= 0) && (Math.Abs(b) > Math.Abs(d))&&(d >= 0))
                    { WaveForm[i] = "A+"; }
                    else if ((c >= 0) && (Math.Abs(b) > Math.Abs(d)) && (0 > d) && (d > b1)) 
                    { WaveForm[i] = "A"; }
                    else if ((c >= 0) && (Math.Abs(b) > Math.Abs(d)) && (b1 >= d) && (d > b2)) 
                    { WaveForm[i] = "A-"; }
                    
                    else if ((c < 0) && (Math.Abs(b) > Math.Abs(d)) 
                        && (c >= d) && (c > b1) && (d > b1)) 
                    { WaveForm[i] = "B+"; }
                    else if ((c < 0) && (Math.Abs(b) > Math.Abs(d)) 
                        && (c >= d) && (c > b1) && (b1 >= d) && (d > b2)) 
                    { WaveForm[i] = "B"; }
                    else if ((c < 0) && (Math.Abs(b) > Math.Abs(d)) 
                        && (c >= d) && (b1 >= c) && (c > b2) && (b1 >= d) && (d > b2)) 
                    { WaveForm[i] = "B-"; }
                    else if ((c < 0) && (Math.Abs(b) > Math.Abs(d)) 
                        && (0 > d) && (d > c) && (c > b1) && (d > b1)) 
                    { WaveForm[i] = "B+X"; }
                    else if ((c < 0) && (Math.Abs(b) > Math.Abs(d)) 
                        && (0 > d) && (d > c) && (b1 >= c) && (c > b2) && (d > b1)) 
                    { WaveForm[i] = "BX"; }
                    else if ((c < 0) && (Math.Abs(b) > Math.Abs(d)) 
                        && (0 > d) && (d > c) && (b1 >= c) && (c > b2) && (b1 >= d) && (d > b2)) 
                    { WaveForm[i] = "B-X"; }

                    else if ((d >= b) && (c >= 0) && (b2 >= d) && (d > b)) 
                    { WaveForm[i] = "C+"; }
                    else if ((d >= b) && (c < 0) && (b2 > d) && (d>= b) && (c > b1)) { WaveForm[i] = "C"; }

                    else if ((d >= b) && (c < 0) && (b2 > d) && (d >= b) && (b1 >= c) && (c > b2)) 
                    { WaveForm[i] = "C-"; }

                    else if ((b > d) && (c >= 0) && (d2 >= b) && (b > d))
                    { WaveForm[i] = "C+"; }
                    else if ((b > d) && (c < 0) && (d2 >= b) && (b > d) && (c > d1))
                    { WaveForm[i] = "C"; }
           
                    else if ((b > d) && (c < 0) && (d2 >= b) && (b > d) && (d1 >= c) && (c > d2)) 
                    { WaveForm[i] = "C--"; }

                    else if ((d >= b) && (b2 >= c) && (c > b) && (0 >d) && (d > b1))
                    { WaveForm[i] = "D++"; }
                    else if ((d >= b) && (b2 >= c) && (c > b) && (b1 >= d) && (d > b2))
                    { WaveForm[i] = "D+"; }
                    else if ((d >= b) && (b2 >= c) && (c > b) && (b2 > d) && (d > b))
                    { WaveForm[i] = "D"; }
                    else if ((b > d) && (d2 >= c) && (c >d) && (d2 >= b) && (b > d))
                    { WaveForm[i] = "D-"; }

                    else if ((b > d) && (c >= 0) && (d1 >= b) && (b > d2)) 
                    { WaveForm[i] = "E+"; }
                    else if ((b > d) && (c < 0) && (c > b) && (c > d1) && (d1 >= b) && (b > d2)) 
                    { WaveForm[i] = "E"; }
                    else if ((b > d) && (c < 0) && (c > b) && (d1 >= c) && (c > d2) && (d1 >= b) && (b > d2)) 
                    { WaveForm[i] = "E-"; }
                    else if ((b > d) && (c < 0) && (c > b) && (c > d1) && (b > d1))
                    { WaveForm[i] = "E--"; }

                    else if ((b > d) && (c >= 0) && (0 > b) && (b > d1))
                    { WaveForm[i] = "E"; } //新Ｅ

                    else if ((b > d) && (c < 0) && (b > c) && (d1 >= c) && (c >= d2) && (d1 >= b) && (b > d2))
                    { WaveForm[i] = "F"; }
                    else if ((b > d) && (c < 0) && (b > c) && (c > d1) && (0 > b) && (b > d1) && (b > d2))
                    { WaveForm[i] = "F-"; }
                    else if ((b > d) && (c < 0) && (d2 >= c) && (c >= d) && (d1 >= b) && (b >= d2))
                    { WaveForm[i] = "G"; }
                    else if ((b > d) && (c < 0) && (d1 >= c) && (c >= d) && (0 > b) && (b > d1))
                    { WaveForm[i] = "G-"; }

                    else { WaveForm[i] = "X"; }

                }
                else
                {
                    if (b >= 0) { WaveForm[i] = "X"; }  //デバッグにつき、書き加えた
                    else if ((c >= 0) && (Math.Abs(b) > Math.Abs(d))) { WaveForm[i] = "A"; }
                    else if ((c < 0) && (b1 <= c) && (Math.Abs(b) > Math.Abs(d))) { WaveForm[i] = "B"; }
                    else if ((b2 < c) && (b1 > c) && (Math.Abs(b) >= Math.Abs(d))) { WaveForm[i] = "C"; }
                    else if ((b2 >= c) && (Math.Abs(b) > Math.Abs(d))) { WaveForm[i] = "D"; }
                    else if ((b <= d1) && (c >= d1) && (Math.Abs(b) < Math.Abs(d))) { WaveForm[i] = "E"; }
                    else if ((c < d1) && (Math.Abs(b) < Math.Abs(d))) { WaveForm[i] = "F"; }
                    else if ((b > d1) && (Math.Abs(b) < Math.Abs(d))) { WaveForm[i] = "G"; }
                    else { WaveForm[i] = "X"; }
                }
            }
        }

        private void mtd_Judge()
        {
            int MatchNum = 0;
            for (int i = 1; i <= 4; i++)
            {
                for (int j = i + 1; j<= 5; j++)
                {
                      if (WaveForm[i] == WaveForm[j] && WaveForm[i] != "X")  MatchNum++;

                      if ((MatchNum >= 3) || ((MatchNum == 2) && mtd_XX())
                          || ((MatchNum == 2) && timerCount > 80))  //13-10-29追記
                      {
                        Typical_WaveForm = WaveForm[i];
                        lblTwave.Text = Typical_WaveForm; 

                        if (mtd_FinalValidity())
                        {
                            stScore = apgIndex_Average.ToString();
                            mtd_LastProcessing();  //重要！デバッグ終了、使えるようにする　15-11-28　10：00

                        }
                        
                          goto W1;  // mtd_FinakValidtyが真(測定完全終了)でも偽(A～D点見直し)でもループから抜ける
                      }

                }

                    MatchNum = 0; //MatdhNumが2以下でiがインクリメントされるとき、初期化が必要
            }

        W1:
                MatchNum = 0;

        }

        //13-10-29追記
        private bool mtd_XX()
        {
            bool k = true;

            for (int i = 1; i <= 5; i++)
            {
                if (WaveForm[i] == "X")
                {
                    k = false;
                    break;
                }
            }


            return k;
        }

        private bool mtd_FinalValidity()
        {
            //脈拍最大値の制限
            if (pulseIndex > 120) return false;  

           //5波形とも次回Ａ点より、今回Ｄ点が前にあるか
            for (int i = 1; i <= 5; i++)
            {
                if (ABCD_Buff[i, 3, 1] > ABCD_Buff[i + 1, 0, 1]) return false;
            }

            //Ａ点最大値がＡ点最小値(から２番目)の2倍以下か　Ａ点に0があるとすべてfalseになる
            int[] AY_Buff = new int[5];

            for (int i = 0; i <= 4; i++)
            {
                AY_Buff[i] = ABCD_Buff[i + 1, 0, 0];
            }

            Array.Sort(AY_Buff);
            if ((AY_Buff[0] * 2) < AY_Buff[4]) return false;

            //5波形のＡ点間のうち、最大の間隔が最小の間隔の2倍以下か
            int[] AX_Buff = new int[4];

            for (int i = 0; i <= 3; i++)
            {
                AX_Buff[i] = ABCD_Buff[i + 2, 0, 1] - ABCD_Buff[i + 1, 0, 1];
            }

            Array.Sort(AX_Buff);
            if ((AX_Buff[0] * 2) < AX_Buff[3]) return false;
  
            //上記すべてに当てはまらない場合のみ、真を返す。
            return true;
        }

        private void mtd_LastProcessing()
        {
            mtd_PortDisconnect();

            //タイマーの停止
            timer1.Enabled = false;
            timerCount = 0;

            //年齢入力時の各種測定結果の表示
            if (ageflag)
            {
                
                lblTW.Text = "波形：" + Typical_WaveForm;  //代表波形の表示
                lblScore.Text = "スコア：" + stScore;  //代表波形の表示
                string s = method_finalJudge();
                lblJudge.Text = "判定：" + s;  //判定の表示
                if (VA_flag)
                {
                    int iVA =method_VascularAge();
                    string sVA = iVA.ToString();
                    lblVasAGE.Text = "血管年齢：" + iVA + "歳";    //
                }
            }


            toolStripProgressBar1.Value = 0;

            if (Saidai != 0 && Saidai < 160)  //15-11-24 波高倍率1/8に変更につき　20＊8＝160
            {
                waveHeight = 320 / Saidai;  //15-11-24　波高倍率1/8に変更につき　40＊80＝320
                mtd_Picture();
                waveHeight = 1;
            }

            MessageBox.Show("測定終了" + "\n" + Typical_WaveForm + " " + apgIndex_Average);

            len = 0;
            foreach (int i in numBuff){numBuff[i] = 0;}  //テスト用コメントアウト
            menuWave22.Enabled = true;
            if (ageflag) menuVasAGE.Enabled = true;

            
        }

        private void mtd_PortDisconnect()
        {
            if (this.port.IsOpen)
            {
                this.port.Close();
                this.port.Dispose();
            }

            ConnectFlag = false;
            btnConnect.Text = "測定";
            tsslconnect.Visible = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerCount++;
            if (timerCount >= 100)
            {
                mtd_PortDisconnect();
                timer1.Enabled = false;
                timerCount = 0;
                MessageBox.Show("測定できませんでした");
                
                len = 0;

            }


        }

        //有効数字少数第一位に変換　
        private float transformFigure(float f)
        { 
            int int_float = (int)(f*10);
            float f_f = ((float)int_float)/10;
            return f_f;
        
        }

        //印刷関係
        private void btnPrint_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            Thread.Sleep(100);
            printDocument1.Print();

        }

        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        //データ保存関係
        private void menuWrite_Click(object sender, EventArgs e)
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

        //血管年齢計算処理
        private int method_VascularAge()
        {
            float i = apgIndex_Average;
            float j = 57 - (i * 45 / 100);
          
            if (j > 90)
            {
                j = 90;
            }
            else if (j < 20)
            {
                j = 20;
            }

            int k = (int)j;
            return k;
            
        }

        //判定処理
        private string method_finalJudge()
        {

            int iAge = agedata;
            string sTW = Typical_WaveForm;
            string finalJudge;

            if (wave22_flag)
            {
                switch (sTW)
                {
                    case "A+":
                    case "A":     
                    case "A-":     
                    case "B+":
                    case "B+X":
                        finalJudge = "良好";
                        break;

                    case "B":
                        if (iAge < 30)
                        {
                            finalJudge = "標準";
                        }
                        else
                        {
                            finalJudge = "良好";
                        }
                        break;

                    case "BX":
                        if (iAge < 50)
                        {
                            finalJudge = "標準";
                        }
                        else
                        {
                            finalJudge = "良好";
                        }
                        break;

                    case "C+":
                        if (iAge < 60)
                        {
                            finalJudge = "標準";
                        }
                        else
                        {
                            finalJudge = "良好";
                        }
                        break;

                    case "C":
                        if (iAge < 30)
                        {
                            finalJudge = "要注意";
                        }
                        else if (iAge < 60)
                        {
                            finalJudge = "標準";
                        }
                        else
                        {
                            finalJudge = "良好";
                        }
                        break;

                    case "B-":
                        if (iAge < 40)
                        {
                            finalJudge = "要注意";
                        }
                        else if (iAge < 60)
                        {
                            finalJudge = "標準";
                        }
                        else
                        {
                            finalJudge = "良好";
                        }
                        break;

                    case "B-X":
                    case "C-":
                    case "E+":
                       if (iAge < 50)
                        {
                            finalJudge = "要注意";
                        }
                        else if (iAge < 70)
                        {
                            finalJudge = "標準";
                        }
                        else
                        {
                            finalJudge = "良好";
                        }
                        break;

                    case "E": 
                        if (iAge < 60)
                        {
                            finalJudge = "要注意";
                        }
                        else
                        {
                            finalJudge = "標準";
                        }
                        break;
                        
                    case "D+":
                    case "D":
                    case "D-":
                    case "E-":
                    case "F":
                    case "F-":
                    case "G":
                    case "G-":
                        finalJudge = "要注意";
                        break;

                    default:
                        finalJudge = "測定不能";
                        break;

                }

                return finalJudge;
                

            }
            else
            {

                switch (sTW)
                {
                    case "A":
                        finalJudge = "良好";
                        break;

                    case "B":
                        if (iAge < 30)
                        {
                            finalJudge = "標準";
                        }
                        else
                        {
                            finalJudge = "良好";
                        }
                        break;

                    case "C":
                        if (iAge < 30)
                        {
                            finalJudge = "要注意";
                        }
                        else if (iAge < 60)
                        {
                            finalJudge = "標準";
                        }
                        else
                        {
                            finalJudge = "良好";
                        }
                        break;

                    case "D":
                    case "E":
                        if (iAge < 60)
                        {
                            finalJudge = "要注意";
                        }
                        else
                        {
                            finalJudge = "標準";
                        }
                        break;

                    case "F":
                    case "G":
                        finalJudge = "要注意";
                        break;

                    default:
                        finalJudge = "測定不能";
                        break;

                }

                return finalJudge;
            }

        }

        //メニューバーなど
        private void menuConnect_Click(object sender, EventArgs e)
        {
            method_ConnectOnOff();
        }


        private void menuPrint_Click(object sender, EventArgs e)
        {
            btnPrint_Click(sender,e);

        }

        private void menuClose_Click(object sender, EventArgs e)
        {
            btnClose_Click(sender,e);

        }

        //血管年齢の表示／非表示の切替。フラグの真偽を逆にする
        private void menuVasAGE_Click(object sender, EventArgs e)  
        {
            if (VA_flag)
            {
                VA_flag = false;
                tsslVGA.Visible = false;
            }
            else
            {
                VA_flag = true;
                tsslVGA.Visible = true;
            }
        }


        private void tsVersion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("このアプリケーションのバージョンは\nver.151201です");
        }


        //22波形分類／7波形分類の切替。フラグの真偽を逆にする
        private void menuWave22_Click(object sender, EventArgs e)
        {
            if (wave22_flag)
            {
                wave22_flag = false;
                tsslWave22.Visible = false;

            }
            else
            {
                wave22_flag = true;
                tsslWave22.Visible = true;
            }
        }

       
        //以下、デジタル信号処理
        //三上プログラム
        private void EvH_Processing()
        {
            int order2 = order_ / 2;
            float[] un = new float[order_ + 1];   // FIRフィルタの作業領域
            Console.WriteLine("窓直前");
            float[] hk = fir_.Coefficients;     // 設計されたフィルタ係数の取得
            Console.WriteLine("窓直後");


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


            }
            /* ============== 信号処理の終了 ============== */

        }

      

    }
}