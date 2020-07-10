using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ContactoNegocio
    {
        Contacto aux = new Contacto();
        public List<Contacto> ListarContacto()
        {
            List<Contacto> ListadoContacto = new List<Contacto>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spListarContacto");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    Contacto aux = new Contacto();
                    aux.IdContacto = datos.lector.GetInt32(0);
                    aux.Email = datos.lector.GetString(1);
                    aux.Telefono = datos.lector.GetInt64(2);
                    ListadoContacto.Add(aux);

                }
                return ListadoContacto;
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


        public void EliminarContacto(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spEliminarContacto");
                datos.agregarParametro("@IdContacto", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ModificarContacto(Contacto contacto)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("spModificarContacto");
                datos.agregarParametro("@IdContacto", contacto.IdContacto);
                datos.agregarParametro("@Email", contacto.Email);
                datos.agregarParametro("@Telefono", contacto.Telefono);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarContacto(Contacto contacto)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("spAgregarContacto");
                datos.agregarParametro("@Email", contacto.Email);
                datos.agregarParametro("@Telefono", contacto.Telefono);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
