using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IntegraData;
using System.Data.SqlClient;

namespace IntegraBussines
{
    public class ClientesBLL
    {
        public static void Cliente(int iMovimiento, int iNumero_Persona, int iNumero_Empresa, string sNombre,
                                    string sPaterno, string sMaterno, string sNombre_Completo, string sNombre_Corto,
                                    string sRFC, string sCURP, DateTime dtFecha_Nacimiento, string sCelular,
                                    string sCorreo_Electronico, string sPersonalidad_Juridica, DateTime dtFecha_Alta,
                                    int iGeneral, int iNumero_Domicilio, string sDomicilio, string sColonia,
                                    string sDelegacion_Municipio, string sCodigo_Postal, string sEstado,string sPais, 
                                    string sTelefono, string sFax, int iEstatus, string sGiro, int iLista_Precio) 
        { 
            try
            {
                SQLConection context = new SQLConection();
                context.Parametros.Clear();
                context.Parametros.Add(new SqlParameter("@Movimiento", iMovimiento));
                context.Parametros.Add(new SqlParameter("@Numero_Persona", iNumero_Persona));
                context.Parametros.Add(new SqlParameter("@Numero_Empresa", iNumero_Empresa));
                context.Parametros.Add(new SqlParameter("@Nombre", sNombre));
                context.Parametros.Add(new SqlParameter("@Paterno", sPaterno));
                context.Parametros.Add(new SqlParameter("@Materno", sMaterno));
                context.Parametros.Add(new SqlParameter("@Nombre_Completo", sNombre_Completo));
                context.Parametros.Add(new SqlParameter("@Nombre_Corto", sNombre_Corto));
                context.Parametros.Add(new SqlParameter("@RFC", sRFC));
                context.Parametros.Add(new SqlParameter("@CURP", sCURP));
                context.Parametros.Add(new SqlParameter("@Fecha_Nacimiento", dtFecha_Nacimiento));
                context.Parametros.Add(new SqlParameter("@Celular", sCelular));
                context.Parametros.Add(new SqlParameter("@Correo_Electronico", sCorreo_Electronico));
                context.Parametros.Add(new SqlParameter("@Personalidad_juridica", sPersonalidad_Juridica));
                context.Parametros.Add(new SqlParameter("@Fecha_Alta", dtFecha_Alta));
                context.Parametros.Add(new SqlParameter("@General", iGeneral));
                context.Parametros.Add(new SqlParameter("@Numero_Domicilio", iNumero_Domicilio));
                context.Parametros.Add(new SqlParameter("@Domicilio", sDomicilio));
                context.Parametros.Add(new SqlParameter("@Colonia", sColonia));
                context.Parametros.Add(new SqlParameter("@Delegacion_Municipio", sDelegacion_Municipio));
                context.Parametros.Add(new SqlParameter("@Codigo_postal", sCodigo_Postal));
                context.Parametros.Add(new SqlParameter("@Estado", sEstado));
                context.Parametros.Add(new SqlParameter("@Pais", sPais));
                context.Parametros.Add(new SqlParameter("@Telefono", sTelefono));
                context.Parametros.Add(new SqlParameter("@Fax", sFax));
                context.Parametros.Add(new SqlParameter("@Estatus", iEstatus));
                context.Parametros.Add(new SqlParameter("@Giro", sGiro));
                context.Parametros.Add(new SqlParameter("@Lista_Precio", iLista_Precio));
                context.ExecuteProcedure("sp_Persona_Cliente_Domicilio", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable ObtenerDatosCliente(int iEmpresa, int iPersona)
        {
            DataTable dt = new DataTable();
            SQLConection context = new SQLConection();
            context.Parametros.Clear();
            context.Parametros.Add(new SqlParameter("@Numero_Empresa", iEmpresa));
            context.Parametros.Add(new SqlParameter("@Numero_Persona", iPersona));

            dt = context.ExecuteProcedure("sp_Persona_Cliente_Domicilio_Obtener_Datos", true).Copy();
            return dt;
        }
        public static DataTable ObtenerClientes(int iEmpresa, int iTipo, string sCadena)
        {
            DataTable dt = new DataTable();
            SQLConection context = new SQLConection();
            context.Parametros.Clear();
            context.Parametros.Add(new SqlParameter("@Numero_Empresa", iEmpresa));
            context.Parametros.Add(new SqlParameter("@Tipo_Persona", iTipo));
            context.Parametros.Add(new SqlParameter("@Cadena", sCadena));

            dt = context.ExecuteProcedure("sp_Producto_WS_Obtener_Clientes", true).Copy();
            return dt;
        }
        public static DataTable ObtenerListaPrecios(int iEmpresa)
        {
            DataTable dt = new DataTable();
            SQLConection context = new SQLConection();
            context.Parametros.Clear();
            context.Parametros.Add(new SqlParameter("@Numero_Empresa", iEmpresa));

            dt = context.ExecuteProcedure("sp_Lista_Precio_Cliente_Obtener_Listas", true).Copy();
            return dt;
        }
        public static DataTable ObtenerClientesPorPersonalidad(int iEmpresa, int iTipo)
        {
            DataTable dt = new DataTable();
            SQLConection context = new SQLConection();
            context.Parametros.Clear();
            context.Parametros.Add(new SqlParameter("@Numero_Empresa", iEmpresa));
            context.Parametros.Add(new SqlParameter("@Personalidad_Juridica", iTipo));

            dt = context.ExecuteProcedure("sp_Persona_Cliente_Obtener_Por_Personalidad_Juridica", true).Copy();
            return dt;
        }
        public static DataTable ObtenerTodosLosClientes(int iEmpresa, string sCadena)
        {
            DataTable dt = new DataTable();
            SQLConection context = new SQLConection();
            context.Parametros.Clear();
            context.Parametros.Add(new SqlParameter("@Numero_Empresa", iEmpresa));
            context.Parametros.Add(new SqlParameter("@Cadena", sCadena));

            dt = context.ExecuteProcedure("sp_WS_Obtener_Clientes", true).Copy();
            return dt;
        }
    }
}
