using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_T2
{
    internal class ColaDePrioridad
    {
        private NodoPacientes primero;
        public ColaDePrioridad()
        {
            // Pacientes ficticios iniciales
            PacientePrioridad clienteprio1 = new PacientePrioridad("Josue", "Perez", 12345678, 30, "juan@gmail.com", "Cirujia Ocular", 987654321, true);
            PacientePrioridad clienteprio2 = new PacientePrioridad("Marcos", "Perez", 11111111, 25, "marcvos@gmail.com", "Oftalmología General", 111111111, true);
            PacientePrioridad clienteprio3 = new PacientePrioridad("Carlos", "Lopez", 22222222, 40, "carlos@gmail.com", "Oftalmología Pediátrica", 222222222, true);
            PacientePrioridad clienteprio4 = new PacientePrioridad("Sara", "Lopez", 33333333, 35, "sara@gmail.com", "Oculoplastica", 333333333, false);
            PacientePrioridad clienteprio5 = new PacientePrioridad("Pedro", "Lopez", 44444444, 28, "pedro@gmail.com", "Cirugía Refractiva", 444444444, false);

            // Nodos para cada Paciente
            NodoPacientes nodo1 = new NodoPacientes(clienteprio1);
            NodoPacientes nodo2 = new NodoPacientes(clienteprio2);
            NodoPacientes nodo3 = new NodoPacientes(clienteprio3);
            NodoPacientes nodo4 = new NodoPacientes(clienteprio4);
            NodoPacientes nodo5 = new NodoPacientes(clienteprio5);

            nodo1.Siguiente = nodo2;
            nodo2.Siguiente = nodo3;
            nodo3.Siguiente = nodo4;
            nodo4.Siguiente = nodo5;

            primero = nodo1;
        }

        public void RegistrarCita()
        {
            Console.WriteLine("Ingrese los datos de la cita:");

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();

            Console.Write("DNI: ");
            if (!int.TryParse(Console.ReadLine(), out int dni))
            {
                Console.WriteLine("Ingrese un dni valido");
                return;
            }

            Console.Write("Edad: ");
            if (!int.TryParse(Console.ReadLine(), out int edad))
            {
                Console.WriteLine("Ingrese una edad valida");
                return;
            }

            Console.Write("Correo: ");
            string correo = Console.ReadLine();

            Console.WriteLine("Seleccione el servicio:");
            Console.WriteLine("1. Cirujia Ocular");
            Console.WriteLine("2. Oftalmología General");
            Console.WriteLine("3. Oftalmología Pediátrica");
            Console.WriteLine("4. Oculoplastica");
            Console.WriteLine("5. Cirugía Refractiva");
            Console.Write("Ingrese el número de especialidad: ");
            int opcionServicio;
            if (!int.TryParse(Console.ReadLine(), out opcionServicio) || opcionServicio < 1 || opcionServicio > 5)
            {
                Console.WriteLine("Opción de servicio no válida.");
                return;
            }
            string tipoServicio = "";
            switch (opcionServicio)
            {
                case 1:
                    tipoServicio = "Cirujia Ocular";
                    break;
                case 2:
                    tipoServicio = "Oftalmología General";
                    break;
                case 3:
                    tipoServicio = "Oftalmología Pediátrica";
                    break;
                case 4:
                    tipoServicio = "Oculoplastica";
                    break;
                case 5:
                    tipoServicio = "Cirugía Refractiva";
                    break;
            }


            Console.Write("Numero de celular: ");
            if (!int.TryParse(Console.ReadLine(), out int celular))
            {
                Console.WriteLine("Ingrese un numero valido");
                return;
            }

            Console.Write("¿Tiene Seguro? (Sí = S, No = N): ");
            bool esSeguro = Console.ReadLine().Trim().ToUpper() == "S";

            //cREA NUEVO PACIENTE
            PacientePrioridad nuevoCliente = new PacientePrioridad(nombre, apellido, dni, edad, correo, tipoServicio, celular, esSeguro);

            // Nuevo nodo con el Paciente
            NodoPacientes nuevoNodo = new NodoPacientes(nuevoCliente);

            // Insertar nodo segun la prioridad SI TIENE SEGURO 
            if (primero == null || nuevoCliente.esSeguro)
            {
                nuevoNodo.Siguiente = primero;
                primero = nuevoNodo;
            }
            else
            {
                NodoPacientes actual = primero;

                // Buscar la posiciOn donde insertar el nuevo nodo
                while (actual.Siguiente != null && actual.Siguiente.Cliente.esSeguro)
                {
                    actual = actual.Siguiente;
                }

                nuevoNodo.Siguiente = actual.Siguiente;
                actual.Siguiente = nuevoNodo;
            }

            Console.WriteLine("Cita registrada correctamente.");
        }

        //Metodo para eliminar cita
        public void EliminarCita()
        {
            if (primero == null)
            {
                Console.WriteLine("No hay citas registradas.");
                return;
            }

            Console.Write("Ingrese el DNI del cliente para eliminar la cita: ");
            if (!int.TryParse(Console.ReadLine(), out int dniCliente))
            {
                Console.WriteLine("DNI debe ser un número entero.");
                return;
            }

            if (primero.Cliente.DNI == dniCliente)
            {
                primero = primero.Siguiente;
                Console.WriteLine($"Cita con DNI {dniCliente} eliminada correctamente.");
                return;
            }

            NodoPacientes actual = primero;

            while (actual.Siguiente != null)
            {
                if (actual.Siguiente.Cliente.DNI == dniCliente)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    Console.WriteLine($"Cita con DNI {dniCliente} eliminada correctamente.");
                    return;
                }
                actual = actual.Siguiente;
            }
        }

        public void ModificarCita()
        {
            Console.Write("Ingrese el DNI del Paciente para modificar la cita: ");
            if (!int.TryParse(Console.ReadLine(), out int dniCliente))
            {
                Console.WriteLine("DNI debe ser un número entero.");
                return;
            }

            NodoPacientes actual = primero;

            while (actual != null)
            {
                if (actual.Cliente.DNI == dniCliente)
                {
                    Console.WriteLine("Datos actuales del cliente:");
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("| NOMBRE".PadRight(22) + "| APELLIDO".PadRight(20) + "| DNI".PadRight(15) + "| EDAD".PadRight(10)
                                         + "| CORREO".PadRight(25) + "| SERVICIO".PadRight(15)
                                         + "| CELULAR".PadRight(15) + "| SEGURO".PadRight(5) + "  |");
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine($"| {actual.Cliente.Nombre.PadRight(20)}" +
                                  $"| {actual.Cliente.Apellido.PadRight(18)}" +
                                  $"| {actual.Cliente.DNI.ToString().PadRight(13)}" +
                                  $"| {actual.Cliente.Edad.ToString().PadRight(8)}" +
                                  $"| {actual.Cliente.Correo.PadRight(23)}" +
                                  $"| {actual.Cliente.TipoServicio.PadRight(13)}" +
                                  $"| {actual.Cliente.Celular.ToString().PadRight(13)}" +
                                  $"| {(actual.Cliente.esSeguro ? "Si" : "No").PadRight(3)}  |");
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");

                    Console.WriteLine("Ingrese los nuevos datos:");

                    Console.Write("Nuevo Nombre: ");
                    string nuevoNombre = Console.ReadLine();

                    Console.Write("Nuevo Apellido: ");
                    string nuevoApellido = Console.ReadLine();

                    Console.Write("Nueva Edad: ");
                    int nuevaEdad;
                    if (!int.TryParse(Console.ReadLine(), out nuevaEdad))
                    {
                        Console.WriteLine("Edad debe ser un número entero. No se modificó.");
                        return;
                    }

                    Console.Write("Nuevo Correo: ");
                    string nuevoCorreo = Console.ReadLine();

                    Console.WriteLine("Seleccione el nuevo servicio:");
                    Console.WriteLine("1. Cirujia Ocular");
                    Console.WriteLine("2. Oftalmología General");
                    Console.WriteLine("3. Oftalmología Pediátrica");
                    Console.WriteLine("4. Oculoplastica");
                    Console.WriteLine("5. Cirugía Refractiva");
                    Console.Write("Ingrese el número de servicio: ");
                    int opcionServicio;
                    if (!int.TryParse(Console.ReadLine(), out opcionServicio) || opcionServicio < 1 || opcionServicio > 5)
                    {
                        Console.WriteLine("Opción de servicio no válida. No se modificó.");
                        return;
                    }
                    string nuevoServicio = "";
                    switch (opcionServicio)
                    {
                        case 1:
                            nuevoServicio = "Cirujia Ocular";
                            break;
                        case 2:
                            nuevoServicio = "Oftalmología General";
                            break;
                        case 3:
                            nuevoServicio = "Oftalmología Pediátrica";
                            break;
                        case 4:
                            nuevoServicio = "Oculoplastica";
                            break;
                        case 5:
                            nuevoServicio = "Cirugía Refractiva";
                            break;
                    }

                    Console.Write("Nuevo numero de celular: ");
                    int nuevoCelular;
                    if (!int.TryParse(Console.ReadLine(), out nuevoCelular))
                    {
                        Console.WriteLine("Edad debe ser un número entero. No se modificó.");
                        return;
                    }

                    Console.Write("¿Tiene Seguro? (Sí = S, No = N): ");
                    bool nuevoesSeguro = Console.ReadLine().Trim().ToUpper() == "S";

                    // Actualiza LOS DATOS DEL CLIENTE
                    actual.Cliente.Nombre = nuevoNombre;
                    actual.Cliente.Apellido = nuevoApellido;
                    actual.Cliente.Edad = nuevaEdad;
                    actual.Cliente.Correo = nuevoCorreo;
                    actual.Cliente.TipoServicio = nuevoServicio;
                    actual.Cliente.Celular = nuevoCelular;
                    actual.Cliente.esSeguro = nuevoesSeguro;

                    Console.WriteLine("Cita modificada correctamente.");
                    return;
                }

                actual = actual.Siguiente;
            }

            Console.WriteLine($"No se encontro la cita con DNI {dniCliente}.");
        }

        public void BuscarCita()
        {
            Console.Write("Ingrese el DNI del cliente que quiere buscar: ");
            if (!int.TryParse(Console.ReadLine(), out int dniCliente))
            {
                Console.WriteLine("DNI debe ser un número entero.");
                return;
            }

            NodoPacientes actual = primero;
            bool encontrado = false;

            while (actual != null)
            {
                if (actual.Cliente.DNI == dniCliente)
                {
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("| NOMBRE".PadRight(22) + "| APELLIDO".PadRight(20) + "| DNI".PadRight(15) + "| EDAD".PadRight(10)
                                         + "| CORREO".PadRight(25) + "| SERVICIO".PadRight(15)
                                         + "| CELULAR".PadRight(15) + "| SEGURO".PadRight(5) + "  |");
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine($"| {actual.Cliente.Nombre.PadRight(20)}" +
                                  $"| {actual.Cliente.Apellido.PadRight(18)}" +
                                  $"| {actual.Cliente.DNI.ToString().PadRight(13)}" +
                                  $"| {actual.Cliente.Edad.ToString().PadRight(8)}" +
                                  $"| {actual.Cliente.Correo.PadRight(23)}" +
                                  $"| {actual.Cliente.TipoServicio.PadRight(13)}" +
                                  $"| {actual.Cliente.Celular.ToString().PadRight(13)}" +
                                  $"| {(actual.Cliente.esSeguro ? "Si" : "No").PadRight(3)}  |");
                    encontrado = true;
                    break;
                }

                actual = actual.Siguiente;
            }
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");

            if (!encontrado)
            {
                Console.WriteLine($"No se encontro cliente con DNI {dniCliente}.");
            }
        }

        public void MostrarCita()
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("| NOMBRE".PadRight(22) + "| APELLIDO".PadRight(20) + "| DNI".PadRight(15) + "| EDAD".PadRight(10)
                                 + "| CORREO".PadRight(25) + "| SERVICIO".PadRight(15)
                                 + "| CELULAR".PadRight(15) + "| SEGURO".PadRight(5) + "  |");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");

            NodoPacientes actual = primero;
            while (actual != null)
            {
                Console.WriteLine($"| {actual.Cliente.Nombre.PadRight(20)}" +
                                  $"| {actual.Cliente.Apellido.PadRight(18)}" +
                                  $"| {actual.Cliente.DNI.ToString().PadRight(13)}" +
                                  $"| {actual.Cliente.Edad.ToString().PadRight(8)}" +
                                  $"| {actual.Cliente.Correo.PadRight(23)}" +
                                  $"| {actual.Cliente.TipoServicio.PadRight(13)}" +
                                  $"| {actual.Cliente.Celular.ToString().PadRight(13)}" +
                                  $"| {(actual.Cliente.esSeguro ? "Si" : "No").PadRight(3)}  |");
                actual = actual.Siguiente;
            }
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
        }

        public void Desencolar()
        {
            primero = null;
            Console.WriteLine("Todos los elementos han sido desencolados correctamente.");

        }
    }
}

    

