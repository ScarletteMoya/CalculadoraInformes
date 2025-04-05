using System.Collections.Generic;
using CapaDatos;

namespace CapaNegocio
{
    public class CarpetaBL
    {
        public List<string> ObtenerNombresCarpetas()
        {
            CarpetaDAO dao = new CarpetaDAO();
            return dao.ObtenerNombresCarpetas();
        }
    }
}
