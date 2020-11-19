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
                if (temp.Content.CompareTo(temp.Content) >dLink.Content.CompareTo(temp.Content))
                {
                    temp.Content = dLink.Content;
                }
            }

            return temp.Content;
        }
    }
}
