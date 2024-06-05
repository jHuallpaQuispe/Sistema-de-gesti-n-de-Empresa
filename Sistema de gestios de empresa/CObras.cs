using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Empresa
{
    internal class CObras
    {
        private List<CObra> listado = new List<CObra>();
        public CObra BuscarObra(string cod)
        {
            foreach (CObra aux in this.listado)
            {
                if (aux.GetCodigo == cod) return aux;
            }
            return null;
        }
        
        public bool CrearObra(string cod, string direc, CProfesional prof)
        {
            if (this.BuscarObra(cod) == null)
            {
                this.listado.Add(new CObra(cod, direc, prof));
                return true;
            }
            return false;
        }

        public bool SupervisaObraProfesional(CProfesional profesional)
        {
            foreach(CObra aux in this.listado)
            {
                if (aux.GetLegajoProfesional == profesional.GetLegajo()) return true; // Supervisa obra
            }
            return false; // No supervisa obra
        }
        public string DarDatos()
        {

            if (this.listado.Count != 0)
            {
                String datos = "";
                foreach (CObra aux in this.listado) datos += aux.DarDatos() + "\n";
                return datos;
            }
            return "No se registraron Obras";
        }
    }
}
