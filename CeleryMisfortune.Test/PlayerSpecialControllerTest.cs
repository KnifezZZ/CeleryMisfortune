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
			
            v.Strength = 70;
            v.Perception = 76;
            v.Endurance = 25;
            v.Charisma = 74;
            v.Intelligence = 72;
            v.Agility = 28;
            v.Luck = 51;
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PlayerSpecial>().FirstOrDefault();
				
                Assert.AreEqual(data.Strength, 70);
                Assert.AreEqual(data.Perception, 76);
                Assert.AreEqual(data.Endurance, 25);
                Assert.AreEqual(data.Charisma, 74);
                Assert.AreEqual(data.Intelligence, 72);
                Assert.AreEqual(data.Agility, 28);
                Assert.AreEqual(data.Luck, 51);
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
       			
                v.Strength = 70;
                v.Perception = 76;
                v.Endurance = 25;
                v.Charisma = 74;
                v.Intelligence = 72;
                v.Agility = 28;
                v.Luck = 51;
                context.Set<PlayerSpecial>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(PlayerSpecialVM));

            PlayerSpecialVM vm = rv.Model as PlayerSpecialVM;
            v = new PlayerSpecial();
            v.ID = vm.Entity.ID;
       		
            v.Strength = 88;
            v.Perception = 62;
            v.Endurance = 44;
            v.Charisma = 64;
            v.Intelligence = 24;
            v.Agility = 89;
            v.Luck = 87;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Strength", "");
            vm.FC.Add("Entity.Perception", "");
            vm.FC.Add("Entity.Endurance", "");
            vm.FC.Add("Entity.Charisma", "");
            vm.FC.Add("Entity.Intelligence", "");
            vm.FC.Add("Entity.Agility", "");
            vm.FC.Add("Entity.Luck", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PlayerSpecial>().FirstOrDefault();
 				
                Assert.AreEqual(data.Strength, 88);
                Assert.AreEqual(data.Perception, 62);
                Assert.AreEqual(data.Endurance, 44);
                Assert.AreEqual(data.Charisma, 64);
                Assert.AreEqual(data.Intelligence, 24);
                Assert.AreEqual(data.Agility, 89);
                Assert.AreEqual(data.Luck, 87);
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
        		
                v.Strength = 70;
                v.Perception = 76;
                v.Endurance = 25;
                v.Charisma = 74;
                v.Intelligence = 72;
                v.Agility = 28;
                v.Luck = 51;
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
				
                v.Strength = 70;
                v.Perception = 76;
                v.Endurance = 25;
                v.Charisma = 74;
                v.Intelligence = 72;
                v.Agility = 28;
                v.Luck = 51;
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
				
                v1.Strength = 70;
                v1.Perception = 76;
                v1.Endurance = 25;
                v1.Charisma = 74;
                v1.Intelligence = 72;
                v1.Agility = 28;
                v1.Luck = 51;
                v2.Strength = 88;
                v2.Perception = 62;
                v2.Endurance = 44;
                v2.Charisma = 64;
                v2.Intelligence = 24;
                v2.Agility = 89;
                v2.Luck = 87;
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
