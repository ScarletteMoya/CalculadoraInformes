using System.Collections.Generic;
using CapaDatos;

namespace CapaNegocio
{
    public class CategoriaBL
    {
        public List<string> ObtenerNombresCategorias()
        {
            CategoriaDAO dao = new CategoriaDAO();
            return dao.ObtenerNombresCategorias();
        }
    }
}
