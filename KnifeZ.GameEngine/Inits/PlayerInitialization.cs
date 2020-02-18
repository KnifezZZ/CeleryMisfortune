using KnifeZ.CelestialMisfortune.Player;
using KnifeZ.GameEngine.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnifeZ.GameEngine.Inits
{
    /// <summary>
    /// 角色初始化
    /// </summary>
    public class PlayerInitialization
    {
        /// <summary>
        /// 初始化角色七维
        /// </summary>
        /// <returns></returns>
        public PlayerSpecial InitPlayerSpecial()
        {
            PlayerSpecial ps = new PlayerSpecial
            {
                Strength = RandMethod.GetRandNumber(),
                Perception = RandMethod.GetRandNumber(),
                Endurance = RandMethod.GetRandNumber(),
                Charisma = RandMethod.GetRandNumber(),
                Intelligence = RandMethod.GetRandNumber(),
                Agility = RandMethod.GetRandNumber(),
                Luck = RandMethod.GetRandNumber()
            };
            return ps;
        }
       

    }
}
