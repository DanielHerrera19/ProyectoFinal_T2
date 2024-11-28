using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_T2
{
    internal class NodoPacientes
    {
            public PacientePrioridad Cliente { get; }
            public NodoPacientes Siguiente { get; set; }

            public NodoPacientes(PacientePrioridad cliente)
            {
                Cliente = cliente;
            }
        }
    }
