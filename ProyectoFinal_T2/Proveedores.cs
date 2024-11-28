using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_T2
{
    internal class Proveedores
    {
        public Proveedor listaP;
        public Proveedores() { listaP = null; }
        public void agregarProv(Proveedor nuevoP) //se agregara al inicio
        {

            //apuntador

            if (listaP == null)
            {
                listaP = nuevoP;
                nuevoP.sgte = nuevoP;
            }

            else
            {
                Proveedor q = listaP;
                while (q.sgte != listaP)
                {
                    q = q.sgte;
                }

                nuevoP.sgte = listaP;
                listaP = nuevoP;
                q.sgte = nuevoP;


            }
        }

        public void buscarProv(long ruc)
        {
            Proveedor t = listaP;
            bool marca = false;

            if (listaP == null) { Console.WriteLine("Lista esta vacia"); }
            else
            {
                do
                {
                    if (t.ruc == ruc)
                    {
                        Console.WriteLine(" RUC " + t.ruc + " ENCONTRADO");
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine(" Se muestran datos del Proveedor");
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine(" Razon Social : " + t.nombreP);
                        Console.WriteLine(" Ruc : " + t.ruc);
                        Console.WriteLine(" Contacto : " + t.contacto);
                        Console.WriteLine(" Telefono : " + t.telefono);
                        Console.WriteLine("-------------------------------");
                        marca = true;
                        return;
                    }
                    t = t.sgte;

                } while (t != listaP);
            }

            if (marca == false)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine(" RUC no ha sido encontrado");

            }
        }
        public Proveedor buscarProvedor(long ruc)
        {
            Proveedor t = listaP;
            bool marca = false;
            Proveedor bus = new Proveedor("", 0, "", 0);
            if (listaP == null) { Console.WriteLine("Lista esta vacia"); }
            else
            {
                do
                {
                    if (t.ruc == ruc)
                    {
                        Console.WriteLine(" RUC " + t.ruc + " ENCONTRADO");
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine(" Razon Social : " + t.nombreP);
                        Console.WriteLine("-------------------------------");
                        marca = true;
                        bus = new Proveedor(t.nombreP, t.ruc, t.contacto, t.telefono);
                        break;
                    }
                    t = t.sgte;

                } while (t != listaP);
            }

            if (marca == false)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine(" RUC no ha sido encontrado");

            }
            return bus;
        }
        public void modificarProv(long ruc)//se buscara por ruc y se mostraran los campos para actualizar 
        {
            Proveedor t = listaP;
            bool marca = false;

            if (listaP == null) //verifica si la lista esta vacia 
            {
                Console.WriteLine(" Lista vacia");

            }
            else
            {
                do
                {
                    if (t.ruc == ruc)
                    {
                        Console.WriteLine(" RUC " + t.ruc + " ENCONTRADO");
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine(" *Razon Social : ");
                        string nombre = Console.ReadLine();
                        Console.WriteLine(" *Ingresar Contacto : ");
                        String contacto = Console.ReadLine();
                        Console.WriteLine(" *Ingresar telefono de contacto : ");
                        int telefono = int.Parse(Console.ReadLine());

                        t.nombreP = nombre;
                        t.contacto = contacto;
                        t.telefono = telefono;
                        marca = true;
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine(" Proveedor ha si modificado");
                        return;

                    }
                    t = t.sgte;
                } while (t != listaP);
            }
            if (marca == false)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine(" RUC no registrado");
            }
        }

        public void eliminarProv(long ruc)
        {
            Proveedor t = listaP, t2 = null;
            Proveedor aux;
            bool marca = false;

            if (listaP != null)
            {
                if (listaP.ruc == ruc)
                {
                    if (listaP.sgte == listaP) //unico nodo
                    {
                        listaP = null;
                        Console.WriteLine(" Proveedor eliminado ");
                        return;
                    }
                    if (t == listaP && t.sgte != listaP) //primer nodo 
                    {
                        t2 = listaP;
                        while (t2.sgte != listaP)
                        {
                            t2 = t2.sgte;
                        }

                        aux = listaP.sgte;
                        t2.sgte = aux;
                        listaP = aux;
                        t = null;
                        marca = true;
                        Console.WriteLine(" RUC" + ruc + "ENCONTRADO");
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("Proveedor eliminado");
                        return;
                    }
                }

                while (t.sgte != listaP) // nodo intermedio
                {
                    if (t.ruc == ruc)
                    {
                        aux = t.sgte;
                        t2.sgte = aux;
                        t = null;
                        marca = true;
                        return;

                    }
                    t2 = t;
                    t = t.sgte;

                }

                if (t.ruc == ruc && listaP.sgte != listaP) //ultimo nodo
                {
                    t2.sgte = listaP;
                    t = null;
                    marca = true;
                }
                if (marca == false)
                {
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine(" Elemento no encontrado");
                }



            }
            else
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine(" Lista esta vacia");
            }
        }

        public void mostrarProv()
        {
            Proveedor t = listaP;
            if (listaP == null)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine(" No hay elementos");
            }

            do
            {

                Console.Write("│ " + t.nombreP.ToString().PadRight(28, ' ') + " │ ");
                Console.Write(t.ruc.ToString().PadRight(13, ' ') + " │ ");
                Console.Write(t.contacto.PadRight(15, ' ') + " │ ");
                Console.WriteLine(t.telefono.ToString().PadRight(12, ' ') + " │ ");

                t = t.sgte;
            }
            while (t != listaP); //para que imprima almenos una vez 

        }

    }
}