using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace KnifeZ.CelestialMisfortune.Player
{
    /// <summary>
    /// 玩家资产
    /// 如 剑术 99级 经验 2345
    /// 如 厨艺 50级
    /// </summary>
    public class PlayerProperty : BasePoco
    {
        [Display(Name = "关联角色")]
        public string FK_PlayerGuId { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int TypeId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 级别
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// 数值
        /// </summary>

        public int Value { get; set; }

    }
}
