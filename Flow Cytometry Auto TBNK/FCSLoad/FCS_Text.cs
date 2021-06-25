/**
 * 模块名称：FCS Text（文本部分）
 * 功能描述：主要负责对FCS文件的Text（文本部分）进行读取
 * */

using System;
using System.Collections.Generic;
using System.IO;


namespace FCS_Load
{
    public class FCS_Text
    {
        String textInfo;                    //字符串
        private char m_Delimiter;           //分隔符(字符)      
        public int m_BitNum;                //表示数据的比特数
        public string m_DataType;              //数据类型(0, 1分别表示整型和浮点型）
        public string m_OS;                   //机器所使用的操作系统（有Windows和DOS）
        public string m_BytpOrd;            //字节顺序
        public int m_TotalEvents;          //每个参数的数据数目
        public int m_ParametersNumber;     //参数数量
        String tempStr;                    //变量
        public List<string> ParametersNamesList = new List<string>();

        #region  根据关键字和分隔符读取相应的值(分隔符为字符)
        public String GetKeywordValue(String txt, String key, char delimiter)
        {
            int keyPos = 0;
            if (txt.IndexOf(key, StringComparison.OrdinalIgnoreCase) < 0)
            {
                keyPos = txt.IndexOf("$DATATYPE");
            }
            else
            {
                keyPos = txt.IndexOf(key);//获取关键字的位置
            }

            int firstDeliPos = txt.IndexOf(delimiter, keyPos);//获取关键字后面的第一个分隔符的位置
            int secondDeliPos = txt.IndexOf(delimiter, firstDeliPos + 1);//获取关键字后面的第二个分隔符的位置
            string resultString = txt.Substring(firstDeliPos + 1, secondDeliPos - firstDeliPos - 1);//读取两个分隔符之间的文本即为关键字对应的值
            return resultString;
        }
        #endregion
        #region 文件头读取  读取FCS Text（文本部分）    
        public bool GetText(BinaryReader br, long startPos, long endPos, string OS_Type)
        {
            Byte[] bytes = new Byte[endPos - startPos + 1];
            br.BaseStream.Seek(startPos, SeekOrigin.Begin);//将文件指针指向Text起始位置
            for (int i = 0; i < endPos - startPos + 1; i++)//将Text部分全部读入到内存
            {
                bytes[i] = br.ReadByte();
            }
            textInfo = System.Text.Encoding.Default.GetString(bytes);//将内存中的Text部分转存到String中
            m_Delimiter = textInfo[0];  //读取分隔符
            if (m_Delimiter == '!')
            { m_OS = "DOS"; }
            else
            { m_OS = "WIN"; }

            #region 读取必须字段，所有仪器必有。PnR的值在下循环中，总计16项，不含已经停用部分
            tempStr = GetKeywordValue(textInfo, "$TOT", m_Delimiter);//读取关键字TOT的值——每个参数对应的数据数量
            m_TotalEvents = Convert.ToInt32(tempStr);
            tempStr = GetKeywordValue(textInfo, "$PAR", m_Delimiter);//读取关键字PAR的值——参数的数量
            m_ParametersNumber = Convert.ToInt32(tempStr);
            tempStr = GetKeywordValue(textInfo, "$P1B", m_Delimiter);//读取关键字PnB的值——数据位数
            m_BitNum = Convert.ToInt32(tempStr);
            tempStr = GetKeywordValue(textInfo, "$DATATYPE", m_Delimiter);//读取关键字$DATATYPE的值——数据格式，ASCII 整型，浮点型
            m_DataType = tempStr;
            tempStr = GetKeywordValue(textInfo, "$BYTEORD", m_Delimiter);//读取关键字$BYTEORD的值——数据字节顺序，4个2进制字节组成32位字节，
            m_BytpOrd = tempStr;

            tempStr = GetKeywordValue(textInfo, "$BEGINSTEXT", m_Delimiter);//读取关键字BEGINSTEXT的值——文本起始
            tempStr = GetKeywordValue(textInfo, "$ENDSTEXT", m_Delimiter);//读取关键字$ENDSTEXT的值——文本结束
            tempStr = GetKeywordValue(textInfo, "$BEGINDATA", m_Delimiter);//读取关键字$BEGINDATA的值——数据起始
            tempStr = GetKeywordValue(textInfo, "$ENDDATA", m_Delimiter);//读取关键字$ENDDATA的值——数据结束
            tempStr = GetKeywordValue(textInfo, "$BEGINANALYSIS", m_Delimiter);//读取关键字$BEGINANALYSIS的值——分析起始
            tempStr = GetKeywordValue(textInfo, "$ENDANALYSIS", m_Delimiter);//读取关键字$ENDANALYSIS的值——分析结束
            tempStr = GetKeywordValue(textInfo, "$MODE", m_Delimiter);//读取关键字$MODE的值——存储格式
            tempStr = GetKeywordValue(textInfo, "$NEXTDATA", m_Delimiter);//读取关键字$NEXTDATA的值——数组间字节偏移量
            tempStr = GetKeywordValue(textInfo, "$P1E", m_Delimiter);//读取关键字PnE的值——数据放大类型
            tempStr = GetKeywordValue(textInfo, "$P1N", m_Delimiter);//读取关键字PnN的值——数据短名称
            #endregion

            #region 读取可选字段，所有仪器选用,44项，不含已经停用部分

            tempStr = GetKeywordValue(textInfo, "$CYT", m_Delimiter);//流式细胞仪型号
            tempStr = GetKeywordValue(textInfo, "$CYTSN", m_Delimiter);//读取关键字$CYTSN的值——流式细胞仪序列号。
            tempStr = GetKeywordValue(textInfo, "$ABRT", m_Delimiter);//读取关键字$ABRT的值——采集电子故障的数据丢失。
            tempStr = GetKeywordValue(textInfo, "$LOST", m_Delimiter);//读取关键字$LOST的值——由于计算机繁忙而丢失的事件数。
            tempStr = GetKeywordValue(textInfo, "$SYS", m_Delimiter);//读取关键字$SYS的值——计算机及其操作系统的类型。
            tempStr = GetKeywordValue(textInfo, "$FIL", m_Delimiter);//读取关键字$FIL的值——数据文件名。
            tempStr = GetKeywordValue(textInfo, "$ORIGINALITY", m_Delimiter);//读取关键字$ORIGINALITY的值——是否为仪器所获取的原始数据，FCS数据是否已被修改的信息（任何部分）
            tempStr = GetKeywordValue(textInfo, "$LAST_MODIFIED", m_Delimiter);//读取关键字$LAST_MODIFIED的值——上次修改数据集的时间。
            tempStr = GetKeywordValue(textInfo, "$LAST_MODIFIER", m_Delimiter);//读取关键字$LAST_MODIFIER的值——上次修改数据的人员的姓名。

            tempStr = GetKeywordValue(textInfo, "$TR", m_Delimiter);//读取关键字$TR的值——参数及其阈值
            tempStr = GetKeywordValue(textInfo, "$CELLS", m_Delimiter);//读取关键字$CELLS的值——测量对象的描述。
            tempStr = GetKeywordValue(textInfo, "$COM", m_Delimiter);//读取关键字$COM的值——注释，备注
            tempStr = GetKeywordValue(textInfo, "$SMNO", m_Delimiter);//读取关键字$SMNO的值——样本（如试管）标签。
            tempStr = GetKeywordValue(textInfo, "$WELLID", m_Delimiter);//读取关键字$WELLID的值——孔标识符
            tempStr = GetKeywordValue(textInfo, "$VOL", m_Delimiter);//读取关键字$VOL的值——数据采集期间的样本量。
            tempStr = GetKeywordValue(textInfo, "$DATE", m_Delimiter);//读取关键字$DATE的值——数据获取日期。
            tempStr = GetKeywordValue(textInfo, "$BTIM", m_Delimiter);//读取关键字$BTIM的值——数据采集开始时间。hh:mm:ss
            tempStr = GetKeywordValue(textInfo, "$ETIM", m_Delimiter);//读取关键字$ETIM的值——数据采集结束时的时钟时间。
            tempStr = GetKeywordValue(textInfo, "$TIMESTEP", m_Delimiter);//读取关键字$TIMESTEP的值——时间参数的步长。
            tempStr = GetKeywordValue(textInfo, "$INST", m_Delimiter);//读取关键字$INST的值——单位名称。
            tempStr = GetKeywordValue(textInfo, "$EXP", m_Delimiter);//读取关键字$EXP的值——启动实验的研究者的姓名。
            tempStr = GetKeywordValue(textInfo, "$OP", m_Delimiter);//读取关键字$OP的值——流式细胞仪操作员的名称。
            tempStr = GetKeywordValue(textInfo, "$SRC", m_Delimiter);//读取关键字$SRC的值——样本来源（患者姓名、细胞类型）

            tempStr = GetKeywordValue(textInfo, "$CSMODE", m_Delimiter);//读取关键字$CSMODE的值——细胞子集模式，隶属细胞子集
            tempStr = GetKeywordValue(textInfo, "$CSVBITS", m_Delimiter);//读取关键字$CSVBITS的值——用于编码单元子集标识符的位数。
            tempStr = GetKeywordValue(textInfo, "$CSVnFLAG", m_Delimiter);//读取关键字$CSVnFLAG的值——设置为n子集标志的字节。
            tempStr = GetKeywordValue(textInfo, "$SPILLOVER", m_Delimiter);//读取关键字$SPILLOVER的值——荧光溢出矩阵。
            tempStr = GetKeywordValue(textInfo, "$GATE", m_Delimiter);//读取关键字$GATE的值——门的数量
            tempStr = GetKeywordValue(textInfo, "$GATING", m_Delimiter);//读取关键字$GATING的值——门的范围
            tempStr = GetKeywordValue(textInfo, "$PLATEID", m_Delimiter);//读取关键字$PLATEID的值——Plate标识符
            tempStr = GetKeywordValue(textInfo, "$PLATENAME", m_Delimiter);//读取关键字$PLATENAME的值——Plate名称

            tempStr = GetKeywordValue(textInfo, "$PnCALIBRATION", m_Delimiter);//读取关键字$PnCALIBRATION的值——转换参数值的单位,例如MESF.
            tempStr = GetKeywordValue(textInfo, "$PnD", m_Delimiter);//读取关键字$PnD的值——参数n的动态范围。
            tempStr = GetKeywordValue(textInfo, "$PnF", m_Delimiter);//读取关键字$PnF的值——参数n的滤光片名称。
            tempStr = GetKeywordValue(textInfo, "$PnG", m_Delimiter);//读取关键字$PnG的值——参数n的放大器增益
            tempStr = GetKeywordValue(textInfo, "$PnL", m_Delimiter);//读取关键字$PnL的值——参数n的激发波长。
            tempStr = GetKeywordValue(textInfo, "$PnO", m_Delimiter);//读取关键字$PnO的值——参数n的激发功率。
            tempStr = GetKeywordValue(textInfo, "$PnP", m_Delimiter);//读取关键字$PnP的值——参数n的收集的发射光百分比。
            tempStr = GetKeywordValue(textInfo, "$PnS", m_Delimiter);//读取关键字$PnS的值——参数n的名称
            tempStr = GetKeywordValue(textInfo, "$PnT", m_Delimiter);//读取关键字$PnT的值——参数n的检测器类型。
            tempStr = GetKeywordValue(textInfo, "$PnV", m_Delimiter);//读取关键字$PnV的值——参数n的检测器电压。
            tempStr = GetKeywordValue(textInfo, "$PROJ", m_Delimiter);//读取关键字$PROJ的值——实验项目的名称。
            tempStr = GetKeywordValue(textInfo, "$RnI", m_Delimiter);//读取关键字$RnI的值——参数n的门范围
            tempStr = GetKeywordValue(textInfo, "$RnW", m_Delimiter);//读取关键字$RnW的值——参数n的门的窗口设置。

            #endregion

            for (int i = 0; i < m_ParametersNumber; i++)
            {

                tempStr = GetKeywordValue(textInfo, "P" + (i + 1).ToString() + "S", m_Delimiter) + " " + GetKeywordValue(textInfo, "P" + (i + 1).ToString() + "N", m_Delimiter);
                ParametersNamesList.Add(tempStr);//循环添加元素
            }

            string[] ParametersNamesArray = ParametersNamesList.ToArray();//strArray=[str0,str1,str2]

            return true;
        }
        #endregion

    }
}