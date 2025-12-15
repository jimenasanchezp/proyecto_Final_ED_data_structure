using System;

namespace ED_data_structure
{
    internal class Node_ListaDobleCircular
    {
        public int Data { get; set; }
        public Node_ListaDobleCircular? Next { get; set; }
        public Node_ListaDobleCircular? Prev { get; set; }

        public Node_ListaDobleCircular(int data)
        {
            this.Data = data;
            this.Next = null;
            this.Prev = null;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}