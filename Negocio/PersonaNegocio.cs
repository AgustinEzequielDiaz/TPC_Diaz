using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class PersonaNegocio
    {
        Persona aux = new Persona();
        public List<Persona> ListarPersona()
        {
            List<Persona> ListadoPersona = new List<Persona>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spListarPersona");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    Persona auxPersona = new Persona();
                    Direccion auxDireccion = new Direccion();
                    Contacto auxContacto = new Contacto();
                    //auxPersona.IdPersona = datos.lector.GetInt32(0);
                    auxPersona.Nombre = datos.lector.GetString(1);
                    auxPersona.Apellido = datos.lector.GetString(2);
                    auxPersona.Imagen = datos.lector.GetString(3);
                    auxPersona.DNI = datos.lector.GetInt64(4);

                    aux.direccion = new Direccion();
                    auxPersona.direccion.Calle = (string)datos.lector["CalleDireccion"];
                    auxPersona.direccion.Numero = (int)datos.lector["NumeroDireccion"];
                    auxPersona.direccion.CP = (int)datos.lector["CPDireccion"];
                    auxPersona.direccion.Localidad = (string)datos.lector["LocalidadDireccion"];
                    auxPersona.direccion.Provincia = (string)datos.lector["ProvinciaDireccion"];

                    aux.contacto = new Contacto();
                    auxPersona.contacto.Email = (string)datos.lector["EmailContacto"];
                    auxPersona.contacto.Telefono = (long)datos.lector["TelefonoContacto"];

                    //aux.FechaNac = datos.lector.GetDateTime(5);
                    //aux.FechaReg = datos.lector.GetDateTime(6);
                    
                    ListadoPersona.Add(auxPersona);

                }
                return ListadoPersona;
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


        public void EliminarPersona(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spEliminarPersona");
                datos.agregarParametro("@IdPersona", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ModificarPersona(Persona persona)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("spModificarPersona");
                //datos.agregarParametro("@IdPersona", persona.IdPersona);
                datos.agregarParametro("@Nombre", persona.Nombre);
                datos.agregarParametro("@Apellido", persona.Apellido);
                datos.agregarParametro("@Imagen", persona.Imagen);
                datos.agregarParametro("@DNI", persona.DNI);
                datos.agregarParametro("@IdDireccion", persona.direccion.IdDireccion);
                datos.agregarParametro("@IdContacto", persona.direccion.IdDireccion);
                //datos.agregarParametro("@FechaReg", persona.FechaReg);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarPersona(Persona persona)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("spAgregarPersona");
                datos.agregarParametro("@Nombre", persona.Nombre);
                datos.agregarParametro("@Apellido", persona.Apellido);
                datos.agregarParametro("@Imagen", persona.Imagen);
                datos.agregarParametro("@DNI", persona.DNI);
                datos.agregarParametro("@IdDireccion", persona.direccion.IdDireccion);
                datos.agregarParametro("@IdContacto", persona.contacto.IdContacto);
                //datos.agregarParametro("@FechaNac", persona.FechaNac);
                //datos.agregarParametro("@FechaReg", persona.FechaReg);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
           

        }       
    }
}
