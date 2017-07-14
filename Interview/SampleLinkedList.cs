using System;
using System.Collections.Generic;

namespace Interview
{
    public static class SampleLinkedList
    {
        private static LinkedList<string> linkList = new LinkedList<string>();
        private static LinkedListNode<string> linkNode;
        public static void SampleMethod()
        {
            linkList.AddLast("Amith Shah");
            linkList.AddLast("Manohar Parikar");
            linkList.AddLast("Rahul Gandhi");
            linkList.AddLast("Sonia");
            linkList.AddLast("Modi");
            linkList.AddLast("Atal");
            linkList.Remove("Rahul Gandhi");

            linkNode = linkList.Find("Sonia");

            linkList.AddBefore(linkNode, "Nehru");
            linkList.AddAfter(linkNode, "Feroz");

            foreach (string st in linkList)
            {
                Console.WriteLine(st);
            }
        }

    }
}
