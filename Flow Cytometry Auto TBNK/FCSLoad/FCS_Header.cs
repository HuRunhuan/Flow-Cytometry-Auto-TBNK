/**
 * 模块名称：FCS Header(文件头)
 * 功能描述：主要负责对FCS文件的Header（头部）信息进行读取
 * */
using System;
using System.IO;//文件读写的名字空间

namespace FCS_Load
{
    public class FCS_Header
    {
        public String m_FcsType;//FCS文件版本
        public int m_TextStart;//Text起始位置
        public int m_TextEnd;//Text结束位置   
        public int m_DataStart;//Data起始位置
        public int m_DataEnd;//Data结束位置

        #region 读取FCS Header（文件头）
        public bool GetHeader(BinaryReader br)
        {
            #region 读取文件头
            Byte[] bytes = new Byte[64];
            for (int i = 0; i < 64; i++)//读取文件的头64个字节即为FCS Header
            {
                bytes[i] = br.ReadByte();
            }
            String headInfo = System.Text.Encoding.Default.GetString(bytes);//将文件头转存到一个String中
            #endregion
            #region 解析文件头
            String tempStr = null;
            tempStr = headInfo.Substring(0, 6);
            //第一部分——FCS文件版本
            if (tempStr.LastIndexOf("FCS") == -1 && tempStr.LastIndexOf("fcs") == -1)
            {
                return false;//非FCS文件
            }
            this.m_FcsType = tempStr;
            this.m_TextStart = Convert.ToInt32(headInfo.Substring(10, 8));//第二部分：Text起始位置
            this.m_TextEnd = Convert.ToInt32(headInfo.Substring(18, 8));//第三部分：Text结束位置
            this.m_DataStart = Convert.ToInt32(headInfo.Substring(26, 8));//第四部分：Data起始位置
            this.m_DataEnd = Convert.ToInt32(headInfo.Substring(34, 8));//第五部分：Data结束位置
            #endregion
            return true;
        }
        #endregion
    }
}
