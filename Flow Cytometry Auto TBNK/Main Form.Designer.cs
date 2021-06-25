
namespace Flow_Cytometry_Auto_TBNK
{
    partial class Main
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Read_FCS_Head = new System.Windows.Forms.Button();
            this.Calculation = new System.Windows.Forms.Button();
            this.FSC = new System.Windows.Forms.Label();
            this.SSC = new System.Windows.Forms.Label();
            this.FL1 = new System.Windows.Forms.Label();
            this.FL2 = new System.Windows.Forms.Label();
            this.FL3 = new System.Windows.Forms.Label();
            this.FL4 = new System.Windows.Forms.Label();
            this.FL5 = new System.Windows.Forms.Label();
            this.FL6 = new System.Windows.Forms.Label();
            this.Channle_Name = new System.Windows.Forms.Label();
            this.ParametersBoxFL1 = new System.Windows.Forms.ComboBox();
            this.ParametersBoxFL2 = new System.Windows.Forms.ComboBox();
            this.ParametersBoxFL3 = new System.Windows.Forms.ComboBox();
            this.ParametersBoxFL4 = new System.Windows.Forms.ComboBox();
            this.ParametersBoxFL5 = new System.Windows.Forms.ComboBox();
            this.ParametersBoxFL6 = new System.Windows.Forms.ComboBox();
            this.ParametersBoxFSC = new System.Windows.Forms.ComboBox();
            this.ParametersBoxSSC = new System.Windows.Forms.ComboBox();
            this.T = new System.Windows.Forms.Label();
            this.B = new System.Windows.Forms.Label();
            this.NK = new System.Windows.Forms.Label();
            this.CD4_T = new System.Windows.Forms.Label();
            this.CD8_T = new System.Windows.Forms.Label();
            this.T_Box = new System.Windows.Forms.TextBox();
            this.CD4_T_Box = new System.Windows.Forms.TextBox();
            this.CD8_T_Box = new System.Windows.Forms.TextBox();
            this.B_Box = new System.Windows.Forms.TextBox();
            this.NK_Box = new System.Windows.Forms.TextBox();
            this.ratio = new System.Windows.Forms.Label();
            this.count = new System.Windows.Forms.Label();
            this.btn_Add_FCS = new System.Windows.Forms.Button();
            this.openFileDialog_FCS = new System.Windows.Forms.OpenFileDialog();
            this.txt_FCS = new System.Windows.Forms.TextBox();
            this.TestFCS = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Read_FCS_Head
            // 
            this.Read_FCS_Head.Location = new System.Drawing.Point(253, 378);
            this.Read_FCS_Head.Name = "Read_FCS_Head";
            this.Read_FCS_Head.Size = new System.Drawing.Size(160, 60);
            this.Read_FCS_Head.TabIndex = 0;
            this.Read_FCS_Head.Text = "Read FCS";
            this.Read_FCS_Head.UseVisualStyleBackColor = true;
            this.Read_FCS_Head.Click += new System.EventHandler(this.Read_FCS_Head_Click);
            // 
            // Calculation
            // 
            this.Calculation.Location = new System.Drawing.Point(501, 378);
            this.Calculation.Name = "Calculation";
            this.Calculation.Size = new System.Drawing.Size(160, 60);
            this.Calculation.TabIndex = 1;
            this.Calculation.Text = "Calculation";
            this.Calculation.UseVisualStyleBackColor = true;
            this.Calculation.Click += new System.EventHandler(this.Calculation_Click);
            // 
            // FSC
            // 
            this.FSC.AutoSize = true;
            this.FSC.Location = new System.Drawing.Point(55, 92);
            this.FSC.Name = "FSC";
            this.FSC.Size = new System.Drawing.Size(23, 12);
            this.FSC.TabIndex = 2;
            this.FSC.Text = "FSC";
            // 
            // SSC
            // 
            this.SSC.AutoSize = true;
            this.SSC.Location = new System.Drawing.Point(55, 127);
            this.SSC.Name = "SSC";
            this.SSC.Size = new System.Drawing.Size(23, 12);
            this.SSC.TabIndex = 3;
            this.SSC.Text = "SSC";
            // 
            // FL1
            // 
            this.FL1.AutoSize = true;
            this.FL1.Location = new System.Drawing.Point(55, 162);
            this.FL1.Name = "FL1";
            this.FL1.Size = new System.Drawing.Size(29, 12);
            this.FL1.TabIndex = 4;
            this.FL1.Text = "CD45";
            // 
            // FL2
            // 
            this.FL2.AutoSize = true;
            this.FL2.Location = new System.Drawing.Point(55, 197);
            this.FL2.Name = "FL2";
            this.FL2.Size = new System.Drawing.Size(23, 12);
            this.FL2.TabIndex = 5;
            this.FL2.Text = "CD3";
            // 
            // FL3
            // 
            this.FL3.AutoSize = true;
            this.FL3.Location = new System.Drawing.Point(55, 232);
            this.FL3.Name = "FL3";
            this.FL3.Size = new System.Drawing.Size(23, 12);
            this.FL3.TabIndex = 6;
            this.FL3.Text = "CD4";
            // 
            // FL4
            // 
            this.FL4.AutoSize = true;
            this.FL4.Location = new System.Drawing.Point(55, 267);
            this.FL4.Name = "FL4";
            this.FL4.Size = new System.Drawing.Size(23, 12);
            this.FL4.TabIndex = 7;
            this.FL4.Text = "CD8";
            // 
            // FL5
            // 
            this.FL5.AutoSize = true;
            this.FL5.Location = new System.Drawing.Point(55, 302);
            this.FL5.Name = "FL5";
            this.FL5.Size = new System.Drawing.Size(29, 12);
            this.FL5.TabIndex = 8;
            this.FL5.Text = "CD19";
            // 
            // FL6
            // 
            this.FL6.AutoSize = true;
            this.FL6.Location = new System.Drawing.Point(55, 337);
            this.FL6.Name = "FL6";
            this.FL6.Size = new System.Drawing.Size(47, 12);
            this.FL6.TabIndex = 9;
            this.FL6.Text = "CD16+56";
            // 
            // Channle_Name
            // 
            this.Channle_Name.AutoSize = true;
            this.Channle_Name.Location = new System.Drawing.Point(44, 60);
            this.Channle_Name.Name = "Channle_Name";
            this.Channle_Name.Size = new System.Drawing.Size(47, 12);
            this.Channle_Name.TabIndex = 10;
            this.Channle_Name.Text = "Channle";
            // 
            // ParametersBoxFL1
            // 
            this.ParametersBoxFL1.FormattingEnabled = true;
            this.ParametersBoxFL1.Location = new System.Drawing.Point(187, 154);
            this.ParametersBoxFL1.Name = "ParametersBoxFL1";
            this.ParametersBoxFL1.Size = new System.Drawing.Size(245, 20);
            this.ParametersBoxFL1.TabIndex = 17;
            // 
            // ParametersBoxFL2
            // 
            this.ParametersBoxFL2.FormattingEnabled = true;
            this.ParametersBoxFL2.Location = new System.Drawing.Point(187, 193);
            this.ParametersBoxFL2.Name = "ParametersBoxFL2";
            this.ParametersBoxFL2.Size = new System.Drawing.Size(245, 20);
            this.ParametersBoxFL2.TabIndex = 18;
            // 
            // ParametersBoxFL3
            // 
            this.ParametersBoxFL3.FormattingEnabled = true;
            this.ParametersBoxFL3.Location = new System.Drawing.Point(187, 228);
            this.ParametersBoxFL3.Name = "ParametersBoxFL3";
            this.ParametersBoxFL3.Size = new System.Drawing.Size(245, 20);
            this.ParametersBoxFL3.TabIndex = 19;
            // 
            // ParametersBoxFL4
            // 
            this.ParametersBoxFL4.FormattingEnabled = true;
            this.ParametersBoxFL4.Location = new System.Drawing.Point(187, 263);
            this.ParametersBoxFL4.Name = "ParametersBoxFL4";
            this.ParametersBoxFL4.Size = new System.Drawing.Size(245, 20);
            this.ParametersBoxFL4.TabIndex = 20;
            // 
            // ParametersBoxFL5
            // 
            this.ParametersBoxFL5.FormattingEnabled = true;
            this.ParametersBoxFL5.Location = new System.Drawing.Point(187, 294);
            this.ParametersBoxFL5.Name = "ParametersBoxFL5";
            this.ParametersBoxFL5.Size = new System.Drawing.Size(245, 20);
            this.ParametersBoxFL5.TabIndex = 21;
            // 
            // ParametersBoxFL6
            // 
            this.ParametersBoxFL6.FormattingEnabled = true;
            this.ParametersBoxFL6.Location = new System.Drawing.Point(187, 329);
            this.ParametersBoxFL6.Name = "ParametersBoxFL6";
            this.ParametersBoxFL6.Size = new System.Drawing.Size(245, 20);
            this.ParametersBoxFL6.TabIndex = 22;
            // 
            // ParametersBoxFSC
            // 
            this.ParametersBoxFSC.FormattingEnabled = true;
            this.ParametersBoxFSC.Location = new System.Drawing.Point(187, 92);
            this.ParametersBoxFSC.Name = "ParametersBoxFSC";
            this.ParametersBoxFSC.Size = new System.Drawing.Size(245, 20);
            this.ParametersBoxFSC.TabIndex = 23;
            // 
            // ParametersBoxSSC
            // 
            this.ParametersBoxSSC.FormattingEnabled = true;
            this.ParametersBoxSSC.Location = new System.Drawing.Point(187, 124);
            this.ParametersBoxSSC.Name = "ParametersBoxSSC";
            this.ParametersBoxSSC.Size = new System.Drawing.Size(245, 20);
            this.ParametersBoxSSC.TabIndex = 24;
            // 
            // T
            // 
            this.T.AutoSize = true;
            this.T.Location = new System.Drawing.Point(499, 132);
            this.T.Name = "T";
            this.T.Size = new System.Drawing.Size(11, 12);
            this.T.TabIndex = 25;
            this.T.Text = "T";
            // 
            // B
            // 
            this.B.AutoSize = true;
            this.B.Location = new System.Drawing.Point(499, 262);
            this.B.Name = "B";
            this.B.Size = new System.Drawing.Size(11, 12);
            this.B.TabIndex = 26;
            this.B.Text = "B";
            // 
            // NK
            // 
            this.NK.AutoSize = true;
            this.NK.Location = new System.Drawing.Point(499, 302);
            this.NK.Name = "NK";
            this.NK.Size = new System.Drawing.Size(17, 12);
            this.NK.TabIndex = 27;
            this.NK.Text = "NK";
            // 
            // CD4_T
            // 
            this.CD4_T.AutoSize = true;
            this.CD4_T.Location = new System.Drawing.Point(499, 179);
            this.CD4_T.Name = "CD4_T";
            this.CD4_T.Size = new System.Drawing.Size(35, 12);
            this.CD4_T.TabIndex = 28;
            this.CD4_T.Text = "CD4 T";
            // 
            // CD8_T
            // 
            this.CD8_T.AutoSize = true;
            this.CD8_T.Location = new System.Drawing.Point(499, 225);
            this.CD8_T.Name = "CD8_T";
            this.CD8_T.Size = new System.Drawing.Size(35, 12);
            this.CD8_T.TabIndex = 29;
            this.CD8_T.Text = "CD8 T";
            // 
            // T_Box
            // 
            this.T_Box.Location = new System.Drawing.Point(545, 129);
            this.T_Box.Name = "T_Box";
            this.T_Box.Size = new System.Drawing.Size(208, 21);
            this.T_Box.TabIndex = 30;
            // 
            // CD4_T_Box
            // 
            this.CD4_T_Box.Location = new System.Drawing.Point(545, 176);
            this.CD4_T_Box.Name = "CD4_T_Box";
            this.CD4_T_Box.Size = new System.Drawing.Size(208, 21);
            this.CD4_T_Box.TabIndex = 31;
            // 
            // CD8_T_Box
            // 
            this.CD8_T_Box.Location = new System.Drawing.Point(545, 223);
            this.CD8_T_Box.Name = "CD8_T_Box";
            this.CD8_T_Box.Size = new System.Drawing.Size(208, 21);
            this.CD8_T_Box.TabIndex = 32;
            // 
            // B_Box
            // 
            this.B_Box.Location = new System.Drawing.Point(545, 258);
            this.B_Box.Name = "B_Box";
            this.B_Box.Size = new System.Drawing.Size(208, 21);
            this.B_Box.TabIndex = 33;
            // 
            // NK_Box
            // 
            this.NK_Box.Location = new System.Drawing.Point(545, 302);
            this.NK_Box.Name = "NK_Box";
            this.NK_Box.Size = new System.Drawing.Size(208, 21);
            this.NK_Box.TabIndex = 34;
            // 
            // ratio
            // 
            this.ratio.AutoSize = true;
            this.ratio.Location = new System.Drawing.Point(570, 100);
            this.ratio.Name = "ratio";
            this.ratio.Size = new System.Drawing.Size(29, 12);
            this.ratio.TabIndex = 35;
            this.ratio.Text = "比例";
            // 
            // count
            // 
            this.count.AutoSize = true;
            this.count.Location = new System.Drawing.Point(669, 100);
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(29, 12);
            this.count.TabIndex = 36;
            this.count.Text = "数量";
            // 
            // btn_Add_FCS
            // 
            this.btn_Add_FCS.Location = new System.Drawing.Point(662, 23);
            this.btn_Add_FCS.Name = "btn_Add_FCS";
            this.btn_Add_FCS.Size = new System.Drawing.Size(84, 21);
            this.btn_Add_FCS.TabIndex = 39;
            this.btn_Add_FCS.Text = "选择文件";
            this.btn_Add_FCS.UseVisualStyleBackColor = true;
            this.btn_Add_FCS.Click += new System.EventHandler(this.btn_Add_FCS_Click);
            // 
            // txt_FCS
            // 
            this.txt_FCS.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_FCS.Location = new System.Drawing.Point(145, 23);
            this.txt_FCS.Name = "txt_FCS";
            this.txt_FCS.ReadOnly = true;
            this.txt_FCS.Size = new System.Drawing.Size(500, 21);
            this.txt_FCS.TabIndex = 37;
            // 
            // TestFCS
            // 
            this.TestFCS.AutoSize = true;
            this.TestFCS.ForeColor = System.Drawing.Color.Red;
            this.TestFCS.Location = new System.Drawing.Point(44, 26);
            this.TestFCS.Name = "TestFCS";
            this.TestFCS.Size = new System.Drawing.Size(47, 12);
            this.TestFCS.TabIndex = 38;
            this.TestFCS.Text = "FCS文件";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Add_FCS);
            this.Controls.Add(this.txt_FCS);
            this.Controls.Add(this.TestFCS);
            this.Controls.Add(this.count);
            this.Controls.Add(this.ratio);
            this.Controls.Add(this.NK_Box);
            this.Controls.Add(this.B_Box);
            this.Controls.Add(this.CD8_T_Box);
            this.Controls.Add(this.CD4_T_Box);
            this.Controls.Add(this.T_Box);
            this.Controls.Add(this.CD8_T);
            this.Controls.Add(this.CD4_T);
            this.Controls.Add(this.NK);
            this.Controls.Add(this.B);
            this.Controls.Add(this.T);
            this.Controls.Add(this.ParametersBoxSSC);
            this.Controls.Add(this.ParametersBoxFSC);
            this.Controls.Add(this.ParametersBoxFL6);
            this.Controls.Add(this.ParametersBoxFL5);
            this.Controls.Add(this.ParametersBoxFL4);
            this.Controls.Add(this.ParametersBoxFL3);
            this.Controls.Add(this.ParametersBoxFL2);
            this.Controls.Add(this.ParametersBoxFL1);
            this.Controls.Add(this.Channle_Name);
            this.Controls.Add(this.FL6);
            this.Controls.Add(this.FL5);
            this.Controls.Add(this.FL4);
            this.Controls.Add(this.FL3);
            this.Controls.Add(this.FL2);
            this.Controls.Add(this.FL1);
            this.Controls.Add(this.SSC);
            this.Controls.Add(this.FSC);
            this.Controls.Add(this.Calculation);
            this.Controls.Add(this.Read_FCS_Head);
            this.Name = "Main";
            this.Text = "AUTO_TBNK BY HRH";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Read_FCS_Head;
        private System.Windows.Forms.Button Calculation;
        private System.Windows.Forms.Label FSC;
        private System.Windows.Forms.Label SSC;
        private System.Windows.Forms.Label FL1;
        private System.Windows.Forms.Label FL2;
        private System.Windows.Forms.Label FL3;
        private System.Windows.Forms.Label FL4;
        private System.Windows.Forms.Label FL5;
        private System.Windows.Forms.Label FL6;
        private System.Windows.Forms.Label Channle_Name;
        private System.Windows.Forms.ComboBox ParametersBoxFL1;
        private System.Windows.Forms.ComboBox ParametersBoxFL2;
        private System.Windows.Forms.ComboBox ParametersBoxFL3;
        private System.Windows.Forms.ComboBox ParametersBoxFL4;
        private System.Windows.Forms.ComboBox ParametersBoxFL5;
        private System.Windows.Forms.ComboBox ParametersBoxFL6;
        private System.Windows.Forms.ComboBox ParametersBoxFSC;
        private System.Windows.Forms.ComboBox ParametersBoxSSC;
        private System.Windows.Forms.Label T;
        private System.Windows.Forms.Label B;
        private System.Windows.Forms.Label NK;
        private System.Windows.Forms.Label CD4_T;
        private System.Windows.Forms.Label CD8_T;
        private System.Windows.Forms.TextBox T_Box;
        private System.Windows.Forms.TextBox CD4_T_Box;
        private System.Windows.Forms.TextBox CD8_T_Box;
        private System.Windows.Forms.TextBox B_Box;
        private System.Windows.Forms.TextBox NK_Box;
        private System.Windows.Forms.Label ratio;
        private System.Windows.Forms.Label count;
        private System.Windows.Forms.Button btn_Add_FCS;
        private System.Windows.Forms.OpenFileDialog openFileDialog_FCS;
        private System.Windows.Forms.TextBox txt_FCS;
        private System.Windows.Forms.Label TestFCS;
    }
}

