using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_T2
{
    internal class CargaPacientes
    {
        public static void PrecargarDatos(PilaPacientes pila)
        {
            {
                NodoPacientes paciente1 = new NodoPacientes("Carlos Diaz", 56789012, 998877665, "carlosdiaz@gmail.com", "carlosdiaz7");
                NodoPacientes paciente2 = new NodoPacientes("Jorge Rodriguez", 26151532, 983194992, "jorgerodriguez@gmail.com", "jorger12");
                NodoPacientes paciente3 = new NodoPacientes("Jorge Morales", 66841196, 977218864, "jorgemorales@gmail.com", "jorgemor74");
                NodoPacientes paciente4 = new NodoPacientes("Miguel Torres", 99667134, 924360256, "migueltorres@gmail.com", "miguelto63");
                NodoPacientes paciente5 = new NodoPacientes("Diego Rodriguez", 51580950, 970584218, "diegorodriguez@gmail.com", "diego716");
                NodoPacientes paciente6 = new NodoPacientes("Jose Garcia", 23211573, 951257494, "josegarcia@gmail.com", "jogarcia9195");
                NodoPacientes paciente7 = new NodoPacientes("Rafael Diaz", 41007722, 930288570, "rafaeldiaz@gmail.com", "diazraf9813");
                NodoPacientes paciente8 = new NodoPacientes("Manuel Lopez", 30621232, 936119426, "manuellopez@gmail.com", "maulopez8407");
                NodoPacientes paciente9 = new NodoPacientes("Marta Rojas", 25059421, 929805334, "martarojas@gmail.com", "rojas2279");
                NodoPacientes paciente10 = new NodoPacientes("Marta Diaz", 44966763, 958410488, "martadiaz@gmail.com", "diaz2414");
                NodoPacientes paciente11 = new NodoPacientes("Manuel Flores", 69627289, 921448685, "manuelflores@gmail.com", "flores2540");
                NodoPacientes paciente12 = new NodoPacientes("Jose Garcia", 32459722, 909421516, "josegarcia@gmail.com", "jose121");
                NodoPacientes paciente13 = new NodoPacientes("Manuel Vargas", 55890441, 920993583, "manuelvargas@gmail.com", "manu145");
                NodoPacientes paciente14 = new NodoPacientes("Maria Rodriguez", 91451125, 935855728, "mariarodriguez@gmail.com", "marix1138");
                NodoPacientes paciente15 = new NodoPacientes("Maria Rojas", 26776315, 905558622, "mariarojas@gmail.com", "mari4783");
                NodoPacientes paciente16 = new NodoPacientes("Lucia Garcia", 65608368, 928886208, "luciagarcia@gmail.com", "luci58");
                NodoPacientes paciente17 = new NodoPacientes("Manuel Morales", 32387412, 907100139, "manuelmorales@gmail.com", "manu2601");
                NodoPacientes paciente18 = new NodoPacientes("Maria Romero", 84864630, 972542165, "mariaromero@gmail.com", "mari65");
                NodoPacientes paciente19 = new NodoPacientes("Jose Rojas", 15707946, 916968543, "joserojas@gmail.com", "rOja20");
                NodoPacientes paciente20 = new NodoPacientes("Jorge Romero", 41761816, 911210724, "jorgeromero@gmail.com", "jorome15");
                NodoPacientes paciente21 = new NodoPacientes("Carlos Romero", 12589277, 985101749, "carlosromero@gmail.com", "xcar12");

                pila.Push(paciente1);
                pila.Push(paciente2);
                pila.Push(paciente3);
                pila.Push(paciente4);
                pila.Push(paciente5);
                pila.Push(paciente6);
                pila.Push(paciente7);
                pila.Push(paciente8);
                pila.Push(paciente9);
                pila.Push(paciente10);
                pila.Push(paciente11);
                pila.Push(paciente12);
                pila.Push(paciente13);
                pila.Push(paciente14);
                pila.Push(paciente15);
                pila.Push(paciente16);
                pila.Push(paciente17);
                pila.Push(paciente18);
                pila.Push(paciente19);
                pila.Push(paciente20);
                pila.Push(paciente21);
            }
        }
    }
}
