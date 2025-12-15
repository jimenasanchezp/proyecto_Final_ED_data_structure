using System;

namespace ED_data_structure
{
    internal class ColaPrioridad
    {
        private readonly ColaSimple cola1; // Mayor prioridad
        private readonly ColaSimple cola2;
        private readonly ColaSimple cola3; // Menor prioridad

        public ColaPrioridad()
        {
            cola1 = new ColaSimple();
            cola2 = new ColaSimple();
            cola3 = new ColaSimple();
        }

        public void Enqueue(int dato, int prioridad) // prioridad 1, 2 o 3
        {
            if (prioridad == 1) cola1.Enqueue(dato);
            else if (prioridad == 2) cola2.Enqueue(dato);
            else if (prioridad == 3) cola3.Enqueue(dato);
            else throw new ArgumentException("Prioridad debe ser 1, 2 o 3");
        }

        public int Dequeue()
        {
            if (!cola1.IsEmpty()) return cola1.Dequeue();
            if (!cola2.IsEmpty()) return cola2.Dequeue();
            if (!cola3.IsEmpty()) return cola3.Dequeue();
            throw new InvalidOperationException("Todas las colas están vacías");
        }

        public int Peek()
        {
            if (!cola1.IsEmpty()) return cola1.Peek();
            if (!cola2.IsEmpty()) return cola2.Peek();
            if (!cola3.IsEmpty()) return cola3.Peek();
            throw new InvalidOperationException("Todas las colas están vacías");
        }

        public override string ToString()
        {
            return $"P1: {cola1}\n P2: {cola2}\n P3: {cola3}";
        }
    }
}
