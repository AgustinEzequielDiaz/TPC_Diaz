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
        public List<Material> ListarMaterial()
        {
            List<Material> ListadoMaterial = new List<Material>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("select M.IdMaterial, M.Nombre, M.Descripcion, M.IdCategoria, M.Imagen, M.Cantidad, M.Eliminado, C.Nombre as NombreCat, C.IdCategoria as IdCat, C.Eliminado as Eliminado From MATERIALES as M Inner join CATEGORIAS as C on C.IdCategoria = M.IdCategoria");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    Material aux = new Material();
                    aux.Id = datos.lector.GetInt32(0);
                    aux.Nombre = datos.lector.GetString(1);
                    aux.Descripcion = datos.lector.GetString(2);
                    aux.Imagen = datos.lector.GetString(4);
                    aux.Cantidad = datos.lector.GetInt32(5);
                    aux.Eliminado = datos.lector.GetInt32(6);
                    aux.Categoria = new Categoria();
                    aux.Categoria.Nombre = (string)datos.lector["NombreCat"];
                    aux.Categoria.Id = (int)datos.lector["IdCat"];
                    aux.Categoria.Eliminado = (int)datos.lector["Eliminado"];
                   
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

    }
}
