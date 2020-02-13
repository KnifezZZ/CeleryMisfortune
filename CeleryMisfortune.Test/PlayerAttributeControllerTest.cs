using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using CeleryMisfortune.Controllers;
using CeleryMisfortune.ViewModel.PlayerAttributeVMs;
using KnifeZ.CelestialMisfortune.Player;
using CeleryMisfortune.DataAccess;

namespace CeleryMisfortune.Test
{
    [TestClass]
    public class PlayerAttributeControllerTest
    {
        private PlayerAttributeController _controller;
        private string _seed;

        public PlayerAttributeControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<PlayerAttributeController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as PlayerAttributeListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(PlayerAttributeVM));

            PlayerAttributeVM vm = rv.Model as PlayerAttributeVM;
            PlayerAttribute v = new PlayerAttribute();
			
            v.AttrValue = 81;
            v.AttributeType = 60;
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PlayerAttribute>().FirstOrDefault();
				
                Assert.AreEqual(data.AttrValue, 81);
                Assert.AreEqual(data.AttributeType, 60);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            PlayerAttribute v = new PlayerAttribute();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.AttrValue = 81;
                v.AttributeType = 60;
                context.Set<PlayerAttribute>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(PlayerAttributeVM));

            PlayerAttributeVM vm = rv.Model as PlayerAttributeVM;
            v = new PlayerAttribute();
            v.ID = vm.Entity.ID;
       		
            v.AttrValue = 19;
            v.AttributeType = 69;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.AttrValue", "");
            vm.FC.Add("Entity.AttributeType", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PlayerAttribute>().FirstOrDefault();
 				
                Assert.AreEqual(data.AttrValue, 19);
                Assert.AreEqual(data.AttributeType, 69);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            PlayerAttribute v = new PlayerAttribute();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.AttrValue = 81;
                v.AttributeType = 60;
                context.Set<PlayerAttribute>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(PlayerAttributeVM));

            PlayerAttributeVM vm = rv.Model as PlayerAttributeVM;
            v = new PlayerAttribute();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<PlayerAttribute>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            PlayerAttribute v = new PlayerAttribute();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.AttrValue = 81;
                v.AttributeType = 60;
                context.Set<PlayerAttribute>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            PlayerAttribute v1 = new PlayerAttribute();
            PlayerAttribute v2 = new PlayerAttribute();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.AttrValue = 81;
                v1.AttributeType = 60;
                v2.AttrValue = 19;
                v2.AttributeType = 69;
                context.Set<PlayerAttribute>().Add(v1);
                context.Set<PlayerAttribute>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(PlayerAttributeBatchVM));

            PlayerAttributeBatchVM vm = rv.Model as PlayerAttributeBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<PlayerAttribute>().Count(), 0);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as PlayerAttributeListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }


    }
}
