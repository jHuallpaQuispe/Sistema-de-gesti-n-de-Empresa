
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Empresa
{
    public class CControladora
    {
        public static void Main()
        {
            CObras listadoObras = new CObras();
            CEmpleados listadoEmpleados = new CEmpleados();
            char opcion;
            uint auxLegajo;


            do
            {
                char.TryParse(CInterfaz.DarOpcion().ToUpper(), out opcion);
                switch (opcion)
                {
                    case 'A':
                        CSueldos.EstablecerVariablesSueldos();
                        break;
                    case 'B':
                        Console.WriteLine("Ingrese el tipo de empleado (Obrero/Profesional)");
                        string TipoEmpleado = Console.ReadLine();

                        if(TipoEmpleado.ToUpper() == "OBRERO")
                        {
                            auxLegajo = uint.Parse(CInterfaz.PedirDato("Legajo"));
                            string auxNombres = CInterfaz.PedirDato("Nombres");
                            string auxApellidos = CInterfaz.PedirDato("Apellidos");
                            string auxOficio = CInterfaz.PedirDato("Oficio");
                            string auxDominio = CInterfaz.PedirDato("Experiencia y Dominio (Oficial/Medio Oficial/Aprendiz)");
                            if(!listadoEmpleados.CrearEmpleado(auxLegajo,auxNombres,auxApellidos,auxOficio,auxDominio))
                                CInterfaz.MostrarInfo("Legajo Preexistente");
                        }
                        else if (TipoEmpleado.ToUpper() == "PROFESIONAL")
                        {
                            auxLegajo = uint.Parse(CInterfaz.PedirDato("Legajo"));
                            string auxNombres = CInterfaz.PedirDato("Nombres");
                            string auxApellidos = CInterfaz.PedirDato("Apellidos");
                            string auxtitulohab = CInterfaz.PedirDato("Titulo Habilitante");
                            ulong auxMatricula = ulong.Parse(CInterfaz.PedirDato("Número de Matrícula"));
                            string auxconsejoProfe = CInterfaz.PedirDato("Consejo Profesional");
                            float auxPorcentajeAumento = float.Parse(CInterfaz.PedirDato("Porcentaje de aumento"));

                            if (!listadoEmpleados.CrearEmpleado(auxLegajo, auxNombres, auxApellidos, auxtitulohab, auxMatricula, auxconsejoProfe, auxPorcentajeAumento))
                                CInterfaz.MostrarInfo("Legajo Preexistente");
                        }
                        break;
                    case 'C':

                        listadoEmpleados.Ordenar();
                        CInterfaz.MostrarInfo(listadoEmpleados.DarDatos());
                        break;
                    case 'D':
                        string auxCodigo = CInterfaz.PedirDato("Codigo");
                        string auxDireccion = CInterfaz.PedirDato("Dirección");
                        uint profLegajo = uint.Parse(CInterfaz.PedirDato("N° Legajo Profesional"));
                        CProfesional auxProfDesignado = (CProfesional)(listadoEmpleados.BuscarEmpleado(profLegajo));
                        if(auxProfDesignado != null)
                        {
                            auxProfDesignado.SupervisandoObra = true; // Ahora supervisa una obra
                            if (!listadoObras.CrearObra(auxCodigo,auxDireccion,auxProfDesignado))
                                CInterfaz.MostrarInfo("Obra Preexistente");
                            break;  
                        }
                        CInterfaz.MostrarInfo("Profesional Inexistente");
                        break;
                    case 'E':
                        string auxObraModificar = CInterfaz.PedirDato("Codigo de Obra");
                        CObra ObraEncontrada = listadoObras.BuscarObra(auxObraModificar);
                        if(ObraEncontrada != null)
                        {
                            uint auxprofLegajoModificar = uint.Parse(CInterfaz.PedirDato("N° Legajo Profesional Nuevo"));
                            CProfesional ProfNuevo = (CProfesional)(listadoEmpleados.BuscarEmpleado(auxprofLegajoModificar));
                            if (ProfNuevo != null)
                            {
                                ObraEncontrada.ModificarProfe(ProfNuevo);
                                break;

                            }
                            CInterfaz.MostrarInfo("Profesional Inexistente.");
                            break;
                        }
                        CInterfaz.MostrarInfo("Obra no encontrada.");
                        break;
                    case 'F':
                        string auxObra = CInterfaz.PedirDato("Codigo de Obra");
                        ObraEncontrada = listadoObras.BuscarObra(auxObra);
                        if (ObraEncontrada !=null)
                        {
                            uint auxObrero = uint.Parse(CInterfaz.PedirDato("N° Legajo Obrero"));
                            CObrero ObreroNuevo = (CObrero)(listadoEmpleados.BuscarEmpleado(auxObrero));
                            if(ObreroNuevo != null)
                            {
                                ObraEncontrada.AgregarObrero(ObreroNuevo);
                                break;
                            }
                            CInterfaz.MostrarInfo("Obrero Inexistente");
                            break;
                        }
                        CInterfaz.MostrarInfo("Obra no encontrada.");
                        break;
                    case 'G':
                        auxObra = CInterfaz.PedirDato("Codigo de Obra");
                        ObraEncontrada = listadoObras.BuscarObra(auxObra);
                        if(ObraEncontrada != null)
                        {
                            CInterfaz.MostrarInfo(ObraEncontrada.DarDatos());
                            break;

                        }
                        CInterfaz.MostrarInfo("No existe tal Obra.");
                        break;
                    case 'H':
                        auxLegajo = uint.Parse(CInterfaz.PedirDato("Legajo Del Profesional"));
                        auxProfDesignado = listadoEmpleados.BuscarProfesional(auxLegajo);

                        if (auxProfDesignado != null) // Por si me ingresan un obrero jeje
                        {
                            if(listadoObras.SupervisaObraProfesional(auxProfDesignado))
                            {
                                CInterfaz.MostrarInfo("Este Profesional Supervisa una obra");
                                break;
                            }
                            else if (!listadoEmpleados.EliminarProfesional(auxLegajo))
                            {
                                CInterfaz.MostrarInfo("Profesional Inexistente.");
                                break;
                            }
                                CInterfaz.MostrarInfo("Profesional Eliminado.");
                                break;

                        }
                        CInterfaz.MostrarInfo("Profesional no Encontrado.");
                        break;
                    case 'I':
                        CInterfaz.MostrarInfo(listadoObras.DarDatos());
                        break;
                    case 'S':
                        break;
                    default:
                        CInterfaz.MostrarInfo("Opción inválida");
                        break;
                }

            } while (opcion != 'S');
        }
    }
}
