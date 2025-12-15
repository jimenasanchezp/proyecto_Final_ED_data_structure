using System;

namespace ED_data_structure
{
    internal class Node_ListCircular
    {
        private int data;
        private Node_ListCircular? next; // referencia al siguiente nodo

        public int Data
        {
            get { return data; }
            set { data = value; }
        }
        public Node_ListCircular Next
        {
            get { return next; }
            set { next = value; }
        }

        public Node_ListCircular(int data)
        {
            this.data = data;
            this.next = null;
        }

        public override string ToString()
        {
            return " " + data.ToString();
        }
    }
}
