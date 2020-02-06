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
    public partial class PlayerSpecialApiSearcher : BaseSearcher
    {
        [Display(Name = "关联角色")]
        public String FK_PlayerGuId { get; set; }
        [Display(Name = "根骨")]
        public Int32? Strength { get; set; }
        [Display(Name = "精神")]
        public Int32? Perception { get; set; }
        [Display(Name = "体魄")]
        public Int32? Endurance { get; set; }
        [Display(Name = "魅力")]
        public Int32? Charisma { get; set; }
        [Display(Name = "悟性")]
        public Int32? Intelligence { get; set; }
        [Display(Name = "敏捷")]
        public Int32? Agility { get; set; }
        [Display(Name = "福源")]
        public Int32? Luck { get; set; }

        protected override void InitVM()
        {
        }

    }
}
