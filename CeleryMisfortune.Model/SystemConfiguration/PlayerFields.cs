using System;
using System.Collections.Generic;
using System.Text;

namespace CeleryMisfortune.Model.SystemConfiguration
{
    public class PlayerFields
    {
        #region PlayerAttribute -- 玩家属性

        /// <summary>
        /// 血量决定人物承伤大小
        /// </summary>
        public const string Hp = "血量";
        /// <summary>
        /// 防御属性决定人物受伤害的比例
        /// </summary>
        public const string Defense = "防御";
        /// <summary>
        /// 灵根决定敌我攻击属性克制关系从而影响伤害大小，也决定着人物修炼术法的效率
        /// </summary>
        public const string BodySprit = "灵根";

        /// <summary>
        /// 真元决定人物释放法术的数量和强度
        /// </summary>
        public const string Mp = "真元";

        /// <summary>
        /// 神识大小决定人物使用法宝的数量和上限
        /// </summary>
        public const string Mind = "神识";

        /// <summary>
        /// 当前加入门派名称
        /// </summary>

        public const string SectName = "宗门";


        #endregion

        #region PlayerProperty -- 玩家资产（洞府，资源）


        #endregion
    }
}
