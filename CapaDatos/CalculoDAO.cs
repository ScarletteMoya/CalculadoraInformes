using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace CapaDatos
{
    public class CalculoDAO
    {
        public void InsertarCalculo(string nombre, string descripcion, string resultado, int idCategoria, int idCarpeta)
        {
            using (OracleConnection conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = @"INSERT INTO Calculos (nombre, descripcion, resultado, id_categoria, id_carpeta)
                                 VALUES (:nombre, :descripcion, :resultado, :id_categoria, :id_carpeta)";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add(":nombre", OracleDbType.Varchar2).Value = nombre;
                cmd.Parameters.Add(":descripcion", OracleDbType.Clob).Value = descripcion;
                cmd.Parameters.Add(":resultado", OracleDbType.Varchar2).Value = resultado;
                cmd.Parameters.Add(":id_categoria", OracleDbType.Int32).Value = idCategoria;
                cmd.Parameters.Add(":id_carpeta", OracleDbType.Int32).Value = idCarpeta;

                cmd.ExecuteNonQuery();
            }
        }

        public List<CalculoDTO> ObtenerCalculos()
        {
            List<CalculoDTO> lista = new List<CalculoDTO>();

            using (OracleConnection conn = ConexionBD.ObtenerConexion())
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string query = @"SELECT c.id, c.nombre, c.descripcion, c.resultado, c.fecha_creacion,
                         cat.nombre AS categoria, car.nombre AS carpeta
                         FROM Calculos c
                         JOIN Categorias cat ON c.id_categoria = cat.id
                         JOIN Carpetas car ON c.id_carpeta = car.id";

                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CalculoDTO calculo = new CalculoDTO
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Descripcion = reader.GetString(2),
                        Resultado = reader.GetString(3),
                        FechaCreacion = reader.GetDateTime(4),
                        Categoria = reader.GetString(5),
                        Carpeta = reader.GetString(6)
                    };
                    lista.Add(calculo);
                }
            }

            return lista;
        }

        public void EliminarCalculo(int id)
        {
            using (OracleConnection conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = "DELETE FROM Calculos WHERE id = :id";
                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add(":id", OracleDbType.Int32).Value = id;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
