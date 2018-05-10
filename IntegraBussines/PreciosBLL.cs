using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IntegraData;
using System.Data.SqlClient;

namespace IntegraBussines
{
    public class PreciosBLL
    {
        public static DataTable ObtenerProductosLista(int iEmpresa)
        {
            DataTable dt = new DataTable();
            SQLConection context = new SQLConection();
            context.Parametros.Clear();
            context.Parametros.Add(new SqlParameter("@Numero_Empresa", iEmpresa));
            dt = context.ExecuteProcedure("sp_Productos_Lista_Precio", true).Copy();
            return dt;
        }
        public static DataTable ObtenerUltimoNumero(int iEmpresa)
        {
            DataTable dt = new DataTable();
            SQLConection context = new SQLConection();
            context.Parametros.Clear();
            context.Parametros.Add(new SqlParameter("@Numero_Empresa", iEmpresa));
            dt = context.ExecuteProcedure("sp_Lista_Precio_Cliente_Obtener_Numero", true).Copy();
            return dt;
        }
        public static void Lista(int iMovimiento, int iNumero, int iNumero_Empresa, int iNumero_Producto, string sNombre, decimal dPrecio_Compra, decimal dPorcentaje, decimal dPrecio_Final, decimal dUtilidad, DataTable dtLista)
        {
            try
            {
                SQLConection context = new SQLConection();
                context.Parametros.Clear();
                context.Parametros.Add(new SqlParameter("@Movimiento", iMovimiento));
                context.Parametros.Add(new SqlParameter("@Numero", iNumero));
                context.Parametros.Add(new SqlParameter("@Numero_Empresa", iNumero_Empresa));
                context.Parametros.Add(new SqlParameter("@Numero_Producto", iNumero_Producto));
                context.Parametros.Add(new SqlParameter("@Nombre", sNombre));
                context.Parametros.Add(new SqlParameter("@Precio_Compra", dPrecio_Compra));
                context.Parametros.Add(new SqlParameter("@Porcentaje", dPorcentaje));
                context.Parametros.Add(new SqlParameter("@Precio_Final", dPrecio_Final));
                context.Parametros.Add(new SqlParameter("@Utilidad", dUtilidad));
                context.Parametros.Add(new SqlParameter("@Lista", dtLista));
                context.ExecuteProcedure("sp_Lista_Precio_Cliente", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
        public static DataTable ObtenerDetalleListaPrecios(int iEmpresa, int iLista)
        {
            DataTable dt = new DataTable();
            SQLConection context = new SQLConection();
            context.Parametros.Clear();
            context.Parametros.Add(new SqlParameter("@Numero_Empresa", iEmpresa));
            context.Parametros.Add(new SqlParameter("@Numero_Lista", iLista));

            dt = context.ExecuteProcedure("sp_Lista_Precio_Cliente_Obtener_Detalle", true).Copy();
            return dt;
        }
    }
}
