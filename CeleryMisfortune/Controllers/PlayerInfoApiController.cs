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

        [ActionDescription("获取角色聚合信息")]
        [HttpGet("GetUnitInfo/{id}")]
        public PlayerInfoApiUnitInfo GetPlayerUnitInfo(string id)
        {

            var vm = CreateVM<PlayerInfoApiVM>(id);
            
            var re= vm.GetUnitInfoVM(vm.Entity);
            return re;
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


    }
}
