using System.Collections.Generic;
using CapaDatos;

namespace CapaNegocio
{
    public class CalculoBL
    {
        public bool GuardarCalculo(string nombre, string descripcion, string resultado, string nombreCategoria, string nombreCarpeta)
        {
            try
            {
                int idCategoria = new CategoriaDAO().ObtenerIdPorNombre(nombreCategoria);
                int idCarpeta = new CarpetaDAO().ObtenerIdPorNombre(nombreCarpeta);

                CalculoDAO dao = new CalculoDAO();
                dao.InsertarCalculo(nombre, descripcion, resultado, idCategoria, idCarpeta);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<CalculoDTO> ObtenerCalculos()
        {
            CalculoDAO dao = new CalculoDAO();
            return dao.ObtenerCalculos();
        }

        public void EliminarCalculo(int id)
        {
            new CalculoDAO().EliminarCalculo(id);
        }
    }
}

