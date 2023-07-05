using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFC_Test_Sys_K10.scripts
{
    public class AM357150455 : domain.Dalay, domain.IBaseScripts
    {
        public Hashtable startTest(Hashtable ht)
        {
            #region 变量初始化，无需关注
            Hashtable htTestResult = new Hashtable();

            domain.EC ec = null;
            utils.NFCHelper nfcHelper = utils.NFCHelper.getInstance();
            #endregion

            #region 以下代码需要根据需求进行修改（即测试流程）
            /*
             * 编写流程：
             * 1.判断failedCount是否>0
             * 2.通过EC号获取EC，utils.ECHelper.GetEC
             * 3.NFC动作并延时
             * 4.给EC.Value赋值
             * 5.调utils.ECHelper.isPass方法
             */
            nfcHelper.OpenReaderAndReadTheTAG();
            delay(500);

            if (utils.ECHelper.getFailedCount(htTestResult) == -1)
            {
                //7030  输入电压（不测，未上电直接赋值）
                ec = utils.ECHelper.GetEC(ht, "7030");
                ec.Value = 0;

                utils.ECHelper.isPass(ec, htTestResult);
            }

            if (utils.ECHelper.getFailedCount(htTestResult) == -1)
            {
                //7040
                ec = utils.ECHelper.GetEC(ht, "7040");
                bool tempResult = nfcHelper.CheckTOCConsistency();
                delay(50);
                ec.Value = tempResult ? -1 : -2;

                utils.ECHelper.isPass(ec, htTestResult);
            }

            //7050
            if (utils.ECHelper.getFailedCount(htTestResult) == -1)
            {
                ec = utils.ECHelper.GetEC(ht, "7050");
                int tempResult = nfcHelper.GTINTest();
                delay(50);
                ec.Value = tempResult;

                utils.ECHelper.isPass(ec, htTestResult);
            }

            if (utils.ECHelper.getFailedCount(htTestResult) == -1)
            {
                ec = utils.ECHelper.GetEC(ht, "7060");
                int tempResult = nfcHelper.SetPassword(1);
                delay(50);
                ec.Value = tempResult;

                utils.ECHelper.isPass(ec, htTestResult);
            }

            //7090
            if (utils.ECHelper.getFailedCount(htTestResult) == -1)
            {
                ec = utils.ECHelper.GetEC(ht, "7090");
                bool tempResult = nfcHelper.CheckAndResetStatusRegister();
                delay(50);
                ec.Value = tempResult ? 1 : 0;

                utils.ECHelper.isPass(ec, htTestResult);
            }

            nfcHelper.CloseReader();

            return htTestResult;
            #endregion
        }
    }
}
