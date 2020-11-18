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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        struct Enumerator : IEnumerator
        {

            private object _current;
            public object Current => _current;


            //T IEnumerator<T>.Current => throw new NotImplementedException();

            private int _index;
            public Person Person1;


            public Enumerator(Person person)
            {
                Person1 = person;
                _index = 0;
                //_current = students[_index];
                _current = Person1.students[_index];

            }


            public bool MoveNext()
            {
                if (_index >= Person1.students.Length)
                {
                    return false;
                }

                _current = Person1.students[_index];
                _index++;

                return true;
            }


            public void Reset()
            {
                throw new NotImplementedException();
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
    }
}
