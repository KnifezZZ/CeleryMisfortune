
using WalkingTec.Mvvm.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace KnifeZ.CelestialMisfortune.Player
{
    /// <summary>
    /// 人物特质 参照辐射 SPECIAL
    /// </summary>
    public class PlayerSpecial : BasePoco
    {
        /// <summary>
        /// 关联角色
        /// </summary>
        [Display(Name = "关联角色")]
        public string FK_PlayerGuId { get; set; }
        /// <summary>
        /// 力量,根骨
        /// </summary>
        [Display(Name = "根骨")]
        public int Strength { get; set; }
        /// <summary>
        /// 洞察力，精神
        /// </summary>
        [Display(Name = "精神")]
        public int Perception { get; set; }
        /// <summary>
        /// 耐力，体魄
        /// </summary>
        [Display(Name = "体魄")]
        public int Endurance { get; set; }
        /// <summary>
        /// 魅力
        /// </summary>
        [Display(Name = "魅力")]
        public int Charisma { get; set; }
        /// <summary>
        /// 智力、悟性
        /// </summary>
        [Display(Name = "悟性")]
        public int Intelligence { get; set; }
        /// <summary>
        /// 敏捷
        /// </summary>
        [Display(Name = "敏捷")]
        public int Agility { get; set; }
        /// <summary>
        /// 幸运，福源
        /// </summary>
        [Display(Name = "福源")]
        public int Luck { get; set; }
    }
}
