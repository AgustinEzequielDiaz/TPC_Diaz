using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CategoriaNegocio
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

        public void EliminarCategoria(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spEliminarCategoria");
                datos.agregarParametro("@IdCategoria", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ModificarCategoria(Material categoria)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("spModificarCategoria");
                datos.agregarParametro("@Nombre", categoria.Nombre);
                datos.agregarParametro("@IdCategoria", categoria.Id);
                datos.agregarParametro("@Eliminado", categoria.Eliminado);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarCategoria(Categoria nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("spAgregarCategorias");

                datos.agregarParametro("@Nombre", nuevo.Nombre);
                datos.agregarParametro("@Eliminado", 0);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
