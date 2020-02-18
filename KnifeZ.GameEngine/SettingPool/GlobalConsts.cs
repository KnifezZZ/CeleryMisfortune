using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace KnifeZ.GameEngine
{
    public class GlobalConsts
    {
        #region 寿命
        /// <summary>
        /// 基础寿命
        /// </summary>
        public const long DefaultLife = 99;
        //大境界增幅
        public const long SuperiorLife = 30;
        //渡劫增加寿命（3，6，9雷劫）
        public const long DuJieLife = 200;

        // LifeRemark
        public const string LifeLess5 = "人命危浅";
        public const string LifeLess20 = "天不假年";
        public const string LifeOver1000 = "椿龄无尽";
        public const string LifeHurt = "修短有命";
        public const string LifeDefaultRemark = "福寿天成";
        // LifeRemark END
        #endregion


    }

    public enum EnumAttrbuteType
    {
        [Description("核心属性")]
        Core = 1,
        [Description("战斗属性")]
        Fight = 2,
        [Description("成就属性")]
        Achievement = 3,
        [Description("逻辑属性")]
        Logic = 4,
    }

    #region 状态
    public enum Status
    {
        [Description("心魔肆虐")]
        Devil = -99,
        [Description("重伤")]
        HeavyHurt = -10,
        [Description("心动")]
        HeartXx = -3,
        [Description("正常")]
        Common = 1,
        [Description("灵光一闪")]
        Smart = 3,
        [Description("醍醐灌顶")]
        PoolQi = 5,
        [Description("悟道")]
        Inspiration = 10,
    }
    #endregion

    #region 境界
    /// <summary>
    /// 小境界划分
    /// </summary>
    public enum SmallState
    {
        [Description("一层")]
        Inferior = 1,
        [Description("二层")]
        Inferior2 = 2,
        [Description("三层")]
        Inferior3 = 3,
        [Description("四层")]
        Medium = 4,
        [Description("五层")]
        Medium2 = 5,
        [Description("六层")]
        Medium3 = 6,
        [Description("七层")]
        Superior = 7,
        [Description("八层")]
        Superior2 = 8,
        [Description("九层")]
        Superior3 = 9,
        [Description("大圆满")]
        Dzogchen = 10
    }
    /// <summary>
    /// 境界划分
    /// </summary>
    public enum SimpleState
    {
        [Description("锻体境")]
        Default = 80,
        [Description("练气期")]
        LianQi = 180,
        [Description("筑基期")]
        ZhuJi = 300,
        [Description("金丹期")]
        JinDan = 500,
        [Description("元婴期")]
        YuanYing = 800,
        [Description("化神期")]
        HuaShen = 1300,
        [Description("练虚期")]
        LianXu = 1800,
        [Description("合体期")]
        HeTi = 2600,
        [Description("大乘期")]
        DaSheng = 4000,
        [Description("渡劫期")]
        Superior3 = 7500,
        [Description("飞升期")]
        DuJie = 9999,



        [Description("玄仙")]
        Xarm = 10000,
        [Description("金仙")]
        JinXarm = 20000,
        [Description("太乙")]
        TailYi = 30000,
        [Description("大罗")]
        DaLuo = 40000,
        [Description("真君")]
        ZhenJun = 50000,
        [Description("道主")]
        DaoMaster = 99999,
    }
    /// <summary>
    /// 仙人境界
    /// </summary>
    public enum XarmState
    {
        [Description("玄仙")]
        Default = 10,
        [Description("金仙")]
        JinXarm = 20,
        [Description("太乙")]
        TailYi = 30,
        [Description("大罗")]
        DaLuo = 40,
        [Description("真君")]
        ZhenJun = 50,
        [Description("道主")]
        DaoMaster = 99,
    }
    #endregion

    #region 宗门职务
    /// <summary>
    /// 宗门职务
    /// </summary>
    public enum SectPosition
    {

        [Description("        ")]
        UnKnow,
        [Description("记名弟子")]
        Follower1,
        [Description("正式弟子")]
        Follower2,
        [Description("内门弟子")]
        Follower3,
        [Description("亲传弟子")]
        Follower4,
        [Description("执    事")]
        Follower5,
        [Description("客卿长老")]
        Follower6,
        [Description("大长老")]
        Follower7,
        [Description("峰    主")]
        Follower8,
        [Description("掌    门")]
        Follower9,
        [Description("宗门老祖")]
        Tensen,
    }

    #endregion
}
