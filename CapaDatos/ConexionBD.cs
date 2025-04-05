using Oracle.ManagedDataAccess.Client;
using System;

namespace CapaDatos
{
    public class ConexionBD
    {
        private static readonly string cadenaConexion = "User Id=system;Password=12345;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SID=xe)));";

        public static OracleConnection ObtenerConexion()
        {
            try
            {
                OracleConnection conexion = new OracleConnection(cadenaConexion);
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar con la base de datos: {ex.Message}");
                return null;
            }
        }
    }
}
