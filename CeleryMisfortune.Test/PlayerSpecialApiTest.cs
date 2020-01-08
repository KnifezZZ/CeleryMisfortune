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
    public class PlayerSpecialApiTest
    {
        private PlayerSpecialApiController _controller;
        private string _seed;

        public PlayerSpecialApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<PlayerSpecialApiController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            string rv = _controller.Search(new PlayerSpecialApiSearcher());
            Assert.IsTrue(string.IsNullOrEmpty(rv)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            PlayerSpecialApiVM vm = _controller.CreateVM<PlayerSpecialApiVM>();
            PlayerSpecial v = new PlayerSpecial();
            
            v.FK_PlayerGuId = "45";
            v.Strength = 48;
            v.Perception = 32;
            v.Endurance = 89;
            v.Charisma = 77;
            v.Intelligence = 60;
            v.Luck = 32;
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PlayerSpecial>().FirstOrDefault();
                
                Assert.AreEqual(data.FK_PlayerGuId, "45");
                Assert.AreEqual(data.Strength, 48);
                Assert.AreEqual(data.Perception, 32);
                Assert.AreEqual(data.Endurance, 89);
                Assert.AreEqual(data.Charisma, 77);
                Assert.AreEqual(data.Intelligence, 60);
                Assert.AreEqual(data.Luck, 32);
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
       			
                v.FK_PlayerGuId = "1231";
                v.Strength = 48;
                v.Perception = 32;
                v.Endurance = 89;
                v.Charisma = 77;
                v.Intelligence = 60;
                v.Luck = 32;
                context.Set<PlayerSpecial>().Add(v);
                context.SaveChanges();
            }

            PlayerSpecialApiVM vm = _controller.CreateVM<PlayerSpecialApiVM>();
            var oldID = v.ID;
            v = new PlayerSpecial();
            v.ID = oldID;
       		
            v.FK_PlayerGuId = "1231";
            v.Strength = 42;
            v.Perception = 51;
            v.Endurance = 11;
            v.Charisma = 20;
            v.Intelligence = 39;
            v.Luck = 80;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.FK_PlayerGuId", "");
            vm.FC.Add("Entity.Strength", "");
            vm.FC.Add("Entity.Perception", "");
            vm.FC.Add("Entity.Endurance", "");
            vm.FC.Add("Entity.Charisma", "");
            vm.FC.Add("Entity.Intelligence", "");
            vm.FC.Add("Entity.Luck", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PlayerSpecial>().FirstOrDefault();
 				
                Assert.AreEqual(data.FK_PlayerGuId, 31);
                Assert.AreEqual(data.Strength, 42);
                Assert.AreEqual(data.Perception, 51);
                Assert.AreEqual(data.Endurance, 11);
                Assert.AreEqual(data.Charisma, 20);
                Assert.AreEqual(data.Intelligence, 39);
                Assert.AreEqual(data.Luck, 80);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            PlayerSpecial v = new PlayerSpecial();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.FK_PlayerGuId = "1231";
                v.Strength = 48;
                v.Perception = 32;
                v.Endurance = 89;
                v.Charisma = 77;
                v.Intelligence = 60;
                v.Luck = 32;
                context.Set<PlayerSpecial>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            PlayerSpecial v1 = new PlayerSpecial();
            PlayerSpecial v2 = new PlayerSpecial();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.FK_PlayerGuId = "1231";
                v1.Strength = 48;
                v1.Perception = 32;
                v1.Endurance = 89;
                v1.Charisma = 77;
                v1.Intelligence = 60;
                v1.Luck = 32;
                v2.FK_PlayerGuId = "1231";
                v2.Strength = 42;
                v2.Perception = 51;
                v2.Endurance = 11;
                v2.Charisma = 20;
                v2.Intelligence = 39;
                v2.Luck = 80;
                context.Set<PlayerSpecial>().Add(v1);
                context.Set<PlayerSpecial>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<PlayerSpecial>().Count(), 0);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}
