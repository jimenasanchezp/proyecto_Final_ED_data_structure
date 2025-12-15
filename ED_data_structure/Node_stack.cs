using System;

namespace ED_data_structure
{
    internal class Node_stack
    {
        public int Value { get; set; }

        // Referencia para stack linked list (apunta al nodo anterior/abajo)
        public Node_stack ? Prev { get; set; }

        public Node_stack (int value)
        {
            Value = value;
            Prev = null;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
