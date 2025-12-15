using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED_data_structure
{
    internal class HashTable<TKey, TValue>
    {
        private const int TAMANO = 10;
        private LinkedList<(TKey clave, TValue valor)>[] tabla;

        public HashTable()
        {
            tabla = new LinkedList<(TKey, TValue)>[TAMANO];
        }

        private int FuncionHash(TKey clave)
        {
            int hash = clave.GetHashCode();
            if (hash < 0) hash = -hash;
            return hash % TAMANO;
        }

        public bool Insertar(TKey clave, TValue valor)
        {
            int indice = FuncionHash(clave);

            if (tabla[indice] == null)
                tabla[indice] = new LinkedList<(TKey, TValue)>();

            foreach (var par in tabla[indice])
            {
                if (par.clave.Equals(clave))
                {
                    tabla[indice].Remove(par);
                    tabla[indice].AddLast((clave, valor));
                    return false; // clave reemplazada
                }
            }

            tabla[indice].AddLast((clave, valor));
            return true; // clave nueva
        }

        public bool TryGetValue(TKey clave, out TValue valor)
        {
            int indice = FuncionHash(clave);

            if (tabla[indice] != null)
            {
                foreach (var par in tabla[indice])
                {
                    if (par.clave.Equals(clave))
                    {
                        valor = par.valor;
                        return true;
                    }
                }
            }

            valor = default;
            return false;
        }

        public bool Eliminar(TKey clave)
        {
            int indice = FuncionHash(clave);

            if (tabla[indice] != null)
            {
                foreach (var par in tabla[indice])
                {
                    if (par.clave.Equals(clave))
                    {
                        tabla[indice].Remove(par);
                        return true;
                    }
                }
            }

            return false;
        }
        public string Mostrar()
        {
            var sb = new StringBuilder();
            sb.AppendLine("TABLA HASH");
            for (int i = 0; i < TAMANO; i++)
            {
                sb.Append($"[{i}] ");
                if (tabla[i] != null && tabla[i].Count > 0)
                {
                    sb.Append(string.Join(" -> ", tabla[i].Select(p => $"({p.clave}, {p.valor})")));
                }
                else
                {
                    sb.Append("Vacío");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public void Clear()
        {
            for (int i = 0; i < TAMANO; i++)
                tabla[i]?.Clear();
        }

        public int Count() =>
            tabla.Where(l => l != null).Sum(l => l.Count);

        public List<TKey> GetKeys() =>
            tabla.Where(l => l != null).SelectMany(l => l.Select(p => p.clave)).ToList();
        public List<TValue> GetValues()
        {
            return tabla.Where(l => l != null)
                        .SelectMany(l => l.Select(p => p.valor))
                        .ToList();
        }

        public bool ContainsKey(TKey clave) =>
            tabla[FuncionHash(clave)]?.Any(x => x.clave.Equals(clave)) ?? false;

        // ================= BUSCAR =================
        public List<(TKey Clave, TValue Valor)> Buscar(string filtro)
        {
            var resultado = new List<(TKey, TValue)>();
            if (string.IsNullOrEmpty(filtro)) return resultado;

            for (int i = 0; i < TAMANO; i++)
            {
                if (tabla[i] != null)
                {
                    foreach (var par in tabla[i])
                    {
                        string claveStr = par.clave.ToString();
                        string valorStr = par.valor != null ? par.valor.ToString() : "";

                        if (claveStr.Contains(filtro) || valorStr.Contains(filtro))
                            resultado.Add((par.clave, par.valor));
                    }
                }
            }
            return resultado;
        }

    }
}
