using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace hibari151201
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool ageInputFlag = false;
        public int ageInputData = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            //スプラッシュ処理
            frmSplash splash1 = new frmSplash();
            splash1.Show();
            splash1.Refresh();
            Thread.Sleep(1200);　//必要に応じてスプラッシュ時間を調整する
            splash1.Close();
            splash1.Dispose();
            this.Activate();
        }


        private void btnThree_Click(object sender, EventArgs e)
        {
            Form2 fm = new Form2();
            fm.ShowDialog();
        }

        private void btnMeasure_Click(object sender, EventArgs e)
        {
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");
            if (txtName.Text == "")
            {
                ageInputFlag = false;
                Form3 fm = new Form3();
                fm.Form1_Dummy = this;
                fm.ShowDialog();
            }
            else if (r.IsMatch(txtName.Text))
            {
                ageInputFlag = true;
                ageInputData = int.Parse(txtName.Text);
                Form3 fm = new Form3();
                fm.Form1_Dummy = this;
                fm.ShowDialog();

            }
            else
            {
                MessageBox.Show("年齢は半角数字で入力してください");
            }
            
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnViewer_Click(object sender, EventArgs e)
        {
            Form4 fm = new Form4();
            fm.ShowDialog();

        }

       
    }
}