using System.Collections;

namespace NFC_Test_Sys_K10.scripts
{
    /*
     * 测试脚本类，必须继承domain.Delay
     * 并实现interface domain.IBaseScripts，实现startTest方法
     */
    public class AM357140255 : domain.Dalay, domain.IBaseScripts
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
                //7030  输入电压（不测，直接赋值230V）
                ec = utils.ECHelper.GetEC(ht, "7030");
                ec.Value = 230;

                utils.ECHelper.isPass(ec, htTestResult);
            }

            if (utils.ECHelper.getFailedCount(htTestResult) == -1)
            {
                //7040
                ec = utils.ECHelper.GetEC(ht, "7040");
                bool tempResult = nfcHelper.CheckAndResetStatusRegister();
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

            //7060
            if (utils.ECHelper.getFailedCount(htTestResult) == -1)
            {
                ec = utils.ECHelper.GetEC(ht, "7060");
                int tempResult = nfcHelper.SetPassword(1);
                delay(50);
                ec.Value = tempResult;

                utils.ECHelper.isPass(ec, htTestResult);
            }

            nfcHelper.CloseReader();

            return htTestResult;
            #endregion
        }

    }
}
