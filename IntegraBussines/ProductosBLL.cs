using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IntegraData;
using System.Data.SqlClient;

namespace IntegraBussines
{
    public class ProductosBLL
    {
        public DataTable ProductoObtenerUltimoNumero(int iEmpresa)
        {
            try
            {
                DataTable dt = new DataTable();
                SQLConection context = new SQLConection();
                context.Parametros.Clear();
                context.Parametros.Add(new SqlParameter("@Numero_Empresa", iEmpresa));
                dt = context.ExecuteProcedure("sp_Producto_Obtener_Numero", true).Copy();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Producto(int iMovimiento, int iNumero_Empresa, int? iNumero, string sNombre, string sClave, string sCodigo, decimal? dPrecio, string sCaracteristicas, int? iEstatus, DataTable dtProducto)
        {
            try
            {
                SQLConection context = new SQLConection();
                context.Parametros.Clear();
                context.Parametros.Add(new SqlParameter("@Movimiento", iMovimiento));
                context.Parametros.Add(new SqlParameter("@Numero_Empresa", iNumero_Empresa));
                context.Parametros.Add(new SqlParameter("@Numero", iNumero.HasValue ? (object)iNumero.Value : DBNull.Value));
                context.Parametros.Add(new SqlParameter("@Nombre", sNombre != "" ? (object)sNombre : DBNull.Value));
                context.Parametros.Add(new SqlParameter("@Clave", sClave != "" ? (object)sClave : DBNull.Value));
                context.Parametros.Add(new SqlParameter("@Codigo_Barras", sCodigo != "" ? (object)sCodigo : DBNull.Value));
                context.Parametros.Add(new SqlParameter("@Precio", dPrecio.HasValue ? (object)dPrecio.Value : DBNull.Value));
                context.Parametros.Add(new SqlParameter("@Caracteristicas", sCaracteristicas != "" ? (object)sCaracteristicas : DBNull.Value));
                context.Parametros.Add(new SqlParameter("@Estatus", iEstatus.HasValue ? (object)iEstatus.Value : DBNull.Value));
                context.Parametros.Add(new SqlParameter("@Producto", dtProducto.Rows.Count > 0 ? (object)dtProducto : DBNull.Value));
                context.ExecuteProcedure("sp_Producto", true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerProductos(int iEmpresa)
        {
            try
            {
                DataTable dt = new DataTable();
                SQLConection context = new SQLConection();
                context.Parametros.Clear();
                context.Parametros.Add(new SqlParameter("@Numero_Empresa", iEmpresa));
                dt = context.ExecuteProcedure("sp_Producto_Obtener_Productos", true).Copy();
                if (dt.Rows.Count > 0)
                    return dt;
                else
                    throw new Exception("1");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerProductosACMP(int iEmpresa, string sCadena)
        {
            DataTable dt = new DataTable();
            SQLConection context = new SQLConection();
            context.Parametros.Clear();
            context.Parametros.Add(new SqlParameter("@Numero_Empresa", iEmpresa));
            context.Parametros.Add(new SqlParameter("@Cadena", sCadena));
            dt = context.ExecuteProcedure("sp_WS_Producto_Obtener_Productos", true).Copy();
            return dt;
        }

    
    }
}
