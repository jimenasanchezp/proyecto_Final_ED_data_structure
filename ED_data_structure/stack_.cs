using System;

namespace ED_data_structure
{
    internal class stack_
    {
        private bool esEstatica; // variable para distinguir tipo de pila

        // variables para lógica dinámica
        private Node_stack? topNode; // Tope para la dinámica

        // variables para lógica estática
        private Node_stack[]? array; // Arreglo para la estática
        private int topIndex;  // Índice para la estática
        private int tamañoMax;

        // CONSTRUCTOR 1: Para Pila DINÁMICA (Sin límite)
        public stack_()
        {
            esEstatica = false;
            topNode = null;
        }

        // CONSTRUCTOR 2: Para Pila ESTÁTICA (Con límite)
        public stack_(int tamaño)
        {
            if (tamaño <= 0) throw new ArgumentException("El tamaño debe ser positivo.");

            esEstatica = true;
            tamañoMax = tamaño;
            array = new Node_stack[tamaño];
            topIndex = -1;
        }

        // MÉTODOS PUSH, POP, PEEK
        public void Push(Node_stack nodo)
        {
            if (esEstatica)
            {
                // verificar que no esté llena
                if (topIndex == tamañoMax - 1)
                    throw new InvalidOperationException("La pila estática está llena (Overflow).");

                topIndex++; // Incrementamos el índice del tope
                array![topIndex] = nodo; // Guardamos el nodo en el arreglo
            }
            else
            {
                // para algoritmo dinámico  
                // "Prev" apunta al nodo que antes era el top (hacia abajo)
                nodo.Prev = topNode;
                topNode = nodo; // El nuevo nodo ahora es el top
            }
        }

        public Node_stack Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("La pila está vacía.");

            if (esEstatica)
            {
                // logica estática
                Node_stack val = array![topIndex]; // Guardamos el valor a retornar
                array[topIndex] = null!; // Limpiamos referencia
                topIndex--; // Decrementamos el índice del tope
                return val;
            }
            else
            {
                // logica dinámica
                Node_stack val = topNode!; // Guardamos el valor a retornar
                topNode = topNode!.Prev; // Bajamos el top al nodo anterior
                return val;
            }
        }

        public Node_stack Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("La pila está vacía.");

            if (esEstatica)
            {
                return array![topIndex];
            }
            else
            {
                return topNode!;
            }
        }

        public bool IsEmpty()
        {
            if (esEstatica)
                return topIndex == -1;
            else
                return topNode == null;
        }

        public void Clear()
        {
            if (esEstatica)
            {
                topIndex = -1;
                // Opcional: limpiar el arreglo
                Array.Clear(array!, 0, array!.Length);
            }
            else
            {
                topNode = null;
            }
        }

        public int Count()
        {
            if (esEstatica)
            {
                return topIndex + 1;
            }
            else
            {
                int count = 0;
                Node_stack? t = topNode;
                while (t != null)
                {
                    count++;
                    t = t.Prev;
                }
                return count;
            }
        }

        // Método ToString para ver el contenido
        public override string ToString()
        {
            string result = "";

            if (esEstatica)
            {
                result += "Modo: Estático (Array)\n";
                if (IsEmpty()) return result + "Pila vacía.";

                for (int i = topIndex; i >= 0; i--)
                {
                    result += $"[{array![i].Value}]\n";
                }
            }
            else
            {
                result += "Modo: Dinámico (Nodos)\n";
                if (IsEmpty()) return result + "Pila vacía.";

                Node_stack? t = topNode;
                while (t != null)
                {
                    result += $"[{t.Value}]\n";
                    t = t.Prev;
                }
            }
            return result;
        }
    }
}