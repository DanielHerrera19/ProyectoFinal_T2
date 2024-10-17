using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_T2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListaDobleAdministradores listaAdministradores = new ListaDobleAdministradores();
            listaAdministradores.AgregarAdministrador("Emmanuel Espiritu", "leoncito");
            listaAdministradores.AgregarAdministrador("Gonzalo Castillo", "elprimo");
            listaAdministradores.AgregarAdministrador("Lisa Mendoza", "patito");

            // Inicializar la pila de pacientes y precargar los datos
            PilaPacientes pilaPacientes = new PilaPacientes(50);
            CargaPacientes.PrecargarDatos(pilaPacientes);

            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("==================================");
                Console.WriteLine("             ▄█████▄                 ");
                Console.WriteLine("           ███  █  ███               ");
                Console.WriteLine("          ███   █   ███              ");
                Console.WriteLine("           ███  █  ███               ");
                Console.WriteLine("             ▀█████▀                 ");
                Console.WriteLine("==================================");
                Console.WriteLine("1. Administradores");
                Console.WriteLine("2. Usuarios");
                Console.WriteLine("3. Salir");
                Console.Write("Selecciona una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        IngresoAdministradores(listaAdministradores);
                        break;
                    case "2":
                        IngresoUsuarios(pilaPacientes);
                        break;
                    case "3":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        // Metodo para el ingreso de administradores
        static void IngresoAdministradores(ListaDobleAdministradores listaAdministradores)
        {
            Console.Clear();
            Console.Write("Ingrese nombre de administrador: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese contraseña: ");
            string contraseña = Console.ReadLine();

            // Usar la lista doblemente enlazada para validar administradores
            bool esValido = listaAdministradores.ValidarAdministrador(nombre, contraseña);

            if (esValido)
            {
                Console.WriteLine($"Bienvenido, {nombre}");
            }
            else
            {
                Console.WriteLine("Nombre o contraseña de administrador incorrectos.");
            }
            Console.ReadLine();
        }

        // Método para el ingreso de usuarios (pacientes)
        static void IngresoUsuarios(PilaPacientes pila)
        {
            Console.Clear();
            Console.Write("Ingrese DNI: ");
            int dni = int.Parse(Console.ReadLine());
            Console.Write("Ingrese Contraseña: ");
            string contraseña = Console.ReadLine();

            // Buscar al paciente en la pila por su DNI
            NodoPaciente actual = pila.BuscarPacientePorDni(dni);
            bool encontrado = false;

            // Verificar si el paciente fue encontrado y la contraseña es correcta
            if (actual != null && actual.Contraseña == contraseña)
            {
                Console.WriteLine($"Bienvenido, {actual.NombrePaciente}");
                encontrado = true;
            }

            if (!encontrado)
            {
                Console.WriteLine("DNI o contraseña incorrectos.");
            }

            Console.ReadLine(); // Pausar para que el usuario pueda leer el mensaje
        }
    }
}
