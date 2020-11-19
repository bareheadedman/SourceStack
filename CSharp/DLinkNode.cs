using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp
{
    public class DLinkNode<T> : IEnumerable<DLinkNode<T>> 
    {
        //List<int>
        public DLinkNode<T> Previous { get; set; }
        public DLinkNode<T> Next { get; set; }
        public T Content { get; set; }

        public void AddAfter(DLinkNode<T> dLink)
        {
            if (this.Next != null)
            {
                dLink.Next = this.Next;
                this.Next.Previous = dLink;

            }
            this.Next = dLink;
            dLink.Previous = this;
        }
        public void AddBefore(DLinkNode<T> dLink)
        {
            if (this.Previous != null)
            {
                this.Previous.Next = dLink;
                dLink.Previous = this.Previous;

            }
            this.Previous = dLink;
            dLink.Next = this;

        }
        public void Delete()
        {


            if (this.Previous == null)
            {
                this.Next.Previous = null;
                this.Next = null;

            }
            else if (this.Next == null)
            {
                this.Previous.Next = null;
                this.Previous = null;
            }
            else
            {
                this.Next.Previous = this.Previous;
                this.Previous.Next = this.Next;
                this.Previous = null;
                this.Next = null;

            }

        }

        public void Swap(DLinkNode<T> dlink)
        {
            DLinkNode<T> PrvThis = this.Previous;
            DLinkNode<T> NextThis = this.Next;
            this.Delete();

            if (PrvThis == dlink)
            {
                dlink.AddBefore(this);
            }
            else if (NextThis == dlink)
            {
                dlink.AddAfter(this);
            }
            else
            {
                dlink.AddAfter(this);
                dlink.Delete();
                if (PrvThis != null)
                {
                    PrvThis.AddAfter(dlink);
                }
                else
                {
                    NextThis.AddBefore(dlink);
                }

            }





        }


        //让之前的双向链表，能够：被foreach迭代

        public IEnumerator<DLinkNode<T>> GetEnumerator()
        {
            return new Enumerator<T>(this);

        }


        private DLinkNode<T> getFirstDlink()
        {
            DLinkNode<T> head = this;
            while (head.Previous != null)
            {
                head = head.Previous;
            }

            return head;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            //throw new NotImplementedException();
            return GetEnumerator();
        }

        struct Enumerator<T> : IEnumerator<DLinkNode<T>> 
        {

            public Enumerator(DLinkNode<T> dLink)
            {
                _index = dLink;
                _current = _index;
                ThisDlink = dLink;
                FirstDlink = dLink.getFirstDlink();
            }

            private DLinkNode<T> _current;
            public object Current => _current;

            DLinkNode<T> IEnumerator<DLinkNode<T>>.Current => _current;

            private DLinkNode<T> _index;


            public DLinkNode<T> FirstDlink;

            public DLinkNode<T> ThisDlink;




            public bool MoveNext()
            {



                if (_index != null)
                {
                    _current = _index;
                    _index = _index.Next;

                    return true;
                }
                else
                {


                    if (FirstDlink == ThisDlink)
                    {
                        return false;

                    }

                    _current = FirstDlink;
                    FirstDlink = FirstDlink.Next; ;

                    return true;

                }



            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            public void Dispose()
            {

            }
        }




    }
}
