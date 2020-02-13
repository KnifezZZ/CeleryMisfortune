using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "人物境界")]
        [StringLength(255)]
        public string StateLevel { get; set; }

        [Display(Name = "人物经验")]
        public int LevelExp { get; set; }

        [Display(Name = "寿元")]
        [StringLength(255)]
        public string LifeRemark { get; set; }

        [Display(Name = "最大寿元")]
        public int MaxLifeTime { get; set; }

        [Display(Name = "当前寿元")]
        public int CurrentLife { get; set; }

        [Display(Name = "精力")]
        public int Energy { get; set; }


        [Display(Name = "灵石")]
        public int Money { get; set; }
        [Display(Name = "仙玉")]
        public int Gold { get; set; }
    }
}
