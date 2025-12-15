using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED_data_structure
{
    internal class Diccionario<TKey, TValue>
    {
        private Dictionary<TKey, TValue> datos;

        public Diccionario()
        {
            datos = new Dictionary<TKey, TValue>();
        }

        public bool Insertar(TKey clave, TValue valor)
        {
            if (datos.ContainsKey(clave))
            {
                datos[clave] = valor;
                return false;
            }

            datos.Add(clave, valor);
            return true;
        }

        public bool TryGetValue(TKey clave, out TValue valor)
        {
            return datos.TryGetValue(clave, out valor);
        }

        public bool Eliminar(TKey clave)
        {
            return datos.Remove(clave);
        }
        public string Mostrar()
        {
            if (!datos.Any())
                return "DICCIONARIO\nEl diccionario está vacío.";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DICCIONARIO");
            sb.Append(string.Join(Environment.NewLine, datos.Select(p => $"{p.Key} -> {p.Value}")));
            return sb.ToString();
        }

        public void Clear() => datos.Clear();

        public int Count() => datos.Count;

        public List<TKey> GetKeys() => datos.Keys.ToList();

        public List<TValue> GetValues() => datos.Values.ToList();

        public bool ContainsKey(TKey clave) => datos.ContainsKey(clave);

        // ================= BUSCAR =================
        public List<(TKey Clave, TValue Valor)> Buscar(string filtro)
        {
            var resultado = new List<(TKey, TValue)>();
            foreach (var kvp in datos)
            {
                string claveStr = kvp.Key.ToString();
                string valorStr = kvp.Value != null ? kvp.Value.ToString() : "";

                if (claveStr.Contains(filtro) || valorStr.Contains(filtro))
                    resultado.Add((kvp.Key, kvp.Value));
            }
            return resultado;
        }
    }
}
