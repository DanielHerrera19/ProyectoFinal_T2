using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_T2
{
    internal class NodoCola
    {
        public NodoArbol Valor;
        public NodoCola Siguiente;

        public NodoCola(NodoArbol valor)
        {
            this.Valor = valor;
            this.Siguiente = null;
        }
    }
}
