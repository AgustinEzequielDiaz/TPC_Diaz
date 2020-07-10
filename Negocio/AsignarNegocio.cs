using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class AsignarNegocio
    {
        public void AgregarAsignacion(Asignar nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spAgregarAsignacion");
                datos.agregarParametro("@IdUsuario", nuevo.IdUsuario.IdUsuario);
                //datos.agregarParametro("@Cantidad", nuevo.Cantidad);
                datos.agregarParametro("@fecha", nuevo.fechaAsignacion);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        //public void AgregarAsignacionxMaterial(Asignar nuevo)
        //{
        //    AccesoDatos datos = new AccesoDatos();
        //    try
        //    {
        //        datos.setearSP("spAgregarAsignacionxMaterial");
        //        datos.agregarParametro("@IDAsignar", nuevo.IdAsignar);

        //        datos.ejecutarAccion();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}
        public void AgregarAsignacionxUsuario(Asignar nuevo, int user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spAgregarAsignacionxusuarios");
                datos.agregarParametro("@IDusuario", user);
                datos.agregarParametro("@IDAsignar", nuevo.IdAsignar);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<Asignar> listarAsignacion()
        {
            List<Asignar> ListadoAsignacion = new List<Asignar>();
            Asignar aux;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spListarAsignacion");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    aux = new Asignar();
                    aux.IdAsignar = datos.lector.GetInt32(0);
                    aux.IdUsuario.IdUsuario = datos.lector.GetInt32(1);
                    //aux.material = datos.lector.GetString(1);
                    aux.fechaAsignacion = datos.lector.GetDateTime(2);
                    ListadoAsignacion.Add(aux);
                }

                return ListadoAsignacion;
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

        public void modificarAsignar(Asignar nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spModificarAsignar");
                datos.agregarParametro("@ID", nuevo.IdAsignar);
                //datos.agregarParametro("@IDprducto", nuevo.material.Id);
                //datos.agregarParametro("@Envio", nuevo.Envios);
                //datos.agregarParametro("@Total", nuevo.Total);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
