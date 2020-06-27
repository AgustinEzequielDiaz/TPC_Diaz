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
                    Persona aux = new Persona();
                    aux.IdPersona = datos.lector.GetInt32(0);
                    aux.Nombre = datos.lector.GetString(1);
                    aux.Apellido = datos.lector.GetString(2);
                    aux.Imagen = datos.lector.GetString(3);
                    aux.DNI = datos.lector.GetInt32(4);
                    aux.FechaNac = datos.lector.GetDateTime(5);
                    aux.FechaReg = datos.lector.GetDateTime(6);
                    aux.Eliminado = datos.lector.GetInt32(7);
                    ListadoPersona.Add(aux);

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
                datos.agregarParametro("@IdMaterial", persona.IdPersona);
                datos.agregarParametro("@Nombre", persona.Nombre);
                datos.agregarParametro("@Apellido", persona.Apellido);
                datos.agregarParametro("@Imagen", persona.Imagen);
                datos.agregarParametro("@DNI", persona.DNI);
                datos.agregarParametro("@FechaNac", persona.FechaNac);
                datos.agregarParametro("@FechaReg", persona.FechaReg);
                datos.agregarParametro("@Eliminado", persona.Eliminado);
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
                datos.agregarParametro("@FechaNac", persona.FechaNac);
                datos.agregarParametro("@FechaReg", persona.FechaReg);
                datos.agregarParametro("@Eliminado", persona.Eliminado);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
