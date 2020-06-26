using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrdenesDetalle.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using OrdenesDetalle.Models;

namespace OrdenesDetalle.BLL.Tests
{
    [TestClass()]
    public class OrdenesBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Ordenes ordenes = new Ordenes();
            ordenes.OrdenId = 0;
            ordenes.SuplidorId = 1;
            ordenes.Fecha = DateTime.Now;
            ordenes.Monto = 25;
            ordenes.OrdenDetalle.Add(new Models.OrdenesDetalle
            {
                OrdenDetalleId = 0,
                OrdenId = 0,
                ProductoId = 1,
                Costo = 25,
                Cantidad = 1
            });
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = OrdenesBLL.Eliminar(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Ordenes ordenes = new Ordenes();
            ordenes = OrdenesBLL.Buscar(1);
            Assert.IsNotNull(ordenes);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var lista = new List<Ordenes>();
            lista = OrdenesBLL.GetList(p => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = OrdenesBLL.Existe(1);
            Assert.AreEqual(paso, true);
        }
    }
}