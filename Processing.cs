//------------------------------------------------------------------------------
//	可変 FIR フィルタ：　信号処理の部分
//------------------------------------------------------------------------------

using System;
using System.Windows.Forms;
using MK_Library;

namespace proto150926
{
	public partial class Form2 : Form
	{
		// button2_Click で行う処理
		private void EvH_Processing()
		{
			int order2 = order_/2;
			float[] un = new float[order_+1];   // FIRフィルタの作業領域
            Console.WriteLine("窓直前");
			float[] hk = fir_.Coefficients;     // 設計されたフィルタ係数の取得
            Console.WriteLine("窓直後");

			//AudioPlatform.DisablePanelButtons();
			//MyProgressBar pBar = new MyProgressBar(xn_.Length);

			/* ============== 信号処理の開始 ============== */
			Array.Clear(un, 0, un.Length);  // FIR フィルタの初期化
			for (int n=0; n<xn_.Length; n++)
			{
				un[0] = xn_[n];
				float acc = hk[0]*un[order2];
				for (int k=1; k<=order2; k++)
                {
                    acc = acc + hk[k] * (un[order2 - k] + un[order2 + k]);
                    //Console.WriteLine("hk[k]"+hk[k]);
                }
				yn_[n] = acc;
				for (int k=order_; k>0; k--) un[k] = un[k-1];
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
