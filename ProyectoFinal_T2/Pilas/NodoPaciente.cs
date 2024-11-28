using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_T2
{
    internal class NodoPaciente
    {
        private string nombrepac;
        private int dniPac;
        private int nroCelular;
        private string correo;
        private string contra;
        private int tope; // Índice del último paciente (cima de la pila)
        private int capacidad; // Capacidad del array


        public string NombrePaciente
        {
            get { return nombrepac; }
            set { nombrepac = value; }
        }

        public int DniPac
        {
            get { return dniPac; }
            set { dniPac = value; }
        }

        public int NroCelular
        {
            get { return nroCelular; }
            set { nroCelular = value; }
        }

        public string CorreoElec
        {
            get { return correo; }
            set { correo = value; }
        }

        public string Contraseña
        {
            get { return contra; }
            set { contra = value; }
        }

        public NodoPaciente(string nombre, int dni, int celular, string email, string contraseña)
        {
            this.nombrepac = nombre;
            this.dniPac = dni;
            this.nroCelular = celular;
            this.correo = email;
            this.contra = contraseña;
        }

        public NodoPaciente() { }
    }
}
