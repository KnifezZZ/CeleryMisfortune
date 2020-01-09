using System;
using System.Collections.Generic;
using System.Text;

namespace KnifeZ.SignalRKit
{
    public class SimpleUserPool
    {

        private static List<KeyValuePair<string, string>> instance = new List<KeyValuePair<string, string>>();

        private static readonly object LockHelper = new object();
        /// <summary>
        /// 队列
        /// </summary>
        public static List<KeyValuePair<string, string>> Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (LockHelper)
                    {
                        if (instance == null)
                        {
                            instance = new List<KeyValuePair<string, string>>();
                        }
                    }
                }

                return instance;
            }
        }
    }
}
