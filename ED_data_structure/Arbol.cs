using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED_data_structure
{
    internal class Arbol
    {
        private Nodo_Arbol? raiz;

        public Nodo_Arbol? Raiz
        {
            get { return raiz; }
            set { raiz = value; }
        }

        public int Numero { get; private set; }

        public Arbol()
        {
            raiz = null;
        }

        public void Agregar(int valor)
        {
            raiz = AgregarRecursivo(raiz, valor);
        }

        public Nodo_Arbol AgregarRecursivo(Nodo_Arbol? actual, int numero)
        {
            if (actual == null)
            {
                return new Nodo_Arbol(numero);
            }

            if (numero == actual.Valor)
            {
                Console.WriteLine("El valor ya existe en el árbol.");
                return actual;
            }

            if (numero < actual.Valor)
            {
                actual.Izquierda = AgregarRecursivo(actual.Izquierda, numero);
            }
            else
            {
                actual.Derecha = AgregarRecursivo(actual.Derecha, numero);
            }
            return actual;
        }

        public void Eliminar(int valor)
        {
            raiz = EliminarRecursivo(raiz, valor);
        }

        private Nodo_Arbol? EliminarRecursivo(Nodo_Arbol? actual, int? numero)
        {
            if (actual == null)
            {
                Console.WriteLine("El valor no existe en el árbol.");
                return null;
            }

            // Buscar el nodo
            if (numero < actual.Valor)
            {
                actual.Izquierda = EliminarRecursivo(actual.Izquierda, numero);
            }
            else if (numero > actual.Valor)
            {
                actual.Derecha = EliminarRecursivo(actual.Derecha, numero);
            }
            else
            {
                // Nodo encontrado
                // Caso 1: sin hijos
                if (actual.Izquierda == null && actual.Derecha == null)
                {
                    return null;
                }
                // Caso 2: un hijo
                if (actual.Izquierda == null)
                {
                    return actual.Derecha;
                }
                if (actual.Derecha == null)
                {
                    return actual.Izquierda;
                }
                // Caso 3: dos hijos
                // Encuentra el sucesor mínimo (menor de la derecha)
                Nodo_Arbol sucesor = EncontrarMinimo(actual.Derecha);
                actual.Valor = sucesor.Valor;
                actual.Derecha = EliminarRecursivo(actual.Derecha, sucesor.Valor);
            }
            return actual;
        }

        private Nodo_Arbol EncontrarMinimo(Nodo_Arbol nodo)
        {
            while (nodo.Izquierda != null)
            {
                nodo = nodo.Izquierda;
            }
            return nodo;
        }

        // --- MÉTODOS DE RECORRIDO ---

        // 1. PreOrden (Público + Privado)
        public void MostrarPreOrden()
        {
            MostrarPreOrdenRecursivo(raiz);
            Console.WriteLine();
        }

        private void MostrarPreOrdenRecursivo(Nodo_Arbol? nodo)
        {
            if (nodo != null)
            {
                Console.Write(nodo.Valor + " "); // Raíz
                MostrarPreOrdenRecursivo(nodo.Izquierda); // Izquierda
                MostrarPreOrdenRecursivo(nodo.Derecha); // Derecha
            }
        }

        // 2. InOrden (Público + Privado)
        public void MostrarInOrden()
        {
            MostrarInOrdenRecursivo(raiz);
            Console.WriteLine();
        }

        private void MostrarInOrdenRecursivo(Nodo_Arbol? nodo)
        {
            if (nodo != null)
            {
                MostrarInOrdenRecursivo(nodo.Izquierda); // Izquierda
                Console.Write(nodo.Valor + " "); // Raíz
                MostrarInOrdenRecursivo(nodo.Derecha); // Derecha
            }
        }

        // 3. PostOrden (Público + Privado)
        public void MostrarPostOrden()
        {
            MostrarPostOrdenRecursivo(raiz);
            Console.WriteLine();
        }

        private void MostrarPostOrdenRecursivo(Nodo_Arbol? nodo)
        {
            if (nodo != null)
            {
                MostrarPostOrdenRecursivo(nodo.Izquierda); // Izquierda
                MostrarPostOrdenRecursivo(nodo.Derecha); // Derecha
                Console.Write(nodo.Valor + " "); // Raíz
            }
        }
    }
}