using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_T2
{
    internal class NodoArbol
    {
        public int IdMedicamento;          
        public string NombreMedicamento;    
        public int Cantidad;                
        public string FechaVencimiento;   
        public double precio;
        public NodoArbol Izquierdo;
        public NodoArbol Derecho;

        public NodoArbol(int id, string nombre, int cantidad, double precio, string fechaVencimiento)
        {
            this.IdMedicamento = id;
            this.NombreMedicamento = nombre;
            this.Cantidad = cantidad;
            this.precio = precio;
            this.FechaVencimiento = fechaVencimiento;
            this.Izquierdo = null;
            this.Derecho = null;
        }
    }
}