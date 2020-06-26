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
    public class SuplidoresBLL
    {
        public static List<Suplidores> GetList(Expression<Func<Suplidores, bool>> expression)
        {
            List<Suplidores> lista = new List<Suplidores>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Suplidores.Where(expression).ToList();
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
