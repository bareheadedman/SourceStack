using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SelfStudy
{
    public class Person : IEnumerable
    {
       public Student[] students = new Student[]
        {
          new Student(){ name = "lw",age = 44},
          new Student(){ name = "zdh",age = 21},
          new Student(){ name = "gty",age = 26},
          new Student(){ name = "lgy",age = 28},
          new Student(){ name = "lzb",age = 91},
          new Student(){ name = "zl",age =33},

        };

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        struct Enumerator : IEnumerator
        {

            private object _current;
            public object Current => _current;

            private int _index;
            Student[] students;

            public Enumerator(Person person)
            {
                students = person.students;
                _index = 0;
                _current = students[_index];
            }
            public bool MoveNext()
            {
                if (_index >= students.Length)
                {
                    return false;
                }

                _current = students[_index];
                _index++;

                return true;
            }


            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}
