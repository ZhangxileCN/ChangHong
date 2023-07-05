using System.Threading;

namespace NFC_Test_Sys_K10.domain
{
    public class Dalay {
        /// <summary>
        /// 延时  ms
        /// </summary>
        /// <param name="ms"></param>
        public void delay(int ms)
        {
            Thread.Sleep(ms);
        }
    }
}
