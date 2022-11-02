using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelingCalculation
{
    class LC
    {
        public string KnPName;      //定义已知点点名
        public string UnPName;      //定义未知点点名
        public double UnPElev;      //定义未知点高程
        public double KnPElev;      //定义已知点高程
        public double deltaElev;     //定义高差   

        //定义计算未知点高程的方法
        public double KPE(double @KnPElev, double @deltaElev)
        {
            double @UnPElev = @KnPElev + @deltaElev;
            return @UnPElev;
        }
    }
}
