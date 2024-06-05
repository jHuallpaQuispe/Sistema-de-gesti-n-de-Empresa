using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Empresa
{
    internal class CEmpleados
    {
        private List<CEmpleado> listadoEmpleados = new List<CEmpleado>();

        public CEmpleado BuscarEmpleado(uint leg)
        {
            foreach (CEmpleado aux in this.listadoEmpleados)
            {
                if (aux.GetLegajo() == leg) return aux;
            }
            return null;
        }
        public CProfesional BuscarProfesional(uint leg)
        {
            CEmpleado auxEmpleado = this.BuscarEmpleado(leg);
            if(auxEmpleado is CProfesional)
            {
                return auxEmpleado as CProfesional;
            }
            return null;
        }
        public bool CrearEmpleado(uint leg, string nom, string ape, string ofi, string dom)
        {
            if (this.BuscarEmpleado(leg) == null)
            {
                this.listadoEmpleados.Add(new CObrero(leg, nom, ape, ofi,dom));
                return true;
            }
            return false;
        }
        public bool CrearEmpleado(uint leg, string nom, string ape, string titulohab, ulong matricula, string consejoProfe, float porcentaje)
        {
            if (this.BuscarEmpleado(leg) == null)
            {
                this.listadoEmpleados.Add(new CProfesional(leg, nom, ape, titulohab, matricula, consejoProfe, porcentaje));
                return true;
            }
            return false;
        }
        public string DarDatos(uint leg)
        {
            CEmpleado aux = this.BuscarEmpleado(leg);
            if (aux != null) return aux.DarDatos();
            return "Empleado inexistente";
        }
        public string DarDatos()
        {

            if (this.listadoEmpleados.Count != 0)
            {
                String datos = "";
                foreach (CEmpleado aux in this.listadoEmpleados) datos += aux.DarDatos() + "\n";
                return datos;
            }
            return "No se registraron Empleados";
        }
        public bool EliminarEmpleado(uint leg)
        {
            CEmpleado aux = this.BuscarEmpleado(leg);
            if (aux != null)
            {
                this.listadoEmpleados.Remove(aux);
                return true;
            }
            return false;
        }
        public void Ordenar()
        {
            this.listadoEmpleados.Sort();
        }
        public bool EliminarProfesional(uint leg)
        {
            CEmpleado aux = this.BuscarEmpleado(leg);
            if (aux != null)
            {
                this.listadoEmpleados.Remove(aux);
                return true;
            }
            return false;
        }
    }
}
