using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using CeleryMisfortune.Controllers;
using CeleryMisfortune.ViewModel.PlayerStateVMs;
using KnifeZ.CelestialMisfortune.Player;
using CeleryMisfortune.DataAccess;

namespace CeleryMisfortune.Test
{
    [TestClass]
    public class PlayerStateControllerTest
    {
        private PlayerStateController _controller;
        private string _seed;

        public PlayerStateControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<PlayerStateController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as PlayerStateListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(PlayerStateVM));

            PlayerStateVM vm = rv.Model as PlayerStateVM;
            PlayerState v = new PlayerState();
			
            v.LevelExp = 44;
            v.MaxLifeTime = 69;
            v.CurrentLife = 52;
            v.Energy = 93;
            v.Money = 7;
            v.Gold = 55;
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PlayerState>().FirstOrDefault();
				
                Assert.AreEqual(data.LevelExp, 44);
                Assert.AreEqual(data.MaxLifeTime, 69);
                Assert.AreEqual(data.CurrentLife, 52);
                Assert.AreEqual(data.Energy, 93);
                Assert.AreEqual(data.Money, 7);
                Assert.AreEqual(data.Gold, 55);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            PlayerState v = new PlayerState();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.LevelExp = 44;
                v.MaxLifeTime = 69;
                v.CurrentLife = 52;
                v.Energy = 93;
                v.Money = 7;
                v.Gold = 55;
                context.Set<PlayerState>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(PlayerStateVM));

            PlayerStateVM vm = rv.Model as PlayerStateVM;
            v = new PlayerState();
            v.ID = vm.Entity.ID;
       		
            v.LevelExp = 72;
            v.MaxLifeTime = 88;
            v.CurrentLife = 5;
            v.Energy = 87;
            v.Money = 16;
            v.Gold = 40;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.LevelExp", "");
            vm.FC.Add("Entity.MaxLifeTime", "");
            vm.FC.Add("Entity.CurrentLife", "");
            vm.FC.Add("Entity.Energy", "");
            vm.FC.Add("Entity.Money", "");
            vm.FC.Add("Entity.Gold", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PlayerState>().FirstOrDefault();
 				
                Assert.AreEqual(data.LevelExp, 72);
                Assert.AreEqual(data.MaxLifeTime, 88);
                Assert.AreEqual(data.CurrentLife, 5);
                Assert.AreEqual(data.Energy, 87);
                Assert.AreEqual(data.Money, 16);
                Assert.AreEqual(data.Gold, 40);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            PlayerState v = new PlayerState();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.LevelExp = 44;
                v.MaxLifeTime = 69;
                v.CurrentLife = 52;
                v.Energy = 93;
                v.Money = 7;
                v.Gold = 55;
                context.Set<PlayerState>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(PlayerStateVM));

            PlayerStateVM vm = rv.Model as PlayerStateVM;
            v = new PlayerState();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<PlayerState>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            PlayerState v = new PlayerState();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.LevelExp = 44;
                v.MaxLifeTime = 69;
                v.CurrentLife = 52;
                v.Energy = 93;
                v.Money = 7;
                v.Gold = 55;
                context.Set<PlayerState>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            PlayerState v1 = new PlayerState();
            PlayerState v2 = new PlayerState();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.LevelExp = 44;
                v1.MaxLifeTime = 69;
                v1.CurrentLife = 52;
                v1.Energy = 93;
                v1.Money = 7;
                v1.Gold = 55;
                v2.LevelExp = 72;
                v2.MaxLifeTime = 88;
                v2.CurrentLife = 5;
                v2.Energy = 87;
                v2.Money = 16;
                v2.Gold = 40;
                context.Set<PlayerState>().Add(v1);
                context.Set<PlayerState>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(PlayerStateBatchVM));

            PlayerStateBatchVM vm = rv.Model as PlayerStateBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<PlayerState>().Count(), 0);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as PlayerStateListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }


    }
}
