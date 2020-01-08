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
        public ExcelPropety FK_PlayerGuId_Excel = ExcelPropety.CreateProperty<PlayerSpecial>(x => x.FK_PlayerGuId);
        public ExcelPropety Strength_Excel = ExcelPropety.CreateProperty<PlayerSpecial>(x => x.Strength);
        public ExcelPropety Perception_Excel = ExcelPropety.CreateProperty<PlayerSpecial>(x => x.Perception);
        public ExcelPropety Endurance_Excel = ExcelPropety.CreateProperty<PlayerSpecial>(x => x.Endurance);
        public ExcelPropety Charisma_Excel = ExcelPropety.CreateProperty<PlayerSpecial>(x => x.Charisma);
        public ExcelPropety Intelligence_Excel = ExcelPropety.CreateProperty<PlayerSpecial>(x => x.Intelligence);
        public ExcelPropety Luck_Excel = ExcelPropety.CreateProperty<PlayerSpecial>(x => x.Luck);

	    protected override void InitVM()
        {
        }

    }

    public class PlayerSpecialApiImportVM : BaseImportVM<PlayerSpecialApiTemplateVM, PlayerSpecial>
    {

    }

}
