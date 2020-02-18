using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WalkingTec.Mvvm.Mvc;
using WalkingTec.Mvvm.Core.Auth.Attribute;
using CeleryMisfortune.ViewModel.PlayerInfoVMs;
using KnifeZ.CelestialMisfortune.Player;
using KnifeZ.GameEngine.Inits;
using KnifeZ.GameEngine;
using KnifeZ.GameEngine.Core;
using KnifeZ.GameEngine.Logic;
using CeleryMisfortune.Model.SystemConfiguration;

namespace CeleryMisfortune.Controllers
{
    
    [AuthorizeJwt]
    [ActionDescription("角色信息")]
    [ApiController]
    [Route("api/PlayerInfo")]
	public partial class PlayerInfoApiController : BaseApiController
    {
        [ActionDescription("搜索")]
        [HttpPost("Search")]
		public string Search(PlayerInfoApiSearcher searcher)
        {
            var vm = CreateVM<PlayerInfoApiListVM>();
            vm.Searcher = searcher;
            return vm.GetJson();
        }

        [ActionDescription("获取")]
        [HttpGet("{id}")]
        public PlayerInfoApiVM Get(string id)
        {
            var vm = CreateVM<PlayerInfoApiVM>(id);
            return vm;
        }


        [ActionDescription("新建")]
        [HttpPost("Add")]
        public IActionResult Add(PlayerInfoApiVM vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorJson());
            }
            else
            {
                vm.DoAdd();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorJson());
                }
                else
                {
                    return Ok(vm.Entity);
                }
            }

        }

        [ActionDescription("修改")]
        [HttpPut("Edit")]
        public IActionResult Edit(PlayerInfoApiVM vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorJson());
            }
            else
            {
                vm.DoEdit(false);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorJson());
                }
                else
                {
                    return Ok(vm.Entity);
                }
            }
        }

		[HttpPost("BatchDelete")]
        [ActionDescription("删除")]
        public IActionResult BatchDelete(string[] ids)
        {
            var vm = CreateVM<PlayerInfoApiBatchVM>();
            if (ids != null && ids.Count() > 0)
            {
                vm.Ids = ids;
            }
            else
            {
                return Ok();
            }
            if (!ModelState.IsValid || !vm.DoBatchDelete())
            {
                return BadRequest(ModelState.GetErrorJson());
            }
            else
            {
                return Ok(ids.Count());
            }
        }


        [ActionDescription("导出")]
        [HttpPost("ExportExcel")]
        public IActionResult ExportExcel(PlayerInfoApiSearcher searcher)
        {
            var vm = CreateVM<PlayerInfoApiListVM>();
            vm.Searcher = searcher;
            vm.SearcherMode = ListVMSearchModeEnum.Export;
            var data = vm.GenerateExcel();
            return File(data, "application/vnd.ms-excel", $"Export_PlayerInfo_{DateTime.Now.ToString("yyyy-MM-dd")}.xls");
        }

        [ActionDescription("勾选导出")]
        [HttpPost("ExportExcelByIds")]
        public IActionResult ExportExcelByIds(string[] ids)
        {
            var vm = CreateVM<PlayerInfoApiListVM>();
            if (ids != null && ids.Count() > 0)
            {
                vm.Ids = new List<string>(ids);
                vm.SearcherMode = ListVMSearchModeEnum.CheckExport;
            }
            var data = vm.GenerateExcel();
            return File(data, "application/vnd.ms-excel", $"Export_PlayerInfo_{DateTime.Now.ToString("yyyy-MM-dd")}.xls");
        }

        [ActionDescription("下载模板")]
        [HttpGet("GetExcelTemplate")]
        public IActionResult GetExcelTemplate()
        {
            var vm = CreateVM<PlayerInfoApiImportVM>();
            var qs = new Dictionary<string, string>();
            foreach (var item in Request.Query.Keys)
            {
                qs.Add(item, Request.Query[item]);
            }
            vm.SetParms(qs);
            var data = vm.GenerateTemplate(out string fileName);
            return File(data, "application/vnd.ms-excel", fileName);
        }

        [ActionDescription("导入")]
        [HttpPost("Import")]
        public ActionResult Import(PlayerInfoApiImportVM vm)
        {

            if (vm.ErrorListVM.EntityList.Count > 0 || !vm.BatchSaveData())
            {
                return BadRequest(vm.GetErrorJson());
            }
            else
            {
                return Ok(vm.EntityList.Count);
            }
        }

        #region 自定义方法

        [ActionDescription("获取角色聚合信息")]
        [HttpGet("GetUnitInfo/{id}")]
        public PlayerInfoApiUnitInfo GetPlayerUnitInfo(string id)
        {

            var vm = CreateVM<PlayerInfoApiVM>(id);

            var re = vm.GetUnitInfoVM(vm.Entity);
            return re;
        }
        [ActionDescription("新建角色")]
        [HttpPost("CreatedNewPlayer")]
        public string CreatedNewPlayer(PlayerInfoCreatedModel model)
        {

            //创建基本信息
            var vm = CreateVM<PlayerInfoApiVM>();
            vm.Entity = new PlayerInfo()
            {
                Name = model.Name,
                NickName = model.NickName,
                IsAlive = true,
                BirthPlace = model.BirthPlace,
                ID= Guid.NewGuid(),
                Sect=0,
                Sex=model.Sex
            };
            string newplayerID = vm.Entity.ID.ToString();
            vm.DoAdd();

            //生成七维属性

            var ps = new PlayerInitialization().InitPlayerSpecial();
            ps.FK_PlayerGuId = newplayerID;
            DC.AddEntity(ps);

            //生成人物核心属性 PlayerAttribute

            //灵根
            DC.AddEntity(new PlayerAttribute()
            {
                AttributeType=(int)EnumAttrbuteType.Core,
                AttrName=PlayerFields.BodySprit,
                AttrValue=model.BodySprit,
                FK_PlayerGuid=newplayerID
            });
            //体魄
            DC.AddEntity(new PlayerAttribute()
            {
                AttributeType = (int)EnumAttrbuteType.Core,
                AttrName = PlayerFields.Defense,
                AttrValue = ps.Endurance * 49,
                FK_PlayerGuid = newplayerID
            });
            //血量
            DC.AddEntity(new PlayerAttribute()
            {
                AttributeType = (int)EnumAttrbuteType.Core,
                AttrName = PlayerFields.Hp,
                AttrValue = (ps.Endurance * 2 + ps.Strength * 3) * 9,
                FK_PlayerGuid = newplayerID
            });
            //神识
            DC.AddEntity(new PlayerAttribute()
            {
                AttributeType = (int)EnumAttrbuteType.Core,
                AttrName = PlayerFields.Mind,
                AttrValue = ps.Perception * 49,
                FK_PlayerGuid = newplayerID
            });
            //真元
            DC.AddEntity(new PlayerAttribute()
            {
                AttributeType = (int)EnumAttrbuteType.Core,
                AttrName = PlayerFields.Mp,
                AttrValue = (ps.Strength * 2 + ps.Perception * 3) * 9,
                FK_PlayerGuid = newplayerID
            });

            //初始化角色状态--境界、经验、寿元、精力、灵石仙玉
            var playerState = new PlayerState()
            {
                StateLevel = SimpleState.Default.GetDescription() + SmallState.Inferior.GetDescription(),
                LevelExp = 0,
                LifeRemark = GlobalConsts.LifeDefaultRemark,
                CurrentLife = 15,
                MaxLifeTime =RandMethod.GetRandNumber(20,80),
                Energy = 100,
                Gold = 0,
                Money =0,
            };
            playerState.FK_PlayerGuId = newplayerID;
            playerState.LifeRemark = PlayerBaseLogic.PlayerLifeRemark(playerState.CurrentLife, playerState.MaxLifeTime);
            //重定义人物宗门、境界 ，可不从练气初期开局--TODO

            DC.AddEntity(playerState);

            //分配人物初始资产 PlayerProperty
            DC.AddEntity(new PlayerProperty()
            {
                FK_PlayerGuId = newplayerID,
                ItemName = "道元真解",
                Level = RandMethod.GetRandNumber(0, 50),
                Value = RandMethod.GetRandNumber(0, 20000),
                TypeId = 1
            });

            //添加新手礼包

            //生成随机词条 --TODO

            //生成特质 --TODO

            DC.SaveChanges();
            //返回角色ID
            return newplayerID;
        }
        #endregion
    }
}
