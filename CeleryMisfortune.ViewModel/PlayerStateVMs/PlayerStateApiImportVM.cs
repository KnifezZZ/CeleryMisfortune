using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using KnifeZ.CelestialMisfortune.Player;


namespace CeleryMisfortune.ViewModel.PlayerStateVMs
{
    public partial class PlayerStateApiTemplateVM : BaseTemplateVM
    {
        public ExcelPropety FK_PlayerGuId_Excel = ExcelPropety.CreateProperty<PlayerState>(x => x.FK_PlayerGuId);
        [Display(Name = "人物境界")]
        public ExcelPropety StateLevel_Excel = ExcelPropety.CreateProperty<PlayerState>(x => x.StateLevel);
        [Display(Name = "人物经验")]
        public ExcelPropety LevelExp_Excel = ExcelPropety.CreateProperty<PlayerState>(x => x.LevelExp);
        [Display(Name = "寿元")]
        public ExcelPropety LifeRemark_Excel = ExcelPropety.CreateProperty<PlayerState>(x => x.LifeRemark);
        [Display(Name = "最大寿元")]
        public ExcelPropety MaxLifeTime_Excel = ExcelPropety.CreateProperty<PlayerState>(x => x.MaxLifeTime);
        [Display(Name = "当前寿元")]
        public ExcelPropety CurrentLife_Excel = ExcelPropety.CreateProperty<PlayerState>(x => x.CurrentLife);
        [Display(Name = "精力")]
        public ExcelPropety Energy_Excel = ExcelPropety.CreateProperty<PlayerState>(x => x.Energy);
        [Display(Name = "灵石")]
        public ExcelPropety Money_Excel = ExcelPropety.CreateProperty<PlayerState>(x => x.Money);
        [Display(Name = "仙玉")]
        public ExcelPropety Gold_Excel = ExcelPropety.CreateProperty<PlayerState>(x => x.Gold);

	    protected override void InitVM()
        {
        }

    }

    public class PlayerStateApiImportVM : BaseImportVM<PlayerStateApiTemplateVM, PlayerState>
    {

    }

}
