using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_T2
{
    internal class Cola
    {
        private NodoCola frente;
        private NodoCola final;

        public Cola()
        {
            this.frente = null;
            this.final = null;
        }

        // Encolar un nuevo nodo del árbol en la cola
        public void Encolar(NodoArbol nodo)
        {
            NodoCola nuevoNodo = new NodoCola(nodo);
            if (final == null)
            {
                frente = nuevoNodo;
                final = nuevoNodo;
            }
            else
            {
                final.Siguiente = nuevoNodo;
                final = nuevoNodo;
            }
        }

        // Desencolar y devolver el nodo del árbol
        public NodoArbol Desencolar()
        {
            if (frente == null) return null;

            NodoArbol nodo = frente.Valor;
            frente = frente.Siguiente;
            if (frente == null) final = null;
            return nodo;
        }

        // Verificar si la cola está vacía
        public bool EstaVacia()
        {
            return frente == null;
        }
    }
}
