using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_T2
{
    internal class NodoPacientes
    {
        public string Nombre { get; set; }
        public int DNI { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public NodoPacientes Siguiente { get; set; }

        public NodoPacientes(string nombre, int dni, int telefono, string correo, string contraseña)
        {
            Nombre = nombre;
            DNI = dni;
            Telefono = telefono;
            Correo = correo;
            Contraseña = contraseña;
            Siguiente = null;
        }
    }
}
