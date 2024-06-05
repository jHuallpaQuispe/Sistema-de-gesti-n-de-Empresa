using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Empresa
{
    internal class CObrero : CEmpleado
    {
        private string oficio;

        private string dominio;

        public CObrero(uint leg, string nom, string ape, string ofi, string dom) : base(leg, nom, ape)
        {
            this.oficio = ofi;
            this.dominio = dom.ToLower();
        }

        public override float DarCuotaPersonal()
        {
            if (dominio == "aprendiz")
                return (CSueldos.MontoReferenciaSindicato * 25) / 100;
            if (dominio == "medio oficial")
                return (CSueldos.MontoReferenciaSindicato * 65) / 100;
            else
                return CSueldos.MontoReferenciaSindicato;
        }

        public override string DarDatos()
        {
            string datos = "Legajo: " + this.GetLegajo();
            datos += "  - Nombre:   " + this.GetNombres();
            datos += "  - Apellido: " + this.GetApellidos();
            datos += "  - Oficio:   " + this.oficio;
            datos += "  - Haber Mensual:    " + this.DarCuotaPersonal();
            return datos;
        }
    }
}
