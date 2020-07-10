using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class DireccionNegocio
    {
        Direccion aux = new Direccion();
        public List<Direccion> ListarDireccion()
        {
            List<Direccion> ListadoDireccion = new List<Direccion>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spListarDireccion");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    Direccion aux = new Direccion();
                    aux.IdDireccion = datos.lector.GetInt32(0);
                    aux.Calle = datos.lector.GetString(1);
                    aux.Numero = datos.lector.GetInt32(2);
                    aux.CP = datos.lector.GetInt32(3);
                    aux.Localidad = datos.lector.GetString(4);
                    aux.Provincia = datos.lector.GetString(5);
                    ListadoDireccion.Add(aux);
                }
                return ListadoDireccion;
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


        public void EliminarDireccion(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spEliminarDireccion");
                datos.agregarParametro("@IdDireccion", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ModificarDireccion(Direccion direccion)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("spModificarDireccion");
                datos.agregarParametro("@IdDireccion", direccion.IdDireccion);
                datos.agregarParametro("@Calle", direccion.Calle);
                datos.agregarParametro("@Numero", direccion.Numero);
                datos.agregarParametro("@CP", direccion.CP);
                datos.agregarParametro("@Localidad", direccion.Localidad);
                datos.agregarParametro("@Provincia", direccion.Provincia);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarDireccion(Direccion direccion)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("spAgregarDireccion");
                datos.agregarParametro("@Calle", direccion.Calle);
                datos.agregarParametro("@Numero", direccion.Numero);
                datos.agregarParametro("@CP", direccion.CP);
                datos.agregarParametro("@Localidad", direccion.Localidad);
                datos.agregarParametro("@Provincia", direccion.Provincia);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }        
    }
}
