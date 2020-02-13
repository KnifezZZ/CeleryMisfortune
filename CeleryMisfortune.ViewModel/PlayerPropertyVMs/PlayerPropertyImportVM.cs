using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using KnifeZ.CelestialMisfortune.Player;


namespace CeleryMisfortune.ViewModel.PlayerPropertyVMs
{
    public partial class PlayerPropertyTemplateVM : BaseTemplateVM
    {
        [Display(Name = "关联角色")]
        public ExcelPropety FK_PlayerGuId_Excel = ExcelPropety.CreateProperty<PlayerProperty>(x => x.FK_PlayerGuId);
        [Display(Name = "类型")]
        public ExcelPropety TypeId_Excel = ExcelPropety.CreateProperty<PlayerProperty>(x => x.TypeId);
        [Display(Name = "资产名称")]
        public ExcelPropety ItemName_Excel = ExcelPropety.CreateProperty<PlayerProperty>(x => x.ItemName);
        [Display(Name = "当前级别")]
        public ExcelPropety Level_Excel = ExcelPropety.CreateProperty<PlayerProperty>(x => x.Level);
        [Display(Name = "掌握经验")]
        public ExcelPropety Value_Excel = ExcelPropety.CreateProperty<PlayerProperty>(x => x.Value);

	    protected override void InitVM()
        {
        }

    }

    public class PlayerPropertyImportVM : BaseImportVM<PlayerPropertyTemplateVM, PlayerProperty>
    {

    }

}
