using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Author:WuYang
//Created_Time:2022-11-16 19:32
//LastEdit_Time:2022-11-15 01:55

namespace GC6.StudentRanking
{
    struct StudentInfo
    {
        public string Name;
        public string Grade;
        public int Score;
        public int Rank;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入该班学生人数：");
            int StudentAmount = Convert.ToInt32(Console.ReadLine());
            StudentRanking.StudentRank(StudentAmount);
        } 
    }
    class StudentRanking
    {
        public static void StudentRank(int parStudentAmount)
        {
            int N = parStudentAmount;
            Random random = new Random();
            StudentInfo[] Student = new StudentInfo[N];

            //输入学生姓名和分数
            for (int i = 0; i < Student.Length; i++)
            {
                Student[i].Name = Name.GetName();
                Student[i].Score = random.Next(50, 101);
                //Console.WriteLine("{0},{1}", Student[i].Name, Student[i].Score);
            }

            //排序
            for (int i = 0; i < Student.Length; i++)
            {
                for (int j = 0; j < Student.Length; j++)
                {
                    if (Student[i].Score > Student[j].Score)
                    {
                        int temper1 = Student[j].Score;
                        Student[j].Score = Student[i].Score;
                        Student[i].Score = temper1;
                        string temper2 = Student[j].Name;
                        Student[j].Name = Student[i].Name;
                        Student[i].Name = temper2;
                    }
                }
            }

            //Rank&&Grade
            for (int i = 0; i < Student.Length; i++)
            {
                Student[i].Rank = i + 1;
                Student[i].Grade = Grade.GradeEvaluate(Student[i].Score);
            }

            //平均分
            double SumScore = 0;
            double AverageScore = 0;
            for (int i = 0; i < Student.Length; i++)
            {
                SumScore = SumScore + Student[i].Score;
                AverageScore = SumScore / Student.Length;
            }

            //优秀率
            int ExcellentCount = 0;
            double ExcellentRate;
            for (int i = 0; i < Student.Length; i++)
            {
                if (Student[i].Score >= 90)
                {
                    ExcellentCount++;
                }
            }
            ExcellentRate = ExcellentCount / Convert.ToDouble(Student.Length) * 100;

            //输出结果
            Console.WriteLine("\n---------------------------------------------------------------------------------------------");
            string OutAverageScore = Math.Round(AverageScore, 2).ToString("0.00");
            string OutExcellentRate = Math.Round(ExcellentRate, 2).ToString("0.00");
            Console.WriteLine("该班共有{0}位同学，他们成绩的平均分为：{1}，优秀率为{2}%\n", N, OutAverageScore, OutExcellentRate);
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine("全班前五名同学的成绩为：");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("{0},{1},{2},{3}", Student[i].Rank, Student[i].Name, Student[i].Score, Student[i].Grade);
            }
            Console.WriteLine("\n---------------------------------------------------------------------------------------------");
            Console.WriteLine("全班所有同学的成绩为：");
            for (int i = 0; i < Student.Length; i++)
            {
                Console.WriteLine("{0},{1},{2},{3}", Student[i].Rank, Student[i].Name, Student[i].Score, Student[i].Grade);
            }
            Console.ReadKey();
        }
    }
    class Name
    {
        public static Random random = new Random();
        public static string GetName()
        {
            //姓名字典
            #region LastNameDictionary
            string[] LastName ={
                "赵", "钱", "孙", "李", "周", "吴", "郑", "王", "冯", "陈", "褚", "卫", "蒋", "沈", "韩", "杨",
        "朱", "秦", "尤", "许", "何", "吕", "施", "张", "孔", "曹", "严", "华", "金", "魏", "陶", "姜",
        "戚", "谢", "邹", "喻", "柏", "水", "窦", "章", "云", "苏", "潘", "葛", "奚", "范", "彭", "郎",
        "鲁", "韦", "昌", "马", "苗", "凤", "花", "方", "俞", "任", "袁", "柳", "酆", "鲍", "史", "唐",
        "费", "廉", "岑", "薛", "雷", "贺", "倪", "汤", "滕", "殷", "罗", "毕", "郝", "邬", "安", "常",
        "乐", "于", "时", "傅", "皮", "卞", "齐", "康", "伍", "余", "元", "卜", "顾", "孟", "平", "黄",
        "和", "穆", "萧", "尹", "姚", "邵", "湛", "汪", "祁", "毛", "禹", "狄", "米", "贝", "明", "臧",
        "计", "伏", "成", "戴", "谈", "宋", "茅", "庞", "熊", "纪", "舒", "屈", "项", "祝", "董", "梁",
        "杜", "阮", "蓝", "闽", "席", "季", "麻", "强", "贾", "路", "娄", "危", "江", "童", "颜", "郭",
        "梅", "盛", "林", "刁", "锺", "徐", "丘", "骆", "高", "夏", "蔡", "田", "樊", "胡", "凌", "霍",
        "虞", "万", "支", "柯", "昝", "管", "卢", "莫", "经", "房", "裘", "缪", "干", "解", "应", "宗",
        "丁", "宣", "贲", "邓", "郁", "单", "杭", "洪", "包", "诸", "左", "石", "崔", "吉", "钮", "龚",
        "程", "嵇", "邢", "滑", "裴", "陆", "荣", "翁", "荀", "羊", "於", "惠", "甄", "麹", "家", "封",
        "芮", "羿", "储", "靳", "汲", "邴", "糜", "松", "井", "段", "富", "巫", "乌", "焦", "巴", "弓",
        "牧", "隗", "山", "谷", "车", "侯", "宓", "蓬", "全", "郗", "班", "仰", "秋", "仲", "伊", "宫",
        "宁", "仇", "栾", "暴", "甘", "斜", "厉", "戎", "祖", "武", "符", "刘", "景", "詹", "束", "龙",
        "叶", "幸", "司", "韶", "郜", "黎", "蓟", "薄", "印", "宿", "白", "怀", "蒲", "邰", "从", "鄂",
        "索", "咸", "籍", "赖", "卓", "蔺", "屠", "蒙", "池", "乔", "阴", "郁", "胥", "能", "苍", "双",
        "闻", "莘", "党", "翟", "谭", "贡", "劳", "逄", "姬", "申", "扶", "堵", "冉", "宰", "郦", "雍",
        "郤", "璩", "桑", "桂", "濮", "牛", "寿", "通", "边", "扈", "燕", "冀", "郏", "浦", "尚", "农",
        "温", "别", "庄", "晏", "柴", "瞿", "阎", "充", "慕", "连", "茹", "习", "宦", "艾", "鱼", "容",
        "向", "古", "易", "慎", "戈", "廖", "庾", "终", "暨", "居", "衡", "步", "都", "耿", "满", "弘",
        "匡", "国", "文", "寇", "广", "禄", "阙", "东", "欧", "殳", "沃", "利", "蔚", "越", "夔", "隆",
        "师", "巩", "厍", "聂", "晁", "勾", "敖", "融", "冷", "訾", "辛", "阚", "那", "简", "饶", "空",
        "曾", "毋", "沙", "乜", "养", "鞠", "须", "丰", "巢", "关", "蒯", "相", "查", "后", "荆", "红",
        "游", "竺", "权", "逑", "盖", "益", "桓", "公", "仉", "督", "晋", "楚", "阎", "法", "汝", "鄢",
        "涂", "钦", "岳", "帅", "缑", "亢", "况", "后", "有", "琴", "归", "海", "墨", "哈", "谯", "笪",
        "年", "爱", "阳", "佟", "商", "牟", "佘", "佴", "伯", "赏",
        "万俟", "司马", "上官", "欧阳", "夏侯", "诸葛", "闻人", "东方", "赫连", "皇甫", "尉迟", "公羊",
        "澹台", "公冶", "宗政", "濮阳", "淳于", "单于", "太叔", "申屠", "公孙", "仲孙", "轩辕", "令狐",
        "锺离", "宇文", "长孙", "慕容", "鲜于", "闾丘", "司徒", "司空", "丌官", "司寇", "子车", "微生",
        "颛孙", "端木", "巫马", "公西", "漆雕", "乐正", "壤驷", "公良", "拓拔", "夹谷", "宰父", "谷梁",
        "段干", "百里", "东郭", "南门", "呼延", "羊舌", "梁丘", "左丘", "东门", "西门", "南宫"};
            #endregion
            #region FirstNameDictionary
            string parFirstName = "刚伟;勇毅;俊峰;强军;平;保;东文;辉力;明永;健世;广志;义兴;良海;山仁;波宁;贵福;生龙;元全;国胜;学祥;才发;武新;利清;飞彬;富顺;信子;杰涛;昌成;康星;光天;达安;岩中;茂进;林有;坚和;彪博;诚先;敬震;振壮;会思;群豪;心邦;承乐;绍功;" +
                    "秀娟;英华;慧巧;美娜;静淑;惠珠;翠雅;芝玉;萍红;娥玲;芬芳;燕彩;春菊;兰凤;洁梅;琳素;云莲;真环;雪荣;爱妹;霞香;月莺;媛艳;瑞凡;佳嘉;琼勤;珍贞;莉桂;娣叶;璧璐;娅琦;晶妍;茜秋;珊莎;锦黛;青倩;婷姣;婉娴;瑾颖;露瑶;怡婵;雁蓓;纨仪;荷丹;蓉眉;君琴;蕊薇;菁梦;岚苑;婕馨;瑗琰";
            string[] FirstName = parFirstName.Split(';');
            #endregion
            //随机取姓和名，并将它们组合起来
            string FN = FirstName[random.Next(0, FirstName.Length)];
            string LN = LastName[random.Next(0, LastName.Length)];
            return LN + FN;
        }
    }
    class Grade
    {
        //根据输入的分数，使用SwitchCase语句将分数分为6个等级
        public static string GradeEvaluate(double parScore)
        {
            string GradeLevel;
            double Score = parScore;
            int number = Convert.ToInt32(Math.Floor(Score / 10));
            switch (number)
            {
                case 10:
                    GradeLevel = "满分";
                    break;
                case 9:
                    GradeLevel = "优秀";
                    break;
                case 8:
                    GradeLevel = "好";
                    break;
                case 7:
                    GradeLevel = "良";
                    break;
                case 6:
                    GradeLevel = "及格";
                    break;
                default:
                    GradeLevel = "不及格";
                    break;
            }
            return GradeLevel;
        }
    }
}