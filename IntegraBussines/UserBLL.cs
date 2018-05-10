using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IntegraData;
using System.Data.SqlClient;


namespace IntegraBussines
{
    public class UserBLL
    {
        public static DataTable GetUserData(int icompany, int iuser, int igeneral)
        {
            DataTable dt = new DataTable();
            SQLConection context = new SQLConection();
            context.Parametros.Clear();
            context.Parametros.Add(new SqlParameter("@companynumber", icompany));
            context.Parametros.Add(new SqlParameter("@user", iuser));
            context.Parametros.Add(new SqlParameter("@general", igeneral));


            dt = context.ExecuteProcedure("sp_Usuario_ObtieneDatosDelUsuario_v1", true).Copy();
            return dt;
        }

    }
}
