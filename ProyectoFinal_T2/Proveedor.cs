using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_T2
{
    internal class Proveedor
    {
        public string nombreP;
        public long ruc;
        public string contacto;
        public long telefono;
        public Proveedor sgte;

        public Proveedor(string nombreP, long ruc, string contacto, long telefono)
        {
            this.nombreP = nombreP;
            this.ruc = ruc;
            this.contacto = contacto;
            this.telefono = telefono;
            sgte = null;
        }
    }
}
