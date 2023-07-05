using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;

namespace NFC_Test_Sys_K10
{
    public partial class MainForm : Form
    {
        public static MainForm mainForm;

        String ICCode;
        String JobNum;
        byte[] gtin = new byte[6];
        Hashtable htECs = new Hashtable();
        utils.NFCHelper nfcHelper = null;
        bool isLinkDB = true;          //是否连接数据库，调试时跳过数据库连接用，默认true

        int total;  //总测试数量
        int passNum;    //通过数量
        int failNum;    //fail数量

        /// <summary>
        /// CheckForIllegalCrossThreadCalls = false;
        /// mainForm = this;
        /// 其他类就可以调用该窗体类或其控件
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            mainForm = this;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (isLinkDB) {
                utils.SqlHelper.connectDB();
            }

            lvInit();
            tbSN0.Focus();
        }

        private void lvInit()
        {
            lvDisplay.Columns.Add("序号", 50, HorizontalAlignment.Center);
            lvDisplay.Columns.Add("EC", 100, HorizontalAlignment.Center);
            lvDisplay.Columns.Add("description", 160, HorizontalAlignment.Center);
            lvDisplay.Columns.Add("LL", 100, HorizontalAlignment.Center);
            lvDisplay.Columns.Add("value", 100, HorizontalAlignment.Center);
            lvDisplay.Columns.Add("UL", 100, HorizontalAlignment.Center);
            lvDisplay.Columns.Add("测试结果", 100, HorizontalAlignment.Center);
            lvDisplay.Columns.Add("测试时间", 100, HorizontalAlignment.Center);
            lvDisplay.View = View.Details;
        }

        /// <summary>
        /// lvDisplay刷新
        /// </summary>
        /// <param name="ec"></param>
        public void lvUpdate(domain.EC ec) {
            int total = lvDisplay.Items.Count;
            lvDisplay.BeginUpdate();
            #region
            ListViewItem item = new ListViewItem();
            item = lvDisplay.Items.Add((total + 1).ToString());     //新增行
            item.SubItems.Add(ec.EcCode.ToString());
            item.SubItems.Add(ec.Desc);
            item.SubItems.Add(ec.LLimit.ToString());
            item.SubItems.Add(ec.Value.ToString());
            item.SubItems.Add(ec.ULimit.ToString());
            item.SubItems.Add(ec.Result?"pass":"fail");
            item.SubItems.Add(ec.CostTime.ToString());
            if (!ec.Result)
            {
                item.BackColor = Color.IndianRed;
            }
            else {
                item.BackColor = Color.MediumSeaGreen;
            }
            #endregion
            lvDisplay.EndUpdate();
        }

        /// <summary>
        /// 清空lvDisplay
        /// </summary>
        public void lvClear() {
            lvDisplay.Items.Clear();
            if(lvDisplay.Items.Count>0)
                lvDisplay.Items.RemoveAt(0);
        }

        public void gp3Update() {
            tbTotal.Text = total.ToString();
            tbPass.Text = passNum.ToString();
            tbFail.Text = failNum.ToString();
            double passRate = passNum / total * 100;
            tbPassRate.Text = String.Format("{0:F}%", passRate);     //默认保留两位小数
            if (passRate < 90)
            {
                tbPassRate.BackColor = Color.IndianRed;
            }
            else {
                tbPassRate.BackColor = Color.MediumSeaGreen;
            }
        }

        /// <summary>
        /// 扫SN码获取ICCode和JobNum
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSN0_TextChanged(object sender, EventArgs e)
        {
            String sn = tbSN0.Text.Trim();
            if (sn.Length != 32)
                return;

            ICCode = sn.Substring(15, 11);
            JobNum = sn.Substring(5, 10);

            tbICCode.Text = ICCode;
            tbJobNum.Text = JobNum;

            btnSure.Focus();
        }

        /// <summary>
        /// 通过ICCode读取xml中的gtin和EC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {
            #region gtin
            Hashtable ht = utils.XMLHelper.readGTIN("gtin.xml");
            if (!ht.ContainsKey(ICCode)) {
                MessageBox.Show(String.Format("未找到{0}的配置！", ICCode));
                tbSN0.Text = "";
                tbSN0.Focus();
                return;
            }

            String gtinHexStr = String.Empty;
            foreach (DictionaryEntry entry in ht) {
                if (!entry.Key.Equals(ICCode))
                {
                    continue;
                }
                else
                {
                    gtinHexStr = (String)entry.Value;
                    //若只有11位则最高位补0
                    if (gtinHexStr.Length == 11 )
                        gtinHexStr = "0" + gtinHexStr;
                    break;
                }
            }

            for (int i = 0; i < 6; i++) {
                String tempStr = gtinHexStr.Substring(2 * i, 2);
                gtin[i] = Convert.ToByte(tempStr, 16);
            }

            #endregion EC
            htECs = utils.XMLHelper.readEC(String.Format("{0}.xml", ICCode));
            #region

            #endregion

            btnSure.BackColor = Color.MediumSeaGreen;
            btnNFCinit.Focus();
        }

        private void btnNFCinit_Click(object sender, EventArgs e)
        {
            nfcHelper = utils.NFCHelper.getInstance();
            nfcHelper.InitGIN(gtin);

            tbState.Text = "NFC初始化成功";
            btnNFCinit.BackColor = Color.MediumSeaGreen;
            tbSN.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSN_TextChanged(object sender, EventArgs e)
        {
            String sn = tbSN.Text.Trim();
            if (sn.Length != 32)
                return;

            if (sn.Substring(15, 11) != ICCode)
            {
                MessageBox.Show("ICCode错误");
                return;
            }

            if (sn.Substring(5, 10) != JobNum)
            {
                MessageBox.Show("订单号错误");
                return;
            }

            if (isLinkDB) {
                if (!utils.SqlHelper.FCTisPass(sn))
                {
                    MessageBox.Show("未测试FCT或FCT测试未通过！");
                    tbSN.Text = "";
                    tbSN.Focus();
                    return;
                }
            }

            //询问产品放到位
            MessageBox.Show("产品是否已放好？");

            //清空lvDisplay
            lvClear();

            //通过ICCode调用其测试脚本
            Assembly assembly = Assembly.GetExecutingAssembly();
            String allName = String.Format("NFC_Test_Sys_K10.scripts.{0}", ICCode);
            domain.IBaseScripts ins = null;
            try
            {
                ins = (domain.IBaseScripts)assembly.CreateInstance(allName);
            }
            catch (Exception) {
                MessageBox.Show(String.Format("实例化{0}失败", allName));
                return;
            }
            Hashtable htTestResult = ins.startTest(htECs);

            //将测试结果写入到服务器
            String[] tempStr = utils.SqlHelper.createDataStr(sn, htTestResult);
            utils.SqlHelper.upToDB(tempStr[0], tempStr[1]);

            //gbState
            total++;
            if (utils.ECHelper.getFailedCount(htTestResult) > 0)
            {
                failNum++;
            }
            else {
                passNum++;
            }
            gp3Update();

            //准备下一次测试
            tbSN.Text = "";
            tbSN.Focus();
        }

        
    }
}
