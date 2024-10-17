using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_T2
{
    internal class NodoAdministradores
    {
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public NodoAdministradores Siguiente { get; set; }

        public NodoAdministradores(string nombre, string contraseña)
        {
            Nombre = nombre;
            Contraseña = contraseña;
            Siguiente = null;
        }
    }
}
