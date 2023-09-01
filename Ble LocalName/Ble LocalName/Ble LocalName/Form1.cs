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

namespace Ble_LocalName
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            Listview_init();
        }

        private void Listview_init()
        {
            listView1.Columns.Add("PacketType", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Address", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Count BT address bytes", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Rssi", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Data", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Payload", 100, HorizontalAlignment.Center);
            listView1.View = View.Details;

            listView2.Columns.Add("PacketType", 100, HorizontalAlignment.Center);
            listView2.Columns.Add("Address", 100, HorizontalAlignment.Center);
            listView2.Columns.Add("Count BT address bytes", 100, HorizontalAlignment.Center);
            listView2.Columns.Add("Rssi", 100, HorizontalAlignment.Center);
            listView2.Columns.Add("Data", 100, HorizontalAlignment.Center);
            listView2.Columns.Add("Payload", 100, HorizontalAlignment.Center);
            listView2.View = View.Details;

        }

        /**
         *  查询listview列是否为空  * 
         * */
        bool IsColumnEmpty(ListView listView, int columnIndex)
        {
            foreach (ListViewItem item in listView.Items)
            {
                if (item.SubItems.Count > columnIndex && !string.IsNullOrEmpty(item.SubItems[columnIndex].Text))
                {
                    return false;
                }
            }
            return true;
        }


        private void 搜索蓝牙(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.Refresh();
            listView2.Items.Clear();
            listView2.Refresh();
            int higher1 = (int)numericUpDown3.Value;
            int _pt = (int)numericUpDown1.Value;
            Thread.Sleep(50);


            //if (listView1.Items.Count > 0)
            //    listView1.Items.RemoveAt(0);

            //根据蓝牙发射器串口端口设定
            BleManager.Instance.ComPort = "com3";
            Thread.Sleep(50);
            BleManager.Instance.StartDiscovery();
            Thread.Sleep(5 * 1000);
            BleManager.Instance.StopDiscovery();

            Thread.Sleep(50);
            Queue<BtDiscoveryEventPacket> queue = BleManager.Instance.DiscoveryPacketQueue;
            foreach (BtDiscoveryEventPacket bt in queue)
            {
                string payload = null;
                //string payloadascii = null;
                if ((bt.Rssi >= numericUpDown3.Value && bt.Rssi <= numericUpDown2.Value) && bt.PacketType == _pt)
                {

                    //higher = bt.Rssi;

                    for (int i = 0; i < bt.PayLoad.Length; i++)
                    {

                        payload += bt.PayLoad[i].ToString();

                    }
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine($"PacketType: {bt.PacketType}");
                    Console.WriteLine($"Address: {bt.Address}");
                    Console.WriteLine($"Count BT address bytes: {bt.Address.ToString().Length - 11}");
                    Console.WriteLine($"Rssi: {bt.Rssi}");
                    Console.WriteLine($"Data: {bt.Data}");
                    Console.WriteLine($"Payload: {payload}");

                    //byte[] bytes = Encoding.ASCII.GetBytes(payload);
                    //for (int i = 0; i < bytes.Length; i++)
                    //{
                    //    payloadascii += bytes[i];
                    //}

                    string[] textdata = { bt.PacketType.ToString(), bt.Address.ToString(), (bt.Address.ToString().Length - 11).ToString(), bt.Rssi.ToString(), bt.Data.ToString(), payload };
                    ListViewItem item1 = new ListViewItem(textdata);
                    listView1.Items.Add(item1);
                    listView1.Refresh();

                    if (bt.Rssi >= higher1)
                    {
                        string[] textdata1 = { bt.PacketType.ToString(), bt.Address.ToString(), (bt.Address.ToString().Length - 11).ToString(), bt.Rssi.ToString(), bt.Data.ToString(), payload };
                        ListViewItem item2 = new ListViewItem(textdata1);
                        listView2.Items.Clear();                        
                        listView2.Items.Add(item2);
                        listView2.Refresh();
                        higher1 = bt.Rssi;
                    }

                }

            }
            if (IsColumnEmpty(listView1, 0))
                MessageBox.Show("未能找到BT", "提示");

        }

        private void 清除(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.Refresh();
            listView2.Items.Clear();
            listView2.Refresh();
        }
    }
}
