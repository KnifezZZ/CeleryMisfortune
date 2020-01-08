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
    public class PlayerInfoApiTest
    {
        private PlayerInfoApiController _controller;
        private string _seed;

        public PlayerInfoApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<PlayerInfoApiController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            string rv = _controller.Search(new PlayerInfoApiSearcher());
            Assert.IsTrue(string.IsNullOrEmpty(rv)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            PlayerInfoApiVM vm = _controller.CreateVM<PlayerInfoApiVM>();
            PlayerInfo v = new PlayerInfo();
            
            v.Sex = 24;
            v.Sect = 89;
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PlayerInfo>().FirstOrDefault();
                
                Assert.AreEqual(data.Sex, 24);
                Assert.AreEqual(data.Sect, 89);
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
       			
                v.Sex = 24;
                v.Sect = 89;
                context.Set<PlayerInfo>().Add(v);
                context.SaveChanges();
            }

            PlayerInfoApiVM vm = _controller.CreateVM<PlayerInfoApiVM>();
            var oldID = v.ID;
            v = new PlayerInfo();
            v.ID = oldID;
       		
            v.Sex = 47;
            v.Sect = 40;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Sex", "");
            vm.FC.Add("Entity.Sect", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PlayerInfo>().FirstOrDefault();
 				
                Assert.AreEqual(data.Sex, 47);
                Assert.AreEqual(data.Sect, 40);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            PlayerInfo v = new PlayerInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Sex = 24;
                v.Sect = 89;
                context.Set<PlayerInfo>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            PlayerInfo v1 = new PlayerInfo();
            PlayerInfo v2 = new PlayerInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Sex = 24;
                v1.Sect = 89;
                v2.Sex = 47;
                v2.Sect = 40;
                context.Set<PlayerInfo>().Add(v1);
                context.Set<PlayerInfo>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<PlayerInfo>().Count(), 0);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}
