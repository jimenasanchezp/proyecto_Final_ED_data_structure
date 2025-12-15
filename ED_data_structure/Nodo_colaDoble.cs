using System;

namespace ED_data_structure
{
    internal class Nodo_colaDoble
    {
        private int dato;
        private Nodo_colaDoble next;
        private Nodo_colaDoble prev;
        public int Dato
        {
            get { return dato; }
            set { dato = value; }
        }
        public Nodo_colaDoble Next
        {
            get { return next; }
            set { next = value; }
        }
        public Nodo_colaDoble Prev
        {
            get { return prev; }
            set { prev = value; }
        }
        public Nodo_colaDoble(int dato)
        {
            this.dato = dato;
            this.next = null;
            this.prev = null;
        }
        public override string ToString()
        {
            return dato.ToString();
        }
    }
}