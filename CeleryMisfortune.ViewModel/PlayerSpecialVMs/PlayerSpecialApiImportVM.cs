using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using KnifeZ.CelestialMisfortune.Player;


namespace CeleryMisfortune.ViewModel.PlayerSpecialVMs
{
    public partial class PlayerSpecialApiTemplateVM : BaseTemplateVM
    {
        [Display(Name = "关联角色")]
        public ExcelPropety FK_PlayerGuId_Excel = ExcelPropety.CreateProperty<PlayerSpecial>(x => x.FK_PlayerGuId);
        [Display(Name = "根骨")]
        public ExcelPropety Strength_Excel = ExcelPropety.CreateProperty<PlayerSpecial>(x => x.Strength);
        [Display(Name = "精神")]
        public ExcelPropety Perception_Excel = ExcelPropety.CreateProperty<PlayerSpecial>(x => x.Perception);
        [Display(Name = "体魄")]
        public ExcelPropety Endurance_Excel = ExcelPropety.CreateProperty<PlayerSpecial>(x => x.Endurance);
        [Display(Name = "魅力")]
        public ExcelPropety Charisma_Excel = ExcelPropety.CreateProperty<PlayerSpecial>(x => x.Charisma);
        [Display(Name = "悟性")]
        public ExcelPropety Intelligence_Excel = ExcelPropety.CreateProperty<PlayerSpecial>(x => x.Intelligence);
        [Display(Name = "敏捷")]
        public ExcelPropety Agility_Excel = ExcelPropety.CreateProperty<PlayerSpecial>(x => x.Agility);
        [Display(Name = "福源")]
        public ExcelPropety Luck_Excel = ExcelPropety.CreateProperty<PlayerSpecial>(x => x.Luck);

	    protected override void InitVM()
        {
        }

    }

    public class PlayerSpecialApiImportVM : BaseImportVM<PlayerSpecialApiTemplateVM, PlayerSpecial>
    {

    }

}
