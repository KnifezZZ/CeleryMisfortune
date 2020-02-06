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
            
            v.Strength = 2;
            v.Perception = 43;
            v.Endurance = 28;
            v.Charisma = 38;
            v.Intelligence = 61;
            v.Agility = 24;
            v.Luck = 19;
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PlayerSpecial>().FirstOrDefault();
                
                Assert.AreEqual(data.Strength, 2);
                Assert.AreEqual(data.Perception, 43);
                Assert.AreEqual(data.Endurance, 28);
                Assert.AreEqual(data.Charisma, 38);
                Assert.AreEqual(data.Intelligence, 61);
                Assert.AreEqual(data.Agility, 24);
                Assert.AreEqual(data.Luck, 19);
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
       			
                v.Strength = 2;
                v.Perception = 43;
                v.Endurance = 28;
                v.Charisma = 38;
                v.Intelligence = 61;
                v.Agility = 24;
                v.Luck = 19;
                context.Set<PlayerSpecial>().Add(v);
                context.SaveChanges();
            }

            PlayerSpecialApiVM vm = _controller.CreateVM<PlayerSpecialApiVM>();
            var oldID = v.ID;
            v = new PlayerSpecial();
            v.ID = oldID;
       		
            v.Strength = 51;
            v.Perception = 7;
            v.Endurance = 80;
            v.Charisma = 69;
            v.Intelligence = 54;
            v.Agility = 88;
            v.Luck = 27;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Strength", "");
            vm.FC.Add("Entity.Perception", "");
            vm.FC.Add("Entity.Endurance", "");
            vm.FC.Add("Entity.Charisma", "");
            vm.FC.Add("Entity.Intelligence", "");
            vm.FC.Add("Entity.Agility", "");
            vm.FC.Add("Entity.Luck", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PlayerSpecial>().FirstOrDefault();
 				
                Assert.AreEqual(data.Strength, 51);
                Assert.AreEqual(data.Perception, 7);
                Assert.AreEqual(data.Endurance, 80);
                Assert.AreEqual(data.Charisma, 69);
                Assert.AreEqual(data.Intelligence, 54);
                Assert.AreEqual(data.Agility, 88);
                Assert.AreEqual(data.Luck, 27);
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
        		
                v.Strength = 2;
                v.Perception = 43;
                v.Endurance = 28;
                v.Charisma = 38;
                v.Intelligence = 61;
                v.Agility = 24;
                v.Luck = 19;
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
				
                v1.Strength = 2;
                v1.Perception = 43;
                v1.Endurance = 28;
                v1.Charisma = 38;
                v1.Intelligence = 61;
                v1.Agility = 24;
                v1.Luck = 19;
                v2.Strength = 51;
                v2.Perception = 7;
                v2.Endurance = 80;
                v2.Charisma = 69;
                v2.Intelligence = 54;
                v2.Agility = 88;
                v2.Luck = 27;
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
