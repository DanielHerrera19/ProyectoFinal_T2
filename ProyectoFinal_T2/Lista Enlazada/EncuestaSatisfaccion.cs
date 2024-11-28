using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_T2.Lista_Enlazada
{
    public class EncuestaSatisfaccion
    {
        public string NombrePaciente { get; set; }
        public int DNI { get; set; }
        public DateTime FechaEncuesta { get; set; }
        public int Puntaje { get; set; } // Rango de 1 a 10
        public string Comentario { get; set; } // Opcional

        public EncuestaSatisfaccion(string nombre, int dni, DateTime fecha, int puntaje, string comentario = "")
        {
            NombrePaciente = nombre;
            DNI = dni;
            FechaEncuesta = fecha;
            Puntaje = puntaje;
            Comentario = comentario;
        }

        public override string ToString()
        {
            return $"Paciente: {NombrePaciente}, DNI: {DNI}, Fecha: {FechaEncuesta.ToShortDateString()}, Puntaje: {Puntaje}, Comentario: {Comentario}";
        }
    }
}