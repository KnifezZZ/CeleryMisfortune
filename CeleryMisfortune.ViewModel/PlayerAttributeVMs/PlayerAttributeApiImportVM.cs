using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using KnifeZ.CelestialMisfortune.Player;


namespace CeleryMisfortune.ViewModel.PlayerAttributeVMs
{
    public partial class PlayerAttributeApiTemplateVM : BaseTemplateVM
    {
        [Display(Name = "关联角色ID")]
        public ExcelPropety FK_PlayerGuid_Excel = ExcelPropety.CreateProperty<PlayerAttribute>(x => x.FK_PlayerGuid);
        [Display(Name = "属性名称")]
        public ExcelPropety AttrName_Excel = ExcelPropety.CreateProperty<PlayerAttribute>(x => x.AttrName);
        [Display(Name = "属性值")]
        public ExcelPropety AttrValue_Excel = ExcelPropety.CreateProperty<PlayerAttribute>(x => x.AttrValue);
        [Display(Name = "属性类型")]
        public ExcelPropety AttributeType_Excel = ExcelPropety.CreateProperty<PlayerAttribute>(x => x.AttributeType);

	    protected override void InitVM()
        {
        }

    }

    public class PlayerAttributeApiImportVM : BaseImportVM<PlayerAttributeApiTemplateVM, PlayerAttribute>
    {

    }

}
