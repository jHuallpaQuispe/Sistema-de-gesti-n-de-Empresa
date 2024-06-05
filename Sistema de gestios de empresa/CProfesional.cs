using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Empresa
{
    internal class CProfesional:CEmpleado
    {
        private string tituloHabilitante;

        private ulong numMatricula;

        private string nomConsejoProfesional;

        public bool SupervisandoObra { get; set; }

        public float PorcentajeAumento { get; set; }

        public CProfesional(uint leg, string nom, string ape, string titulohab, ulong matricula, string consejoProfe, float porcentaje) : base(leg, nom, ape)
        {
            this.tituloHabilitante = titulohab;
            this.numMatricula = matricula;
            this.nomConsejoProfesional = consejoProfe;
            this.PorcentajeAumento = porcentaje;
            this.SupervisandoObra = false;
        }
        public override float DarCuotaPersonal()
        {
            float montoTotal;
            montoTotal = CSueldos.MontoReferenciaSindicato * (1+(this.PorcentajeAumento / 100)); // Aumento dependiendo de la negociacion con la empresa
            
            if(SupervisandoObra)
            {
                montoTotal += CSueldos.CanonUniversalMatricula;
            }
            return montoTotal;
        }
        public override string DarDatos()
        {
            string datos = "Legajo: " + this.GetLegajo();
            datos += "  - Nombre:   " + this.GetNombres();
            datos += "  - Apellido: " + this.GetApellidos();
            datos += "  - Titulo:   " + this.tituloHabilitante;
            datos += "  - N° Matricula:   " + this.numMatricula;
            datos += "  - Consejo Profesional:   " + this.nomConsejoProfesional;
            datos += "  - Haber Mensual:    " + this.DarCuotaPersonal();
            return datos;
        }

    }
}
