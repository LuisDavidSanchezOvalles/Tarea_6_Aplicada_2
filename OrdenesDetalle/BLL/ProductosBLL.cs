using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrdenesDetalle.DAL;
using Microsoft.EntityFrameworkCore;
using OrdenesDetalle.Models;
using System.Linq.Expressions;

namespace OrdenesDetalle.BLL
{
    public class ProductosBLL
    {
        public static Productos Buscar(int id)
        {
            Contexto db = new Contexto();
            Productos productos;

            try
            {
                productos = db.Productos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return productos;

        }
        public static List<Productos> GetList(Expression<Func<Productos, bool>> producto)
        {
            List<Productos> lista = new List<Productos>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Productos.Where(producto).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return lista;
        }
    }
}
