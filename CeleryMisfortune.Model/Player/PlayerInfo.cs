using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace KnifeZ.CelestialMisfortune.Player
{
    /// <summary>
    /// 人物基本信息
    /// </summary>
    public class PlayerInfo : BasePoco
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名")]
        [StringLength(255)]
        public string Name { get; set; }
        /// <summary>
        /// 江湖名号
        /// </summary>
        [Display(Name = "名号")]
        [StringLength(255)]
        public string NickName { get; set; }
        /// <summary>
        /// 出生地
        /// </summary>
        [Display(Name = "出身")]
        [StringLength(100)]
        public string BirthPlace { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [Display(Name = "性别")]
        public int Sex { get; set; }

        /// <summary>
        /// 门派
        /// </summary>
        [Display(Name = "门派")]
        public int Sect { get; set; }

        [Display(Name = "是否陨落")]
        public bool IsAlive { get; set; }

    }
}
