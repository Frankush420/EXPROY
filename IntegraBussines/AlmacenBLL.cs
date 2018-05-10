using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IntegraData;
using System.Data.SqlClient;


namespace IntegraBussines
{
    public class AlmacenBLL
    {
        public static void AlmacenMovimientos(int iNumero_Empresa, int iNumero_Producto, int iClas_Almacen, int iClas_Movimiento, string sMovimieto, decimal dCantidad)
        {
            SQLConection context = new SQLConection();
            context.Parametros.Clear();
            context.Parametros.Add(new SqlParameter("@Numero_Empresa", iNumero_Empresa));
            context.Parametros.Add(new SqlParameter("@Numero_Producto", iNumero_Producto));
            context.Parametros.Add(new SqlParameter("@Clas_Almacen", iClas_Almacen));
            context.Parametros.Add(new SqlParameter("@Clas_Movimiento", iClas_Movimiento));
            context.Parametros.Add(new SqlParameter("@Tipo_Movimiento", sMovimieto));
            context.Parametros.Add(new SqlParameter("@Cantidad", dCantidad));

            context.ExecuteProcedure("sp_Almacen_Movimientos", true);
        }
        public static DataTable ObtenerProductosDisponibles(int iEmpresa)
        {
            DataTable dt = new DataTable();
            SQLConection context = new SQLConection();
            context.Parametros.Clear();
            context.Parametros.Add(new SqlParameter("@Numero_Empresa", iEmpresa));

            dt = context.ExecuteProcedure("sp_Producto_Obtener_Todos", true).Copy();
            return dt;
        }
        public static DataTable ObtenerExistenciaAlmacen(int iEmpresa, int iAlmacen)
        {
            DataTable dt = new DataTable();
            SQLConection context = new SQLConection();
            context.Parametros.Clear();
            context.Parametros.Add(new SqlParameter("@Numero_Empresa", iEmpresa));
            context.Parametros.Add(new SqlParameter("@Clas_Almacen", iAlmacen));

            dt = context.ExecuteProcedure("sp_cc_Almacen_Movimientos", true).Copy();
            return dt;
        }
        public static DataTable ObtenerRegistroMovimientos(int iEmpresa, int iAlmacen)
        {
            DataTable dt = new DataTable();
            SQLConection context = new SQLConection();
            context.Parametros.Clear();
            context.Parametros.Add(new SqlParameter("@Numero_Empresa", iEmpresa));
            context.Parametros.Add(new SqlParameter("@Clas_Almacen", iAlmacen));

            dt = context.ExecuteProcedure("sp_Almacen_Movimientos_Registro_Movimientos", true).Copy();
            return dt;
        }
        public static DataTable ObtenerAlmacenes(int iEmpresa)
        {
            DataTable dt = new DataTable();
            SQLConection context = new SQLConection();
            context.Parametros.Clear();
            context.Parametros.Add(new SqlParameter("@Numero_Empresa", iEmpresa));

            dt = context.ExecuteProcedure("sp_Clasificacion_ObtenerAlmacen", true).Copy();
            return dt;
        }
        public static DataTable ObtenerMovimientosAlmacen(int iEmpresa)
        {
            DataTable dt = new DataTable();
            SQLConection context = new SQLConection();
            context.Parametros.Clear();
            context.Parametros.Add(new SqlParameter("@Numero_Empresa", iEmpresa));

            dt = context.ExecuteProcedure("sp_Clasificacion_ObtenerMovimientosAlmacen", true).Copy();
            return dt;
        }
    }
}
