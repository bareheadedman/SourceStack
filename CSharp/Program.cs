using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Globalization;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Xml;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {


            //观察一起帮个人资料页面，用合适的变量类型存储页面用户输入信息，并解释为什么。

            //String UserImages = Console.ReadLine();
            // 用户 头像

            //String Female = Console.ReadLine();
            // 性别

            //int Birthday = Convert.ToInt32(Console.ReadLine());
            //出生日期

            //String KeyWord = Console.ReadLine();
            //关键字

            //String SelfIntroduction = Console.ReadLine();
            //自我介绍







            //            输出两个整数 / 小数的和 / 差 / 积 / 商

            //Console.WriteLine(Sum(5,5));
            //Console.WriteLine(Difference(5,5));
            //Console.WriteLine(Product(5,5));
            //Console.WriteLine(Division(5,5));

            //电脑计算并输出：[(23 + 7)x12-8]÷6的小数值（挑战：精确到小数点以后2位）
            //Console.WriteLine(((23 + 7) * 12 - 8) / 6F);

            //想一想以下语句输出的结果：
            //    int i = 15;
            //            Console.WriteLine(i++);
            //            i -= 5;
            //            Console.WriteLine(i);
            //            Console.WriteLine(i >= 10);

            //            Console.WriteLine("i值的最终结果为：" + i);

            //             i=11

            //            int j = 20;
            //            Console.WriteLine($"{i}+{j}={i + j}");



            //            想一想如下代码的结果是什么，并说明原因：
            //    int a = 10;
            //            Console.WriteLine(a > 9 && (!(a < 11) || a > 10));

            // false

            //            当a为何值时，结果为true？
            //int a = 10;
            //bool result = (a + 3 > 12) && a < 3.14 * 4 && a != 11;









            //            观察一起帮登录页面，用if...else ...完成以下功能。

            //用户依次由控制台输入：验证码、用户名和密码：

            //如果验证码输入错误，直接输出：“*验证码错误”；
            //如果用户名不存在，直接输出：“*用户名不存在”；
            //如果用户名或密码错误，输出：“*用户名或密码错误”
            //以上全部正确无误，输出：“恭喜！登录成功！”
            //PS：验证码 / 用户名 / 密码直接预设在源代码中，输入由Console.ReadLine()完成

            //string cause;
            //if (Users("qz12s", "jkl123", "q123", out cause))
            //{
            //    Console.WriteLine(cause);
            //}
            //else
            //{
            //    Console.WriteLine(cause);
            //}





            //            将源栈同学姓名 / 昵称分别：
            //按进栈时间装入一维数组，

            //string[] student = { "刘", "周", "李", "邹", "龚", "廖" };

            //按座位装入二维数组，

            //string[,] student = new string[3, 3];
            //student[0, 1] = "刘";
            //student[0, 2] = "龚";
            //student[1, 0] = "李";
            //student[1, 1] = "周";
            //student[1, 2] = "廖";
            //student[2, 1] = "邹";

            //并输出共有多少名同学。

            //Console.WriteLine(student.Length);





            //            分别用for循环和while循环输出：1,2,3,4,5 和 1,3,5,7,9

            //for (int i = 1; i < 6; i++)
            //{
            //    Console.WriteLine(i);
            //}

            //int i = 1;
            //while (i<10)
            //{
            //    Console.WriteLine(i);
            //    i += 2;

            //}

            //用for循环输出存储在一维 / 二维数组里的源栈所有同学姓名 / 昵称
            //OneStudents(student);




            //TwoStudentS(student);





            //让电脑计算并输出：99 + 97 + 95 + 93 + ...+1的值

            //Console.WriteLine(Accumulation(99));chen


            //        将源栈同学的成绩存入一个double数组中，用循环找到最高分和最低分

            //double[] score = { 23.5, 15.4, 35.7, 54.8, 96.8, 84.3, 99.1 };

            //Console.WriteLine(maxormin(score,false));

            //        找到100以内的所有质数（只能被1和它自己整除的数）

            //for (int i = 0; i < 100; i++)
            //{
            //    for (int j = 2; j < i; j++)
            //    {
            //        if (i % j > 0)
            //        {
            //            if (j == i - 1)
            //            {
            //                Console.WriteLine(i);

            //            }// else
            //        }
            //        else
            //        {
            //            break;
            //        }

            //    }
            //}


            //生成一个元素（值随机）从小到大排列的数组
            //int[] student = new int[5];
            //student=random(student);


            //设立并显示一个多维数组的值，元素值等于下标之和。Console.Write()

            //MoreArray();


            //            将之前作业封装成方法（自行思考参数和返回值），并调用执行。且以后作业，如无特别声明，皆需使用方法封装。


            //计算得到源栈同学的平均成绩（精确到两位小数），方法名GetAverage()

            //double [] student = { 95.3, 92.6 };

            //Console.WriteLine(GetAverage(student));


            //完成“猜数字”游戏，方法名GuessMe()：
            //GuessMe();
            //随机生成一个大于0小于1000的整数
            //用户输入一个猜测值，系统进行判断，告知用户猜测的数是“大了”，还是“小了”
            //没猜中可以继续猜，但最多不能超过10次
            //如果5次之内猜中，输出：你真牛逼！
            //如果8次之内猜中，输出：不错嘛！
            //10次还没猜中，输出：(～￣(OO)￣)ブ






            //            利用ref调用Swap()方法交换两个同学的床位号
            //int lw = 1001;
            //int gty = 6001;
            //Swap(ref lw, ref gty);


            //将登陆的过程封装成一个方法LogOn()，调用之后能够获得：
            //true / false，表示登陆是否成功
            //string，表示登陆失败的原因


            //string reason;
            //if (Logon("lw","12345", out reason))
            //{
            //    Console.WriteLine(reason);
            //}
            //else
            //{
            //    Console.WriteLine(reason);
            //}



            //定义一个生成数组的方法：int[] GetArray()，其元素随机生成从小到大排列。利用可选参数控制：
            //最小值min（默认为1）
            //         相邻两个元素之间的最大差值gap（默认为5）
            //         元素个数length（默认为10个）

            //int[] array = new int[10];
            //GetArray(array, 5);
            //for (int i = 0; i < array.Length; i++)
            //{
            //    Console.WriteLine(array[i]);
            //}


            //实现二分查找，方法名BinarySeek(int[] numbers, int target)：
            //         传入一个有序（从大到小 / 从小到大）数组和数组中要查找的元素
            //         如果找到，返回该元素所在的下标；否则，返回 - 1

            //int[] seek = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };

            //Console.WriteLine(BinarySeek(seek,12));


            // 冒泡排序


            //bubbleSort(array, true);
            //for (int i = 0; i < array.Length; i++)
            //{
            //    Console.WriteLine(array[i]);
            //}

            //HelpMoney money = new HelpMoney { };

            //money.Sava(money);
            //            观察“一起帮”的：
            //注册 / 登录功能，定义一个User类，包含字段：Name（用户名）、Password（密码）和 邀请人（InvitedBy），和方法：Register()、Login()
            //求助版块，定义一个类Problem，包含字段：标题（Title）、正文（Body）、悬赏（Reward）、发布时间（PublishDateTime）和作者（Author），和方法Publish()
            //帮帮币版块，定义一个类HelpMoney，表示一行帮帮币交易数据，包含你认为应该包含的字段和方法
            //为这些类的字段和方法设置合适的访问修饰符。

            //DateTime dt = DateTime.Now;
            //Console.WriteLine(string.Format("{0:f}", dt));


            //快排


            //int[] array = { 4, 2, 9, 11, 5, 0, 55, 6, 4 };

            //Sort(array, 0, array.Length - 1);

            //QuickSort(array, 0, array.Length - 1);
            //for (int i = 0; i < array.Length; i++)
            //{
            //    Console.WriteLine(array[i]);
            //}










            //            将之前User / Problem / HelpMoney类的字段封装成属性，其中：
            //user.Password在类的外部只能改不能读
            //如果user.Name为“admin”，输入时修改为“系统管理员”

            //User lw = new User("admin", "1552");
            //lw.Name = "admin";
            //Console.WriteLine();



            //problem.Reward不能为负数

            //Problem lw = new Problem("512");
            //lw.Reward = (-32);



            //调用这些类的有参 / 无参构造函数，生成这些类的对象，调用他们的方法
            //  一起帮的求助可以有多个（最多10个）关键字，请为其设置索引器，以便于我们通过其整数下标进行读写。

            //Problem lw = new Problem("123");
            //lw[1] = "关键字256";
            //lw[2] = "关键字985";
            //Console.WriteLine(lw[2]);

            //设计一种方式，保证：
            //每一个Problem对象一定有Body赋值
            //每一个User对象一定有Name和Password赋值







            //            定义一个仓库（Repoistory）类，用于存取对象，其中包含：
            //一个int类型的常量version
            //一个静态只读的字符串connection，以后可用于连接数据库

            //思考Respoitory应该是static类还是实例类更好
            //考虑求助（Problem）的以下方法 / 属性，哪些适合实例，哪些适合静态，然后添加到类中：
            //Publish()：发布一篇求助，并将其保存到数据库
            //Load(int Id)：根据Id从数据库获取一条求助
            //Delete(int Id)：根据Id删除某个求助
            //repoistory：可用于在底层实现上述方法和数据库的连接操作等

            //设计一个类FactoryContext，保证整个程序运行过程中，无论如何，外部只能获得它的唯一的一个实例化对象。（提示：设计模式之单例）

            //FactoryContext lw = FactoryContext.GetFactoryContext();



            //想一想，为什么Publish()方法不是放置在User类中呢？用户（user）发布（Publish）一篇文章（article），不正好是user.Publish(article)么？

            //自己实现一个模拟栈（MimicStack）类，入栈出栈数据均为int类型，包含如下功能：
            //出栈Pop()，弹出栈顶数据
            //入栈Push()，可以一次性压入多个数据
            //出 / 入栈检查，
            //如果压入的数据已超过栈的深度（最大容量），提示“栈溢出”
            //如果已弹出所有数据，提示“栈已空”

            //for (int i = 100; i < 110; i++)
            //{
            //    MimicStack.Push(i);

            //}


            //for (int i = 0; i < 11; i++)
            //{
            //    MimicStack.Pop();

            //}



            //            让User类无法被继承

            //观察一起帮的求助（Problem）、文章（Article）和意见建议（Suggest），根据他们的特点，抽象出一个父类：内容（Content）

            //Content中有一个字段：kind，记录内容的种类（problem / article / suggest等），只能被子类使用

            //    确保每个Content对象都有kind的非空值
            //Content中的createTime，不能被子类使用，但只读属性PublishTime使用它为外部提供内容的发布时间
            //其他方法和属性请自行考虑，尽量贴近一起帮的功能实现。
            //实例化文章和意见建议，调用他们：
            //继承自父类的属性和方法
            //自己的属性和方法
            //再为之前所有类（含User、HelpMoney等）抽象一个基类：Entity，包含一个只读的Id属性。试一试，Suggest能有Id属性么？








        }

        static int Sum(int a, int b)
        {
            return a + b;
        }

        static int Difference(int a, int b)
        {
            return a - b;
        }

        static int Product(int a, int b)
        {
            return a * b;
        }

        static int Division(int a, int b)
        {
            return a / b;
        }


        static bool Users(string UserSecurityCode, string UserName, string UserPassWord, out string cause)
        {
            string SecurityCode = "qz12s";
            string Name = "jkl123";
            string PassWord = "q123";
            if (UserSecurityCode == SecurityCode)
            {
                if (UserName == Name && UserPassWord == PassWord)
                {
                    cause = "恭喜！登录成功";
                    return true;
                }
                else
                {
                    cause = "用户名或密码错误";
                    return false;
                }

            }
            else
            {
                cause = "验证码错误";
                return false;
            }
        }



        static int SumStudent(string[] student)
        {
            return student.Length;
        }

        static void Students(string[] student)
        {
            for (int i = 0; i < student.Length; i++)
            {
                Console.WriteLine(student[i]);
            }

        }


        static void Students(string[,] student)
        {
            for (int i = 0; i < student.GetLength(0); i++)
            {
                for (int j = 0; j < student.GetLength(1); j++)
                {
                    Console.WriteLine(student[i, j]);
                }
            }
        }


        static int Accumulation(int a)
        {
            int sum = 0;
            for (int i = a; i > 0; i -= 2)
            {
                sum += i;
            }
            return sum;
        }


        static double maxormin(double[] score, bool maxormin)
        {

            double max = 0, min = score[0];

            for (int i = 0; i < score.Length; i++)
            {
                if (max < score[i])
                {
                    max = score[i];
                }//else
                if (min > score[i])
                {
                    min = score[i];
                }//else
            }

            if (maxormin)
            {
                return max;
            }
            else
            {
                return min;
            }

        }


        static int[] random(int[] a)
        {
            Random ran = new Random();
            int[] Random = new int[a.Length];
            Random[0] = ran.Next();
            for (int i = 1; i < a.Length; i++)
            {
                while (true)
                {
                    int temp = ran.Next();
                    if (temp > Random[i - 1])
                    {
                        Random[i] = temp;
                        break;
                    }//else
                }
            }
            return Random;
        }


        static void MoreArray()
        {
            int[,] moreArray = new int[3, 4];

            for (int i = 0; i < moreArray.GetLength(0); i++)
            {
                for (int j = 0; j < moreArray.GetLength(1); j++)
                {
                    moreArray[i, j] = j + i;
                    Console.Write(moreArray[i, j]);
                }
                Console.WriteLine();
            }
        }


        static void GuessMe()
        {
            Random ran = new Random();
            int RandKey = ran.Next(0, 1000);
            string Output = null;
            string Hint = null;
            Console.WriteLine("请输入一个不超过1000的自然数");
            for (int i = 9; i >= 0; i--)
            {
                int UserInput = Convert.ToInt32(Console.ReadLine());
                if (UserInput == RandKey)
                {
                    if (i > 5)
                    {
                        Output = "你真牛逼！";
                        break;
                    }
                    else
                    {
                        Output = "不错嘛";
                        break;
                    }

                }
                else if (i == 0)
                {
                    Output = "(～￣(OO)￣)ブ";
                    break;
                }
                else if (UserInput > RandKey)
                {
                    Hint = "太大了";
                }
                else if (UserInput < RandKey)
                {
                    Hint = "太小了";
                }

                Console.WriteLine($"数字{Hint},还剩{i}次");
            }
            Console.WriteLine(Output);
        }

        static double GetAverage(double[] a)
        {
            double sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];
            }
            sum /= a.Length;
            string temp = sum.ToString("0.00");
            double avg = Convert.ToDouble(temp);
            return avg;
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void Swap(int[] array, int a, int b)
        {
            int temp;
            temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }


        static bool Logon(string userName, string userPassWord, out string reason)
        {
            string name = "lw";
            string passWord = "12345";

            if (name == userName && passWord == userPassWord)
            {
                reason = "登录成功";
                return true;
            }
            else
            {
                reason = "账号或密码错误";
                return false;
            }
        }


        static void GetArray(int[] array, int a)
        {
            Random random = new Random();
            array[0] = random.Next(a);
            for (int i = 1; i < array.Length; i++)
            {
                array[i] = random.Next(a) + array[i - 1];
            }
        }

        static int BinarySeek(int[] numbers, int target)
        {
            int left = 0;
            int right = numbers.Length - 1;
            int middle;
            while (left <= right)
            {
                middle = (left + right) / 2;
                if (target > numbers[middle])
                {
                    left = middle + 1;
                }
                else if (target < numbers[middle])
                {
                    right = middle - 1;
                }
                else
                {
                    return middle;
                }
            }
            return -1;
        }

        static void bubbleSort(int[] array, bool lowToHigh)
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i; j++)
                {
                    if (lowToHigh)
                    {
                        if (array[j] > array[j + 1])
                        {
                            Swap(array, j, j + 1);
                        }//else
                    }
                    else
                    {
                        if (array[j] < array[j + 1])
                        {
                            Swap(array, j, j + 1);
                        }//else 
                    }
                }
            }
        }

        static void QuickSort(int[] array, int left, int right)
        {
            if (left >= right)
            {
                return;
            }
            int pivot = array[left];
            int l = left, r = right;

            while (l < r)
            {
                while (l < r)
                {
                    if (pivot <= array[r])
                    {
                        r--;
                    }
                    else
                    {
                        Swap(array, l, r);
                        break;
                    }
                }
                while (l < r)
                {
                    if (array[l] <= pivot)
                    {
                        l++;
                    }
                    else
                    {
                        Swap(array, l, r);
                        break;
                    }
                }
            }

            QuickSort(array, left, r - 1);
            QuickSort(array, r + 1, right);

        }


        static int Partition(int[] array, int low, int high)
        {
            //1. Select a pivot point.
            int pivot = array[high];

            int lowIndex = (low - 1);

            //2. Reorder the collection.
            for (int j = low; j < high; j++)
            {
                if (array[j] <= pivot)
                {
                    lowIndex++;

                    int temp = array[lowIndex];
                    array[lowIndex] = array[j];
                    array[j] = temp;
                }
            }

            int temp1 = array[lowIndex + 1];
            array[lowIndex + 1] = array[high];
            array[high] = temp1;

            return lowIndex + 1;
        }

        static void Sort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = Partition(array, low, high);

                //3. Recursively continue sorting the array
                Sort(array, low, partitionIndex - 1);
                Sort(array, partitionIndex + 1, high);
            }
        }

    }


}

