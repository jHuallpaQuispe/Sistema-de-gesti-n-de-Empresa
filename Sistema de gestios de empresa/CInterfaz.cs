
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Empresa
{
    public class CInterfaz
    {
        static CInterfaz()
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        public static string DarOpcion()
        {
            Console.Clear();
            Console.WriteLine("**********************************************************");
            Console.WriteLine("*                Sistema de Gestión de la Empresa            *");
            Console.WriteLine("***********************************************");
            Console.WriteLine("\n[A]     Establecer e informar las variables de sueldos.");
            Console.WriteLine("\n[B]     Registrar un Empleado.");
            Console.WriteLine("\n[C]     Listar datos de todos los Empleados.");
            Console.WriteLine("\n[D]     Registrar una Obra.");
            Console.WriteLine("\n[E]     Modificar el profesional designado como supervisor de una obra.");
            Console.WriteLine("\n[F]     Asignar un obrero en una obra.");
            Console.WriteLine("\n[G]     Listar una obra en específico.");
            Console.WriteLine("\n[H]     Eliminar un profesional de la empresa.");
            Console.WriteLine("\n[I]     Listar todas las Obras.");
            Console.WriteLine("\n[S]     Salir de la aplicación.");
            Console.WriteLine("\n********************************************************");
            return CInterfaz.PedirDato("opción elegida");
        }
        public static string PedirDato(string nombDato)
        {
            Console.Write("[?] Ingrese " + nombDato + ": ");
            string ingreso = Console.ReadLine();
            while (ingreso == "")
            {
                Console.Write("[!] " + nombDato + "es de ingreso OBLIGATORIO:");
                ingreso = Console.ReadLine();
            }
            Console.Clear();
            return ingreso.Trim();
        }

        public static void MostrarInfo(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.Write("<Pulse Enter>");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
