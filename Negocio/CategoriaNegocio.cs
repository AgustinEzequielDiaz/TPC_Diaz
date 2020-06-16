using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    class CategoriaNegocio
    {
        public List<Categoria> ListarCategoria()
        {
            List<Categoria> ListadoCategoria = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("select C.Id, C.Nombre, C.Eliminado from CATEGORIAS as C");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = datos.lector.GetInt32(0);
                    aux.Nombre = datos.lector.GetString(1);
                    aux.Eliminado = datos.lector.GetInt32(2);

                    ListadoCategoria.Add(aux);
                }
                return ListadoCategoria;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
