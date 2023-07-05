using System;
using OSRAM;
using System.Reflection;

namespace NFC_Test_Sys_K10.utils
{
    /// <summary>
    /// NFC工具类
    /// 工具类中的所有方法均已做了异常处理，调用时不处理异常，方便查看异常
    /// </summary>
    public class NFCHelper
    {

        public static NFCHelper helper = null;
        private static OSRAM_OBID_NCF2 nfc = null;

        public byte[] GTIN = new byte[6];
        byte[] SR = new byte[4] { 0x00, 0x00, 0x1D, 0x0F };

        private NFCHelper() { }

        //NFCHelper单例
        public static NFCHelper getInstance() {
            if (helper == null) {
                helper = new NFCHelper();
                try
                {
                    nfc = new OSRAM_OBID_NCF2();
                }
                catch (Exception ex) {
                    throw new NFCException(String.Format("执行{0}时产生异常：{1}", MethodBase.GetCurrentMethod().Name, ex.Message), ex.StackTrace);
                }
            }

            return helper;
        }

        public void InitGIN(byte[] ArrayGTIN)
        {
            GTIN = ArrayGTIN;
        }

        public bool OpenReaderAndReadTheTAG()
        {
            try
            {
                return nfc.OpenReaderAndReadTheTAG(nfc.ReaderList[0].DeviceId);
            }
            catch (Exception ex)
            {
                throw new NFCException(String.Format("执行{0}时产生异常：{1}", MethodBase.GetCurrentMethod().Name, ex.Message), ex.StackTrace);
            }
        }

        public bool CheckTOCConsistency()
        {
            try
            {
                return nfc.CheckTOCConsistency();
            }
            catch (Exception ex)
            {
                throw new NFCException(String.Format("执行{0}时产生异常：{1}", MethodBase.GetCurrentMethod().Name, ex.Message), ex.StackTrace);
            }
        }

        public int SetPassword(int level)
        {
            try
            {
                if (nfc.SetPassword(level))
                    return 0;
                return -1;
            }
            catch (Exception ex)
            {
                throw new NFCException(String.Format("执行{0}时产生异常：{1}", MethodBase.GetCurrentMethod().Name, ex.Message), ex.StackTrace);
            }
        }

        public bool CheckAndResetStatusRegister()
        {
            try
            {
                return nfc.CheckAndResetStatusRegister(SR);
            }
            catch (Exception ex)
            {
                throw new NFCException(String.Format("执行{0}时产生异常：{1}", MethodBase.GetCurrentMethod().Name, ex.Message), ex.StackTrace);
            }
        }

        public bool CloseReader()
        {
            try
            {
                nfc.CloseReader();
                return true;
            }
            catch (Exception ex)
            {
                throw new NFCException(String.Format("执行{0}时产生异常：{1}", MethodBase.GetCurrentMethod().Name, ex.Message), ex.StackTrace);
            }
        }

        public int GTINTest()
        {
            if (GTIN == null)
                return -1;

            try
            {
                string tempsn = nfc.TagSN;
                OSRAM_OBID_NCF2.DIR Dir = nfc.ReadDeviceIdentificationRegister();
                System.Threading.Thread.Sleep(25);
                byte[] temp = BitConverter.GetBytes(Dir.Gtin);
                System.Threading.Thread.Sleep(25);

                int count = -6;
                for (int i = 0; i < 6; i++)
                {
                    if (GTIN[i] == temp[5 - i])
                        count++;
                }

                return count;
            }
            catch (Exception ex)
            {
                throw new NFCException(String.Format("执行{0}时产生异常：{1}", MethodBase.GetCurrentMethod().Name, ex.Message), ex.StackTrace);
            }
        }
    }


        /// <summary>
        /// NFC异常类
        /// </summary>
        public class NFCException : Exception {
            private String msg;
            private String stackTrace;

            public NFCException(String msg, String stackTrace) {
                this.msg = msg;
                this.stackTrace = stackTrace;
            }
        }
    }

