using System;

namespace ED_data_structure
{
    internal class Nodo_Arbol
    { 
        public int Valor;
        private Nodo_Arbol? izquierda;
        private Nodo_Arbol? derecha;

        public Nodo_Arbol? Izquierda
        { 
           get { return izquierda; }
            set { izquierda = value; }
        }

        public Nodo_Arbol? Derecha
        {
            get { return derecha; }
            set { derecha = value; }
        }

        public Nodo_Arbol(int valor)
        {
            this.Valor = valor;
        }
    }
}
