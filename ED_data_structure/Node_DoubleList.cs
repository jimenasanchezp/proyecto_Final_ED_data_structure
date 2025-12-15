using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED_data_structure
{
    internal class Node_DoubleList
    {
        private int data;
        private Node_DoubleList? next; // referencia al siguiente nodo
        private Node_DoubleList? back; // referencia al nodo anterior

        public int Data
        {
            get { return data; }
            set { data = value; }
        }
        public Node_DoubleList? Next
        {
            get { return next; }
            set { next = value; }
        }
        public Node_DoubleList? Back
        {
            get { return back; }
            set { back = value; }
        }
        public Node_DoubleList(int data)
        {
            this.data = data;
            this.next = null;
            this.back = null;
        }
        public override string ToString()
        {
            return "Data; " + ToString();
        }
    }
}
