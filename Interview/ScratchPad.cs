using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{

    public class LinkedList
    {

        public LinkedList()
        {
            head = new Node();
            current = head;

        }


        public void AddAtLast(object data)
        {
            Node newNode = new Node();
            newNode.value = data;
            current.Next = newNode;
            current = newNode;
            Count++;
        }



        private Node head;
        
        //This will have the latest Node
        private Node current;

        public int Count;

    }

    public class Node
    {
        public Node Next;
        public object value;
    }


}
