using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_T2
{
    internal class CargaPacientesReserva
    {
        public static void PrecargarDatos(ColaReserva cola)
        {
            // Crear nodos con datos predefinidos y agregarlos a la cola
            cola.encola(new NodoReserva("Carlos", "Diaz", 56789012, 2369988776654567));
            cola.encola(new NodoReserva("Jorge", "Rodriguez", 26151532, 2393831949459245));
            cola.encola(new NodoReserva("Jorge", "Morales", 66841196, 5569584104886452));
            cola.encola(new NodoReserva("Miguel", "Torres", 99667134, 7029243602563490));
            cola.encola(new NodoReserva("Diego", "Rodriguez", 51580950, 2297058421836789));
            cola.encola(new NodoReserva("Jose", "Garcia", 23211573, 9512574946738496));
            cola.encola(new NodoReserva("Rafael", "Diaz", 41007722, 9302885705289104));
            cola.encola(new NodoReserva("Manuel", "Lopez", 30621232, 9361194264785901));
            cola.encola(new NodoReserva("Marta", "Rojas", 25059421, 9298053342435567));
            cola.encola(new NodoReserva("Marta", "Diaz", 44966763, 9584104883478945));
            cola.encola(new NodoReserva("Manuel", "Flores", 69627289, 9214486858900323));
            cola.encola(new NodoReserva("Jose", "Garcia", 32459722, 9094215169612745));
            cola.encola(new NodoReserva("Manuel", "Vargas", 55890441, 9209935838900421));
            cola.encola(new NodoReserva("Maria", "Rodriguez", 91451125, 9358557281345661));
            cola.encola(new NodoReserva("Maria", "Rojas", 26776315, 9055586225900321));
            cola.encola(new NodoReserva("Lucia", "Garcia", 65608368, 9288862082358904));
            cola.encola(new NodoReserva("Manuel", "Morales", 32387412, 9071001395672204));
            cola.encola(new NodoReserva("Maria", "Romero", 84864630, 9725421654512890));
            cola.encola(new NodoReserva("Jose", "Rojas", 15707946, 9169685433477824));
            cola.encola(new NodoReserva("Jorge", "Romero", 41761816, 9112107246789123));
            cola.encola(new NodoReserva("Carlos", "Romero", 12589277, 9851017493406651));

        }
    }
}
