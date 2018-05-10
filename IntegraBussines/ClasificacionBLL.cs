using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IntegraData;
using System.Data.SqlClient;


namespace IntegraBussines
{
    public class ClasificacionBLL
    {
        public static DataTable ClasificacionObtenerUltimoNumero(int iEmpresa)
        {
            DataTable dt = new DataTable();
            SQLConection context = new SQLConection();
            context.Parametros.Clear();
            context.Parametros.Add(new SqlParameter("@Numero_Empresa", iEmpresa));
            dt = context.ExecuteProcedure("sp_Clasificacion_Obtener_Numero", true).Copy();
            return dt;
        }
        public static void InsertarClasificacion(int iMovimiento, int iNumero_Empresa, int iNumero, string sClave, string sClave1, string sClave2, DataTable dtClasificacion) {
            try
            {
                SQLConection context = new SQLConection();
                context.Parametros.Clear();
                context.Parametros.Add(new SqlParameter("@Movimiento", iMovimiento));
                context.Parametros.Add(new SqlParameter("@Numero_Empresa", iNumero_Empresa));
                context.Parametros.Add(new SqlParameter("@Numero", iNumero));
                context.Parametros.Add(new SqlParameter("@Clave", sClave));
                context.Parametros.Add(new SqlParameter("@Clave1", sClave1));
                context.Parametros.Add(new SqlParameter("@Clave2", sClave2));
                context.Parametros.Add(new SqlParameter("@Clasificacion", dtClasificacion));
                context.ExecuteProcedure("sp_Clasificacion", true);
            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}
