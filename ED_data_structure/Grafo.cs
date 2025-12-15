using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED_data_structure
{
    internal class Grafo
    {
        private List<Nodo_grafo> nodos;
        private int[,] matriz;
        private bool dirigido;
        private bool ponderado;

        public Grafo(bool dirigido, bool ponderado)
        {
            nodos = new List<Nodo_grafo>();
            matriz = new int[0, 0];
            this.dirigido = dirigido;
            this.ponderado = ponderado;
        }

        public void AddNodo(Nodo_grafo nodo)
        {
            bool existe = nodos.Any(n => n.Data == nodo.Data);

            if (existe)
            {
                Console.WriteLine($"Error: ya existe un vértice con el identificador '{nodo.Data}'.");
                return;
            }
            nodos.Add(nodo);
            int nuevoTam = nodos.Count;
            int[,] nuevaMatriz = new int[nuevoTam, nuevoTam];

            // Copiar los valores anteriores
            for (int i = 0; i < nuevoTam - 1; i++)
            {
                for (int j = 0; j < nuevoTam - 1; j++)
                {
                    nuevaMatriz[i, j] = matriz[i, j];
                }
            }

            matriz = nuevaMatriz; // Reemplaza la matriz anterior

            // --- ESTA LÍNEA ES LA QUE FALTABA PARA QUE SE VEA EN EL TXT ---
            Console.WriteLine($"Nodo agregado: {nodo.Data}");
        }

        public void AddArista(int src, int dst, int w = 1)
        {
            if (!ponderado) w = 1;
            matriz[src, dst] = w;
            if (!dirigido)
            {
                matriz[dst, src] = w;
            }
        }

        public void AddArista(char src, char dst, int w = 1)
        {
            int i = ObtenerIndice(src);
            int j = ObtenerIndice(dst);
            if (i == -1 || j == -1)
            {
                Console.WriteLine($"Error: alguno de los vértices '{src}' o '{dst}' no existe.");
                return;
            }
            if (matriz[i, j] != 0)
            {
                Console.WriteLine($"Error: Ya existe una arista entre {src} y {dst}");
                return;
            }
            if (!ponderado) w = 1;
            matriz[i, j] = w;
            if (!dirigido)
                matriz[j, i] = w;

            // --- Mensaje detallado de la arista ---
            Console.WriteLine($"Arista agregada: {src} -> {dst}");
        }

        public bool CheckArista(int src, int dst)
        {
            return matriz[src, dst] != 0;
        }

        public string Print()
        {
            string matrizString = "  ";
            foreach (var node in nodos)
            {
                matrizString += node.Data + " ";
            }
            // Usamos Environment.NewLine para que se vea bien en el TextBox
            matrizString += Environment.NewLine;

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                matrizString += nodos[i].Data + " ";
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    matrizString += matriz[i, j] + " ";
                }
                matrizString += Environment.NewLine;
            }
            return matrizString;
        }

        public void BFS(char start)
        {
            int s = ObtenerIndice(start);
            if (s == -1)
            {
                Console.WriteLine($"Error: el vértice '{s}' no existe.");
                return;
            }
            bool[] visitado = new bool[nodos.Count];
            Queue<int> cola = new Queue<int>();

            visitado[s] = true;
            cola.Enqueue(s);

            Console.Write("Recorrido BFS: ");
            while (cola.Count > 0)
            {
                int actual = cola.Dequeue();
                Console.Write(nodos[actual].Data + " ");

                for (int i = 0; i < nodos.Count; i++)
                {
                    if (matriz[actual, i] != 0 && !visitado[i])
                    {
                        visitado[i] = true;
                        cola.Enqueue(i);
                    }
                }
            }
            Console.WriteLine();
        }

        public void DFS(char start)
        {
            int s = ObtenerIndice(start);
            if (s == -1)
            {
                Console.WriteLine($"Error: el vértice '{s}' no existe.");
                return;
            }
            bool[] visitado = new bool[nodos.Count];
            Console.Write("Recorrido DFS: ");
            DFSRecursivo(s, visitado);
            Console.WriteLine();
        }

        private void DFSRecursivo(int v, bool[] visitado)
        {
            visitado[v] = true;
            Console.Write(nodos[v].Data + " ");

            for (int i = 0; i < nodos.Count; i++)
            {
                if (matriz[v, i] != 0 && !visitado[i])
                {
                    DFSRecursivo(i, visitado);
                }
            }
        }

        public void EliminarArista(int src, int dst)
        {
            matriz[src, dst] = 0;
            if (!dirigido) matriz[dst, src] = 0;
        }

        public void EliminarArista(char src, char dst)
        {
            int i = ObtenerIndice(src);
            int j = ObtenerIndice(dst);
            if (i == -1 || j == -1)
            {
                Console.WriteLine($"Error: alguno de los vértices '{src}' o '{dst}' no existe.");
                return;
            }
            matriz[i, j] = 0;
            if (!dirigido) matriz[j, i] = 0;

            Console.WriteLine($"Arista eliminada: {src} - {dst}");
        }

        public void RemoveNodo(char src)
        {
            int s = ObtenerIndice(src);
            if (s == -1)
            {
                Console.WriteLine($"Error: El nodo {src} no existe.");
                return;
            }

            nodos.RemoveAt(s);

            int size = matriz.GetLength(0);
            int[,] nuevaMatriz = new int[size - 1, size - 1];

            int filaNueva = 0;
            for (int i = 0; i < size; i++)
            {
                if (i == s) continue;
                int colNueva = 0;
                for (int j = 0; j < size; j++)
                {
                    if (j == s) continue;
                    nuevaMatriz[filaNueva, colNueva] = matriz[i, j];
                    colNueva++;
                }
                filaNueva++;
            }

            matriz = nuevaMatriz;

            // --- Mensaje de confirmación al eliminar ---
            Console.WriteLine($"Nodo eliminado: {src}");
        }

        private int ObtenerIndice(char id)
        {
            for (int i = 0; i < nodos.Count; i++)
            {
                if (nodos[i].Data == id) return i;
            }
            return -1;
        }
    }
}

