﻿using System;
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

        public void AddBefore(DLinkNode dLink)
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

        public void Swap(DLinkNode dlink)
        {
            DLinkNode PrvThis = this.Previous;
            DLinkNode NextThis = this.Previous;

            this.Delete();

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
}
