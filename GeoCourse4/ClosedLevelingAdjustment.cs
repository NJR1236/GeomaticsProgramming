using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Author:WuYang
//Created_Time:2022-11-09 19:20
//LastEdit_Time:2022-11-09 23:01

//输入闭合水准路线各水准点的点号以及各测段的观测高差，计算高差闭合差并平均分配到各个测段，最后计算各未知点的高程并输出。
//PName-点号
//Elevation-高程
//DeltaElev-高差
//Correction-改正数
//StartElev-起始点高程
//ClosingError-高差闭合差

namespace GC4.ClosedLevelingAdjustment
{
    class ClosedLevelingAdjustment
    {
        public static void CloLevAdj(double StartElev, string PName, string DeltaElev)
        {
            double ClosingError, Correction;
            double[] Elevation, parDeltaElev, AdjDeltaElev;
            string[] parPName, StrDeltaElev;

            //将点号转化为字符串数组，并确定数组长度
            parPName = PName.Split(';');
            int n = parPName.Length;

            //将观测高差数据转换为Double型
            StrDeltaElev = DeltaElev.Split(';');
            parDeltaElev = new double[n];
            for (int i = 0; i < n; i++)
            {
                parDeltaElev[i] = Convert.ToDouble(StrDeltaElev[i]);
            }

            //计算高差闭合差
            ClosingError = 0;
            for (int i = 0; i < n; i++)
            {
                ClosingError = ClosingError + parDeltaElev[i];
            }

            //将高差闭合差反号平均分配到各个测段
            Correction = -ClosingError / n;
            AdjDeltaElev = new double[n];
            for (int i = 0; i < n; i++)
            {
                AdjDeltaElev[i] = parDeltaElev[i] + Correction;
            }

            //根据起始点高程计算出各未知点高程
            Elevation = new double[n];
            Elevation[0] = StartElev;
            for (int i = 1; i <n; i++)
            {
                Elevation[i] = Elevation[i - 1] + AdjDeltaElev[i - 1];
            }

            //输出结果
            Console.WriteLine("\n该闭合水准路线的高差闭合差为：{0}m", Math.Round(ClosingError, 3).ToString("0.000"));
            Console.WriteLine("\n经过近似平差后：");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("水准点{0}的高程为{1}m",parPName[i],Math.Round(Elevation[i],3).ToString("0.000"));
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double StartElev;
            string PName, DeltaElev;

            Console.WriteLine("请输入闭合水准路线已知点高程：");
            StartElev = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请依次输入各点点号，并以分号间隔：");
            PName = Console.ReadLine();
            Console.WriteLine("请依次输入测段观测高差，并以分号间隔：");
            DeltaElev = Console.ReadLine();

            //调用CloLevAdj方法进行闭合水准路线平差
            ClosedLevelingAdjustment.CloLevAdj(StartElev, PName, DeltaElev);
            Console.ReadKey();
        }
    }
}