using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Author:WuYang
//Created_Time:2022-11-21 22:04
//LastEdit_Time:2022-11-21 01:57

//task1:矩阵求和
//task2:矩阵求积
//task3:矩阵求逆

namespace GC7.MatrixAlgebra
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请选择所需的MatrixModel，0为矩阵求和，1位矩阵求积，2为矩阵求逆");
            int MatrixModelNumber=Convert.ToInt32(Console.ReadLine());
            if (MatrixModelNumber==0)
            {
                //矩阵求和
                Console.WriteLine("\n请输入第一个矩阵");
                double[,] A = MatrixAlgebra.ReadMatrix();
                Console.WriteLine("\n请输入第二个矩阵");
                double[,] B = MatrixAlgebra.ReadMatrix();
                double[,] C = MatrixAlgebra.AddMatrix(A, B);
            }
            else if (MatrixModelNumber==1)
            {
                //矩阵求积
                Console.WriteLine("\n请输入第一个矩阵");
                double[,] A = MatrixAlgebra.ReadMatrix();
                Console.WriteLine("\n请输入第二个矩阵");
                double[,] B = MatrixAlgebra.ReadMatrix();
                double[,] D = MatrixAlgebra.MultiplyMatrix(A, B);
            }
            else if (MatrixModelNumber==2)
            {
                //矩阵求逆
                Console.WriteLine("\n请输入需要求逆的矩阵：");
                double[,] A = MatrixAlgebra.ReadMatrix();
                double[,] E = MatrixAlgebra.InverseMatrix(A);
            }
            else
            {
                Console.WriteLine("\n请输入正确的MatrixModelNumber！");
            }
            Console.ReadKey();
        }
    }
    class MatrixAlgebra
    {
        public static double[,] ReadMatrix()
        {
            int row, column;
            string strElement;
            Console.WriteLine("请输入矩阵的行数：");
            row = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入矩阵的列数：");
            column = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入矩阵的元素，从左到右从上到下，元素之间用空格隔开：");
            strElement = Console.ReadLine();
            string[] Element = strElement.Split(' ');
            double[,] Matrix = new double[row, column];
            int index = 0;
            Console.WriteLine("您输入的矩阵为：");
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Matrix[i, j] = Convert.ToDouble(Element[index]);
                    index++;
                    Console.Write("{0}\0", Matrix[i, j]);
                }
                Console.Write("\n");
            }
            return Matrix;
        }
        public static double[,] AddMatrix(double[,] A, double[,] B)
        {
            double[,] C = new double[A.GetLength(0), A.GetLength(1)];
            if (A.GetLength(0) == B.GetLength(0) && A.GetLength(1) == B.GetLength(1))
            {
                int row = A.GetLength(0);
                int column = A.GetLength(1);
                Console.WriteLine("\n矩阵求和结果为：");
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        C[i, j] = A[i, j] + B[i, j];
                        Console.Write("{0}\0", C[i, j]);
                    }
                    Console.Write("\n");
                }
            }
            else
            {
                Console.WriteLine("\n您输入的两个矩阵具有不同的行列数！");
            }
            return C;
        }
        public static double[,] MultiplyMatrix(double[,] A, double[,] B)
        {
            int Arow = A.GetLength(0);
            int Acolumn = A.GetLength(1);
            int Brow = B.GetLength(0);
            int Bcolumn = B.GetLength(1);
            double[,] C = new double[Arow, Bcolumn];
            if (Acolumn == Brow)
            {
                Console.WriteLine("\n矩阵求积结果为：");
                for (int i = 0; i < Arow; i++)
                {
                    for (int j = 0; j < Bcolumn; j++)
                    {
                        C[i, j] = 0;
                        for (int k = 0; k < Acolumn; k++)
                        {
                            C[i, j] = C[i, j] + A[i, k] * B[k, j];
                        }
                        Console.Write("{0}\0", C[i, j]);
                    }
                    Console.Write("\n");
                }
            }
            else
            {
                Console.WriteLine("\n您输入的A矩阵的列数和B矩阵的行数不相等！");
            }
            return C;
        }
        public static double[,] InverseMatrix(double[,] A)
        {
            //判断是否为方阵以及是否可逆
            int m = A.GetLength(0);
            double[,] C = new double[m, m];
            int i, j, k;//计数
            double u, temp;//临时变量
            //初始单位阵
            for (i = 0; i < m; i++)
            {
                for (j = 0; j <= m - 1; j++)
                {
                    C[i, j] = (i == j) ? 1 : 0;
                }
            }
            // 求左下
            for (i = 0; i <= m - 2; i++)
            {
                //提取该行的主对角线元素
                u = A[i, i];   //可能为0
                if (u == 0)  //为0 时，在下方搜索一行不为0的行并交换
                {
                    for (i = 0; i < m; i++)
                    {
                        k = i;
                        for (j = i + 1; j < m; j++)
                        {
                            if (A[j, i] != 0) //不为0的元素
                            {
                                k = j;
                                break;
                            }
                        }
                        if (k != i) //如果没有发生交换： 情况1 下方元素也全是0
                        {
                            for (j = 0; j < m; j++)
                            {
                                //行交换
                                temp = A[i, j];
                                A[i, j] = A[k, j];
                                A[k, j] = temp;
                                //伴随交换
                                temp = C[i, j];
                                C[i, j] = C[k, j];
                                C[k, j] = temp;
                            }
                        }
                        else //满足条件1 弹窗提示
                            Console.WriteLine("不可逆矩阵", "ERROR");
                    }
                }
                for (j = 0; j < m; j++)//该行除以主对角线元素的值 使主对角线元素为1  
                {
                    A[i, j] = A[i, j] / u;   //分母不为0
                    C[i, j] = C[i, j] / u;  //伴随矩阵
                }
                for (k = i + 1; k < m; k++)  //下方的每一行减去  该行的倍数
                {
                    u = A[k, i];   //下方的某一行的主对角线元素
                    for (j = 0; j < m; j++)
                    {
                        A[k, j] = A[k, j] - u * A[i, j];  //下方的每一行减去该行的倍数  使左下角矩阵化为0
                        C[k, j] = C[k, j] - u * C[i, j];  //左下伴随矩阵
                    }
                }
            }
            u = A[m - 1, m - 1];  //最后一行最后一个元素
            if (u == 0) //条件2 初步计算后最后一行全是0 在只上步骤中没有计算最后一行，所以可能会遗漏
                Console.WriteLine("不可逆矩阵", "ERROR");
            A[m - 1, m - 1] = 1;
            for (j = 0; j < m; j++)
            {
                C[m - 1, j] = C[m - 1, j] / u;
            }
            // 求右上
            for (i = m - 1; i >= 0; i--)
            {
                for (k = i - 1; k >= 0; k--)
                {
                    u = A[k, i];
                    for (j = 0; j < m; j++)
                    {
                        A[k, j] = A[k, j] - u * A[i, j];
                        C[k, j] = C[k, j] - u * C[i, j];
                    }
                }
            }
            Console.WriteLine("\n矩阵求逆结果为：");
            for (int ii = 0; ii < C.GetLength(0); ii++)
            {
                for (int jj = 0; jj < C.GetLength(1); jj++)
                {
                    Console.Write("{0}\0", C[ii, jj]);
                }
                Console.Write("\n");
            }
            return C;
        }
    }
}