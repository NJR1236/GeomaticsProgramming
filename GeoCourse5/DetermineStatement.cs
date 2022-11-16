using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Author:WuYang
//Created_Time:2022-11-15 20:55
//LastEdit_Time:2022-11-15 22:42

//Task1：利用SwitchCase判断语句将输入的百分制成绩分为6个等级
//Task2：利用If判断语句判断输入点所在的象限

namespace GC5.DetermineStatement
{
    class Program
    {
        static void Main(string[] args)
        {
            //根据parDetermine的取值选择判断条件类型
            Console.WriteLine("请选择判断条件类型：\n'0'代表Switch，'1'代表If：");
            int parDetermine = Convert.ToInt32(Console.ReadLine());
            //Switch判断类型
            if (parDetermine == 0)
            {
                Console.WriteLine("请输入百分制分数：");
                double Score = Convert.ToDouble(Console.ReadLine());
                DetermineStatement_Switch.SwitchDetermine(Score);
            }
            //If判断类型
            else if (parDetermine == 1)
            {
                Console.WriteLine("请输入该点的坐标，并以分号隔开x和y：");
                string Coordinate = Console.ReadLine();
                DetermineStatement_If.IfDetermine(Coordinate);
            }
            //稳定性保证
            else
            {
                Console.WriteLine("输入错误，请输入正确的判断条件类型！");
            }
            Console.ReadKey();
        }
    }
    class DetermineStatement_Switch
    {
        //根据输入的分数，使用SwitchCase语句将分数分为6个等级
        public static void SwitchDetermine(double parScore)
        {
            double Score = parScore;
            int number = Convert.ToInt32(Math.Floor(Score / 10));
            switch (number)
            {
                case 10:
                    Console.WriteLine("你的成绩：满分");
                    break;
                case 9:
                    Console.WriteLine("你的成绩：优秀");
                    break;
                case 8:
                    Console.WriteLine("你的成绩：好");
                    break;
                case 7:
                    Console.WriteLine("你的成绩：良");
                    break;
                case 6:
                    Console.WriteLine("你的成绩：及格");
                    break;
                default:
                    Console.WriteLine("你的成绩：不及格");
                    break;
            }
        }
    }
    class DetermineStatement_If
    {
        //根据输入的坐标，使用If判断点所处的象限
        public static void IfDetermine(string parCoordinate)
        {
            string[] temper = parCoordinate.Split(';');
            double x, y;
            x = Convert.ToDouble(temper[0]);
            y = Convert.ToDouble(temper[1]);

            if (x == 0 && y == 0)
            {
                Console.WriteLine("该点位于原点");
            }
            if (x == 0 && y > 0)
            {
                Console.WriteLine("该点位于y轴正半轴");
            }
            if (x == 0 && y < 0)
            {
                Console.WriteLine("该点位于y轴负半轴");
            }
            if (x > 0 && y == 0)
            {
                Console.WriteLine("该点位于x轴正半轴");
            }
            if (x < 0 && y == 0)
            {
                Console.WriteLine("该点位于x轴负半轴");
            }
            if (x > 0 && y > 0)
            {
                Console.WriteLine("该点位于第一象限");
            }
            if (x < 0 && y > 0)
            {
                Console.WriteLine("该点位于第二象限");
            }
            if (x < 0 && y < 0)
            {
                Console.WriteLine("该点位于第三象限");
            }
            if (x > 0 && y < 0)
            {
                Console.WriteLine("该点位于第四象限");
            }
        }
    }
}
