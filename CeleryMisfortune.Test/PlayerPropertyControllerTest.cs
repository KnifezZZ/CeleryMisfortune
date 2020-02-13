using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using CeleryMisfortune.Controllers;
using CeleryMisfortune.ViewModel.PlayerPropertyVMs;
using KnifeZ.CelestialMisfortune.Player;
using CeleryMisfortune.DataAccess;

namespace CeleryMisfortune.Test
{
    [TestClass]
    public class PlayerPropertyControllerTest
    {
        private PlayerPropertyController _controller;
        private string _seed;

        public PlayerPropertyControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<PlayerPropertyController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as PlayerPropertyListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(PlayerPropertyVM));

            PlayerPropertyVM vm = rv.Model as PlayerPropertyVM;
            PlayerProperty v = new PlayerProperty();
			
            v.TypeId = 80;
            v.Level = 98;
            v.Value = 7;
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PlayerProperty>().FirstOrDefault();
				
                Assert.AreEqual(data.TypeId, 80);
                Assert.AreEqual(data.Level, 98);
                Assert.AreEqual(data.Value, 7);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            PlayerProperty v = new PlayerProperty();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.TypeId = 80;
                v.Level = 98;
                v.Value = 7;
                context.Set<PlayerProperty>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(PlayerPropertyVM));

            PlayerPropertyVM vm = rv.Model as PlayerPropertyVM;
            v = new PlayerProperty();
            v.ID = vm.Entity.ID;
       		
            v.TypeId = 35;
            v.Level = 62;
            v.Value = 93;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.TypeId", "");
            vm.FC.Add("Entity.Level", "");
            vm.FC.Add("Entity.Value", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PlayerProperty>().FirstOrDefault();
 				
                Assert.AreEqual(data.TypeId, 35);
                Assert.AreEqual(data.Level, 62);
                Assert.AreEqual(data.Value, 93);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            PlayerProperty v = new PlayerProperty();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.TypeId = 80;
                v.Level = 98;
                v.Value = 7;
                context.Set<PlayerProperty>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(PlayerPropertyVM));

            PlayerPropertyVM vm = rv.Model as PlayerPropertyVM;
            v = new PlayerProperty();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<PlayerProperty>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            PlayerProperty v = new PlayerProperty();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.TypeId = 80;
                v.Level = 98;
                v.Value = 7;
                context.Set<PlayerProperty>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            PlayerProperty v1 = new PlayerProperty();
            PlayerProperty v2 = new PlayerProperty();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.TypeId = 80;
                v1.Level = 98;
                v1.Value = 7;
                v2.TypeId = 35;
                v2.Level = 62;
                v2.Value = 93;
                context.Set<PlayerProperty>().Add(v1);
                context.Set<PlayerProperty>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(PlayerPropertyBatchVM));

            PlayerPropertyBatchVM vm = rv.Model as PlayerPropertyBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<PlayerProperty>().Count(), 0);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as PlayerPropertyListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }


    }
}
