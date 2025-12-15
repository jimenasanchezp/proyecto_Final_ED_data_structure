using System;

namespace ED_data_structure
{
    internal class CircularDoubleList
    {
        private Node_ListaDobleCircular? head;

        public CircularDoubleList()
        {
            head = null;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        // AGREGAR (Ordenado)
        public void Add(int data)
        {
            Node_ListaDobleCircular newNode = new Node_ListaDobleCircular(data);

            // Caso 1: Lista vacía
            if (head == null)
            {
                head = newNode;
                head.Next = head;
                head.Prev = head;
                return;
            }

            Node_ListaDobleCircular tail = head.Prev!;

            // Caso 2: Insertar al inicio (el nuevo es menor que head)
            if (data < head.Data)
            {
                newNode.Next = head;
                newNode.Prev = tail;

                head.Prev = newNode;
                tail.Next = newNode;

                head = newNode; // Actualizamos la cabeza
                return;
            }

            // Caso 3: Insertar en medio o al final
            Node_ListaDobleCircular current = head;

            // Recorremos mientras no demos la vuelta completa Y el siguiente sea menor
            while (current.Next != head && current.Next!.Data < data)
            {
                current = current.Next!;
            }

            // Insertamos DESPUÉS de 'current'
            // (current podría ser el último nodo si el nuevo dato es el más grande)
            newNode.Next = current.Next;
            newNode.Prev = current;

            current.Next!.Prev = newNode; // El anterior del siguiente apunta al nuevo
            current.Next = newNode;       // El siguiente del actual apunta al nuevo
        }

        // ELIMINAR
        public bool Delete(int data)
        {
            if (head == null) return false;

            Node_ListaDobleCircular current = head;

            do
            {
                if (current.Data == data)
                {
                    // Nodo encontrado. 

                    // Caso único: Si solo hay un nodo
                    if (current.Next == current)
                    {
                        head = null;
                        return true;
                    }

                    // Reconexión de enlaces (saltamos el nodo 'current')
                    // El siguiente del anterior = siguiente del actual
                    current.Prev!.Next = current.Next;
                    // El anterior del siguiente = anterior del actual
                    current.Next!.Prev = current.Prev;

                    // Si borramos la cabeza, debemos mover head al siguiente
                    if (current == head)
                    {
                        head = current.Next;
                    }

                    return true;
                }
                current = current.Next!;
            } while (current != head); // Repetimos hasta volver al inicio

            return false; // No encontrado
        }

        // MOSTRAR
        public void Show()
        {
            if (head == null)
            {
                Console.WriteLine("Lista Doble Circular vacía.");
                return;
            }

            Node_ListaDobleCircular current = head;
            do
            {
                Console.Write(current.Data + " <-> ");
                current = current.Next!;
            } while (current != head);

            Console.WriteLine("(Inicio)");
        }

        public int Count()
        {
            if (head == null) return 0;
            int count = 0;
            Node_ListaDobleCircular current = head;
            do
            {
                count++;
                current = current.Next!;
            } while (current != head);
            return count;
        }

        public Node_ListaDobleCircular? Peek()
        {
            return head;
        }
    }
}
