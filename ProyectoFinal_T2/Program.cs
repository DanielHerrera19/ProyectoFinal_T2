using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_T2
{
    class Program
    {
        public static PilaPacientes Pila = new PilaPacientes(50);
        static void Main(string[] args)
        {
            ListaDobleAdministradores listaAdministradores = new ListaDobleAdministradores();
            listaAdministradores.AgregarAdministrador("Emmanuel Espiritu", "leoncito");
            listaAdministradores.AgregarAdministrador("Gonzalo Castillo", "elprimo");
            listaAdministradores.AgregarAdministrador("Lisa Mendoza", "patito");

            // Inicializar la pila de pacientes y precargar los datos
            
            CargaPacientes.PrecargarDatos(Pila);

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
                        IngresoUsuarios(Pila);
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
            Pantalla_Admin();
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

        public static int Pantalla_Admin()
        {
            int opcion = 0;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("|-----------------------------------|");
                Console.WriteLine("|           ADMINISTRADOR           |");
                Console.WriteLine("|-----------------------------------|");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1. Gestionar perfiles del personal medico");
                Console.WriteLine("2. Gestionar perfiles del paciente");
                Console.WriteLine("3. Gestion de citas reservadas");
                Console.WriteLine("4. Salir");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Eliga opcion:"); opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:

                        break;
                    case 2:
                        GestionarUsuarios();
                        break;
                    case 3:
                        
                        break;
                    case 0:
                    default:
                        Console.WriteLine("Opcion incorrecta");
                        break;
                }
            } while (opcion != 4);
            return opcion;
        }

        static void GestionarUsuarios()
        {
            

            int opc; //Opcion del menu

            //Definir el menu de pila
            do
            {
                Console.Clear();
                Console.WriteLine("Lista de Pacientes");
                Console.WriteLine("*************************");
                Console.WriteLine("[1] Ingresar Paciente (Push)");
                Console.WriteLine("[2] Eliminar Paciente (Pop)");
                Console.WriteLine("[3] Mostrar Pacientes");
                Console.WriteLine("[4] Modificar datos");
                Console.WriteLine("[5] Salir");
                Console.Write("Ingrese Opcion : ");
                opc = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (opc)
                {
                    case 1: //Push Agregar 

                       IngresarPaciente();
                        break;


                    case 2: //Pop Eliminar

                        EliminarPaciente();
                        break;

                    case 3:

                        MostrarPacientes();
                        break;

                    case 4:

                        ModificarPaciente();
                        break;
                }

                Console.ReadKey();
            } while (opc != 5);

        }

        // Función para agregar un paciente
        public static void IngresarPaciente()
        {
            Console.Clear();
            Console.WriteLine("[1] Registro de Pacientes (Push)");

            // Ingresar datos del paciente
            NodoPaciente nuevoPaciente = new NodoPaciente();
            Console.Write("Nombre del paciente : ");
            nuevoPaciente.NombrePaciente = Console.ReadLine();
            nuevoPaciente.DniPac = LeerDni("DNI :  ");
            nuevoPaciente.NroCelular = LeerCelular("Número de celular : ");
            Console.Write("Correo Electrónico: ");
            nuevoPaciente.CorreoElec = Console.ReadLine();
            Console.Write("Contraseña: ");
            nuevoPaciente.Contraseña = Console.ReadLine();

            // Intentar agregar el paciente a la pila
            if (Pila.Push(nuevoPaciente))
            {
                Console.Clear();
                Console.WriteLine("Paciente agregado exitosamente:");
                MostrarDatosPaciente(nuevoPaciente);
            }
            else
            {
                Console.WriteLine("Error: La pila está llena, no se pudo agregar el paciente.");
            }
        }

        // Función para eliminar un paciente
        public static void EliminarPaciente()
        {
            Console.Clear();
            Console.WriteLine("[2] Eliminar Paciente (Pop)");
            Console.WriteLine("");

            NodoPaciente pacienteEliminado = Pila.Pop(); // Eliminar el paciente de la pila

            if (pacienteEliminado != null)
            {
                Console.WriteLine("Paciente eliminado:");
                MostrarDatosPaciente(pacienteEliminado);
            }
            else
            {
                Console.WriteLine("Error: No hay pacientes en la pila para eliminar.");
            }
        }

        // Función para mostrar los pacientes en la pila
        public static void MostrarPacientes()
        {
            Console.Clear();
            Console.WriteLine("[3] Mostrar Pacientes");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("         Paciente         |        DNI        |   Celular   |     Correo Electrónico    ");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            for (int i = 0; i < Pila.Top; i++)
            {
                NodoPaciente paciente = Pila.Consultar(i);
                Console.WriteLine(paciente.NombrePaciente.PadRight(25) + " | " +
                                  paciente.DniPac.ToString().PadRight(16) + "  | " +
                                  paciente.NroCelular.ToString().PadRight(10) + "  | " +
                                  paciente.CorreoElec.PadRight(25));
            }

            Console.WriteLine("---------------------------------------------------------------------------------------");
        }

        // Función para modificar los datos de un paciente
        public static void ModificarPaciente()
        {
            Console.Clear();
            Console.WriteLine("[4] Modificar Paciente por DNI");

            int dni = LeerDni("Ingrese el DNI del paciente a modificar: ");

            NodoPaciente paciente = Pila.BuscarPacientePorDni(dni);

            if (paciente != null)
            {
                Console.WriteLine("\nDatos actuales del paciente:");
                MostrarDatosPaciente(paciente);
                Console.WriteLine("");

                paciente.NombrePaciente = LeerString("Nuevo Nombre del paciente: ");
                paciente.DniPac = LeerDni("DNI : ");
                paciente.NroCelular = LeerCelular("Nuevo Número de celular:  ");
                paciente.CorreoElec = LeerString("Nuevo Correo Electrónico: ");
                paciente.Contraseña = LeerString("Nueva Contraseña: ");

                if (Pila.ActualizarPaciente(paciente))
                {
                    Console.WriteLine("Paciente modificado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Error al modificar el paciente.");
                }
            }
            else
            {
                Console.WriteLine("Error: Paciente no encontrado.");
            }
        }

        // Función para mostrar los datos de un paciente
        static void MostrarDatosPaciente(NodoPaciente paciente)
        {
            Console.WriteLine("Nombre: " + paciente.NombrePaciente);
            Console.WriteLine("DNI: " + paciente.DniPac);
            Console.WriteLine("Número de celular: " + paciente.NroCelular);
            Console.WriteLine("Correo Electrónico: " + paciente.CorreoElec);
        }

        static int LeerDni(string mensaje)
        {
            int dni;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out dni) || dni < 10000000 || dni > 99999999)
            {
                Console.WriteLine("Por favor, ingrese un DNI válido de 8 dígitos.");
                Console.Write("DNI: ");
            }
            return dni;
        }

        static int LeerCelular(string mensaje)
        {
            int celular;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out celular) || celular < 100000000 || celular > 999999999)
            {
                Console.WriteLine("Por favor, ingrese un número de celular válido de 9 dígitos.");
                Console.Write("Numero de celular: ");
            }
            return celular;
        }

        static string LeerString(string mensaje)
        {
            Console.Write(mensaje);
            return Console.ReadLine();
        }
    }
}
