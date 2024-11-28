using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_T2.Lista_Enlazada
{
    namespace ProyectoFinal_T2.Listas_Enlazadas
    {
        public class ListaEncuestas
        {
            private NodoEncuesta Primero;

            public ListaEncuestas()
            {
                Primero = null;
            }

            public void AgregarEncuesta(EncuestaSatisfaccion encuesta)
            {
                NodoEncuesta nuevoNodo = new NodoEncuesta(encuesta);
                if (Primero == null)
                {
                    Primero = nuevoNodo;
                }
                else
                {
                    NodoEncuesta actual = Primero;
                    while (actual.Siguiente != null)
                    {
                        actual = actual.Siguiente;
                    }
                    actual.Siguiente = nuevoNodo;
                }
            }

            public void MostrarEncuestas()
            {
                if (Primero == null)
                {
                    Console.WriteLine("No hay encuestas registradas.");
                    return;
                }

                NodoEncuesta actual = Primero;
                while (actual != null)
                {
                    Console.WriteLine(actual.Datos);
                    actual = actual.Siguiente;
                }
            }

            public EncuestaSatisfaccion BuscarEncuestaPorDNI(int dni)
            {
                NodoEncuesta actual = Primero;
                while (actual != null)
                {
                    if (actual.Datos.DNI == dni)
                    {
                        return actual.Datos;
                    }
                    actual = actual.Siguiente;
                }
                return null;
            }

            public bool EliminarEncuestaPorDNI(int dni)
            {
                if (Primero == null) return false;

                if (Primero.Datos.DNI == dni)
                {
                    Primero = Primero.Siguiente;
                    return true;
                }

                NodoEncuesta actual = Primero;
                while (actual.Siguiente != null && actual.Siguiente.Datos.DNI != dni)
                {
                    actual = actual.Siguiente;
                }

                if (actual.Siguiente != null)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    return true;
                }

                return false;
            }
        }
    }
}
