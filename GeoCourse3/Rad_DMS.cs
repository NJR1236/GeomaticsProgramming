using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Author:WuYang
//Created_Time:2022-11-08 16:55
//LastEdit_Time:2022-11-08 18:45

//根据需求，选择一种弧角转换方式：将弧度值转换为角度值，并保留两位小数；或者以ddmmss格式输入角度值，并将角度值转换为弧度值，。
//Rad-弧度值
//Angle-角度值

namespace GC3.Rad_DMS
{
    class Rad_DMS
    {
        public static void Rad2DMS(double @Rad)
        {
            double degree, minute;
            string second;
            double t1 = (@Rad * 180 / Math.PI);
            degree = Math.Floor(t1);                                               //根据弧度值计算度
            double t2 = (t1 - degree) * 60;
            minute = Math.Floor(t2);                                                //根据弧度值计算分
            double t3 = (t2 - minute) * 60;
            second = Math.Round(t3,2).ToString("0.00");                  //根据弧度值计算秒，并根据四舍五入保留两位小数
            Console.WriteLine("弧度值{0}转化为角度值为{1}度{2}分{3}秒", @Rad, degree, minute, second);
        }
        public static void DMS2Rad(double @angle)
        {
            double Rad;
            // @angle 格式为ddmmss
            double p1 = Math.Floor(@angle);                         //提取度
            double p2 = Math.Floor((@angle - p1) * 100);       //提取分
            double p3 = ((@angle - p1) * 100 - p2) * 100;       //提取秒
            double ang = p1 + p2 / 60 + p3 / 3600;                 //以度为单位的角度值
            Rad = ang / 180 * Math.PI;                                  //根据角度值计算弧度值
            Console.WriteLine("角度值{0}转化为弧度值为{1}", @angle, Rad);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //选择一种转换方式
            Console.WriteLine("请选择转换方式：\n0表示Rad2DMS，1表示DMS2Rad");
            int conv = Convert.ToInt32 (Console.ReadLine());

            //若conv=0，选择Rad2DMS；若conv=1，选择DMS2Rad
            if (conv==0)
            {
                //调用Rad2DMS方法
                Console.WriteLine("请输入该角的弧度值：");
                double Rad = Convert.ToDouble(Console.ReadLine());
                Rad_DMS.Rad2DMS(Rad);
            }
            else if(conv==1)
            {

                //调用DMS2Rad方法
                Console.WriteLine("请以dd.mmss格式输入该角的角度值：");
                double Angle = Convert.ToDouble(Console.ReadLine());
                Rad_DMS.DMS2Rad(Angle);
            }
            Console.ReadKey();
        }
    }
}
