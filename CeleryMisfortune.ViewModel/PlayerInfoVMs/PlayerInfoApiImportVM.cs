using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using KnifeZ.CelestialMisfortune.Player;


namespace CeleryMisfortune.ViewModel.PlayerInfoVMs
{
    public partial class PlayerInfoApiTemplateVM : BaseTemplateVM
    {
        [Display(Name = "姓名")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<PlayerInfo>(x => x.Name);
        [Display(Name = "名号")]
        public ExcelPropety NickName_Excel = ExcelPropety.CreateProperty<PlayerInfo>(x => x.NickName);
        [Display(Name = "出身")]
        public ExcelPropety BirthPlace_Excel = ExcelPropety.CreateProperty<PlayerInfo>(x => x.BirthPlace);
        [Display(Name = "性别")]
        public ExcelPropety Sex_Excel = ExcelPropety.CreateProperty<PlayerInfo>(x => x.Sex);
        [Display(Name = "门派")]
        public ExcelPropety Sect_Excel = ExcelPropety.CreateProperty<PlayerInfo>(x => x.Sect);
        [Display(Name = "是否陨落")]
        public ExcelPropety IsAlive_Excel = ExcelPropety.CreateProperty<PlayerInfo>(x => x.IsAlive);

	    protected override void InitVM()
        {
        }

    }

    public class PlayerInfoApiImportVM : BaseImportVM<PlayerInfoApiTemplateVM, PlayerInfo>
    {

    }

}
