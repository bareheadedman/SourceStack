using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    static public class MimicStack
    {
        static int[] stack = new int[10];
        static int top = 0;
        static int bottom = 0;

        public static void Push(int count)
        {
            if (top <= stack.Length - 1)
            {
                stack[top] = count;
                top++;
            }
            else
            {
                Console.WriteLine("Stack Overflow");
            }
        }

        public static void Pop()
        {
            if (top != bottom)
            {
                top--;
                Console.WriteLine(stack[top]);
            }
            else
            {
                Console.WriteLine("栈已空");
            }
        }
    }
}
