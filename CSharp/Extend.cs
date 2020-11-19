using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public static class Extend
    {
        public static T Max<T>(this DLinkNode<T> dLink) where T : IComparable
        {
            DLinkNode<T> temp = new DLinkNode<T>();
            foreach (var item in dLink)
            {
                if (temp.Content.CompareTo(temp) >dLink.Content.CompareTo(temp))
                {
                    temp.Content = dLink.Content;
                }
            }

            return temp.Content;
        }
    }
}
