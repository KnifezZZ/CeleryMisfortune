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
    public partial class PlayerInfoTemplateVM : BaseTemplateVM
    {
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<PlayerInfo>(x => x.Name);
        public ExcelPropety NickName_Excel = ExcelPropety.CreateProperty<PlayerInfo>(x => x.NickName);
        public ExcelPropety BirthPlace_Excel = ExcelPropety.CreateProperty<PlayerInfo>(x => x.BirthPlace);
        public ExcelPropety Sex_Excel = ExcelPropety.CreateProperty<PlayerInfo>(x => x.Sex);
        public ExcelPropety Sect_Excel = ExcelPropety.CreateProperty<PlayerInfo>(x => x.Sect);

	    protected override void InitVM()
        {
        }

    }

    public class PlayerInfoImportVM : BaseImportVM<PlayerInfoTemplateVM, PlayerInfo>
    {

    }

}
