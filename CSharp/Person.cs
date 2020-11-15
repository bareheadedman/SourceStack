using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public class Person
    {
        public string Name;
        public int Water;


        public static void GetWater(ProvideWater provideWater,Person person)
        {
            Console.WriteLine(provideWater(person));
        }

        public static int GoWater(Person person)
        {
            return person.Water += 5;
        }
    }

    public delegate int ProvideWater(Person person);







}
