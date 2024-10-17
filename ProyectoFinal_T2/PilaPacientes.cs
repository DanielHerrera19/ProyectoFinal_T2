using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_T2
{
    internal class PilaPacientes
    {
        private readonly int Max;
        static private int top;
        NodoPaciente[] Arreglo;

        public PilaPacientes(int Tamaño)
        {
            Max = Tamaño; //Define el tamaño de la pila
            top = 0; //Inicializa la pila vacia
            Arreglo = new NodoPaciente[Max]; //Creacion del arreglo de nodos
        }

        private bool PilaLlena()
        {
            if (top == Max)
                return true;
            else
                return false;
        }

        private bool PilaVacia()
        {
            if (top == 0)
                return true; //Pila esta vacia
            else
                return false; //Pila tiene elementos
        }

        public int Top
        {
            get { return top; } //Leer la cantidad de elementos de la pila
        }

        public bool Push(NodoPaciente Nodo)
        {
            //Peguntar si hay espacio en Pila
            if (!PilaLlena())
            {
                //Crear el espacio para el nuevo nodo de la pila       
                Arreglo[top] = Nodo; //Insertar el nodo en pila
                top++; //Incrementar en 1 la cantidad de nodos almacenados en pila
                return true; //Operacion exitosa
            }
            else
                return false; //No se pudo insertar el nodo en pila
        }

        public NodoPaciente Pop()
        {
            //Preguntar si la pila no esta vacia
            if (!PilaVacia())
            {
                Arreglo[top] = null; //Eliminar el nodo de la pila
                top--; //Disminuir en 1 la cantidad de nodos en pila
                return Arreglo[top]; //Devolver el nodo
            }
            else
                return null; //No se pudo realizar la eliminacion
        }
        public NodoPaciente Consultar(int r)
        {
            return Arreglo[r]; //Retornar el nodo consultado
        }

        public NodoPaciente BuscarPacientePorDni(int dni)
        {
            for (int i = top - 1; i >= 0; i--)
            {
                if (Arreglo[i].DniPac == dni)
                {
                    return Arreglo[i]; // Retorna el nodo si el paciente es encontrado
                }
            }
            return null; // Retorna null si no se encuentra
        }

        public bool ActualizarPaciente(NodoPaciente pacienteActualizado)
        {
            for (int i = top - 1; i >= 0; i--)
            {
                if (Arreglo[i].DniPac == pacienteActualizado.DniPac)
                {
                    Arreglo[i] = pacienteActualizado; // Actualiza el nodo del paciente
                    return true;
                }
            }
            return false; // Retorna false si no se encuentra
        }
    }
}
