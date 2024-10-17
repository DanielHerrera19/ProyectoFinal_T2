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

        static listadoctores a = new listadoctores();

        public static void agregar1()
        {
            a.agregardoctor();
        }
        public static void eliminar1()
        {
            a.eliminardoctor();
        }
        public static void modificar1()
        {
            a.modoficardoctor();
        }
        public static void mostrar1()
        {
            a.ver();
        }
        public static void buscar1()
        {
            a.buscardoctor();
        }

        static ColaReserva Cola = new ColaReserva(50);
        static PilaDeReservas pilaDeEliminados = new PilaDeReservas(10);

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
				Console.ForegroundColor = ConsoleColor.DarkBlue;
				Console.WriteLine(@"         
===================================================
██╗░░░██╗ ██╗ ░██████╗ ██╗ ░█████╗░ ███╗░░██╗
██║░░░██║ ██║ ██╔════╝ ██║ ██╔══██╗ ████╗░██║
╚██╗░██╔╝ ██║ ╚█████╗░ ██║ ██║░░██║ ██╔██╗██║
░╚████╔╝░ ██║ ░╚═══██╗ ██║ ██║░░██║ ██║╚████║
░░╚██╔╝░░ ██║ ██████╔╝ ██║ ╚█████╔╝ ██║░╚███║
░░░╚═╝░░░ ╚═╝ ╚═════╝░ ╚═╝ ░╚════╝░ ╚═╝░░╚══╝
===================================================   ");
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				
				Console.WriteLine("\nBienvenido a clinica oftalmologica ");
				
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
                Console.WriteLine($"Bienvenido(@), {nombre}");
                Console.ReadLine();
                Pantalla_Admin();
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

        public static int Pantalla_Admin()
        {
            int opcion = 0;
            do
            {
                //Liampiar pantalla
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("======================================");
                Console.WriteLine("|           ADMINISTRADOR            |");
                Console.WriteLine("======================================");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("1. Gestionar perfiles del personal medico");
                Console.WriteLine("2. Gestionar perfiles del paciente");
                Console.WriteLine("3. Gestion de citas reservadas");
                Console.WriteLine("4. Salir");
                Console.WriteLine("======================================");
                //Solicitar opción 
                Console.Write("Elige una opcion:");

                // Validación de la entrada
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    // Evaluar la opción seleccionada
                    switch (opcion)
                    {
                        case 1:
                            GestionarPersonal();
                            break;

                        case 2:
                            GestionarUsuarios();
                            break;

                        case 3:
                            GestionReserva();
                            break;

                        case 4:
                            // Opción de salida
                            Console.WriteLine("Saliendo del sistema...");
                            Environment.Exit(0);  // Cierra la consola
                            break;

                        default:
                            Console.WriteLine("Opción incorrecta. Intenta nuevamente.");
                            break;
                    }
                }
                else
                {
                    // Mensaje de error si la entrada no es un número
                    Console.WriteLine("Por favor, ingresa un número válido.");
                }
                // Pausa para que el usuario pueda ver el mensaje antes de limpiar la pantalla
                if (opcion != 4) // Solo pausar si no es la opción de salida
                {
                    Console.WriteLine("Presiona cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 4); // Repetir el ciclo hasta que se elija la opción 4
			return opcion;
		}
			
        public static void GestionarPersonal()
        {
            int opcion;
            do
            {
                Console.Clear();
				Console.ForegroundColor = ConsoleColor.DarkBlue;
				Console.WriteLine("=======================================");
                Console.WriteLine("|         GESTION DE DOCTORES         |");
                Console.WriteLine("=======================================");
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.WriteLine("|  1. Agregar  doctor                 |");
                Console.WriteLine("|  2. Eliminar doctor                 |");
                Console.WriteLine("|  3. Modificar doctor                |");
                Console.WriteLine("|  4. Mostrar  doctor                 |");
                Console.WriteLine("|  5. Buscar doctor                   |");
                Console.WriteLine("|  6. Salir                           |");
                Console.WriteLine("=======================================");
                Console.Write("Ingrese el número de opción: ");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        agregar1();
                        break;
                    case 2:
                        Console.Clear();
                        eliminar1();
                        break;
                    case 3:
                        Console.Clear();
                        modificar1();
                        break;
                    case 4:
                        Console.Clear();
                        mostrar1();
                        break;
                    case 5:
                        Console.Clear();
                        buscar1();
                        break;
                    case 6:
                        Pantalla_Admin();
                        break;

                }
                Console.ReadKey();
            } while (opcion != 7);
        }

        static void GestionarUsuarios()
        {
            

            int opc; //Opcion del menu

            //Definir el menu de pila
            do
            {
                Console.Clear();
				Console.ForegroundColor = ConsoleColor.DarkBlue;				
				Console.WriteLine("Lista de Pacientes");
                Console.WriteLine("*************************");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
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
                    case 5:
                        Pantalla_Admin();
                        break;
                }

                Console.ReadKey();
            } while (opc != 6);

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
			Console.ForegroundColor = ConsoleColor.DarkBlue;
			Console.WriteLine("[3] Mostrar Pacientes");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("         Paciente         |        DNI        |   Celular   |     Correo Electrónico    ");
            Console.WriteLine("---------------------------------------------------------------------------------------");
			Console.ForegroundColor = ConsoleColor.DarkCyan;
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

        static void GestionReserva()
        {
            // Precargar datos de pacientes al iniciar el programa
            CargaPacientesReserva.PrecargarDatos(Cola);
            int opcion;

            // Definir el menú para la cola de reservas
            do
            {
                MostrarMenu();
                opcion = ObtenerOpcion();

                switch (opcion)
                {
                    case 1: // Agregar una reserva a la cola
                        AgregarReserva();
                        break;

                    case 2: // Mostrar todas las reservas en la cola
                        MostrarReservas();
                        break;

                    case 3: // Eliminar una reserva de la cola
                        EliminarReserva();
                        break;

                    case 4: // Vaciar la cola
                        VaciarCola();
                        break;

                    case 5: // Salir
                        Pantalla_Admin();
                        break;

                    default:
                        Console.WriteLine("Opción no válida, intenta nuevamente.");
                        break;
                }

                Console.ReadKey();
            } while (opcion != 5);
        }

        static void MostrarMenu()
        {
            Console.Clear();
			Console.ForegroundColor = ConsoleColor.DarkBlue;
			Console.WriteLine("Reserva tu cita");
            Console.WriteLine("*************************");
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine("[1] Agregar Reserva");
            Console.WriteLine("[2] Mostrar Reservas");
            Console.WriteLine("[3] Eliminar la primera reserva hecha");
            Console.WriteLine("[4] Vaciar Reserva");
            Console.WriteLine("[5] Salir");
            Console.Write("Elige una opción: ");
        }

        // Método para obtener la opción del menú
        static int ObtenerOpcion()
        {
            int opcion = 0;
            try
            {
                opcion = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Por favor, ingresa un número válido.");
            }
            return opcion;
        }

        // Método para agregar una reserva
        static void AgregarReserva()
        {
            Console.Clear();
            Console.WriteLine("[1] Agregar Reserva");

            // Ingresar los datos de la reserva
            Console.Write("Nombre: ");
            string nombreReserva = Console.ReadLine();
            Console.Write("Apellido: ");
            string apellidoReserva = Console.ReadLine();
            Console.Write("DNI: ");
            int dniReserva;
            while (!int.TryParse(Console.ReadLine(), out dniReserva))
            {
                Console.WriteLine("Por favor, ingresa un número válido para el DNI.");
                Console.Write("DNI: ");
            }

            Console.Write("Número de Tarjeta: ");
            long numeroTarjeta;
            while (!long.TryParse(Console.ReadLine(), out numeroTarjeta))
            {
                Console.WriteLine("Por favor, ingresa un número válido para el número de tarjeta.");
                Console.Write("Número de Tarjeta: ");
            }

            // Crear el nodo de reserva utilizando el constructor con parámetros
            NodoReserva reserva = new NodoReserva(nombreReserva, apellidoReserva, dniReserva, numeroTarjeta);

            // Agregar la reserva a la cola
            if (Cola.encola(reserva))
            {
                Console.WriteLine("Reserva agregada exitosamente.");
            }
            else
            {
                Console.WriteLine("Error: Cola llena. No se puede agregar más reservas.");
            }
        }

        // Método para mostrar todas las reservas
        static void MostrarReservas()
        {
            Console.Clear();
			Console.ForegroundColor = ConsoleColor.DarkBlue;
			Console.WriteLine("[2] Mostrar Reservas");
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("  Nombre        | Apellido        |   DNI        |  Número de Tarjeta");
            Console.WriteLine("-----------------------------------------------------------------------");
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			if (!Cola.vaciaCola())
            {
                Cola.verCola();
            }
            else
            {
                Console.WriteLine("No hay reservas en la cola.");
            }

            Console.WriteLine("-----------------------------------------------------------------------");
        }

        // Método para eliminar la primera reserva de la cola
        static void EliminarReserva()
        {
            Console.Clear();
            Console.WriteLine("[3] Eliminar Reserva");

            NodoReserva reservaEliminada = Cola.desencola();

            if (reservaEliminada != null)
            {
                Console.WriteLine("Reserva eliminada exitosamente:");
                Console.WriteLine("Nombre: " + reservaEliminada.Nombre);
                Console.WriteLine("Apellido: " + reservaEliminada.Apellido);
                Console.WriteLine("DNI: " + reservaEliminada.Dni);
                Console.WriteLine("Número de Tarjeta: " + reservaEliminada.NumTarjeta);

                // Apilar la reserva eliminada en la pila
                pilaDeEliminados.ApilarReservaEliminada(reservaEliminada);
            }
            else
            {
                Console.WriteLine("Error: No hay reservas para eliminar.");
            }
        }

        // Método para vaciar la cola
        static void VaciarCola()
        {
            Console.Clear();
            Console.WriteLine("[4] Vaciar Cola");
            Cola = new ColaReserva(50); // Reinicia la cola
            Console.WriteLine("Cola vaciada exitosamente.");
        }
    }
}