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
        public Int32? FK_PlayerGuId { get; set; }
        public Int32? Strength { get; set; }
        public Int32? Perception { get; set; }
        public Int32? Endurance { get; set; }
        public Int32? Charisma { get; set; }
        public Int32? Intelligence { get; set; }
        public Int32? Luck { get; set; }

        protected override void InitVM()
        {
        }

    }
}
