using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrdenesDetalle.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using OrdenesDetalle.Models;

namespace OrdenesDetalle.BLL.Tests
{
    [TestClass()]
    public class SuplidoresBLLTests
    {
        [TestMethod()]
        public void GetListTest()
        {
            var lista = new List<Suplidores>();
            lista = SuplidoresBLL.GetList(p => true);
            Assert.IsNotNull(lista);
        }
    }
}