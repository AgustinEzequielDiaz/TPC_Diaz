using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class StockAutoNegocio
    {
        public List<StockAuto> ListadoStock()
        {
            List<StockAuto> ListadoStockAuto = new List<StockAuto>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spListarStockAuto");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    StockAuto aux = new StockAuto();
                    aux.IdStockAuto = datos.lector.GetInt32(0);
                    aux.IdAuto.IdAuto = datos.lector.GetInt32(1);
                    aux.material.Id = datos.lector.GetInt32(2);
                    aux.Cantidad = datos.lector.GetInt32(3);
                    aux.Eliminado = datos.lector.GetInt32(4);

                    ListadoStockAuto.Add(aux);

                }
                return ListadoStockAuto;
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

        public List<StockAuto> ListadoAsigxMat(int IdAuto)
        {
            List<StockAuto> ListadoStock = new List<StockAuto>();
            //StockAuto aux = new StockAuto();
            Asignar asignar = new Asignar();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spListarAsignacionXMaterial");
                datos.agregarParametro("IdAuto", IdAuto);
                datos.ejecutarAccion();
                datos.ejecutarLector();
                while(datos.lector.Read())
                {
                    StockAuto aux = new StockAuto();
                    aux.material.Id = datos.lector.GetInt32(0);
                    aux.material.Nombre = datos.lector.GetString(1);
                    aux.Cantidad = datos.lector.GetInt32(2);
                    ListadoStock.Add(aux);
                }
                return ListadoStock;
            }
            catch (Exception)
            {

                throw;
            }
        }


        //public List<StockAuto> ListadoStockXAuto()
        //{
        //    List<StockAuto> ListadoStockAuto = new List<StockAuto>();
        //    AccesoDatos datos = new AccesoDatos();
        //    try
        //    {
        //        datos.setearSP("spListarStockAuto");
        //        datos.ejecutarLector();
        //        while (datos.lector.Read())
        //        {
        //            StockAuto aux = new StockAuto();
        //            aux.IdStock = datos.lector.GetInt32(0);
        //            aux.material.Id = datos.lector.GetInt32(1);
        //            aux.IdAuto = datos.lector.GetInt32(2);
        //            aux.Cantidad = datos.lector.GetInt32(3);
        //            aux.Eliminado = datos.lector.GetInt32(4);

        //            ListadoStockAuto.Add(aux);

        //        }
        //        return ListadoStockAuto;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }
        //}

        public void EliminarStockAuto(int idAsignar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spEliminarStockAuto");
                datos.agregarParametro("@IdAsignar", idAsignar);
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
                datos.agregarParametro("@IdAuto", auto.IdAuto);
               
                datos.agregarParametro("@Modelo", auto.Modelo);
                datos.agregarParametro("@Patente", auto.Patente);
                datos.agregarParametro("@Eliminado", auto.Eliminado);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarStock(StockAuto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearSP("spAgregarStockAuto");
                datos.agregarParametro("@IdAuto", nuevo.IdAuto);
                datos.agregarParametro("@Cantidad", nuevo.material.Cantidad);
                datos.agregarParametro("@Eliminado", 0);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarAsignacionAuto(StockAuto nueva)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearSP("spAgregarAsignacionXStockAuto");
                datos.agregarParametro("@IdAsignar", nueva.IdAsignar.IdAsignar);
                datos.agregarParametro("@IdStockAuto", nueva.IdStockAuto);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarMaterialAuto(StockAuto stock)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearSP("spAsignacionStockAuto");
                datos.agregarParametro("@IdMaterial", stock.material.Id);
                datos.agregarParametro("@IdAuto", stock.IdAuto.IdAuto);
                datos.agregarParametro("@Cantidad", stock.material.Cantidad);
                datos.agregarParametro("@Eliminar", stock.Eliminado);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StockAuto> ListarRegistros()
        {
            List<StockAuto> ListadoStock = new List<StockAuto>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spListarRegistros");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    StockAuto aux = new StockAuto();
                    aux.usuario.Nombre = datos.lector.GetString(0);
                    aux.material.Nombre = datos.lector.GetString(1);
                    aux.material.Descripcion = datos.lector.GetString(2);
                    aux.Cantidad = datos.lector.GetInt32(3);
                    aux.IdAuto.Patente = datos.lector.GetString(4);
                    aux.IdAsignar.fechaAsignacion = datos.lector.GetDateTime(5);
                    ListadoStock.Add(aux);
                }
                return ListadoStock;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
