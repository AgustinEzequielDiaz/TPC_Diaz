using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MaterialNegocio
    {
        Material aux = new Material();
        public List<Material> ListarMaterial()
        {
            List<Material> ListadoMaterial = new List<Material>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spListarMateriales");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    Material aux = new Material();
                    aux.Id = datos.lector.GetInt32(0);
                    aux.Nombre = datos.lector.GetString(1);
                    aux.Descripcion = datos.lector.GetString(2);
                    aux.Categoria = new Categoria();
                    aux.Categoria.Nombre = (string)datos.lector["Nombre"];
                    aux.Categoria.Id = (int)datos.lector["IdCategoria"];
                    aux.Categoria.Eliminado = (int)datos.lector["Eliminado"];
                    aux.Imagen = datos.lector.GetString(4);
                    aux.Cantidad = datos.lector.GetInt32(5);
                    aux.Eliminado = datos.lector.GetInt32(6);
                   
                    ListadoMaterial.Add(aux);

                }
                return ListadoMaterial;
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


        public void EliminarMaterial(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("spEliminarMaterial");
                datos.agregarParametro("@IdMaterial", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ModificarMaterial(Material material)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("spModificarMaterial");
                datos.agregarParametro("@Nombre", material.Nombre);
                datos.agregarParametro("@IdMaterial", material.Id);
                datos.agregarParametro("@Descripcion", material.Descripcion);
                datos.agregarParametro("@Imagen", material.Imagen);
                datos.agregarParametro("@Cantidad", material.Cantidad);
                datos.agregarParametro("@Eliminado", material.Eliminado);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarMaterial(Material nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("spAgregarMaterial");

                datos.agregarParametro("@Nombre", nuevo.Nombre);
                datos.agregarParametro("@Descripcion", nuevo.Descripcion);
                datos.agregarParametro("@Imagen", nuevo.Imagen);
                datos.agregarParametro("@IdCategoria", nuevo.Categoria.Id);
                datos.agregarParametro("@Cantidad", nuevo.Cantidad);
                datos.agregarParametro("@Eliminado", 0);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        //public void eliminar(int id)
        //{
        //    AccesoDatos datos = new AccesoDatos();
        //    try
        //    {
        //        datos.setearQuery("spEliminar");
        //        datos.agregarParametro("@ID", id);
        //        datos.ejecutarAccion();

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

    }
}
