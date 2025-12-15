using System;

namespace ED_data_structure
{
    internal class ColaSimple
    {
        private Nodo_cola head;

        public ColaSimple()
        {
            head = null;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public void Enqueue(int dato)
        {
            Nodo_cola nuevoNodo = new Nodo_cola(dato);
            if (IsEmpty())
            {
                head = nuevoNodo;
            }
            else
            {
                Nodo_cola h = head;
                while (h.Next != null)
                {
                    h = h.Next;
                }
                h.Next = nuevoNodo;
            }
        }

        public int Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("La cola está vacía.");
            }
            int dato = head.Dato;
            head = head.Next;
            return dato;
        }

        public int Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("La cola está vacía.");
            }
            return head.Dato;
        }

        public override string ToString()
        {
            if (head == null) return "Cola vacía";
            Nodo_cola h = head;
            var resultado = "";
            while (h != null)
            {
                resultado += h.Dato + " → ";
                h = h.Next;
            }
            return resultado + "null";
        }
    }
}