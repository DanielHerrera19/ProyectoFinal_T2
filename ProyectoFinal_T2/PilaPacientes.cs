using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_T2
{
    internal class PilaPacientes
    {
        private NodoPacientes cima;

        public PilaPacientes()
        {
            cima = null;
        }

        public void Push(NodoPacientes paciente)
        {
            paciente.Siguiente = cima;
            cima = paciente;
        }

        public NodoPacientes Pop()
        {
            if (cima == null) return null;

            NodoPacientes paciente = cima;
            cima = cima.Siguiente;
            return paciente;
        }

        public NodoPacientes Peek()
        {
            return cima;
        }

        public bool EstaVacia()
        {
            return cima == null;
        }
    }
}
