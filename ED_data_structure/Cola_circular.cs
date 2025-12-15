using System;

namespace ED_data_structure
{
    internal class ColaCircular
    {
        private Nodo_cola head;

        public ColaCircular()
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
                head.Next = head; // apunta a sí mismo
            }
            else
            {
                Nodo_cola h = head;
                // recorremos hasta el último nodo (que apunta a head)
                while (h.Next != head)
                {
                    h = h.Next;
                }
                h.Next = nuevoNodo;
                nuevoNodo.Next = head; // nuevo nodo apunta a head
            }
        }

        public int Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("La cola está vacía");

            int dato = head.Dato;

            if (head.Next == head) // solo un nodo
            {
                head = null;
            }
            else
            {
                // buscamos el último nodo para actualizar su Next
                Nodo_cola h = head;
                while (h.Next != head)
                {
                    h = h.Next;
                }
                h.Next = head.Next; // último nodo apunta al nuevo head
                head = head.Next;   // movemos head
            }
            return dato;
        }

        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("La cola está vacía");
            return head.Dato;
        }

        public override string ToString()
        {
            if (head == null) return "Cola circular vacía";
            Nodo_cola h = head;
            var resultado = "";
            do
            {
                resultado += h.Dato + " → ";
                h = h.Next;
            } while (h != head);
            return resultado + "(vuelve al inicio)";
        }
    }
}