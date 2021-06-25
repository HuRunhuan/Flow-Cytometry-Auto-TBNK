using System;
using System.Collections.Generic;
using System.Linq;


namespace Calculate
{
    public class AutoCalTBNK
    {
        public int CalTBNK(int totalnum, List<int> PN, double[,] data, ref string T, ref string CD4_T, ref string CD8_T, ref string B, ref string NK)
        {
            #region 计算用数组参数定义
            List<int> SSC_In_Gate = new List<int>();
            List<int> CD45_In_Gate = new List<int>();
            List<int> CD3_In_Gate = new List<int>();
            List<int> CD4_In_Gate = new List<int>();
            List<int> CD8_In_Gate = new List<int>();
            List<int> CD3N_In_Gate = new List<int>();
            List<int> CD19_In_Gate = new List<int>();
            List<int> CD16_56_In_Gate = new List<int>();
            SortedList<int, uint> SSC_Frequency = new SortedList<int, uint>();
            SortedList<int, uint> CD45_Frequency = new SortedList<int, uint>();
            SortedList<int, uint> CD3_Frequency = new SortedList<int, uint>();
            SortedList<int, uint> CD3N_Frequency = new SortedList<int, uint>();
            SortedList<int, uint> CD4_Frequency = new SortedList<int, uint>();
            SortedList<int, uint> CD8_Frequency = new SortedList<int, uint>();
            SortedList<int, uint> CD19_Frequency = new SortedList<int, uint>();
            SortedList<int, uint> CD16_56_Frequency = new SortedList<int, uint>();

            #endregion

            #region 计算用参数定义
            uint T_Count, CD45_Count, CD3_T_Count, CD4_T_Count, CD8_T_Count, B_Count, NK_Count;
            double T_pct, CD45_pct, CD3_T_pct, CD4_T_pct, CD8_T_pct, B_pct, NK_pct;
            T_Count = CD45_Count = CD3_T_Count = CD4_T_Count = CD8_T_Count = B_Count = NK_Count = 0;
            T_pct = CD45_pct = CD3_T_pct = CD4_T_pct = CD8_T_pct = B_pct = NK_pct = 0;
            #endregion

            #region 频率建数组，求LYM range   -    CD45 range

            for (int i = 0; i < totalnum; i++)
            {
                if (((int)(293 * Math.Log10(data[i, PN[2]])) > 0))
                {
                    CD45_In_Gate.Add((int)(293 * Math.Log10(data[i, PN[2]])));
                }
            }
            CalUtils.GetFrequency(CD45_In_Gate, ref CD45_Frequency);

            int CD45Maxindex = 0;
            uint CD45Maxvavle = 0;
            int CD45Maxupindex = 0;
            uint CD45Maxupvavle = 99999;
            int CD45Maxdownindex = 0;
            uint CD45Maxdownvavle = 99999;
            int CD45Gata = CD45Maxupindex;
            CalUtils.FrequencyMax(CD45_Frequency, CD45_In_Gate.Count, 0.001, 0, CD45_Frequency.Count - 10, ref CD45Maxindex, ref CD45Maxvavle);
            CalUtils.FrequencyUp(CD45_Frequency, CD45_In_Gate.Count, 0.001, CD45Maxindex, CD45_Frequency.Count - 10, ref CD45Maxupindex, ref CD45Maxupvavle);
            CalUtils.FrequencyDown(CD45_Frequency, CD45_In_Gate.Count, 0.001, 0, CD45Maxindex, ref CD45Maxdownindex, ref CD45Maxdownvavle);

            uint CD45_sum_up = 0;
            {
                for (int j = CD45Maxupindex; j < CD45_Frequency.Count; j++)
                {
                    CD45_sum_up += CD45_Frequency.ElementAt(j).Value;
                }
            }
            uint CD45_sum_down = 0;
            {
                for (int j = 0; j < CD45Maxdownindex; j++)
                {
                    CD45_sum_down += CD45_Frequency.ElementAt(j).Value;
                }
            }
            if (CD45_sum_down > 0 &&
                CD45_sum_up > 0) //中间
            { CD45Gata = CD45Maxupindex; }
            if (CD45_sum_down > CD45_In_Gate.Count * 0.1 &&
                CD45_sum_up < CD45_In_Gate.Count * 0.05)                //上
            { CD45Gata = CD45Maxdownindex; }
            if (CD45_sum_down < CD45_In_Gate.Count * 0.05 &&
                CD45_sum_up > CD45_In_Gate.Count * 0.1)                //下
            { CD45Gata = CD45Maxupindex; }

            #endregion

            #region SSC range
            for (int i = 0; i < totalnum; i++)
            {
                if (293 * Math.Log10(data[i, PN[2]]) > CD45Gata &&
                    ((int)(293 * Math.Log10(data[i, PN[1]])) > 0))
                {
                    SSC_In_Gate.Add((int)(293 * Math.Log10(data[i, PN[1]])));
                }
            }
            CalUtils.GetFrequency(SSC_In_Gate, ref SSC_Frequency);

            int SSCMaxindex = 0;
            uint SSCMaxvavle = 0;
            int SSCMaxupindex = 0;
            uint SSCMaxupvavle = 99999;
            int SSCGata = 0;
            CalUtils.FrequencyMax(SSC_Frequency, SSC_In_Gate.Count, 0.05, 0, SSC_Frequency.Count - 10, ref SSCMaxindex, ref SSCMaxvavle);
            CalUtils.FrequencyUp(SSC_Frequency, SSC_In_Gate.Count, 0.05, SSCMaxindex, SSC_Frequency.Count - 10, ref SSCMaxupindex, ref SSCMaxupvavle);

            SSCGata = SSCMaxupindex;

            #endregion
            #region 频率建数组2 CD3

            for (int i = 0; i < totalnum; i++)
            {
                if (293 * Math.Log10(data[i, PN[2]]) > CD45Gata &&
                    293 * Math.Log10(data[i, PN[1]]) < SSCGata &&
                    ((int)(293 * Math.Log10(data[i, PN[3]])) > 0)
                    )
                {
                    CD3_In_Gate.Add((int)(293 * Math.Log10(data[i, PN[3]])));
                }
            }
            CalUtils.GetFrequency(CD3_In_Gate, ref CD3_Frequency);

            int CD3Maxindex = 0;
            uint CD3Maxvavle = 0;
            int CD3Maxupindex = 0;
            uint CD3Maxupvavle = 99999;
            int CD3Maxdownindex = 0;
            uint CD3Maxdownvavle = 99999;
            int CD3Gata = 0;
            CalUtils.FrequencyMax(CD3_Frequency, CD3_In_Gate.Count, 0.00, 0, CD3_Frequency.Count - 10, ref CD3Maxindex, ref CD3Maxvavle);
            CalUtils.FrequencyUp(CD3_Frequency, CD3_In_Gate.Count, 0.00, CD3Maxindex, CD3_Frequency.Count - 10, ref CD3Maxupindex, ref CD3Maxupvavle);
            CalUtils.FrequencyDown(CD3_Frequency, CD3_In_Gate.Count, 0.00, 0, CD3Maxindex, ref CD3Maxdownindex, ref CD3Maxdownvavle);

            uint CD3_sum_up = 0;
            {
                for (int j = CD3Maxupindex; j < CD3_Frequency.Count; j++)
                {
                    CD3_sum_up += CD3_Frequency.ElementAt(j).Value;
                }
            }
            uint CD3_sum_down = 0;
            {
                for (int j = 0; j < CD3Maxdownindex; j++)
                {
                    CD3_sum_down += CD3_Frequency.ElementAt(j).Value;
                }
            }

            if (CD3_sum_down > CD3_sum_up) //中间
            { CD3Gata = CD3Maxdownindex; }
            if (CD3_sum_down < CD3_sum_up) //中间             //下
            { CD3Gata = CD3Maxupindex; }

            for (int j = CD3Gata; j < CD3_Frequency.Count; j++)
            {
                T_Count += CD3_Frequency.ElementAt(j).Value;
            }
            T_pct = (double)T_Count / CD3_In_Gate.Count;
            #endregion


            #region CD3 range

            #endregion

            #region 频率建数组3 CD3 N P

            for (int i = 0; i < totalnum; i++)
            {
                if (293 * Math.Log10(data[i, PN[2]]) > CD45Gata &&
                    293 * Math.Log10(data[i, PN[1]]) < SSCGata &&
                    293 * Math.Log10(data[i, PN[3]]) > CD3Gata &&
                    ((int)(293 * Math.Log10(data[i, PN[4]])) > 0) &&
                    ((int)(293 * Math.Log10(data[i, PN[5]])) > 0))
                {
                    CD4_In_Gate.Add((int)(293 * Math.Log10(data[i, PN[4]])));
                    CD8_In_Gate.Add((int)(293 * Math.Log10(data[i, PN[5]])));
                }
                if (293 * Math.Log10(data[i, PN[2]]) > CD45Gata &&
                    293 * Math.Log10(data[i, PN[1]]) < SSCGata &&
                    293 * Math.Log10(data[i, PN[3]]) < CD3Gata &&
                    ((int)(293 * Math.Log10(data[i, PN[6]])) > 0) &&
                    ((int)(293 * Math.Log10(data[i, PN[7]])) > 0))
                {
                    CD19_In_Gate.Add((int)(293 * Math.Log10(data[i, PN[6]])));
                    CD16_56_In_Gate.Add((int)(293 * Math.Log10(data[i, PN[7]])));
                }

            }
            CalUtils.GetFrequency(CD4_In_Gate, ref CD4_Frequency);
            CalUtils.GetFrequency(CD8_In_Gate, ref CD8_Frequency);
            CalUtils.GetFrequency(CD19_In_Gate, ref CD19_Frequency);
            CalUtils.GetFrequency(CD16_56_In_Gate, ref CD16_56_Frequency);

            #endregion
            #region CD4 range
            int CD4Maxindex = 0;
            uint CD4Maxvavle = 0;
            int CD4Maxupindex = 0;
            uint CD4Maxupvavle = 99999;
            int CD4Maxdownindex = 0;
            uint CD4Maxdownvavle = 99999;
            int CD4Gata = 0;
            CalUtils.FrequencyMax(CD4_Frequency, CD4_In_Gate.Count, 0.00, 0, CD4_Frequency.Count - 10, ref CD4Maxindex, ref CD4Maxvavle);
            CalUtils.FrequencyUp(CD4_Frequency, CD4_In_Gate.Count, 0.00, CD4Maxindex, CD4_Frequency.Count - 10, ref CD4Maxupindex, ref CD4Maxupvavle);
            CalUtils.FrequencyDown(CD4_Frequency, CD4_In_Gate.Count, 0.00, 0, CD4Maxindex, ref CD4Maxdownindex, ref CD4Maxdownvavle);

            uint CD4_sum_up = 0;
            {
                for (int j = CD4Maxupindex; j < CD4_Frequency.Count; j++)
                {
                    CD4_sum_up += CD4_Frequency.ElementAt(j).Value;
                }
            }
            uint CD4_sum_down = 0;
            {
                for (int j = 0; j < CD4Maxdownindex; j++)
                {
                    CD4_sum_down += CD4_Frequency.ElementAt(j).Value;
                }
            }

            if (CD4_sum_down > CD4_sum_up) //中间
            { CD4Gata = CD4Maxdownindex; }
            if (CD4_sum_down < CD4_sum_up) //中间             //下
            { CD4Gata = CD4Maxupindex; }

            #endregion
            #region CD8 range
            int CD8Maxindex = 0;
            uint CD8Maxvavle = 0;
            int CD8Maxupindex = 0;
            uint CD8Maxupvavle = 99999;
            int CD8Maxdownindex = 0;
            uint CD8Maxdownvavle = 99999;
            int CD8Gata = 0;
            CalUtils.FrequencyMax(CD8_Frequency, CD8_In_Gate.Count, 0.00, 0, CD8_Frequency.Count - 10, ref CD8Maxindex, ref CD8Maxvavle);
            CalUtils.FrequencyUp(CD8_Frequency, CD8_In_Gate.Count, 0.00, CD8Maxindex, CD8_Frequency.Count - 10, ref CD8Maxupindex, ref CD8Maxupvavle);
            CalUtils.FrequencyDown(CD8_Frequency, CD8_In_Gate.Count, 0.00, 0, CD8Maxindex, ref CD8Maxdownindex, ref CD8Maxdownvavle);

            uint CD8_sum_up = 0;
            {
                for (int j = CD8Maxupindex; j < CD8_Frequency.Count; j++)
                {
                    CD8_sum_up += CD8_Frequency.ElementAt(j).Value;
                }
            }
            uint CD8_sum_down = 0;
            {
                for (int j = 0; j < CD8Maxdownindex; j++)
                {
                    CD8_sum_down += CD8_Frequency.ElementAt(j).Value;
                }
            }

            if (CD8_sum_down > CD8_sum_up) //中间
            { CD8Gata = CD8Maxdownindex; }
            if (CD8_sum_down < CD8_sum_up) //中间             //下
            { CD8Gata = CD8Maxupindex; }

            for (int i = 0; i < totalnum; i++)
            {
                if (293 * Math.Log10(data[i, PN[2]]) > CD45Gata &&
                    293 * Math.Log10(data[i, PN[1]]) < SSCGata &&
                    293 * Math.Log10(data[i, PN[3]]) > CD3Gata &&
                    293 * Math.Log10(data[i, PN[4]]) > CD4Gata &&
                    293 * Math.Log10(data[i, PN[5]]) < CD8Gata
                    )
                {
                    CD4_T_Count++;
                }
            }
            CD4_T_pct = (double)CD4_T_Count / CD3_In_Gate.Count;

            for (int i = 0; i < totalnum; i++)
            {
                if (293 * Math.Log10(data[i, PN[2]]) > CD45Gata &&
                    293 * Math.Log10(data[i, PN[1]]) < SSCGata &&
                    293 * Math.Log10(data[i, PN[3]]) > CD3Gata &&
                    293 * Math.Log10(data[i, PN[4]]) < CD4Gata &&
                    293 * Math.Log10(data[i, PN[5]]) > CD8Gata
                    )
                {
                    CD8_T_Count++;
                }
            }
            CD8_T_pct = (double)CD8_T_Count / CD3_In_Gate.Count;

            #endregion
            #region CD19 range
            int CD19Maxindex = 0;
            uint CD19Maxvavle = 0;
            int CD19Maxupindex = 0;
            uint CD19Maxupvavle = 99999;
            int CD19Maxdownindex = 0;
            uint CD19Maxdownvavle = 99999;
            int CD19Gata = 0;
            CalUtils.FrequencyMax(CD19_Frequency, CD19_In_Gate.Count, 0.00, 0, CD19_Frequency.Count - 10, ref CD19Maxindex, ref CD19Maxvavle);
            CalUtils.FrequencyUp(CD19_Frequency, CD19_In_Gate.Count, 0.00, CD19Maxindex, CD19_Frequency.Count - 10, ref CD19Maxupindex, ref CD19Maxupvavle);
            CalUtils.FrequencyDown(CD19_Frequency, CD19_In_Gate.Count, 0.00, 0, CD19Maxindex, ref CD19Maxdownindex, ref CD19Maxdownvavle);

            uint CD19_sum_up = 0;
            {
                for (int j = CD19Maxupindex; j < CD19_Frequency.Count; j++)
                {
                    CD19_sum_up += CD19_Frequency.ElementAt(j).Value;
                }
            }
            uint CD19_sum_down = 0;
            {
                for (int j = 0; j < CD19Maxdownindex; j++)
                {
                    CD19_sum_down += CD19_Frequency.ElementAt(j).Value;
                }
            }

            if (CD19_sum_down > CD19_sum_up) //中间
            { CD19Gata = CD19Maxdownindex; }
            if (CD19_sum_down < CD19_sum_up) //中间             //下
            { CD19Gata = CD19Maxupindex; }


            #endregion
            #region CD16+56 range
            int CD16_56Maxindex = 0;
            uint CD16_56Maxvavle = 0;
            int CD16_56Maxupindex = 0;
            uint CD16_56Maxupvavle = 99999;
            int CD16_56Maxdownindex = 0;
            uint CD16_56Maxdownvavle = 99999;
            int CD16_56Gata = 0;
            CalUtils.FrequencyMax(CD16_56_Frequency, CD16_56_In_Gate.Count, 0.00, 0, CD16_56_Frequency.Count - 10, ref CD16_56Maxindex, ref CD16_56Maxvavle);
            CalUtils.FrequencyUp(CD16_56_Frequency, CD16_56_In_Gate.Count, 0.00, CD16_56Maxindex, CD16_56_Frequency.Count - 10, ref CD16_56Maxupindex, ref CD16_56Maxupvavle);
            CalUtils.FrequencyDown(CD16_56_Frequency, CD16_56_In_Gate.Count, 0.00, 0, CD16_56Maxindex, ref CD16_56Maxdownindex, ref CD16_56Maxdownvavle);

            uint CD16_56_sum_up = 0;
            {
                for (int j = CD16_56Maxupindex; j < CD16_56_Frequency.Count; j++)
                {
                    CD16_56_sum_up += CD16_56_Frequency.ElementAt(j).Value;
                }
            }
            uint CD16_56_sum_down = 0;
            {
                for (int j = 0; j < CD16_56Maxdownindex; j++)
                {
                    CD16_56_sum_down += CD16_56_Frequency.ElementAt(j).Value;
                }
            }

            if (CD16_56_sum_down > CD16_56_sum_up) //中间
            { CD16_56Gata = CD16_56Maxdownindex; }
            if (CD16_56_sum_down < CD16_56_sum_up) //中间             //下
            { CD16_56Gata = CD16_56Maxupindex; }


            for (int i = 0; i < totalnum; i++)
            {
                if (293 * Math.Log10(data[i, PN[2]]) > CD45Gata &&
                    293 * Math.Log10(data[i, PN[1]]) < SSCGata &&
                    293 * Math.Log10(data[i, PN[3]]) < CD3Gata &&
                    293 * Math.Log10(data[i, PN[6]]) > CD19Gata &&
                    293 * Math.Log10(data[i, PN[7]]) < CD16_56Gata
                    )
                {
                    B_Count++;
                }
            }
            for (int i = 0; i < totalnum; i++)
            {
                if (293 * Math.Log10(data[i, PN[2]]) > CD45Gata &&
                    293 * Math.Log10(data[i, PN[1]]) < SSCGata &&
                    293 * Math.Log10(data[i, PN[3]]) < CD3Gata &&
                    293 * Math.Log10(data[i, PN[6]]) < CD19Gata &&
                    293 * Math.Log10(data[i, PN[7]]) > CD16_56Gata
                    )
                {
                    NK_Count++;
                }
            }

            B_pct = (double)B_Count / CD3_In_Gate.Count;
            NK_pct = (double)NK_Count / CD3_In_Gate.Count;
            #endregion


            T = T_pct.ToString("P") + "          " + T_Count.ToString();
            CD4_T = CD4_T_pct.ToString("P") + "          " + CD4_T_Count.ToString();
            CD8_T = CD8_T_pct.ToString("P") + "          " + CD8_T_Count.ToString();
            B = B_pct.ToString("P") + "          " + B_Count.ToString();
            NK = NK_pct.ToString("P") + "          " + NK_Count.ToString();

            return 0;
        }




    }


