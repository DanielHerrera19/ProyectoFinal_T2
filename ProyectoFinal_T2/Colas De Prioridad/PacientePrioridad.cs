using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_T2
{
    internal class PacientePrioridad
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public int Edad { get; set; }
        public string Correo { get; set; }
        public string TipoServicio { get; set; }
        public int Celular { get; set; }
        public bool esSeguro { get; set; }

        public PacientePrioridad(string nombre, string apellido, int dni, int edad, string correo, string tipoServicio, int celular, bool Seguro)
        {
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
            Edad = edad;
            Correo = correo;
            TipoServicio = tipoServicio;
            Celular = celular;
            esSeguro = Seguro;
        }
    }
}

