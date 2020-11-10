using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public class DLinkNode
    {
        public DLinkNode Previous { get; set; }
        public DLinkNode Next { get; set; }

        public void AddAfter(DLinkNode dLink)
        {
            if (this.Next != null)
            {
                dLink.Next = this.Next;
                this.Next.Previous = dLink;

            }
            this.Next = dLink;
            dLink.Previous = this;
        }

        public void AddFront(DLinkNode dLink)
        {
            if (this.Previous != null)
            {
                this.Previous.Next = dLink;
                dLink.Previous = this.Previous;

            }
            this.Previous = dLink;
            dLink.Next = this;

        }


        public void DeleteAfter()
        {
            if (this.Next.Next != null)
            {
                this.Next.Next.Previous = this;
                this.Next = this.Next.Next;
            }
            else
            {
                this.Next.Previous = null;
                this.Next = null;
            }
        }

        public void DeleteFront()
        {
            if (this.Previous.Previous != null)
            {
                this.Previous.Previous.Next = this;
                this.Previous = this.Previous.Previous;
            }
            else
            {
                this.Previous.Next = null;
                this.Previous = null;
            }
        }

        public void Delete()
        {

        }

        public void Swap(DLinkNode dlink)
        {

        }

    }
}
