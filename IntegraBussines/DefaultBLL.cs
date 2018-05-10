using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IntegraData;
using System.Data.SqlClient;

namespace IntegraBussines
{
    public class DefaultBLL
    {
        public static DataTable GetUserNumber(string sUsuario, int iTipo)
        {
            DataTable dt = new DataTable();
            SQLConection context = new SQLConection();
            context.Parametros.Clear();
            context.Parametros.Add(new SqlParameter("@Usuario", sUsuario));
            context.Parametros.Add(new SqlParameter("@Tipo", iTipo));

            dt = context.ExecuteProcedure("sp_Persona_Obtener_Numero", true).Copy();
            return dt;
        }
        public static DataTable GetUserPassword(int iNumero_Usuario, string sPasword)
        {
            DataTable dt = new DataTable();
            SQLConection context = new SQLConection();
            context.Parametros.Clear();
            context.Parametros.Add(new SqlParameter("@Numero_Usuario", iNumero_Usuario));
            context.Parametros.Add(new SqlParameter("@Contraseña", sPasword));

            dt = context.ExecuteProcedure("sp_Usuario_Validar_Existencia", true).Copy();
            return dt;
        }
        public static DataTable GetUserData(int iNumero_Usuario)
        {
            DataTable dt = new DataTable();
            SQLConection context = new SQLConection();
            context.Parametros.Clear();
            context.Parametros.Add(new SqlParameter("@Numero_Persona", iNumero_Usuario));

            dt = context.ExecuteProcedure("sp_Persona_Obtener_Datos_Sesion", true).Copy();
            return dt;
        }

    }
}
