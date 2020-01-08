using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using CeleryMisfortune.Controllers;
using CeleryMisfortune.ViewModel.PlayerSpecialVMs;
using KnifeZ.CelestialMisfortune.Player;
using CeleryMisfortune.DataAccess;

namespace CeleryMisfortune.Test
{
    [TestClass]
    public class PlayerSpecialControllerTest
    {
        private PlayerSpecialController _controller;
        private string _seed;

        public PlayerSpecialControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<PlayerSpecialController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as PlayerSpecialListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(PlayerSpecialVM));

            PlayerSpecialVM vm = rv.Model as PlayerSpecialVM;
            PlayerSpecial v = new PlayerSpecial();
			
            v.FK_PlayerGuId = "62";
            v.Strength = 33;
            v.Perception = 75;
            v.Endurance = 81;
            v.Charisma = 2;
            v.Intelligence = 1;
            v.Luck = 80;
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PlayerSpecial>().FirstOrDefault();
				
                Assert.AreEqual(data.FK_PlayerGuId, "62");
                Assert.AreEqual(data.Strength, 33);
                Assert.AreEqual(data.Perception, 75);
                Assert.AreEqual(data.Endurance, 81);
                Assert.AreEqual(data.Charisma, 2);
                Assert.AreEqual(data.Intelligence, 1);
                Assert.AreEqual(data.Luck, 80);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            PlayerSpecial v = new PlayerSpecial();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.FK_PlayerGuId = "62";
                v.Strength = 33;
                v.Perception = 75;
                v.Endurance = 81;
                v.Charisma = 2;
                v.Intelligence = 1;
                v.Luck = 80;
                context.Set<PlayerSpecial>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(PlayerSpecialVM));

            PlayerSpecialVM vm = rv.Model as PlayerSpecialVM;
            v = new PlayerSpecial();
            v.ID = vm.Entity.ID;
       		
            v.FK_PlayerGuId = "61";
            v.Strength = 15;
            v.Perception = 12;
            v.Endurance = 55;
            v.Charisma = 54;
            v.Intelligence = 37;
            v.Luck = 5;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.FK_PlayerGuId", "");
            vm.FC.Add("Entity.Strength", "");
            vm.FC.Add("Entity.Perception", "");
            vm.FC.Add("Entity.Endurance", "");
            vm.FC.Add("Entity.Charisma", "");
            vm.FC.Add("Entity.Intelligence", "");
            vm.FC.Add("Entity.Luck", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PlayerSpecial>().FirstOrDefault();
 				
                Assert.AreEqual(data.FK_PlayerGuId, 61);
                Assert.AreEqual(data.Strength, 15);
                Assert.AreEqual(data.Perception, 12);
                Assert.AreEqual(data.Endurance, 55);
                Assert.AreEqual(data.Charisma, 54);
                Assert.AreEqual(data.Intelligence, 37);
                Assert.AreEqual(data.Luck, 5);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            PlayerSpecial v = new PlayerSpecial();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.FK_PlayerGuId = "62";
                v.Strength = 33;
                v.Perception = 75;
                v.Endurance = 81;
                v.Charisma = 2;
                v.Intelligence = 1;
                v.Luck = 80;
                context.Set<PlayerSpecial>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(PlayerSpecialVM));

            PlayerSpecialVM vm = rv.Model as PlayerSpecialVM;
            v = new PlayerSpecial();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<PlayerSpecial>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            PlayerSpecial v = new PlayerSpecial();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.FK_PlayerGuId = "62";
                v.Strength = 33;
                v.Perception = 75;
                v.Endurance = 81;
                v.Charisma = 2;
                v.Intelligence = 1;
                v.Luck = 80;
                context.Set<PlayerSpecial>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            PlayerSpecial v1 = new PlayerSpecial();
            PlayerSpecial v2 = new PlayerSpecial();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.FK_PlayerGuId = "62";
                v1.Strength = 33;
                v1.Perception = 75;
                v1.Endurance = 81;
                v1.Charisma = 2;
                v1.Intelligence = 1;
                v1.Luck = 80;
                v2.FK_PlayerGuId = "61";
                v2.Strength = 15;
                v2.Perception = 12;
                v2.Endurance = 55;
                v2.Charisma = 54;
                v2.Intelligence = 37;
                v2.Luck = 5;
                context.Set<PlayerSpecial>().Add(v1);
                context.Set<PlayerSpecial>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(PlayerSpecialBatchVM));

            PlayerSpecialBatchVM vm = rv.Model as PlayerSpecialBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<PlayerSpecial>().Count(), 0);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as PlayerSpecialListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }


    }
}
