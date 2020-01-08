using System;
using System.Collections.Generic;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace KnifeZ.CelestialMisfortune.Player
{
    /// <summary>
    /// 人物状态
    /// </summary>
    public class PlayerState : BasePoco
    {
        /// <summary>
        /// 关联角色ID
        /// </summary>
        public string FK_PlayerGuId { get; set; }
    }
}
