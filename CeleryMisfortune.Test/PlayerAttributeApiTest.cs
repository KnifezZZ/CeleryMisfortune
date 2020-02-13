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
    public class PlayerAttributeApiTest
    {
        private PlayerAttributeApiController _controller;
        private string _seed;

        public PlayerAttributeApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<PlayerAttributeApiController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            string rv = _controller.Search(new PlayerAttributeApiSearcher());
            Assert.IsTrue(string.IsNullOrEmpty(rv)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            PlayerAttributeApiVM vm = _controller.CreateVM<PlayerAttributeApiVM>();
            PlayerAttribute v = new PlayerAttribute();
            
            v.AttrValue = 18;
            v.AttributeType = 74;
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PlayerAttribute>().FirstOrDefault();
                
                Assert.AreEqual(data.AttrValue, 18);
                Assert.AreEqual(data.AttributeType, 74);
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
       			
                v.AttrValue = 18;
                v.AttributeType = 74;
                context.Set<PlayerAttribute>().Add(v);
                context.SaveChanges();
            }

            PlayerAttributeApiVM vm = _controller.CreateVM<PlayerAttributeApiVM>();
            var oldID = v.ID;
            v = new PlayerAttribute();
            v.ID = oldID;
       		
            v.AttrValue = 45;
            v.AttributeType = 56;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.AttrValue", "");
            vm.FC.Add("Entity.AttributeType", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<PlayerAttribute>().FirstOrDefault();
 				
                Assert.AreEqual(data.AttrValue, 45);
                Assert.AreEqual(data.AttributeType, 56);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            PlayerAttribute v = new PlayerAttribute();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.AttrValue = 18;
                v.AttributeType = 74;
                context.Set<PlayerAttribute>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            PlayerAttribute v1 = new PlayerAttribute();
            PlayerAttribute v2 = new PlayerAttribute();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.AttrValue = 18;
                v1.AttributeType = 74;
                v2.AttrValue = 45;
                v2.AttributeType = 56;
                context.Set<PlayerAttribute>().Add(v1);
                context.Set<PlayerAttribute>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<PlayerAttribute>().Count(), 0);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}
