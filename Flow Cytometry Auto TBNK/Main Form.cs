using Calculate;
using FCSM;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Flow_Cytometry_Auto_TBNK
{

    public partial class Main : Form
    {
        #region 成员变量
        String FCSPath = "";//FCS文件全名（包括路径）
        FCSManage FCSM = new FCSManage();//实例化FCSManage类对象
        AutoCalTBNK CalM = new AutoCalTBNK();//实例化FCSManage类对象
        public FCS_Load.FCS_Data Data = null;    //FCS Data（数据部分）
        List<string> ParametersNamesList = new List<string>();
        string Parameter = null;

        public string T_result;                 //T cell总数
        public string CD4_T_result;             //CD4 T cell总数
        public string CD8_T_result;             //CD8 T cell总数
        public string B_result;                 //B cell总数
        public string NK_result;                //NK cell总数
        List<int> PN = new List<int>();
        int totalnum;

        #endregion
        public Main()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {

        }

        private void Read_FCS_Head_Click(object sender, EventArgs e)
        {
            FCSM.Get_FCS_Info(this.FCSPath, ref ParametersNamesList, ref Data, ref totalnum);//读取FCS
            ParametersBoxFSC.Items.Clear();
            ParametersBoxSSC.Items.Clear();
            ParametersBoxFL1.Items.Clear();
            ParametersBoxFL2.Items.Clear();
            ParametersBoxFL3.Items.Clear();
            ParametersBoxFL4.Items.Clear();
            ParametersBoxFL5.Items.Clear();
            ParametersBoxFL6.Items.Clear();
            for (int i = 0; i < ParametersNamesList.Count; i++)
            {
                ParametersBoxFSC.Items.Add(ParametersNamesList[i]);
                ParametersBoxSSC.Items.Add(ParametersNamesList[i]);
                ParametersBoxFL1.Items.Add(ParametersNamesList[i]);
                ParametersBoxFL2.Items.Add(ParametersNamesList[i]);
                ParametersBoxFL3.Items.Add(ParametersNamesList[i]);
                ParametersBoxFL4.Items.Add(ParametersNamesList[i]);
                ParametersBoxFL5.Items.Add(ParametersNamesList[i]);
                ParametersBoxFL6.Items.Add(ParametersNamesList[i]);
            }
        }

        private void Calculation_Click(object sender, EventArgs e)
        {

            PN.Clear();
            PN.Add(ParametersNamesList.IndexOf(ParametersBoxFSC.Text));
            PN.Add(ParametersNamesList.IndexOf(ParametersBoxSSC.Text));
            PN.Add(ParametersNamesList.IndexOf(ParametersBoxFL1.Text));
            PN.Add(ParametersNamesList.IndexOf(ParametersBoxFL2.Text));
            PN.Add(ParametersNamesList.IndexOf(ParametersBoxFL3.Text));
            PN.Add(ParametersNamesList.IndexOf(ParametersBoxFL4.Text));
            PN.Add(ParametersNamesList.IndexOf(ParametersBoxFL5.Text));
            PN.Add(ParametersNamesList.IndexOf(ParametersBoxFL6.Text));

            CalM.CalTBNK(totalnum, PN, Data.m_data, ref T_result, ref CD4_T_result, ref CD8_T_result, ref B_result, ref NK_result);
            T_Box.Text = T_result;
            CD4_T_Box.Text = CD4_T_result;
            CD8_T_Box.Text = CD8_T_result;
            B_Box.Text = B_result;
            NK_Box.Text = NK_result;

        }

        private void btn_Add_FCS_Click(object sender, EventArgs e)
        {
            #region 写入文件名
            /************根据情况修改**************/
            openFileDialog_FCS.RestoreDirectory = true;//设置存储目录为true
            if (openFileDialog_FCS.ShowDialog() == DialogResult.OK)//显示打开文件对话框
            {
                this.FCSPath = openFileDialog_FCS.FileName;//获取FCS文件全名（包括路径）
            }
            this.txt_FCS.Text = this.FCSPath;//在文本框中显示FCS文件全名（包括路径）

            #endregion
        }
    }
}
