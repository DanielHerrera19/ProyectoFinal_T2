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
                NodoPaciente paciente1 = new NodoPaciente("Carlos Diaz", 56789012, 998877665, "carlosdiaz@gmail.com", "carlosdiaz7");
                NodoPaciente paciente2 = new NodoPaciente("Jorge Rodriguez", 26151532, 983194992, "jorgerodriguez@gmail.com", "jorger12");
                NodoPaciente paciente3 = new NodoPaciente("Jorge Morales", 66841196, 977218864, "jorgemorales@gmail.com", "jorgemor74");
                NodoPaciente paciente4 = new NodoPaciente("Miguel Torres", 99667134, 924360256, "migueltorres@gmail.com", "miguelto63");
                NodoPaciente paciente5 = new NodoPaciente("Diego Rodriguez", 51580950, 970584218, "diegorodriguez@gmail.com", "diego716");
                NodoPaciente paciente6 = new NodoPaciente("Jose Garcia", 23211573, 951257494, "josegarcia@gmail.com", "jogarcia9195");
                NodoPaciente paciente7 = new NodoPaciente("Rafael Diaz", 41007722, 930288570, "rafaeldiaz@gmail.com", "diazraf9813");
                NodoPaciente paciente8 = new NodoPaciente("Manuel Lopez", 30621232, 936119426, "manuellopez@gmail.com", "maulopez8407");
                NodoPaciente paciente9 = new NodoPaciente("Marta Rojas", 25059421, 929805334, "martarojas@gmail.com", "rojas2279");
                NodoPaciente paciente10 = new NodoPaciente("Marta Diaz", 44966763, 958410488, "martadiaz@gmail.com", "diaz2414");
                NodoPaciente paciente11 = new NodoPaciente("Manuel Flores", 69627289, 921448685, "manuelflores@gmail.com", "flores2540");
                NodoPaciente paciente12 = new NodoPaciente("Jose Garcia", 32459722, 909421516, "josegarcia@gmail.com", "jose121");
                NodoPaciente paciente13 = new NodoPaciente("Manuel Vargas", 55890441, 920993583, "manuelvargas@gmail.com", "manu145");
                NodoPaciente paciente14 = new NodoPaciente("Maria Rodriguez", 91451125, 935855728, "mariarodriguez@gmail.com", "marix1138");
                NodoPaciente paciente15 = new NodoPaciente("Maria Rojas", 26776315, 905558622, "mariarojas@gmail.com", "mari4783");
                NodoPaciente paciente16 = new NodoPaciente("Lucia Garcia", 65608368, 928886208, "luciagarcia@gmail.com", "luci58");
                NodoPaciente paciente17 = new NodoPaciente("Manuel Morales", 32387412, 907100139, "manuelmorales@gmail.com", "manu2601");
                NodoPaciente paciente18 = new NodoPaciente("Maria Romero", 84864630, 972542165, "mariaromero@gmail.com", "mari65");
                NodoPaciente paciente19 = new NodoPaciente("Jose Rojas", 15707946, 916968543, "joserojas@gmail.com", "rOja20");
                NodoPaciente paciente20 = new NodoPaciente("Jorge Romero", 41761816, 911210724, "jorgeromero@gmail.com", "jorome15");
                NodoPaciente paciente21 = new NodoPaciente("Carlos Romero", 12589277, 985101749, "carlosromero@gmail.com", "xcar12");


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
