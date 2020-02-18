using KnifeZ.CelestialMisfortune.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace CeleryMisfortune.ViewModel.PlayerInfoVMs
{
    public class PlayerInfoCreatedModel : PlayerInfo
    {
        /// <summary>
        /// 灵根
        /// </summary>
        public int BodySprit { get; set; }
        /// <summary>
        /// 经历特质
        /// </summary>
        public string Trait { get; set; }
        /// <summary>
        /// 种族
        /// </summary>
        public string Race { get; set; }
    }
}
