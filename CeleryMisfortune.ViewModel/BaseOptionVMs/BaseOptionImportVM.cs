using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using CeleryMisfortune.Model.Base;


namespace CeleryMisfortune.ViewModel.BaseOptionVMs
{
    public partial class BaseOptionTemplateVM : BaseTemplateVM
    {
        [Display(Name = "父类编码")]
        public ExcelPropety PID_Excel = ExcelPropety.CreateProperty<BaseOption>(x => x.PID);
        [Display(Name = "基类名称")]
        public ExcelPropety Text_Excel = ExcelPropety.CreateProperty<BaseOption>(x => x.Text);

	    protected override void InitVM()
        {
        }

    }

    public class BaseOptionImportVM : BaseImportVM<BaseOptionTemplateVM, BaseOption>
    {

    }

}
