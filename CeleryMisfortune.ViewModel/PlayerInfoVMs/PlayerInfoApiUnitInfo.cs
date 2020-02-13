using KnifeZ.CelestialMisfortune.Player;
using System;
using System.Collections.Generic;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace CeleryMisfortune.ViewModel.PlayerInfoVMs
{
    public class PlayerInfoApiUnitInfo
    {
        /// <summary>
        /// 角色信息
        /// </summary>
        public PlayerInfo Infos { get; set; }

        public PlayerSpecial Special { get; set; }

        public List<PlayerAttribute> Attributes { get; set; }

        public PlayerState State { get; set; }
    }
}
