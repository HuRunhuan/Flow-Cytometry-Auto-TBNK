/**
 * 模块名称：FCS Data（数据部分）
 * 功能描述：主要负责对FCS文件的Data（数据部分）进行读取
**/
using System;
using System.IO;

namespace FCS_Load
{
    public class FCS_Data
    {
        private int m_TotalEvents = 0;  //数据数量
        private int m_ParametersNumber = 0; //参数数量
        public double[,] m_data = null; //一个[数据数量]*[参数数量]数组，用以存储读取的数据
        #region FCS数据读取
        public bool GetData(BinaryReader br, int startPos, int endPos, int paraNum, int eventNum, int bitNum, string dataType, string byteOrd, string OS_Type)
        {
            m_ParametersNumber = paraNum; //接收参数，分别代表参数数量和数据数量
            m_TotalEvents = eventNum;
            br.BaseStream.Seek(startPos, SeekOrigin.Begin);//将文件指针指到数据部分的起始位置
            switch (bitNum)//根据数据比特数以及数据类型选择读取数据的函数
            {
                case 16://16位整型读法
                    ReadData16I(br, byteOrd, OS_Type);
                    break;
                case 32://32位读法
                    if (dataType.Equals("I"))//32位整型
                    {
                        ReadData32I(br, byteOrd);
                    }
                    else//32位浮点型
                    {
                        ReadData32F(br, byteOrd);
                    }
                    break;
            }
            return true;
        }
        private void ReadData16I(BinaryReader br, string byteOrd, string OS_Type)//16位读法
        {
            m_data = new double[m_TotalEvents, m_ParametersNumber];//根据参数数量和数据数量为数组申请内存空间
            uint tempUint;
            for (int i = 0; i < m_TotalEvents; i++)
            {
                for (int j = 0; j < m_ParametersNumber; j++)
                {
                    tempUint = br.ReadUInt16();//读取一个2Bytes = 16bits的数据
                    if (OS_Type.Equals("DOS"))//貝克曼FC500前代儀器
                    {
                        m_data[i, j] = (tempUint & 0x03FFU);//交换字节顺序
                    }
                    else if (byteOrd.Equals("4,3,2,1") || byteOrd.Equals("2,1"))
                    {
                        m_data[i, j] = ((tempUint & 0xFFU) << 8 | (tempUint & 0xFF00U) >> 8);//交换字节顺序
                    }
                    else
                    {
                        m_data[i, j] = tempUint;
                    }
                }
            }
        }
        private void ReadData32I(BinaryReader br, string byteOrd)//32位整型读法
        {
            m_data = new double[m_TotalEvents, m_ParametersNumber];//根据参数数量和数据数量为数组申请内存空间                                                                  
            uint tempInt;
            for (int i = 0; i < m_TotalEvents; i++)
            {
                for (int j = 0; j < m_ParametersNumber; j++)
                {
                    tempInt = br.ReadUInt32();
                    if (byteOrd.Equals("4,3,2,1"))
                    {
                        m_data[i, j] = ((tempInt & 0xFFU) << 24 | (tempInt & 0xFF00U) << 8 | (tempInt & 0xFF0000U) >> 8 | (tempInt & 0xFF000000U) >> 24);
                    }
                    else
                    {
                        m_data[i, j] = tempInt;
                    }
                }
            }
        }
        private void ReadData32F(BinaryReader br, string byteOrd)//32位浮点型读法
        {
            m_data = new double[m_TotalEvents, m_ParametersNumber];//根据参数数量和数据数量为数组申请内存空间
            Byte[] tempBytes = new Byte[4];
            for (int i = 0; i < m_TotalEvents; i++)
            {
                for (int j = 0; j < m_ParametersNumber; j++)
                {
                    tempBytes = br.ReadBytes(4);
                    if (byteOrd.Equals("4,3,2,1") || byteOrd.Equals("2,1"))
                    {
                        Byte tempByte = tempBytes[0];//交换字节顺序
                        tempBytes[0] = tempBytes[3];
                        tempBytes[3] = tempByte;
                        tempByte = tempBytes[1];
                        tempBytes[1] = tempBytes[2];
                        tempBytes[2] = tempByte;
                        float tempFloat = System.BitConverter.ToSingle(tempBytes, 0);
                        m_data[i, j] = Math.Pow(tempFloat, (float)1);
                    }
                    else
                    {
                        float tempFloat = System.BitConverter.ToSingle(tempBytes, 0);
                        m_data[i, j] = Math.Pow(tempFloat, (float)1);
                    }
                }
            }
        }
        #endregion
    }
}