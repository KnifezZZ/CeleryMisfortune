using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using KnifeZ.CelestialMisfortune.Player;


namespace CeleryMisfortune.ViewModel.PlayerStateVMs
{
    public partial class PlayerStateApiSearcher : BaseSearcher
    {
        public String FK_PlayerGuId { get; set; }
        [Display(Name = "人物经验")]
        public Int32? LevelExp { get; set; }
        [Display(Name = "仙玉")]
        public Int32? Gold { get; set; }

        protected override void InitVM()
        {
        }

    }
}
