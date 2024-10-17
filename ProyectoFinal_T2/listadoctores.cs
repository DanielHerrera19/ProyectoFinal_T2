using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_T2
{
    internal class listadoctores
    {
        public doctor primero;
        public doctor ultimo;

        public listadoctores()
        {
            primero = null;
            ultimo = null;

            insertar("Dr Juan", "Perez", 43511457, "Cirujia Ocular", 346854);
            insertar("Dr Daniel", "Hernandez", 73829104, "Oftalmología General", 346854);
            insertar("Dr Rodrigo", "Mendoza", 54683927, "Oftalmología Pediátrica", 346854);
            insertar("Dr Leonardo", "Cruz", 12098376, "Glaucoma", 346854);
            insertar("Dra Jimena", "Martinez", 78562431, "Retina y Vítreo", 346854);
            insertar("Dra Fiorella", "Romero", 49382715, "Oculoplastica", 346854);
            insertar("Dra Jenny", "Zevallos", 82576143, "Cirugía Refractiva", 346854);

        }
        public void insertar(string nombre, string apellido, int dni, string especialidad, int licencia)
        {
            doctor ingresar = new doctor(nombre, apellido, dni, especialidad, licencia);

            if (primero == null)
            {
                primero = ingresar;
                ultimo = ingresar;


            }
            else
            {
                ultimo.anterior = ingresar;
                ingresar.siguiente = ultimo;
                ultimo = ingresar;
            }
        }

        public void agregardoctor()
        {
            Console.WriteLine("Ingrese el nombre del doctor: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el apellido del doctor: ");
            string apellido = Console.ReadLine();
            Console.WriteLine("Ingrese el numero del Dni: ");
            int dni = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la especialidad del doctor: ");
            string especialidad = Console.ReadLine();
            Console.WriteLine("Ingrese la licencia del doctor: ");
            int licencia = int.Parse(Console.ReadLine());
            insertar(nombre, apellido, dni, especialidad, licencia);

        }

        public void buscardoctor()
        {
            bool r = false;
            Console.WriteLine("Ingrese la licencia del doctor: ");
            int licencia = int.Parse(Console.ReadLine());
            doctor puntero = ultimo;

            while (puntero != null)
            {
                if (puntero.licencia == licencia && r == false)
                {
                    Console.WriteLine("Nombre : " + puntero.nombre + " | " + "Apellido : " + puntero.apellido + " | " + "Dni : " + puntero.dni + " | " + "Especialidad : " + puntero.especialidad + " | " + "Licencia : " + puntero.licencia);
                    r = true;
                }
                puntero = puntero.siguiente;
            }
            if (r == false)
            {
                Console.WriteLine("El doctor no existe!!!");
            }
        }

        public void modoficardoctor()
        {
            bool d = false;
            Console.WriteLine("Ingrese la licencia del doctor: ");
            int licencia = int.Parse(Console.ReadLine());
            doctor puntero = ultimo;

            if (primero != null)
            {
                while (puntero != null && d == false)
                {
                    Console.WriteLine("Ingrese el dato que desee cambiar en la base de datos: ");
                    string info = Console.ReadLine();
                    if ("nombre" == info)
                    {
                        Console.WriteLine("Ingrese el nombre: ");
                        puntero.nombre = Console.ReadLine();
                        Console.WriteLine("Nombre cambiado ");
                        d = true;
                    }
                    if ("apelliddo" == info)
                    {
                        Console.WriteLine("Ingrese el apellido: ");
                        puntero.nombre = Console.ReadLine();
                        Console.WriteLine("Apellido cambiado ");
                        d = true;
                    }
                    if ("dni" == info)
                    {
                        Console.WriteLine("Ingrese el dni: ");
                        puntero.nombre = Console.ReadLine();
                        Console.WriteLine("Dni cambiado ");
                        d = true;
                    }
                    if ("especialidad" == info)
                    {
                        Console.WriteLine("Ingrese la especialidad: ");
                        puntero.nombre = Console.ReadLine();
                        Console.WriteLine("Especialidad cambiada ");
                        d = true;
                    }
                    if ("licencia" == info)
                    {
                        Console.WriteLine("Ingrese la licencia: ");
                        puntero.nombre = Console.ReadLine();
                        Console.WriteLine("Licencia cambiado ");
                        d = true;
                    }
                    puntero = puntero.siguiente;
                }
                if (d == false)
                {
                    Console.WriteLine("La licencia no existe!!!");
                }
            }
            else
            {
                Console.WriteLine("La lista está vacía!");
            }
        }

        public void eliminardoctor()
        {
            bool j = false;
            Console.WriteLine("Ingresa la licencia del doctr que deseas eliminar :");
            int licencia = int.Parse(Console.ReadLine());

            doctor eliminar = ultimo;
            doctor puntero = ultimo;

            if (primero != null)
            {
                while (eliminar != null)
                {
                    if (eliminar.licencia == licencia)
                    {
                        if (eliminar == ultimo)
                        {
                            ultimo = ultimo.siguiente;
                            j = true;
                        }
                        else if (eliminar == primero)
                        {
                            puntero = primero.anterior;
                            puntero.siguiente = primero.siguiente;
                            primero = puntero;
                            j = true;
                        }
                        else
                        {
                            puntero = eliminar.anterior;
                            puntero.siguiente = eliminar.siguiente;
                            j = true;
                        }
                        Console.WriteLine("Elemento Eliminado");
                    }
                    eliminar = eliminar.siguiente;
                }
                if (j == false)
                {
                    Console.WriteLine("Dni no existe ..........");
                }
            }
            else
            {
                Console.WriteLine("Lista vacia ....");
            }
        }

        public void ver()
        {
            doctor u = ultimo;
            Console.WriteLine(" -------------------------------------------------");
            Console.WriteLine("| NOMBRE " + "|" + " APELLIDO " + " | " + " DNI " + "    |" + " ESPECIALIDAD " + "|" + " LICENCIA |");
            Console.WriteLine(" -------------------------------------------------");
            while (u != null)
            {


                Console.WriteLine(u.nombre + "   " + u.apellido + " " + u.dni + " " + u.especialidad + "  " + u.licencia);
                Console.WriteLine("------------------------------------------");
                u = u.siguiente;
            }
        }

        public string devolver3(int s)
        {
            bool p = false;
            string m = "";
            doctor w = ultimo;

            while (w != null && p == false)
            {
                if (w.dni == s)
                {
                    m = w.nombre;
                    p = true;
                }
                w = w.siguiente;
            }
            if (p == false)
            {
                m = "x";
            }
            return m;

        }

        public int dni(string k)
        {
            int e = 1;
            bool n = false;
            doctor j = ultimo;
            while (j != null && n == false)
            {
                if (j.nombre == k)
                {
                    e = j.dni;
                    n = true;
                }
                j = j.siguiente;
            }
            if (n == false)
            {
                e = 0;
            }
            return e;
        }
    }
}
