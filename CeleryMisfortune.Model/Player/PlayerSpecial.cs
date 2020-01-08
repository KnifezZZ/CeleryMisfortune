
using WalkingTec.Mvvm.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace KnifeZ.CelestialMisfortune.Player
{
    /// <summary>
    /// 人物特质
    /// 参照辐射 SPECIAL
    /// S-P-E-C-I-A-L:Strength, Perception, Endurance, Charisma, Intelligence, Agility, and Luck.
    /// S:Strength 力量, 关系到你能携带物品的数量, 和近身攻击的效果
    /// P:Perception 洞察力, 关系到你能看到多远的敌人, 以及每电P增加2点能量武器, 爆破开锁技能
    /// E:Endurance 关系到你的生命值, 每点E加2点大枪, 和徒手攻击
    /// C:Charisma,关系到说服的成功率,每点C加2点交易和演说
    /// I:Intelligence,关系到每升一级奖励的技能点,并且每点I加2点医药,修理和科学
    /// A:Agility,敏捷.每升一点A,加两点AP值,小枪和潜行
    /// L:Luck.每升一点L加1%的致命攻击可能性,每两点L加所有技能一点
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
        /// 幸运，福源
        /// </summary>
        [Display(Name = "福源")]
        public int Luck { get; set; }
    }
}
