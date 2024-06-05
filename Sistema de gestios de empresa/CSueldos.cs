using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Empresa
{
    public class CSueldos
    {
        public static float MontoReferenciaSindicato { get; set; }
        public static float CanonUniversalMatricula { get; set; }

        public static void EstablecerVariablesSueldos()
        {
            Console.Write("Ingrese el monto de referencia definido por el sindicato: ");
            MontoReferenciaSindicato = float.Parse(Console.ReadLine());

            Console.Write("Ingrese el canon universal para el pago de la matrícula profesional: ");
            CanonUniversalMatricula = float.Parse(Console.ReadLine());
        }
    }
}
