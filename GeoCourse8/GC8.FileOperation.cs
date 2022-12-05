using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Author:WuYang
//Created_Time:2022-12-05 19:47
//LastEdit_Time:2022-12-05 22:03

/// <summary>
/// 用StreamReader类实现文本文件中每一个元素的读取，并赋值给一个二维数组，然后输出这个二维数组。
/// </summary>
namespace GC8.FileOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\academic\GeoCoding\Leveling.dat";
            string[,] data = FileOperation.dataRead(path);
            Console.ReadKey();
        }
    }
    class FileOperation
    {
        /// <summary>
        /// 计算行数
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static int rowsCalculate(string filePath)
        {
            StreamReader streamReader = new StreamReader(filePath);
            int rows = 0;
            while (streamReader.ReadLine() != null)
            {
                rows++;
            }
            streamReader.Close();
            return rows;
        }
        /// <summary>
        ///  计算列数
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static int columnsCalculate(string filePath)
        {
            StreamReader streamReader = new StreamReader(filePath);
            string str = streamReader.ReadLine();
            string[] strColumn = str.Split(',');
            int columns = strColumn.Length;
            return columns;
        }
        /// <summary>
        /// 读取元素并赋值
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string[,] dataRead(string filePath)
        {
            StreamReader streamReader = new StreamReader(filePath);
            int rows = rowsCalculate(filePath);
            int columns = columnsCalculate(filePath);
            string[,] data = new string[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                string rowData = streamReader.ReadLine();
                for (int j = 0; j < columns; j++)
                {
                    data[i, j] = rowData.Split(',')[j];
                }
            }
            //对齐并输出
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    string strFormat = String.Format("{0,3}", data[i, j]);
                    if (j == columns - 1)
                    {
                        Console.Write("{0}", strFormat);
                    }
                    else
                    {
                        Console.Write("{0},", strFormat);
                    }
                }
                Console.Write("\n");
            }
            return data;
        }
    }
}
