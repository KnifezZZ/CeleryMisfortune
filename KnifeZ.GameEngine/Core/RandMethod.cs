using System;
using System.Collections.Generic;
using System.Text;

namespace KnifeZ.GameEngine.Core
{
    public class RandMethod
    {
        /// <summary>
        /// 获取指定范围随机数
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static int GetRandNumber(int start=0,int end=10)
        {
            return new Random().Next(start, end);
        }
    }
}
