using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace KnifeZ.CelestialMisfortune.Player
{
    /// <summary>
    /// 玩家核心属性
    /// </summary>
    public class PlayerAttribute : BasePoco
    {

        [Display(Name = "关联角色ID")]
        [StringLength(255)]
        public string FK_PlayerGuid { get; set; }
        [Display(Name = "属性名称")]
        [StringLength(255)]
        public string AttrName { get; set; }
        [Display(Name ="属性值")]
        public int AttrValue { get; set; }
        [Display(Name ="属性类型")]
        public int AttributeType { get; set; }

    }
}
