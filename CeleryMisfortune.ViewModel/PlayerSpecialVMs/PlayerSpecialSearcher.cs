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
    public partial class PlayerSpecialSearcher : BaseSearcher
    {
        [Display(Name = "关联角色")]
        public String FK_PlayerGuId { get; set; }
        [Display(Name = "根骨")]
        public Int32? Strength { get; set; }

        protected override void InitVM()
        {
        }

    }
}
