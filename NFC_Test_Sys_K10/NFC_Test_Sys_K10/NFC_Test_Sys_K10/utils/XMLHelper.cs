using System;
using System.Collections;
using System.Xml;
using System.IO;

namespace NFC_Test_Sys_K10.utils
{
    public class XMLHelper
    {
        /// <summary>
        /// 读gtin
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Hashtable readGTIN(String fileName="gtin.xml") {
            Hashtable ht = new Hashtable();
            XmlDocument doc = new XmlDocument();
            DirectoryInfo binPath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            doc.Load(binPath.Parent.Parent.FullName + String.Format("\\config\\{0}", fileName));
            XmlElement root =  doc.DocumentElement;
            XmlNodeList list =  root.ChildNodes;
            foreach (XmlNode node in list) {
                XmlAttributeCollection attrs = node.Attributes;                
                ht.Add(attrs[0].Value, node.InnerText);
            }

            return ht;
        }

        /// <summary>
        /// 读EC
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Hashtable readEC(String fileName)
        {
            Hashtable ht = new Hashtable();
            XmlDocument doc = new XmlDocument();
            DirectoryInfo binPath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            doc.Load(binPath.Parent.Parent.FullName + String.Format("\\config\\{0}", fileName));
            XmlElement root = doc.DocumentElement;
            XmlNodeList list = root.ChildNodes;
            foreach (XmlNode node in list)
            {
                domain.EC ec = new domain.EC();
                ec.EcCode = Convert.ToInt32(node.Attributes[0].Value);
                foreach (XmlNode node_ in node.ChildNodes) {
                    if (node_.Attributes[0].Value.Equals("desc"))
                    {
                        ec.Desc = node_.Attributes[1].Value;
                        continue;
                    }
                    if (node_.Attributes[0].Value.Equals("lLimit"))
                    {
                        ec.LLimit = Convert.ToDouble(node_.Attributes[1].Value);
                        continue;
                    }
                    if (node_.Attributes[0].Value.Equals("uLimit"))
                    {
                        ec.ULimit = Convert.ToDouble(node_.Attributes[1].Value);
                        continue;
                    }
                    if (node_.Attributes[0].Value.Equals("unit"))
                    {
                        ec.Unit = node_.Attributes[1].Value;
                        continue;
                    }
                }
                ht.Add(ec.EcCode, ec);
            }

            return ht;
        }
    }
}
