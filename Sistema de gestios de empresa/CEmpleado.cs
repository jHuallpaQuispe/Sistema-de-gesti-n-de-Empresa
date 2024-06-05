using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Empresa
{
    abstract internal class CEmpleado : IComparable
    {
        private uint legajo;

        private string apellido;

        private string nombre;

        public CEmpleado(uint leg, string nom, string ape)
        {
            this.legajo = leg;
            this.apellido = ape;
            this.nombre = nom;
        }

        //Getters de instancia
        public uint GetLegajo()
        { return this.legajo; }
        public string GetNombres()
        { return this.nombre; }
        public string GetApellidos()
        { return this.apellido; }

        public virtual string DarDatos()
        {
            string datos = "Legajo: " + this.legajo;
            datos += "  - Nombre:   " + this.nombre;
            datos += "  - Apellido: " + this.apellido;
            return datos;
        }

        public virtual float DarCuotaPersonal()
        {
            return 0;
        }
        public int CompareTo(object empleado)
        {
            if(empleado is CEmpleado)
                return this.apellido.CompareTo(((CEmpleado)empleado).GetApellidos());
            return int.MaxValue;
        }
    }
}
