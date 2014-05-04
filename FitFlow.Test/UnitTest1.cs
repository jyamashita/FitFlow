using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitFlow.Models;
using System.Linq;
using FitFlow.Models.FitFlow;

namespace FitFlow.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var dbc = new FitFlow.Models.FitFlow.FitFlowEntities();

            var list = dbc.GroupView.ToList();
            var dep = new Departments { 
                Id = "aiueo",
                Level = 1,
                ParentId = null,
                CreateUserId = "admin",
                CreateDateTime = DateTime.Now
            };
            dbc.Departments.Add(dep);
            dbc.SaveChanges();
        }
    }
}
