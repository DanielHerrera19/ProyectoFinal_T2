using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_T2
{
    internal class Arbol
    {
        public NodoArbol arbol;

        public Arbol()
        {

            Agregar(10006, "Vistagel 0.2%", 40, 47.30, "20/12/2026");
            Agregar(10004, "Bio Tears", 80, 14.90, "15/06/2025");
            Agregar(10001, "Cosomidol", 42, 65.90, "11/08/2025");
            Agregar(10003, "Dortim", 45, 11.20, "30/04/2025");
            Agregar(10008, "Floril", 100, 12.40, "08/03/2026");
            Agregar(10010, "Framidex NF", 40, 10, "16/02/2026");
            Agregar(10007, "Gotabiotic Plus ", 30, 19.40, "30/12/2024");
            Agregar(10013, "Hidrocil Pensolac 0.5%", 150, 30.20, "27/09/2025");
            Agregar(10015, "Glamax Ocuviales", 70, 12.50, "22/07/2025");
        }

        public void Agregar(int id, string nombre, int cantidad, double precio, string fechave)
        {
            int Raiz;
            NodoArbol q = new NodoArbol(id, nombre, cantidad, precio, fechave);
            NodoArbol t = arbol;

            if (arbol == null)
            {
                arbol = q;
            }
            else
            {
                while (t != null)
                {
                    Raiz = t.IdMedicamento;
                    if (id < Raiz)
                    {
                        if (t.Izquierdo != null)
                        {
                            t = t.Izquierdo;
                        }
                        else
                        {
                            t.Izquierdo = q;
                            return;
                        }
                    }
                    else
                    {
                        if (id > Raiz || id == Raiz)
                        {
                            if (t.
                                Derecho != null)
                            {
                                t = t.Derecho;
                            }
                            else
                            {
                                t.Derecho = q;
                                return;
                            }
                        }
                    }
                }
            }
        }

        public void muestraInventario(NodoArbol arb, int cont)
        {
            
            if (arb == null)
            {
                return;
            }
            else
            {
                muestraInventario(arb.Derecho, cont + 1);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("***********************");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("ID del producto : " + arb.IdMedicamento);
                Console.WriteLine("Nombre : " + arb.NombreMedicamento);
                Console.WriteLine("inventario : " + arb.Cantidad);
                Console.WriteLine("Precio : " + "S/" + arb.precio);
                Console.WriteLine("Fecha de vencimiento : " + arb.FechaVencimiento);
                muestraInventario(arb.Izquierdo, cont + 1);
            }
        }

        public void muestraArbol(NodoArbol arb, int cont)
        {
            if (arb == null)
            {
                return;
            }
            else
            {
                muestraArbol(arb.Derecho, cont + 1);
                for (int i = 0; i < cont; i++)
                {
                    Console.Write("        ");
                }
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(arb.IdMedicamento);
                muestraArbol(arb.Izquierdo, cont + 1);
            }
        }


        public void preOrden(NodoArbol arb)
        {
            if (arb == null)
            {
                return;
            }
            else
            {
                Console.ForegroundColor= ConsoleColor.Green;
                Console.Write(arb.IdMedicamento + "-");
                preOrden(arb.Izquierdo);
                preOrden(arb.Derecho);
            }
        }

        public void inOrden(NodoArbol arb)
        {
            if (arb == null)
            {
                return;
            }
            else
            {
                inOrden(arb.Izquierdo);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(arb.IdMedicamento + "-");
                inOrden(arb.Derecho);
            }
        }

        public void postOrden(NodoArbol arb)
        {
            if (arb == null)
            {
                return;
            }
            else
            {
                postOrden(arb.Izquierdo);
                postOrden(arb.Derecho);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(arb.IdMedicamento + "-");
            }
        }
        public void RecorridoPorNiveles()
        {
            if (arbol == null)
            {
                Console.WriteLine("El árbol está vacío.");
                return;
            }

            Cola cola = new Cola();
            cola.Encolar(arbol);

            Console.WriteLine("Recorrido por niveles:");
            while (!cola.EstaVacia())
            {
                NodoArbol nodoActual = cola.Desencolar();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"ID: {nodoActual.IdMedicamento}, Nombre: {nodoActual.NombreMedicamento}, Cantidad: {nodoActual.Cantidad}, Precio: S/{nodoActual.precio}, Vencimiento: {nodoActual.FechaVencimiento}");

                if (nodoActual.Izquierdo != null)
                    cola.Encolar(nodoActual.Izquierdo);

                if (nodoActual.Derecho != null)
                    cola.Encolar(nodoActual.Derecho);
            }
        }

        //Metodo para buscar un elemento en el arbol de manera recursiva
        //Metodo que se llama a si mismo para buscar el dato en el arbol
        public int busquedaRec(NodoArbol arbol, int dato)
        {
            int Encontrado = 0; //Indica si se encontro o no el elemento en el arbol
            //Si el arbol no tiene nodos
            if (arbol == null) return Encontrado;
            //Si el dato buscado es menor al dato del nodo del arbol
            //Buscar el dato en el arbol por la izquierda
            if (dato < arbol.IdMedicamento)
                Encontrado = busquedaRec(arbol.Izquierdo, dato);
            //Si el dato buscado es mayor al dato del nodo del arbol
            //Buscar el dato en el arbol por la derecha
            else if (dato > arbol.IdMedicamento)
                Encontrado = busquedaRec(arbol.Derecho, dato);
            else Encontrado = 1; //Si son iguales lo encontro
            return Encontrado;
        }

        //Metodo para buscar un elemento en el arbol de manera Iterativa (por Bucle)
        public int busquedaIter(NodoArbol arb, int dato)
        {
            //Mientras hay nodos en el arbol
            while (arb != null)
            {
                //Si el dato buscado es menor al dato del nodo del arbol
                //Buscar el dato recorriendo el arbol por la izquierda
                if (dato < arb.IdMedicamento) arb = arb.Izquierdo;
                //Si el dato buscado es mayor al dato del nodo del arbol
                //Buscar el dato recorriendo el arbol por la derecha
                else if (dato > arb.IdMedicamento) arb = arb.Derecho;
                else return 1; //Dato encontrado
            }
            return 0; //Dato no encontrado en el arbol
        }

        public void BuscarMedicamento(int buscado)
        {
            int valorRaiz;
            NodoArbol t = arbol;
            int nivel = 0;

            if (arbol == null)
            {
                Console.WriteLine("Arbol vacio ... ");
            }
            else
            {
                while (t != null)
                {
                    valorRaiz = t.IdMedicamento;
                    if (buscado.CompareTo(valorRaiz) == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("------------------------------------");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\tMedicamento encontrado");
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("------------------------------------");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("ID       : " + t.IdMedicamento);
                        Console.WriteLine("Nombre   : " + t.NombreMedicamento);
                        Console.WriteLine("Cantidad : " + t.Cantidad);
                        Console.WriteLine("Precio   : " + t.precio);
                        Console.WriteLine("Fecha de vencimiento: " + t.FechaVencimiento);
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("------------------------------------");
                    }

                    if (buscado.CompareTo(valorRaiz) == -1)
                    {
                        if (t.Izquierdo != null)
                        {
                            t = t.Izquierdo;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (t.Derecho != null)
                        {
                            t = t.Derecho;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }

        }

        public void eliminaNodoABB(ref NodoArbol arbol, int dato)
        {
            NodoArbol p1, p2; //Punteros p1 y p2 referentes al nodo del arbol
            //Si el arbol no tiene elementos, salir
            if (arbol == null) return;
            //Si el dato es menor al dato del nodo del arbol,
            //eliminar el nodo por la izquierda
            if (dato < arbol.IdMedicamento) eliminaNodoABB(ref arbol.Izquierdo, dato);
            //Si el dato es mayor al dato del nodo del arbol,
            //eliminar el nodo por la derecha
            else if (dato > arbol.IdMedicamento) eliminaNodoABB(ref arbol.Derecho, dato);
            //Si soy iguales, no tiene hijos
            else if (arbol.Izquierdo == arbol.Derecho)
            {
                arbol = null; //Arbol apunta a null
            }
            //Si no tiene hijo por la izquierda
            else if (arbol.Izquierdo == null)
            {
                //p1 apunta al nodo del arbol (Guardar el puntero del elemento a eliminar)
                p1 = arbol;
                //Apuntar al hijo derecho del arbol
                arbol = arbol.Derecho;
                p1 = null; //p1 apunta a null (eliminar)
            }
            //Si no tiene hijo por la derecha
            else if (arbol.Derecho == null)
            {
                //p1 apunta al nodo del arbol (Guardar el puntero del elemento a eliminar)
                p1 = arbol;
                //Apuntar al hijo izquierdo del arbol
                arbol = arbol.Izquierdo;
                p1 = null; //p1 apunta a null (eliminar)
            }
            else
            {
                //Si el arbol tiene dos hijos
                //p1 apunta al hijo derecho del arbol (guardar el puntero)
                p1 = arbol.Derecho;
                //p2 apunta al hijo derecho del arbol (para avanzar)
                p2 = arbol.Derecho;
                //Buscar el menor elemento de los mayores
                while (p2.Izquierdo != null)
                    //Avanzar hacia el siguiente hijo del arbol por la izquierda
                    p2 = p2.Izquierdo;
                //Hijo izquierdo de menor de mayor  = Hijo izquierdo de eliminado
                p2.Izquierdo = arbol.Izquierdo;
                arbol = null; //Eliminar nodo del arbol
                arbol = p1; //El padre apunta al derecho de eliminado
            }
        }
    }
}