    public class CalUtils
    {
        public static void FrequencyMax(SortedList<int, uint> Frequency, int In_Gate, double accuracy, int LowerBound, int UpperBound, ref int Max_Index, ref uint Max_Value)//求峰极值
        {
            //求最大的value值
            for (int i = LowerBound; i < UpperBound; i++)
            {
                if (Max_Value < Frequency.ElementAt(i).Value + 1)
                {
                    Max_Index = Frequency.ElementAt(i).Key;
                    Max_Value = Frequency.ElementAt(i).Value;
                }
            }
        }
        public static void FrequencyUp(SortedList<int, uint> Frequency, int In_Gate, double accuracy, int LowerBound, int UpperBound, ref int Min_Indexup, ref uint Min_Valueup)//求峰上限
        {
            for (int i = LowerBound; i < UpperBound; i++)
            {
                if (Min_Valueup > Frequency.ElementAt(i).Value && Min_Valueup > In_Gate * accuracy)
                {
                    Min_Indexup = Frequency.ElementAt(i).Key;
                    Min_Valueup = Frequency.ElementAt(i).Value;
                }
            }
        }
        public static void FrequencyDown(SortedList<int, uint> Frequency, int In_Gate, double accuracy, int LowerBound, int UpperBound, ref int Min_Indexdown, ref uint Min_Valuedown)//求峰下限
        {
            for (int i = UpperBound; i > LowerBound; i--)
            {
                if (Min_Valuedown > Frequency.ElementAt(i).Value && Min_Valuedown > In_Gate * accuracy)
                {
                    Min_Indexdown = Frequency.ElementAt(i).Key;
                    Min_Valuedown = Frequency.ElementAt(i).Value;
                }
            }
        }

        public static void GetFrequency(List<int> In_Gate, ref SortedList<int, uint> Frequency) //频率数组
        {
            for (int i = 0; i < In_Gate.Count; i++)
            {
                if (Frequency.ContainsKey(In_Gate[i]))
                {
                    Frequency[In_Gate[i]]++;
                }
                else
                {
                    Frequency.Add(In_Gate[i], 1);
                }
            }
            int aa = ((Frequency.ElementAt(Frequency.Count - 1).Key));
            for (int i = 0; i < aa; i++)
            {
                if (!Frequency.ContainsKey(i))
                {
                    Frequency.Add(i, 0);
                }
            }
        }
    }
}

