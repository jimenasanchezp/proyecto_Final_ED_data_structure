using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED_data_structure
{
    internal class Nodo_cola
    {
        private int dato;
        private Nodo_cola next;

        public int Dato
        {
            get { return dato; }
            set { dato = value; }
        }
        public Nodo_cola Next
        {
            get { return next; }
            set { next = value; }
        }
        public Nodo_cola(int dato)
        {
            this.dato = dato;
            this.next = null;
        }

        public override string ToString()
        {
            return dato.ToString();
        }
    }
}
