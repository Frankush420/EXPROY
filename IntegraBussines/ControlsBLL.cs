using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IntegraData;
using System.Data.SqlClient;


namespace IntegraBussines
{
    public class ControlsBLL
    {

        public static DataTable ObtenDatosEmpresa(int iEmpresa)
        {
            DataTable dt = new DataTable();
            SQLConection context = new SQLConection();
            context.Parametros.Clear();
            context.Parametros.Add(new SqlParameter("@Numero_Empresa", iEmpresa));


            dt = context.ExecuteProcedure("sp_Empresa_ObtenerDatos", true).Copy();
            return dt;
        }

    }
}
