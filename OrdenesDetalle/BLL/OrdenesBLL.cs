using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrdenesDetalle.Models;
using OrdenesDetalle.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace OrdenesDetalle.BLL
{
    public class OrdenesBLL
    {
        public static bool Existe(int id)
        {
            Contexto db = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = db.Ordenes.Any(o => o.OrdenId == id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return encontrado;

        }

        private static bool Insertar(Ordenes orden)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                //sumamos la cantidad de productos adquiridos al inventario del producto
                foreach (var item in orden.OrdenDetalle)
                {
                    var auxOrden = db.Productos.Find(item.ProductoId);
                    if (auxOrden != null)
                    {
                        auxOrden.Inventario += item.Cantidad;
                    }
                }
                db.Ordenes.Add(orden);
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;

            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        private static bool Modificar(Ordenes orden)
        {
            bool paso = false;
            var OrdenAnterior = Buscar(orden.OrdenId);
            Contexto db = new Contexto();

            try
            {
                //aqui borro del detalle y disminuyo el producto devuelto en inventario
                foreach (var item in OrdenAnterior.OrdenDetalle)
                {
                    var auxProducto = db.Productos.Find(item.ProductoId);
                    if (!orden.OrdenDetalle.Exists(d => d.OrdenDetalleId == item.OrdenDetalleId))
                    {
                        if (auxProducto != null)
                        {
                            auxProducto.Inventario -= item.Cantidad;
                        }

                        db.Entry(item).State = EntityState.Deleted;
                    }

                }

                //aqui agrego lo nuevo al detalle
                foreach (var item in orden.OrdenDetalle)
                {
                    var auxProducto = db.Productos.Find(item.ProductoId);
                    if (item.OrdenDetalleId == 0)
                    {
                        db.Entry(item).State = EntityState.Added;
                        if (auxProducto != null)
                        {
                            auxProducto.Inventario += item.Cantidad;
                        }
                    }
                    else
                        db.Entry(item).State = EntityState.Modified;
                }

                db.Entry(orden).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Guardar(Ordenes ordenes)
        {
            if (!Existe(ordenes.OrdenId))
                return Insertar(ordenes);
            else
                return Modificar(ordenes);

        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            var OrdenAnterior = Buscar(id);
            Contexto db = new Contexto();

            try
            {
                if (Existe(id))
                {
                    //resta las cantidades correspondientes a los producto
                    foreach (var item in OrdenAnterior.OrdenDetalle)
                    {
                        var auxProducto = db.Productos.Find(item.ProductoId);
                        if (auxProducto != null)
                        {
                            auxProducto.Inventario -= item.Cantidad;
                        }
                    }

                    //remueve la entidad
                    var auxOrden = db.Ordenes.Find(id);
                    if (auxOrden != null)
                    {
                        db.Ordenes.Remove(auxOrden);
                        paso = db.SaveChanges() > 0;
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Ordenes Buscar(int id)
        {
            Contexto db = new Contexto();
            Ordenes ordenes;

            try
            {
                ordenes = db.Ordenes.Where(o => o.OrdenId == id).Include(d => d.OrdenDetalle).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return ordenes;

        }

        public static List<Ordenes> GetList(Expression<Func<Ordenes, bool>> expression)
        {
            List<Ordenes> lista = new List<Ordenes>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Ordenes.Where(expression).ToList();
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
