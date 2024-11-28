using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_T2
{
    internal class ListaDobleAdministradores
    {
        private NodoAdministradores cabeza;
        private NodoAdministradores cola;

        public ListaDobleAdministradores()
        {
            cabeza = null;
            cola = null;
        }

        public void AgregarAdministrador(string nombre, string contraseña)
        {
            NodoAdministradores nuevo = new NodoAdministradores(nombre, contraseña);
            if (cabeza == null)
            {
                cabeza = nuevo;
                cola = nuevo;
            }
            else
            {
                cola.Siguiente = nuevo;
                cola = nuevo;
            }
        }

        public bool ValidarAdministrador(string nombre, string contraseña)
        {
            NodoAdministradores actual = cabeza;
            while (actual != null)
            {
                if (actual.Nombre == nombre && actual.Contraseña == contraseña)
                {
                    return true;
                }
                actual = actual.Siguiente;
            }
            return false;
        }
    }
}
