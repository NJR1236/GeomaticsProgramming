using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevelingCalculation;      //引用LevelingCalculation Namespace

//Author:WuYang
//Created_Time:2022-11-02 21:45
//LastEdit_Time:2022-11-02 23:27

//手动输入已知点的点名和高程与未知点的点名，再通过观测高差，计算出未知点的高程并输出。
//LM.KnPName-已知点点名
//LM.UnPName-未知点点名
//LM.UnPElev-未知点高程
//LM.KnPElev-已知点高程
//LM.deltaElev-高差

namespace GC2.LevelingMeasurement
{
    class LevelingMeasurement
    {
        static void Main(string[] args)
        {
            //调用LC类并new一个对象
            LC LM = new LC();
            Console.WriteLine("请输入已知点点名：");
            LM.KnPName = Console.ReadLine();
            Console.WriteLine("请输入未知点点名：");
            LM.UnPName = Console.ReadLine();
            Console.WriteLine("请输入已知点高程：");
            LM.KnPElev = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入观测高差：");
            LM.deltaElev = Convert.ToDouble(Console.ReadLine());
            //调用LC中KPE方法，计算未知点高程
            LM.UnPElev = LM.KPE(LM.KnPElev, LM.deltaElev);
            Console.WriteLine("{0}点的高程为：{1}m", LM.UnPName, LM.UnPElev);
            Console.ReadKey();
        }
    }
}
