using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_T2
{
    internal class ColaReservaConLista
    {
        private NodoReserva frente;
        private NodoReserva final;

        public ColaReservaConLista()
        {
            frente = null;
            final = null;
        }

        // Encolar
        public void encola(NodoReserva reserva)
        {
            if (final == null)
            {
                frente = reserva;
                final = reserva;
            }
            else
            {
                final.Siguiente = reserva;
                final = reserva;
            }
            Console.WriteLine("Reserva agregada: " + reserva.Nombre);
        }

        // Desencolar
        public NodoReserva desencola()
        {
            if (frente == null)
            {
                Console.WriteLine("La cola está vacía.");
                return null;
            }

            NodoReserva reservaEliminada = frente;
            frente = frente.Siguiente;

            if (frente == null)
                final = null;

            return reservaEliminada;
        }

        // Mostrar reservas
        public void verCola()
        {
            if (frente == null)
            {
                Console.WriteLine("La cola está vacía.");
                return;
            }

            NodoReserva actual = frente;
            while (actual != null)
            {
                Console.WriteLine($"Nombre: {actual.Nombre}, Apellido: {actual.Apellido}, DNI: {actual.Dni}, Tarjeta: {actual.NumTarjeta}");
                actual = actual.Siguiente;
            }
        }
    }
}
