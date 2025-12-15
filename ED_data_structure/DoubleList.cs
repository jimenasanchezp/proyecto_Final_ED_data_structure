using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ED_data_structure
{
    internal class DoubleList
    {
        private Node_DoubleList? head;
        public Node_DoubleList? Head
        {
            get { return head; }
            set { head = value; }
        }

        public DoubleList()
        {
            this.head = null;
        }

        public void Add(Node_DoubleList n)
        {

            if (head == null)
            {
                head = n;
                return;
            }

            if (n.Data < head.Data)
            {
                n.Next = head;
                head.Back = n;
                head = n;
                return;
            }

            Node_DoubleList? h = head;
            while (h.Next != null)
            {
                if (n.Data < h.Next.Data)
                {
                    n.Next = h.Next;
                    n.Back = h;
                    h.Next = n;
                    n.Next.Back = n;
                    return;
                }
                h = h.Next;

            }
        }
    }
}
