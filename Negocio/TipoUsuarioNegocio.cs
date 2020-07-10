using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class TipoUsuarioNegocio
    {
        TipoUsuario aux = new TipoUsuario();
        public List<TipoUsuario> ListarTipoUsuario()
        {
            List<TipoUsuario> ListadoTipoUsuario = new List<TipoUsuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spListarTipoUsuario");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    TipoUsuario aux = new TipoUsuario();
                    aux.IdTipoUsuario = datos.lector.GetInt32(0);
                    aux.Nombre = datos.lector.GetString(1);
                    aux.Eliminado = datos.lector.GetInt32(2);

                    ListadoTipoUsuario.Add(aux);

                }
                return ListadoTipoUsuario;
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


        public void EliminarTipoUsuario(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spEliminarTipoUsuario");
                datos.agregarParametro("@IdTipoUsuario", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ModificarTipoUsuario(TipoUsuario tipoUsuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("spModificarTipoUsuario");
                datos.agregarParametro("@Nombre", tipoUsuario.Nombre);
                datos.agregarParametro("@IdTipoUsuario", tipoUsuario.IdTipoUsuario);
                datos.agregarParametro("@Eliminado", tipoUsuario.Eliminado);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarTipoUsuario(TipoUsuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("spAgregarTipoUsuario");

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
