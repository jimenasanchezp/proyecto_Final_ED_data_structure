using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ED_data_structure
{
    public partial class Form1 : Form
    {
        // Instancias de las estructuras
        private stack_ pila;
        private ColaSimple colaSimple;
        private ColaCircular colaCircular;
        private ColaDoble colaDoble;
        private ColaPrioridad colaPrioridad;
        private ListCircular listaCircular;
        private DoubleList listaDoble;
        private Arbol arbol;
        private Grafo grafo;
        private HashTable<string, string> tablaHash;
        private Diccionario<string, string> diccionario;

        public Form1()
        {
            InitializeComponent();
            InicializarEstructuras();
            cmbEstructuras.SelectedIndex = 0;
        }

        private void InicializarEstructuras()
        {
            pila = new stack_();
            colaSimple = new ColaSimple();
            colaCircular = new ColaCircular();
            colaDoble = new ColaDoble();
            colaPrioridad = new ColaPrioridad();
            listaCircular = new ListCircular();
            listaDoble = new DoubleList();
            arbol = new Arbol();
            grafo = new Grafo(false, false);
            tablaHash = new HashTable<string, string>();
            diccionario = new Diccionario<string, string>();
        }

        // --- MANEJO DE INTERFAZ ---
        private void cmbEstructuras_SelectedIndexChanged(object sender, EventArgs e)
        {
            string op = cmbEstructuras.SelectedItem.ToString();
            txtDato1.Clear();
            txtDato2.Clear();
            txtResultado.Clear();

            // 1. Visibilidad Buscar / Clear
            if (op == "Tabla Hash" || op == "Diccionario")
            {
                btnBuscar.Visible = true;
                btnClear.Visible = false;
            }
            else
            {
                btnBuscar.Visible = false;
                btnClear.Visible = true;
            }

            // 2. Visibilidad Botones Árbol (Pre/In/Post)
            if (op == "Árbol Binario")
            {
                btnMostrar.Visible = false; // Ocultar el "Mostrar Todo" genérico
                btnPreOrden.Visible = true;
                btnInOrden.Visible = true;
                btnPostOrden.Visible = true;
            }
            else
            {
                btnMostrar.Visible = true; // Mostrar el genérico
                btnPreOrden.Visible = false;
                btnInOrden.Visible = false;
                btnPostOrden.Visible = false;
            }

            // Configurar etiquetas y campos
            switch (op)
            {
                case "Cola Prioridad":
                    lblDato1.Text = "Dato (int):";
                    lblDato2.Text = "Prioridad (1-3):";
                    txtDato2.Enabled = true;
                    break;
                case "Grafo":
                    lblDato1.Text = "Nodo Origen (char):";
                    lblDato2.Text = "Nodo Destino (char):";
                    txtDato2.Enabled = true;
                    break;
                case "Tabla Hash":
                case "Diccionario":
                    lblDato1.Text = "Clave / Filtro:";
                    lblDato2.Text = "Valor (string):";
                    txtDato2.Enabled = true;
                    break;
                default:
                    // Estructuras simples
                    lblDato1.Text = "Dato (int):";
                    lblDato2.Text = "N/A";
                    txtDato2.Enabled = false;
                    break;
            }
        }

        private void Log(string mensaje)
        {
            txtResultado.AppendText(mensaje + "\r\n");
            txtResultado.ScrollToCaret();
        }

        private void EjecutarCapturandoConsola(Action accion)
        {
            var writerOriginal = Console.Out;
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                try
                {
                    accion();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    Console.SetOut(writerOriginal);
                    Log(sw.ToString());
                }
            }
        }

        // --- BOTÓN AGREGAR ---
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string structName = cmbEstructuras.SelectedItem.ToString();
                string d1 = txtDato1.Text;
                string d2 = txtDato2.Text;

                switch (structName)
                {
                    case "Pila (Stack)":
                        pila.Push(new Node_stack(int.Parse(d1)));
                        Log($"Push: {d1}");
                        break;
                    case "Cola Simple":
                        colaSimple.Enqueue(int.Parse(d1));
                        Log($"Enqueue: {d1}");
                        break;
                    case "Cola Circular":
                        colaCircular.Enqueue(int.Parse(d1));
                        Log($"Enqueue: {d1}");
                        break;
                    case "Cola Doble":
                        colaDoble.Enqueue(int.Parse(d1));
                        Log($"Enqueue (Final): {d1}");
                        break;
                    case "Cola Prioridad":
                        colaPrioridad.Enqueue(int.Parse(d1), int.Parse(d2));
                        Log($"Enqueue: {d1} con Prioridad {d2}");
                        break;
                    case "Lista Circular":
                        listaCircular.dd(new Node_ListCircular(int.Parse(d1)));
                        Log($"Agregado a Lista Circular: {d1}");
                        break;
                    case "Lista Doble":
                        listaDoble.Add(new Node_DoubleList(int.Parse(d1)));
                        Log($"Agregado a Lista Doble: {d1}");
                        break;
                    case "Árbol Binario":
                        EjecutarCapturandoConsola(() => arbol.Agregar(int.Parse(d1)));
                        Log($"Agregado al Árbol: {d1}");
                        break;
                    case "Grafo":
                        char nodo = d1.Length > 0 ? d1[0] : '?';
                        if (string.IsNullOrWhiteSpace(d2))
                        {
                            EjecutarCapturandoConsola(() => grafo.AddNodo(new Nodo_grafo(nodo)));
                        }
                        else
                        {
                            char destino = d2.Length > 0 ? d2[0] : '?';
                            EjecutarCapturandoConsola(() => grafo.AddArista(nodo, destino));
                        }
                        break;
                    case "Tabla Hash":
                        tablaHash.Insertar(d1, d2);
                        Log($"Insertado Hash: [{d1}] = {d2}");
                        break;
                    case "Diccionario":
                        diccionario.Insertar(d1, d2);
                        Log($"Insertado Diccionario: [{d1}] = {d2}");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar: " + ex.Message);
            }
        }

        // --- BOTÓN ELIMINAR ---
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string structName = cmbEstructuras.SelectedItem.ToString();
                switch (structName)
                {
                    case "Pila (Stack)":
                        var popped = pila.Pop();
                        Log($"Pop: {popped.Value}");
                        break;
                    case "Cola Simple":
                        Log($"Dequeue: {colaSimple.Dequeue()}");
                        break;
                    case "Cola Circular":
                        Log($"Dequeue: {colaCircular.Dequeue()}");
                        break;
                    case "Cola Doble":
                        Log($"Dequeue: {colaDoble.Dequeue()}");
                        break;
                    case "Cola Prioridad":
                        Log($"Dequeue: {colaPrioridad.Dequeue()}");
                        break;
                    case "Lista Circular":
                        int val = int.Parse(txtDato1.Text);
                        bool res = listaCircular.Delete(val);
                        Log(res ? $"Eliminado: {val}" : "No encontrado");
                        break;
                    case "Lista Doble":
                        Log("Operación Delete no implementada en DoubleList.");
                        break;
                    case "Árbol Binario":
                        int vArbol = int.Parse(txtDato1.Text);
                        EjecutarCapturandoConsola(() => arbol.Eliminar(vArbol));
                        Log($"Comando Eliminar ejecutado para: {vArbol}");
                        break;
                    case "Grafo":
                        char nodo = txtDato1.Text[0];
                        if (string.IsNullOrWhiteSpace(txtDato2.Text))
                            EjecutarCapturandoConsola(() => grafo.RemoveNodo(nodo));
                        else
                        {
                            char dst = txtDato2.Text[0];
                            EjecutarCapturandoConsola(() => grafo.EliminarArista(nodo, dst));
                        }
                        break;
                    case "Tabla Hash":
                        bool delH = tablaHash.Eliminar(txtDato1.Text);
                        Log(delH ? "Eliminado" : "Clave no encontrada");
                        break;
                    case "Diccionario":
                        bool delD = diccionario.Eliminar(txtDato1.Text);
                        Log(delD ? "Eliminado" : "Clave no encontrada");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        // --- BOTÓN MOSTRAR (Genérico) ---
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                string structName = cmbEstructuras.SelectedItem.ToString();
                Log($"--- Mostrando {structName} ---");

                switch (structName)
                {
                    case "Pila (Stack)":
                        Log(pila.ToString());
                        break;
                    case "Cola Simple":
                        Log(colaSimple.ToString());
                        break;
                    case "Cola Circular":
                        Log(colaCircular.ToString());
                        break;
                    case "Cola Doble":
                        Log(colaDoble.ToString());
                        break;
                    case "Cola Prioridad":
                        Log(colaPrioridad.ToString());
                        break;
                    case "Lista Circular":
                        EjecutarCapturandoConsola(() => listaCircular.ShowList());
                        break;
                    case "Lista Doble":
                        var nodo = listaDoble.Head;
                        if (nodo == null) Log("Lista vacía");
                        while (nodo != null)
                        {
                            txtResultado.AppendText(nodo.Data + " <-> ");
                            nodo = nodo.Next;
                        }
                        txtResultado.AppendText("null\r\n");
                        break;
                    case "Grafo":
                        Log(grafo.Print());
                        break;
                    case "Tabla Hash":
                        Log(tablaHash.Mostrar());
                        break;
                    case "Diccionario":
                        Log(diccionario.Mostrar());
                        break;
                        // NOTA: Árbol Binario ahora usa sus botones propios
                }
            }
            catch (Exception ex)
            {
                Log("Error al mostrar: " + ex.Message);
            }
        }

        // --- EVENTOS DE BOTONES DE ÁRBOL ---
        private void btnPreOrden_Click(object sender, EventArgs e)
        {
            Log("--- Recorrido PreOrden ---");
            EjecutarCapturandoConsola(() => arbol.MostrarPreOrden());
        }

        private void btnInOrden_Click(object sender, EventArgs e)
        {
            Log("--- Recorrido InOrden ---");
            EjecutarCapturandoConsola(() => arbol.MostrarInOrden());
        }

        private void btnPostOrden_Click(object sender, EventArgs e)
        {
            Log("--- Recorrido PostOrden ---");
            EjecutarCapturandoConsola(() => arbol.MostrarPostOrden());
        }

        // --- BOTÓN ESTADO ---
        private void btnEstado_Click(object sender, EventArgs e)
        {
            try
            {
                string structName = cmbEstructuras.SelectedItem.ToString();
                switch (structName)
                {
                    case "Pila (Stack)":
                        Log(pila.IsEmpty() ? "Vacía" : "Tope: " + pila.Peek().Value);
                        Log("Cantidad: " + pila.Count());
                        break;
                    case "Cola Simple":
                        Log(colaSimple.IsEmpty() ? "Vacía" : "Frente: " + colaSimple.Peek());
                        break;
                    case "Cola Circular":
                        Log(colaCircular.IsEmpty() ? "Vacía" : "Frente: " + colaCircular.Peek());
                        break;
                    case "Cola Doble":
                        Log(colaDoble.IsEmpty() ? "Vacía" : "Frente: " + colaDoble.Peek());
                        break;
                    case "Cola Prioridad":
                        Log("Frente: " + colaPrioridad.Peek());
                        break;
                    case "Lista Circular":
                        Log("Cantidad: " + listaCircular.Count());
                        break;
                    case "Lista Doble":
                        Log(listaDoble.Head == null ? "Lista vacía" : "Cabeza: " + listaDoble.Head.Data);
                        break;
                    case "Árbol Binario":
                        Log(arbol.Raiz == null ? "Árbol vacío" : "Raíz: " + arbol.Raiz.Valor);
                        break;
                    case "Grafo":
                        Log("Usa 'Mostrar Todo' para ver la matriz.");
                        break;
                    case "Tabla Hash":
                        Log("Elementos: " + tablaHash.Count());
                        break;
                    case "Diccionario":
                        Log("Elementos: " + diccionario.Count());
                        break;
                }
            }
            catch (Exception ex)
            {
                Log("Info Estado: " + ex.Message);
            }
        }

        // --- BOTÓN BUSCAR (Solo Hash y Diccionario) ---
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtDato1.Text;
            string structName = cmbEstructuras.SelectedItem.ToString();
            Log($"Buscando '{filtro}' en {structName}...");

            try
            {
                List<(string Clave, string Valor)> resultados = new List<(string, string)>();

                if (structName == "Tabla Hash")
                {
                    resultados = tablaHash.Buscar(filtro);
                }
                else if (structName == "Diccionario")
                {
                    resultados = diccionario.Buscar(filtro);
                }

                if (resultados.Count > 0)
                {
                    foreach (var item in resultados)
                    {
                        Log($"Encontrado -> [{item.Clave}]: {item.Valor}");
                    }
                }
                else
                {
                    Log("No se encontraron coincidencias.");
                }
            }
            catch (Exception ex)
            {
                Log("Error búsqueda: " + ex.Message);
            }
        }

        // --- BOTÓN CLEAR ---
        private void btnClear_Click(object sender, EventArgs e)
        {
            string structName = cmbEstructuras.SelectedItem.ToString();

            switch (structName)
            {
                case "Pila (Stack)":
                    pila.Clear();
                    break;
                case "Cola Simple":
                    colaSimple = new ColaSimple();
                    break;
                case "Cola Circular":
                    colaCircular = new ColaCircular();
                    break;
                case "Cola Doble":
                    colaDoble = new ColaDoble();
                    break;
                case "Cola Prioridad":
                    colaPrioridad = new ColaPrioridad();
                    break;
                case "Lista Circular":
                    listaCircular = new ListCircular();
                    break;
                case "Lista Doble":
                    listaDoble = new DoubleList();
                    break;
                case "Árbol Binario":
                    arbol = new Arbol();
                    break;
                case "Grafo":
                    grafo = new Grafo(false, false);
                    break;
            }
            Log($"Estructura '{structName}' limpiada correctamente.");
        }
    }
}