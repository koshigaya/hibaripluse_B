using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace hibari151201
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private bool viewerFlag = false;


        private void btnViewer_Click(object sender, EventArgs e)
        {
              
            openFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog1.Filter = "BMP形式(*.Bmp)|*.Bmp|すべてのファイル(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(filename);
            }
            
            viewerFlag = true;
        
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (viewerFlag)
            {
                printDocument1.Print();
            }
            else
            {
                MessageBox.Show("画像データを開いてください");
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(pictureBox1.Image,e.MarginBounds.Left,e.MarginBounds.Top,650,380);
        }
    }
}