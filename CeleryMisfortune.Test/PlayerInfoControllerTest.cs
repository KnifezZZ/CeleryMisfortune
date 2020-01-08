using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using CeleryMisfortune.Controllers;
using CeleryMisfortune.ViewModel.PlayerInfoVMs;
using KnifeZ.CelestialMisfortune.Player;
using CeleryMisfortune.DataAccess;

namespace CeleryMisfortune.Test
{
    [TestClass]
    public class PlayerInfoControllerTest
    {
        private PlayerInfoController _controller;
        private string _seed;

        public PlayerInfoControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<PlayerInfoController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as PlayerInfoListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(PlayerInfoVM));

            PlayerInfoVM vm = rv.Model as PlayerInfoVM;
            PlayerInfo v = new PlayerInfo();
			
            v.Sex = 65;
            v.Sect = 1;
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PlayerInfo>().FirstOrDefault();
				
                Assert.AreEqual(data.Sex, 65);
                Assert.AreEqual(data.Sect, 1);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            PlayerInfo v = new PlayerInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Sex = 65;
                v.Sect = 1;
                context.Set<PlayerInfo>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(PlayerInfoVM));

            PlayerInfoVM vm = rv.Model as PlayerInfoVM;
            v = new PlayerInfo();
            v.ID = vm.Entity.ID;
       		
            v.Sex = 99;
            v.Sect = 90;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Sex", "");
            vm.FC.Add("Entity.Sect", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PlayerInfo>().FirstOrDefault();
 				
                Assert.AreEqual(data.Sex, 99);
                Assert.AreEqual(data.Sect, 90);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            PlayerInfo v = new PlayerInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Sex = 65;
                v.Sect = 1;
                context.Set<PlayerInfo>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(PlayerInfoVM));

            PlayerInfoVM vm = rv.Model as PlayerInfoVM;
            v = new PlayerInfo();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<PlayerInfo>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            PlayerInfo v = new PlayerInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Sex = 65;
                v.Sect = 1;
                context.Set<PlayerInfo>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            PlayerInfo v1 = new PlayerInfo();
            PlayerInfo v2 = new PlayerInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Sex = 65;
                v1.Sect = 1;
                v2.Sex = 99;
                v2.Sect = 90;
                context.Set<PlayerInfo>().Add(v1);
                context.Set<PlayerInfo>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(PlayerInfoBatchVM));

            PlayerInfoBatchVM vm = rv.Model as PlayerInfoBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<PlayerInfo>().Count(), 0);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as PlayerInfoListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }


    }
}
