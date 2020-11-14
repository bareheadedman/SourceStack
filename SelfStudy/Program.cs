using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text.Json;

namespace SelfStudy
{
    public class Program
    {

        static void Main(string[] args)
        {

            //Queue<Student> kk = new Queue<Student>();

            //Student lw = new Student();
            //Student gty = new Student();
            //Student lzb = new Student();


            //kk.Enqueue(lw);
            //kk.Enqueue(gty);
            //kk.Enqueue(lzb);
            //Console.WriteLine(kk.TryPeek(out Student result));




            foreach (var item in new Person())
            {
                Console.WriteLine(item);
            }




            IList<Student> kk = new List<Student>
            {
            new Student(){name= "ss",age =22},
            new Student(){name= "qq",age =23},
            new Student(){name= "zz",age =72},

            };

            foreach (var item in kk)
            {
                Console.WriteLine(item.age);
            }





        }
    }












}
