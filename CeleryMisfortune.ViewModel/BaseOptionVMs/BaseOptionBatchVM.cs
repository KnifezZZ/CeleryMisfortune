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
    public partial class BaseOptionBatchVM : BaseBatchVM<BaseOption, BaseOption_BatchEdit>
    {
        public BaseOptionBatchVM()
        {
            ListVM = new BaseOptionListVM();
            LinkedVM = new BaseOption_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class BaseOption_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
