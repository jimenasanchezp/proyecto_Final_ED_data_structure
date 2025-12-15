using System;

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

        // AGREGAR ORDENADO
        public void Add(Node_DoubleList n)
        {
            // Caso 0: Lista vacía
            if (head == null)
            {
                head = n;
                return;
            }

            // Caso 1: Insertar al inicio (menor que head)
            if (n.Data < head.Data)
            {
                n.Next = head;
                head.Back = n;
                head = n;
                return;
            }

            // Caso 2: Insertar en medio o final
            Node_DoubleList h = head;
            while (h.Next != null)
            {
                if (n.Data < h.Next.Data)
                {
                    // Insertar entre 'h' y 'h.Next'
                    n.Next = h.Next;
                    n.Back = h;

                    h.Next.Back = n; // Importante: conectar el de atrás del siguiente
                    h.Next = n;      // Conectar el siguiente del actual
                    return;
                }
                h = h.Next;
            }

            // Caso 3: Insertar al final (si llegamos aquí, es el mayor)
            h.Next = n;
            n.Back = h;
        }

        // ELIMINAR NODO
        public bool Delete(int data)
        {
            if (head == null) return false;

            // Caso 1: Eliminar la cabeza
            if (head.Data == data)
            {
                head = head.Next;
                if (head != null)
                {
                    head.Back = null; // La nueva cabeza no tiene anterior
                }
                return true;
            }

            // Caso 2: Eliminar en medio o final
            Node_DoubleList? h = head;
            while (h != null)
            {
                if (h.Data == data)
                {
                    // Desconectar nodo 'h'
                    // El siguiente del anterior apunta al siguiente de h
                    if (h.Back != null) h.Back.Next = h.Next;

                    // El anterior del siguiente apunta al anterior de h
                    if (h.Next != null) h.Next.Back = h.Back;

                    return true;
                }
                h = h.Next;
            }

            return false; // No encontrado
        }

        // MOSTRAR LISTA
        public void ShowList()
        {
            if (head == null)
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            Node_DoubleList? h = head;
            while (h != null) // Recorrido lineal hasta null
            {
                Console.Write(h.ToString() + " <-> ");
                h = h.Next;
            }
            Console.WriteLine("null");
        }
    }
}
