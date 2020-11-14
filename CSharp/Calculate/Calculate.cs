using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Calculate
{
    public static class Calculate<T>
    {

        public static int Sum(int a, int b)
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
