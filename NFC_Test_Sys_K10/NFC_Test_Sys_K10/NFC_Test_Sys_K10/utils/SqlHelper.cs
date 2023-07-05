using System;
using System.Text;
using System.Data.SqlClient;
using System.Reflection;
using System.IO;
using System.Collections;

namespace NFC_Test_Sys_K10.utils
{
    public class SqlHelper
    {
        private static String dbConnectStr = "Data Source=192.168.16.254;Initial Catalog=PanDataArch14;User Id=HRDY;Password=123";
        private static SqlConnection conn = null;

        public static void connectDB() {
            //连接数据库
            try
            {
                conn = new SqlConnection(dbConnectStr);
                conn.Open();
            }
            catch (Exception ex)
            {
                throw new SqlHelperException(String.Format("执行{0}时产生异常：{1}", MethodBase.GetCurrentMethod().Name, ex.Message), ex.StackTrace);
            }
        }

        public static void closeConn()
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new SqlHelperException(String.Format("执行{0}时产生异常：{1}", MethodBase.GetCurrentMethod().Name, ex.Message), ex.StackTrace);
            }
            finally
            {
                conn = null;
            }
        }

        /// <summary>
        /// FCT测试是否通过
        /// </summary>
        /// <param name="SN"></param>
        /// <returns></returns>
        public static bool FCTisPass(String SN)
        {
            String sql = String.Format("SELECT TOP 1 Result FROM FCTESTMaster WHERE SN='{0:G}' ORDER BY StartTime DESC", SN);
            SqlDataReader sdr = null;
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    if (Convert.ToInt32(sdr["Result"]) == 0)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new SqlHelperException(String.Format("执行{0}时产生异常：{1}", MethodBase.GetCurrentMethod().Name, ex.Message), ex.StackTrace);
            }
            finally {
                if (sdr != null)
                    sdr.Close();
            }
        }

        public static String[] createDataStr(String sn, Hashtable htTestResult)
        {
            /*
             * 拼接字符串示例
             * strWrite = "" + Chr(39) + SN2 + Chr(39) + "," + Chr(39) + Chr(39) + "," + Chr(39) + "SocketIndex1" + Chr(39) + "," + Chr(39) + Format(Now, "yyyy-mm-dd hh:mm:ss") + Chr(39) + "," + Chr(39) + CStr(CostTime) + Chr(39) + _
                "," + Chr(39) + txtICcode1.Text + Chr(39) + "," + Chr(39) + "AA" + Chr(39) + "," + Chr(39) + ComboPline.Text + Chr(39) + "," + Chr(39) + txtWorkNo2.Text + Chr(39) + "," + Chr(39) + ComboStationNo.Text + Chr(39) + "," + TestResult2 + _
                "," + Chr(39) + Chr(39) + "," + Chr(39) + "prod1_QJZM-EQ1900" + Chr(39) + "," + Chr(39) + FailedEC2 + Chr(39) + "," + Chr(39) + iProductionMode + Chr(39) + "," + Chr(39) + Chr(39) + "," + Chr(39) + Chr(39) + "," + "0" + ";" + _
                "10" + "," + CStr(MDBResult(10, 2)) + ";" + "100" + "," + CStr(MDBResult(100, 2)) + ";" + "110" + "," + CStr(MDBResult(110, 2)) + ";" + "120" + "," + CStr(MDBResult(120, 2)) + ";" + "130" + "," + CStr(MDBResult(130, 2)) + ";" + "140" + "," + CStr(MDBResult(140, 2)) + ";" + "150" + "," + CStr(MDBResult(150, 2)) + ";"
             */
            StringBuilder sb = new StringBuilder("");
            sb.Append(String.Format("'{0}',", sn));
            sb.Append("'','SocketIndex1',");
            String dateStr = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            sb.Append(String.Format("'{0}',", dateStr));
            sb.Append(String.Format("{0},", 0));      //CostTtime
            sb.Append(String.Format("'{0}',", sn.Substring(15, 11)));
            sb.Append("'AA',");
            sb.Append("'NFC',");
            sb.Append(String.Format("'{0}',", sn.Substring(5, 10)));
            sb.Append("'FCTEST_100',");     //必填项，否则无法上传数据
            sb.Append(String.Format("{0},'',", ECHelper.getFailedCount(htTestResult)>0?1:0));   //0 pass
            sb.Append(String.Format("'{0}',", "NFC"));
            String failedEC = ECHelper.getFailedECCode(htTestResult);
            sb.Append(String.Format("'{0}',", failedEC));
            sb.Append("'3','','',0;");  //量产模式
            foreach (DictionaryEntry entry in htTestResult)
            {
                if (entry.Key.ToString().Equals("failedCount") || entry.Key.ToString().Equals("failedEC"))
                    continue;
                domain.EC ec = (domain.EC)entry.Value;
                sb.Append(String.Format("{0},{1};", ec.EcCode, ec.Value));
            }
            String dataStr = sb.ToString();

            StringBuilder fileName = new StringBuilder("");
            Random rd = new Random();
            fileName.Append(String.Format("{0}@NFC_SocketIndex1@{1}.txt", sn, (int)(rd.Next(999988889) + 11111)));
            return new string[] { fileName.ToString(), dataStr };
        }

        /// <summary>
        /// 上传数据到Z:\\MPLine\\FCTEST\\
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="data"></param>
        public static void upToDB(String fileName, String data)
        {
            StreamWriter sw = new StreamWriter(String.Format("Z:\\MPLine\\FCTEST\\{0}", fileName), false);
            sw.Write(data);
            sw.Close();
        }


        public class SqlHelperException : Exception
        {
            private String msg;
            private String stackTrace;

            public SqlHelperException(String msg, String stackTrace)
            {
                this.msg = msg;
                this.stackTrace = stackTrace;
            }
        }
    }
}
