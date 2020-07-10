using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        Usuario aux = new Usuario();
        AccesoDatos datos = new AccesoDatos();

        public Usuario login(Usuario usuario)
        {
            try
            {
                datos.setearQuery("select Id from USUARIO where Usuario = @Usuario and Pass = @Pass");
                datos.agregarParametro("@Usuario", usuario.Nombre);
                datos.agregarParametro("@Pass", usuario.Clave);
                datos.ejecutarLector();
                if (datos.lector.Read())
                {
                    usuario.IdUsuario = (int)datos.lector["IdUsuario"];
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public Usuario Registrarse()
        //{

        //    try
        //    {
        //        datos.setearSP("spRegistrar");
        //        datos.agregarParametro("Clave", aux.Clave);
        //        datos.agregarParametro();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public List<Usuario> ListarUsuario()
        {
            List<Usuario> ListadoUsuario = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spListarUsuario");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.IdUsuario = datos.lector.GetInt32(0);
                    aux.Nombre = datos.lector.GetString(1);
                    aux.Clave = datos.lector.GetString(2);
                    aux.Permiso = datos.lector.GetInt32(3);
                    aux.direccion.IdDireccion = (int)datos.lector["IdDireccion"];
                    aux.contacto.IdContacto = (int)datos.lector["IdContacto"];
                    //aux.IdTipo.Nombre = datos.lector.GetString(2);
                    //aux.Imagen = datos.lector.GetString(3);
                    //aux.FechaNac = datos.lector.GetDateTime(5);
                    //aux.FechaReg = datos.lector.GetDateTime(6);
                    //aux.Eliminado = datos.lector.GetInt32(7);
                    ListadoUsuario.Add(aux);

                }
                return ListadoUsuario;
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


        public List<Usuario> ListarUsuarioCompleto()
        {
            List<Usuario> ListadoUsuario = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spListarUsuarioCompleto");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.IdUsuario = datos.lector.GetInt32(0);
                    aux.Nombre = datos.lector.GetString(1);
                    aux.Apellido = datos.lector.GetString(2);
                    aux.DNI = datos.lector.GetInt64(3);
                    aux.direccion.IdDireccion = (int)datos.lector["IdDireccion"];
                    aux.direccion.Calle = (string)datos.lector["Calle"];
                    aux.direccion.Numero = (int)datos.lector["Numero"];
                    aux.direccion.CP = (int)datos.lector["CP"];
                    aux.direccion.Localidad = (string)datos.lector["Localidad"];
                    aux.direccion.Provincia = (string)datos.lector["Provincia"];
                    aux.contacto.IdContacto = (int)datos.lector["IdContacto"];
                    aux.contacto.Email = (string)datos.lector["Email"];
                    aux.contacto.Telefono = (long)datos.lector["Telefono"];
                    //aux.IdTipo.Nombre = datos.lector.GetString(2);
                    //aux.Imagen = datos.lector.GetString(3);
                    //aux.FechaNac = datos.lector.GetDateTime(5);
                    //aux.FechaReg = datos.lector.GetDateTime(6);
                    //aux.Eliminado = datos.lector.GetInt32(7);
                    ListadoUsuario.Add(aux);

                }
                return ListadoUsuario;
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

        public void EliminarUsuario(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spEliminarUsuario");
                datos.agregarParametro("@IdUsuario", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ModificarUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("spModificarUsuario");
                datos.agregarParametro("@IdUsuario", usuario.IdUsuario);
                datos.agregarParametro("@Nombre", usuario.Nombre);
                datos.agregarParametro("@Apellido", usuario.Apellido);
                datos.agregarParametro("@Imagen", usuario.Imagen);
                datos.agregarParametro("@DNI", usuario.DNI);
                //datos.agregarParametro("@Direccion", usuario.direccion.Calle);
                //datos.agregarParametro("@Numero", usuario.direccion.Numero);
                //datos.agregarParametro("@CP", usuario.direccion.CP);
                //datos.agregarParametro("@Localidad", usuario.direccion.Localidad);
                //datos.agregarParametro("@Provincia", usuario.direccion.Provincia);
                //datos.agregarParametro("@Email", usuario.contacto.Email);
                //datos.agregarParametro("@Telefono", usuario.contacto.Telefono);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ModificarCuenta(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("spModificarCuenta");
                datos.agregarParametro("@IdUsuario", usuario.IdUsuario);
                datos.agregarParametro("@Nombre", usuario.Nombre);
                datos.agregarParametro("@Clave", usuario.Clave);
                datos.agregarParametro("@Permiso", usuario.Permiso);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void RegistrarUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("spAgregarUsuario");
                datos.agregarParametro("@Nombre", usuario.Nombre);
                datos.agregarParametro("@Clave", usuario.Clave);
                datos.agregarParametro("@Apellido", usuario.Apellido);
                datos.agregarParametro("@DNI", usuario.DNI);              
                datos.agregarParametro("@FechaReg", usuario.FechaReg);
                datos.agregarParametro("@Imagen", usuario.Imagen);
                datos.agregarParametro("@IdTipo", usuario.Permiso);
                datos.agregarParametro("@IdContacto", usuario.contacto.IdContacto);
                datos.agregarParametro("@IdDireccion", usuario.direccion.IdDireccion);
                datos.agregarParametro("@Eliminado", usuario.Eliminado);
                //datos.agregarParametro("@Email", usuario.contacto.Email);
                //datos.agregarParametro("@Telefono", usuario.contacto.Telefono);
                //datos.agregarParametro("@Calle",usuario.direccion.Calle);
                //datos.
                //datos.agregarParametro("@direccion", usuario.direccion);
                //datos.agregarParametro("@FechaNac", persona.FechaNac);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public List<Usuario> BuscarAuto()
        {
            List<Usuario> ListadoUsuarioXVehiculo = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spListarUsuarioXVehiculo");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.IdAuto = datos.lector.GetInt32(0);
                    aux.IdUsuario = datos.lector.GetInt32(1);
                    //aux.IdTipo.Nombre = datos.lector.GetString(2);
                    //aux.Imagen = datos.lector.GetString(3);
                    //aux.FechaNac = datos.lector.GetDateTime(5);
                    //aux.FechaReg = datos.lector.GetDateTime(6);
                    //aux.Eliminado = datos.lector.GetInt32(7);
                    ListadoUsuarioXVehiculo.Add(aux);

                }
                return ListadoUsuarioXVehiculo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
