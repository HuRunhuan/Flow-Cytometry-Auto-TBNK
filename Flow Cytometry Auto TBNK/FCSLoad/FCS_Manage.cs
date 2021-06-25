using FCS_Load;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace FCSM
{
    public class FCSManage
    {

        //以下变量均来自FCS_File，可自行查看
        private String m_fileName = null;   //FCS文件名
        private FCS_Header Header = null;    //FCS Header（文件头）
        private FCS_Text Text = null;    //FCS Text（文本部分）
        public FCS_Data Data = null;    //FCS Data（数据部分）
        bool m_isFCSType = false;   //标记文件是否FCS文件
                                    // List<string> ParametersNamesList = null;
        /// <summary>
        /// 根据文件名获取值
        /// </summary>
        /// <param name="filePath">文件名</param>

        /// <returns>
        /// 执行状态
        /// 0——执行成功
        /// 1——执行失败，失败原因：文件打开失败
        /// 2——执行失败，失败原因：选择的不是FCS文件
        /// 3——执行失败，失败原因：读取Text部分失败
        /// 4——执行失败，失败原因：读取Data部分失败
        /// </returns>

        public int Get_FCS_Info(String filePath, ref List<string> ParametersNamesList, ref FCS_Data Data, ref int totalnum)
        {

            FileStream fsr = null;  //文件流
            BinaryReader br = null; //字节读取器
            #region 打开FCS文件
            try
            {
                String path = filePath; //获取文件名
                fsr = new FileStream(path, FileMode.Open, FileAccess.Read);//根据文件名构建文件流
                br = new BinaryReader(fsr, Encoding.Unicode);//根据文件流构建字节读取器
            }
            catch (Exception e)//打开异常
            {
                Console.WriteLine(e.ToString());
                return 1;//返回状态信息（打开文件失败）
            }
            #endregion

            #region 读取Header
            Header = new FCS_Header();//构建FCS_Header类
            if (!Header.GetHeader(br))//读取文件头并判断是否为FCS文件
            {
                m_isFCSType = false;
                return 2;//返回状态信息（文件非FCS文件）
            }
            else
            {
                m_isFCSType = true;
            }
            #endregion

            #region 读取Text
            Text = new FCS_Text();//构建FCS_Text类
            if (!Text.GetText(br, Header.m_TextStart, Header.m_TextEnd, Text.m_OS))//读取FCS文件的Text
            {
                return 3;//返回状态信息（读取FCS文件的Text失败）
            }

            #endregion

            #region 读取Data
            Data = new FCS_Data();//构建FCS_Data类
            if (!Data.GetData(br, Header.m_DataStart, Header.m_DataEnd, Text.m_ParametersNumber, Text.m_TotalEvents, Text.m_BitNum, Text.m_DataType, Text.m_BytpOrd, Text.m_OS))//读取FCS文件的Data
            {
                return 4;//返回状态信息（读取FCS文件的Data失败）
            }
            #endregion
            ParametersNamesList = this.Text.ParametersNamesList;
            totalnum = Text.m_TotalEvents;
            br.Dispose();
            fsr.Dispose();
            return 0;
        }


    }
}

