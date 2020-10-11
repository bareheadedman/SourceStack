using System;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            String UserImages = Console.ReadLine();
            // 用户 头像

            String Female = Console.ReadLine();
            // 性别

            int Birthday = Convert.ToInt32(Console.ReadLine());
            //出生日期

            String KeyWord = Console.ReadLine();
            //关键字

            String SelfIntroduction = Console.ReadLine();
            //自我介绍

            Console.WriteLine(5+5);
            Console.WriteLine(5-5);
            Console.WriteLine(5/5);
            Console.WriteLine(5*5);

            Console.WriteLine(((23 + 7) * 12 - 8) / 6F);            

            int i = 15;
            Console.WriteLine(i++);   
            i -= 5;                   
            Console.WriteLine(i);    
            Console.WriteLine(i >= 10);  

            Console.WriteLine("i值的最终结果为：" + i); 

            int j = 20;
            Console.WriteLine($"{i}+{j}={i + j}");  
           

            int a = 10;
            Console.WriteLine(a > 9 && (!(a < 11) || a > 10));

            
            a = 10;
            bool result = (a + 3 > 12) && a < 3.14 * 4 && a != 11;
            Console.WriteLine(result);
        }
    }
}
