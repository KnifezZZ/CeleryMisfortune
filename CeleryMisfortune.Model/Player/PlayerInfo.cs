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
        [StringLength(255)]
        public string Name { get; set; }
        /// <summary>
        /// 江湖名号
        /// </summary>
        [StringLength(255)]
        public string NickName { get; set; }
        /// <summary>
        /// 出生地
        /// </summary>
        [StringLength(100)]
        public string BirthPlace { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 门派
        /// </summary>
        public int Sect { get; set; }

    }
}
