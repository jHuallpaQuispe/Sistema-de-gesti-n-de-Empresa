using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Empresa
{
    internal class CObra
    {
        private string codigo;
        private string direccion;
        private CProfesional profesionalDesignado;
        private List<CObrero> listaObreros = new List<CObrero>();

        public CObra(string codigo, string direccion, CProfesional prof)
        {
            this.codigo = codigo;
            this.direccion = direccion;
            this.profesionalDesignado = prof;
        }
        public string SetCodigo
        {
            set { this.codigo = value; }
        }
        public string GetCodigo
        {
            get { return this.codigo; }
        }

        public uint GetLegajoProfesional
        {
            get { return profesionalDesignado.GetLegajo(); }
        }
        public void ModificarProfe(CProfesional prof)
        {
            this.profesionalDesignado.SupervisandoObra = false;
            this.profesionalDesignado = prof;
            this.profesionalDesignado.SupervisandoObra = true;
        }

        public CObrero BuscarObrero(uint leg)
        {
            foreach (CObrero aux in listaObreros)
            {
                if (aux.GetLegajo() == leg) return aux;
            }
            return null;
        }
        public bool AgregarObrero(CObrero obreroNuevo)
        {
            if (this.BuscarObrero(obreroNuevo.GetLegajo()) == null)
            {
                this.listaObreros.Add(obreroNuevo);
                return true;
            }
            return false;
        }

        public string DarDatos(uint leg)
        {
            CObrero aux = this.BuscarObrero(leg);
            if (aux != null) return aux.DarDatos();
            return "Obra inexistente";
        }
        public string DarDatos()
        {
            String datos = "";
            datos += "Obra: " + this.GetCodigo;
            datos += "  - Direccion: " + this.direccion + "\n";
            datos += profesionalDesignado.DarDatos() + "\n";
            datos += "\t\tObreros:\n";
            if (this.listaObreros.Count != 0)
            {
                foreach (CObrero aux in this.listaObreros) datos += "\t\t" + aux.DarDatos() + "\n";
                return datos;
            }
            return datos +"\t\tNo se registraron Obreros válidos";
        }
    }
}
