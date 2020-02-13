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
    public partial class PlayerInfoApiSearcher : BaseSearcher
    {
        [Display(Name = "姓名")]
        public String Name { get; set; }
        [Display(Name = "名号")]
        public String NickName { get; set; }
        [Display(Name = "出身")]
        public String BirthPlace { get; set; }
        [Display(Name = "性别")]
        public Int32? Sex { get; set; }
        [Display(Name = "门派")]
        public Int32? Sect { get; set; }
        [Display(Name = "是否陨落")]
        public Boolean? IsAlive { get; set; }

        protected override void InitVM()
        {
        }

    }
}
