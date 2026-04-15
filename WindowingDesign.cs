//------------------------------------------------------------------------------
//	ハミング窓を使う窓関数法による FIR フィルタの設計
//		作成者：三上直樹，2011/05/27 作成，©三上直樹 2011
//------------------------------------------------------------------------------

using System;
using System.Numerics;
using System.Windows.Forms;
using hibari151201;

namespace MK_Library
{
	public class WindowingDesign
	{
		public enum Type { LPF, HPF, BPF, BRF };	// 通過域の区別用
		private float[] hk_;	// 設計されたフィルタの係数，order/2 ～ 0
		private double	fS_;	// 標本化周波数
		private double	fC_;	// 遮断周波数
		private double	w0_;	// BPF, BRF で使用
		private int order_; 	// 伝達関数の次数


		// 設計パラメータを与え，係数を計算する
		public bool Design(int order, Type pb, double fs,
						   double fc1, double fc2 = 0.0)
		{

            Console.WriteLine("Design通過");
            
            if ((order % 2) != 0)
				return ErrorMessage("次数を偶数にしてください．");
			order_ = order; 	// 次数（偶数のみ）
			fS_ = fs;			// 標本化周波数
			w0_ = Math.PI*(fc1 + fc2)/fs;

			if ( (fc1 < 0) || (fc1> fS_/2) || (fc2 < 0) || (fc2> fS_/2) )
				return ErrorMessage("遮断周波数が不適切です．");
			// 遮断周波数の設定
			if (pb == Type.LPF) fC_ = fc1;
			if (pb == Type.HPF) fC_ = 0.5*fs - fc1;
			if (pb == Type.BPF) fC_ = 0.5*Math.Abs(fc2 - fc1);
			if (pb == Type.BRF) fC_ = 0.5*Math.Abs(fc2 - fc1);

			hk_ = new float[order_/2+1];
			LpfCoefficients();		// LPF の係数の計算
			// LPF 以外の場合，係数を変換
			if (pb != Type.LPF) Transform(pb);
			return true;
		}

		// 周波数応答を計算するための伝達関数の定義
		public Complex? GetResponse(Complex u)
		{
			if (hk_ == null)
			{
				MessageBox.Show("フィルタの設計が済んでいません．");
				return null;
			}
			Complex hz = hk_[order_/2];
			for (int n=order_/2-1; n>0; n--) hz = hz*u + hk_[n];
			return 2.0*((hz*u).Real) +	hk_[0];
		}

		// プロパティ：設計された係数
		public float[] Coefficients { get { return hk_; } }

		// LPF の係数を計算
		private void LpfCoefficients()
		{
			double w = 2.0*Math.PI*fC_/fS_;
			hk_[0] = (float)(2.0*fC_/fS_);
			for (int k=1; k<=order_/2; k++)
				hk_[k] = (float)((Math.Sin(k*w)/(Math.PI*k))*HammingWindow(k));
		}

		// LPF 以外の場合：係数の変換
		private void Transform(Type pb)
		{
			if (pb == Type.HPF) 	// HPF の係数に変換
				for (int k=1; k<=order_/2; k+=2) hk_[k] = -hk_[k];

			if (pb == Type.BPF) 	// BPF の係数に変換
				for (int k=0; k<=order_/2; k++)
					hk_[k] = (float)(2.0*Math.Cos(w0_*k)*hk_[k]);

			if (pb == Type.BRF) 	// BRF の係数に変換
			{
				hk_[0] = (float)(1.0 - 2.0*hk_[0]);
				for (int k=1; k<=order_/2; k++)
					hk_[k] = (float)(-2.0*Math.Cos(w0_*k)*hk_[k]);
			}
		}

		// Hamming窓
		private double HammingWindow(int k)
		{
			return 0.54 + 0.46*Math.Cos(2.0*Math.PI*k/(double)(order_ + 1));
		}

		// エラーメッセージ
		private bool ErrorMessage(string message)
		{
			MessageBox.Show(message, "入力エラー!");
			return false;
		}
	}
}
