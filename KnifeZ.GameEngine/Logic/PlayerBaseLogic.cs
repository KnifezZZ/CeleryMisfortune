using System;
using System.Collections.Generic;
using System.Text;

namespace KnifeZ.GameEngine.Logic
{
    public class PlayerBaseLogic
    {
        /// <summary>
        /// 寿元描述
        /// </summary>
        /// <param name="currentLife"></param>
        /// <param name="maxLife"></param>
        /// <returns></returns>
        public static string PlayerLifeRemark(int currentLife, int maxLife)
        {
            int re = maxLife - currentLife;
            if (re <= 0)
            {
                //设置人物陨落 --TODO
                return "寿元耗尽";
            }
            if (re < 5)
            {
                return GlobalConsts.LifeLess5;
            }
            if (re < 20)
            {
                return GlobalConsts.LifeLess20;
            }
            if (re > 1000)
            {
                return GlobalConsts.LifeOver1000;
            }
            return GlobalConsts.LifeDefaultRemark;
        }
    }
}
