using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace CapaDatos
{
    public class CategoriaDAO
    {
        public List<string> ObtenerCategorias()
        {
            List<string> lista = new List<string>();

            using (OracleConnection conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT nombre FROM Categorias";
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(reader.GetString(0));
                }
            }

            return lista;
        }

        public int ObtenerIdPorNombre(string nombre)
        {
            int id = -1;

            using (OracleConnection conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT id FROM Categorias WHERE nombre = :nombre";
                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add(":nombre", OracleDbType.Varchar2).Value = nombre;

                object resultado = cmd.ExecuteScalar();
                if (resultado != null)
                {
                    id = Convert.ToInt32(resultado);
                }
            }

            return id;
        }

        public List<string> ObtenerNombresCategorias()
        {
            List<string> lista = new List<string>();
            using (var con = ConexionBD.ObtenerConexion())
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                string query = "SELECT nombre FROM Categorias";
                using (var cmd = new OracleCommand(query, con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        lista.Add(reader.GetString(0));
                }
            }
            return lista;
        }
    }
}
