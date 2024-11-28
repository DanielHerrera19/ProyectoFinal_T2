using ProyectoFinal_T2.Lista_Enlazada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_T2
{
    public class NodoEncuesta
    {
        public EncuestaSatisfaccion Datos { get; set; }
        public NodoEncuesta Siguiente { get; set; }

        public NodoEncuesta(EncuestaSatisfaccion datos)
        {
            Datos = datos;
            Siguiente = null;
        }
    }
}
