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
        object[] element;
        int top = 0;
        const int bottom = 0;


        public MimicStack(int size)
        {
            element = new object[size];
        }

        public void Push(object element)
        {
            if (top <= this.element.Length - 1)
            {
                this.element[top] = element;
                top++;
            }
            else
            {
                Console.WriteLine("Stack Overflow");
            }
        }


        public void Push(params object[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Push(array[i]);
            }
        }

        public object Pop()
        {
            if (top != bottom)
            {
                top--;
                return element[top];
            }
            else
            {
                Console.WriteLine("栈已空");
                return -1;
            }
        }
    }
}
