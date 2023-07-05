using System;
using System.Collections;

namespace NFC_Test_Sys_K10.utils
{
    public class ECHelper
    {
        /// <summary>
        /// 通过ecCode获取EC
        /// </summary>
        /// <param name="ht"></param>
        /// <param name="ecCode"></param>
        /// <returns></returns>
        public static domain.EC GetEC(Hashtable ht, String ecCode) {
            foreach (DictionaryEntry entry in ht) {
                if (entry.Key.ToString().Equals(ecCode))
                    return (domain.EC)entry.Value;
            }
            return null;
        }


        /// <summary>
        /// 更新lvDisplay，并保存fail的信息
        /// </summary>
        /// <param name="ec"></param>
        /// <param name="htTestResult"></param>
        /// <param name="failedCount"></param>
        /// <param name="failedEC"></param>
        /// <returns></returns>
        public static Hashtable isPass(domain.EC ec, Hashtable htTestResult)
        {
            if (ec.Value >= ec.LLimit && ec.Value <= ec.ULimit)
            {
                ec.Result = true;
                MainForm.mainForm.lvUpdate(ec);
            }
            else {
                ec.Result = false;
                MainForm.mainForm.lvUpdate(ec);

                String failedEC = ec.EcCode.ToString();
                htTestResult.Add("failedCount", 1);
                htTestResult.Add("failedEC", failedEC);
            }
            htTestResult.Add(ec.EcCode, ec);

            return htTestResult;
        }

        /// <summary>
        /// 若存在该key则返回failedCount，若不存在则返回-1
        /// </summary>
        /// <param name="htTestResult"></param>
        /// <returns></returns>
        public static int getFailedCount(Hashtable htTestResult) {
            foreach (DictionaryEntry entry in htTestResult)
            {
                if (entry.Key.ToString().Equals("failedCount"))
                    return (int)entry.Value;
            }
            return -1;
        }

        public static String getFailedECCode(Hashtable htTestResult)
        {
            foreach (DictionaryEntry entry in htTestResult)
            {
                if (entry.Key.ToString().Equals("failedEC"))
                    return (String)entry.Value;
            }
            return String.Empty;
        }
    }
}
