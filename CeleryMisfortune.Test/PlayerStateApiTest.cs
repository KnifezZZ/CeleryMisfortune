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
    public class PlayerStateApiTest
    {
        private PlayerStateApiController _controller;
        private string _seed;

        public PlayerStateApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<PlayerStateApiController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            string rv = _controller.Search(new PlayerStateApiSearcher());
            Assert.IsTrue(string.IsNullOrEmpty(rv)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            PlayerStateApiVM vm = _controller.CreateVM<PlayerStateApiVM>();
            PlayerState v = new PlayerState();
            
            v.LevelExp = 71;
            v.MaxLifeTime = 38;
            v.CurrentLife = 10;
            v.Energy = 48;
            v.Money = 23;
            v.Gold = 99;
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PlayerState>().FirstOrDefault();
                
                Assert.AreEqual(data.LevelExp, 71);
                Assert.AreEqual(data.MaxLifeTime, 38);
                Assert.AreEqual(data.CurrentLife, 10);
                Assert.AreEqual(data.Energy, 48);
                Assert.AreEqual(data.Money, 23);
                Assert.AreEqual(data.Gold, 99);
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
       			
                v.LevelExp = 71;
                v.MaxLifeTime = 38;
                v.CurrentLife = 10;
                v.Energy = 48;
                v.Money = 23;
                v.Gold = 99;
                context.Set<PlayerState>().Add(v);
                context.SaveChanges();
            }

            PlayerStateApiVM vm = _controller.CreateVM<PlayerStateApiVM>();
            var oldID = v.ID;
            v = new PlayerState();
            v.ID = oldID;
       		
            v.LevelExp = 22;
            v.MaxLifeTime = 54;
            v.CurrentLife = 47;
            v.Energy = 86;
            v.Money = 67;
            v.Gold = 33;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.LevelExp", "");
            vm.FC.Add("Entity.MaxLifeTime", "");
            vm.FC.Add("Entity.CurrentLife", "");
            vm.FC.Add("Entity.Energy", "");
            vm.FC.Add("Entity.Money", "");
            vm.FC.Add("Entity.Gold", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PlayerState>().FirstOrDefault();
 				
                Assert.AreEqual(data.LevelExp, 22);
                Assert.AreEqual(data.MaxLifeTime, 54);
                Assert.AreEqual(data.CurrentLife, 47);
                Assert.AreEqual(data.Energy, 86);
                Assert.AreEqual(data.Money, 67);
                Assert.AreEqual(data.Gold, 33);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            PlayerState v = new PlayerState();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.LevelExp = 71;
                v.MaxLifeTime = 38;
                v.CurrentLife = 10;
                v.Energy = 48;
                v.Money = 23;
                v.Gold = 99;
                context.Set<PlayerState>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            PlayerState v1 = new PlayerState();
            PlayerState v2 = new PlayerState();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.LevelExp = 71;
                v1.MaxLifeTime = 38;
                v1.CurrentLife = 10;
                v1.Energy = 48;
                v1.Money = 23;
                v1.Gold = 99;
                v2.LevelExp = 22;
                v2.MaxLifeTime = 54;
                v2.CurrentLife = 47;
                v2.Energy = 86;
                v2.Money = 67;
                v2.Gold = 33;
                context.Set<PlayerState>().Add(v1);
                context.Set<PlayerState>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<PlayerState>().Count(), 0);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}
