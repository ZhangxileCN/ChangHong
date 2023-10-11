using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Osram;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Ble_LocalName
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataGridView_init();
        }

        private void DataGridView_init()
        {
            // 初始化DataGridView的列
            dataGridView1.Columns.Add("PacketType", "PacketType");
            dataGridView1.Columns.Add("Address", "Address");
            dataGridView1.Columns.Add("Count BT address bytes", "Count BT address bytes");
            dataGridView1.Columns.Add("Rssi", "Rssi");
            dataGridView1.Columns.Add("Data", "Data");
            dataGridView1.Columns.Add("Payload", "Payload");
            dataGridView1.ReadOnly = true;

            dataGridView2.Columns.Add("PacketType", "PacketType");
            dataGridView2.Columns.Add("Address", "Address");
            dataGridView2.Columns.Add("Count BT address bytes", "Count BT address bytes");
            dataGridView2.Columns.Add("Rssi", "Rssi");
            dataGridView2.Columns.Add("Data", "Data");
            dataGridView2.Columns.Add("Payload", "Payload");
            dataGridView2.ReadOnly = true;
        }

        //检查DataGridView第一行是否有数据
        private bool IsDataGridViewEmpty(DataGridView dataGridView)
        {
            return dataGridView.Rows.Count == 0 || dataGridView.Rows[0].Cells.Cast<DataGridViewCell>().All(cell => cell.Value == null || cell.Value.ToString() == string.Empty);
        }


        private void 搜索蓝牙(object sender, EventArgs e)
        {
            
            // 清除DataGridView的行
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            int higher1 = (int)numericUpDown3.Value;
            int _pt = (int)numericUpDown1.Value;
            int _second = (int)numericUpDown4.Value;
            new Thread(async () =>
            {
                BleManager.Instance.DiscoverCom();
                await Task.Delay(50);
                if (!BleManager.Instance.DiscoverCom())
                {
                    Invoke(new Action(() =>
                    {
                        led1.Value = false;
                        textBox1.AppendText($"{DateTime.Now.ToString("HH:mm:ss")}  请检查蓝牙dongle是否接好\r\n\r\n");
                        textBox1.ScrollToCaret();
                    }));
                }
                else
                {
                    Invoke(new Action(() =>
                    {
                        led1.Value = true;
                        textBox1.AppendText($"{DateTime.Now.ToString("HH:mm:ss")}  正在搜索... {_second} 秒之后查看结果\r\n\r\n");
                        textBox1.ScrollToCaret();
                    }));
                    BleManager.Instance.StartDiscovery();
                    Thread.Sleep(_second * 1000);
                    BleManager.Instance.StopDiscovery();
                    Queue<BtDiscoveryEventPacket> queue = BleManager.Instance.DiscoveryPacketQueue;
                    foreach (BtDiscoveryEventPacket bt in queue)
                    {
                        
                        string payload = null;
                        if ((bt.Rssi >= numericUpDown3.Value && bt.Rssi <= numericUpDown2.Value) && bt.PacketType == _pt)
                        {
                            for (int i = 0; i < bt.PayLoad.Length; i++)
                            {
                                payload += bt.PayLoad[i].ToString();
                            }
                            string[] rowData = { bt.PacketType.ToString(), bt.Address.ToString(), (bt.Address.ToString().Length - 11).ToString(), bt.Rssi.ToString(), bt.Data.ToString(), payload };
                            Invoke(new Action(() =>
                            {                                
                                dataGridView1.Rows.Add(rowData);
                            }));
                            await Task.Delay(50);
                            if (bt.Rssi >= higher1)
                            {

                                Invoke(new Action(() =>
                                {
                                    dataGridView2.Rows.Clear();
                                    dataGridView2.Rows.Add(rowData);
                                }));
                                higher1 = bt.Rssi;
                            }
                        }
                    }
                }

                if (IsDataGridViewEmpty(dataGridView1))
                {
                    Invoke(new Action(() =>
                    {
                        textBox1.AppendText($"{DateTime.Now.ToString("HH:mm:ss")}  未能找到PayLoad为 {_pt} 的蓝牙数据\r\n\r\n");
                        textBox1.ScrollToCaret();
                        led1.Value = false;
                    }));

                }
                else
                {
                    Invoke(new Action(() =>
                    {
                        textBox1.AppendText($"{DateTime.Now.ToString("HH:mm:ss")}  查看搜索结果\r\n\r\n");
                        textBox1.ScrollToCaret();
                        led1.Value = true;
                    }));
                }

            }).Start();
        }

        private void 清除列表(object sender, EventArgs e)
        {
            // 清除DataGridView的行
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            textBox1.Clear();
        }
    }
}