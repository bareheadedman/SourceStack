using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{



    //    自己实现一个模拟栈（MimicStack）类，入栈出栈数据均为int类型，包含如下功能：
    //出栈Pop()，弹出栈顶数据
    //入栈Push()，可以一次性压入多个数据
    //出/入栈检查，
    //如果压入的数据已超过栈的深度（最大容量），提示“栈溢出”
    //如果已弹出所有数据，提示“栈已空”




    public class MimicStack
    {
        int[] stack;
        int top = 0;
        const int bottom = 0;


        public MimicStack(int size)
        {
            stack = new int[size];
        }

        public void Push(int element)
        {
            if (top <= stack.Length - 1)
            {
                stack[top] = element;
                top++;
            }
            else
            {
                Console.WriteLine("Stack Overflow");
            }
        }


        public void Push(params int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Push(array[i]);
            }
        }

        public int Pop()
        {
            if (top != bottom)
            {
                top--;
                return stack[top];
            }
            else
            {
                Console.WriteLine("栈已空");
                return -1;
            }
        }
    }
}
