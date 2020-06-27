using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class AutoNegocio
    {
        Auto aux = new Auto();
        public List<Auto> ListarAuto()
        {
            List<Auto> ListadoAuto = new List<Auto>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spListarAuto");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    Auto aux = new Auto();
                    aux.IdAuto = datos.lector.GetInt32(0);
                    aux.Patente = datos.lector.GetString(1);
                    aux.Modelo = datos.lector.GetString(2);
                    aux.Eliminado = datos.lector.GetInt32(3);

                    ListadoAuto.Add(aux);

                }
                return ListadoAuto;
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


        public void EliminarAuto(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spEliminarAuto");
                datos.agregarParametro("@IdAuto", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ModificarAuto(Auto auto)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("spModificarAuto");
                datos.agregarParametro("@Patente", auto.Patente);
                datos.agregarParametro("@IdAuto", auto.IdAuto);
                datos.agregarParametro("@Modelo", auto.Modelo);
                datos.agregarParametro("@Eliminado", auto.Eliminado);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarAuto(Auto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("spAgregarAuto");

                datos.agregarParametro("@Patente", nuevo.Patente);
                datos.agregarParametro("@Modelo", nuevo.Modelo);
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
