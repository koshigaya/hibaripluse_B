namespace hibari151201
{
    partial class Form1
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
            this.btnThree = new System.Windows.Forms.Button();
            this.btnMeasure = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnViewer = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lalExplain = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnThree
            // 
            this.btnThree.Location = new System.Drawing.Point(119, 18);
            this.btnThree.Name = "btnThree";
            this.btnThree.Size = new System.Drawing.Size(75, 23);
            this.btnThree.TabIndex = 0;
            this.btnThree.Text = "3波形表示";
            this.btnThree.UseVisualStyleBackColor = true;
            this.btnThree.UseWaitCursor = true;
            this.btnThree.Click += new System.EventHandler(this.btnThree_Click);
            // 
            // btnMeasure
            // 
            this.btnMeasure.Location = new System.Drawing.Point(6, 18);
            this.btnMeasure.Name = "btnMeasure";
            this.btnMeasure.Size = new System.Drawing.Size(75, 23);
            this.btnMeasure.TabIndex = 1;
            this.btnMeasure.Text = "測定画面";
            this.btnMeasure.UseVisualStyleBackColor = true;
            this.btnMeasure.Click += new System.EventHandler(this.btnMeasure_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(119, 62);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(75, 23);
            this.btnEnd.TabIndex = 2;
            this.btnEnd.Text = "終了";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnViewer
            // 
            this.btnViewer.Location = new System.Drawing.Point(6, 62);
            this.btnViewer.Name = "btnViewer";
            this.btnViewer.Size = new System.Drawing.Size(75, 23);
            this.btnViewer.TabIndex = 3;
            this.btnViewer.Text = "ビューワ";
            this.btnViewer.UseVisualStyleBackColor = true;
            this.btnViewer.Click += new System.EventHandler(this.btnViewer_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(43, 66);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 19);
            this.txtName.TabIndex = 4;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnThree);
            this.groupBox1.Controls.Add(this.btnEnd);
            this.groupBox1.Controls.Add(this.btnMeasure);
            this.groupBox1.Controls.Add(this.btnViewer);
            this.groupBox1.Location = new System.Drawing.Point(37, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "歳";
            // 
            // lalExplain
            // 
            this.lalExplain.AutoSize = true;
            this.lalExplain.Font = new System.Drawing.Font("ＭＳ 明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lalExplain.Location = new System.Drawing.Point(42, 20);
            this.lalExplain.Name = "lalExplain";
            this.lalExplain.Size = new System.Drawing.Size(195, 32);
            this.lalExplain.TabIndex = 7;
            this.lalExplain.Text = "\r\n年齢を入力してください\r\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 227);
            this.Controls.Add(this.lalExplain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtName);
            this.Name = "Form1";
            this.Text = "ひばりパルス";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThree;
        private System.Windows.Forms.Button btnMeasure;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnViewer;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lalExplain;
    }
}

