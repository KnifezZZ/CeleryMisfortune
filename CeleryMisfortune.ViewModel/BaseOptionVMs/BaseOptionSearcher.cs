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
    public partial class BaseOptionSearcher : BaseSearcher
    {
        [Display(Name = "父类编码")]
        public Int32? PID { get; set; }
        [Display(Name = "基类名称")]
        public String Text { get; set; }

        protected override void InitVM()
        {
        }

    }
}
