using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Author:WuYang
//First_Edit_Time:2022-10-31 18:51
//Last_Edit_Time:2022-10-31 20:26

//手动输入控制点的点名、高程、XY坐标，然后按照规定的格式输出这些值。
//PName-点名;
//Elevation-高程;
//X-坐标X；
//Y-坐标Y;

namespace GC1.ReadPoint
{
    class ReadPoint
    {
        static void Main(string[] args)
        {
            //Input
            Console.WriteLine("请输入点号:");
            string PName = Console.ReadLine();
            Console.WriteLine("请输入高程:");
            double Elevation = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入X坐标:");
            double X = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入Y坐标:");
            double Y = Convert.ToDouble(Console.ReadLine());
            //Output
            Console.WriteLine("(1)已知点{0}的高程为:{1}m\n(2)已知点{2}坐标为:\nX={3}\nY={4}", PName, Elevation, PName,X,Y);
            Console.ReadKey();
        }
    }
}