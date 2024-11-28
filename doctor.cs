using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_T2
{
    internal class doctor
    {
        public string nombre;
        public string apellido;
        public int dni;
        public string especialidad;
        public int licencia;
        public doctor siguiente;
        public doctor anterior;

        public doctor(string nombre, string apellido, int dni, string especialidad, int licencia)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.especialidad = especialidad;
            this.licencia = licencia;
            siguiente = null;
            anterior = null;
        }
    }
}
