using AutoLANLink.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoLANLink
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 采集本接收
        /// </summary>
        UdpClient Cj_udpClientReceive = new UdpClient(8899);

        /// <summary>
        /// 汇总本接收
        /// </summary>
        UdpClient Hz_udpClientReceive = new UdpClient(7788);

        /*  汇总本 ，采集本 发送都使用 1122 端口  接收都是用 2211 */

        #region 页面常量

        string gComputerType = "cj";              //汇总本 采集本 标记
        string gIpAddress = "";                   //IP地址
        string gSubnetMask = "";                  //子网掩码
        string gGateway = "";                     //网关

        #endregion

        #region 笔记本链接情况

        /// <summary>
        /// 采集本链接情况  ip地址， 链接内容
        /// </summary>
        public Dictionary<string, string> gCjDic = new Dictionary<string, string>();

        /// <summary>
        /// 汇总本链接情况  ip地址， 链接内容
        /// </summary>
        public Dictionary<string, string> gHZDic = new Dictionary<string, string>();
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 系统初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Initialize_Click(object sender, EventArgs e)
        {
            this.gComputerType = rCheck_HZ.Checked ? "hz" : "cj";                             //hz:表示“汇总本”；cj:表示“采集本”
            if (InternetHepler.GetIpAddress(out gIpAddress, out gSubnetMask, out gGateway))
            {
                //初始化
                if (this.gComputerType == "hz")            //汇总本
                {
                    timer_HZ_Fasong.Enabled = true;                //汇总本进行广播发送
                    timer_HZ_Jieshou.Enabled = true;              //汇总本进行接收链接信息
                    timer_CJ_Jieshou.Enabled = false;               //采集本进行接收链接信息
                }
                else if (this.gComputerType == "cj")       //采集本
                {
                    timer_HZ_Fasong.Enabled = false;               //汇总本进行广播发送
                    timer_HZ_Jieshou.Enabled = false;              //汇总本进行接收链接信息
                    timer_CJ_Jieshou.Enabled = true;               //采集本进行接收链接信息
                }
                else
                {
                    timer_HZ_Fasong.Enabled = false;
                    timer_HZ_Jieshou.Enabled = false;
                    timer_CJ_Jieshou.Enabled = false;
                }

                rickMessage.Clear();
                lab_ip.Text = this.gIpAddress;
                lab_ziwang.Text = this.gSubnetMask;
                lab_wangguan.Text = this.gGateway;
                #region rbox提示信息

                rickMessage.AppendText("-------------------------------------------------------------\r\n");
                rickMessage.AppendText("初始化成功" + "\r\n");
                rickMessage.AppendText("类型：" + this.gComputerType + "\r\n");
                rickMessage.AppendText("IP地址：" + this.gIpAddress + "\r\n");
                rickMessage.AppendText("子网掩码：" + this.gSubnetMask + "\r\n");
                rickMessage.AppendText("网关：" + this.gGateway + "\r\n");
                rickMessage.AppendText("-------------------------------------------------------------\r\n");
                #endregion
            }
        }

        #region 采集本业务处理

        private void back_CaiJi_Jieshou_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                Byte[] receiveBytes = Cj_udpClientReceive.Receive(ref RemoteIpEndPoint);
                string str = Encoding.UTF8.GetString(receiveBytes);
                Cj_udpClientReceive.Close();
                e.Result = str;
            }
            catch (Exception ee)
            {
                e.Result = "Error: 采集本 " + ee.ToString();
            }
        }

        private void back_CaiJi_Jieshou_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string ipAddress = StrJiaMi.JieMiStr(e.Result.ToString());
            if (!string.IsNullOrEmpty(ipAddress))
            {
                if (gCjDic.ContainsKey(ipAddress))
                {
                    gCjDic[ipAddress] = ipAddress;
                }
                else
                {
                    gCjDic.Add(ipAddress, ipAddress);
                }

                //判断当前接收的汇总本信息 有多少。
                if (gCjDic != null && gCjDic.Count > 1)
                {
                    MessageBox.Show("存在" + gCjDic.Count + ",需进行选择。。。");
                    return;
                }

                if (UseRight(ipAddress))                   //采集本接收完成并，并对接收内容进行解析处理，返回汇总本指定消息
                {
                    ReceiveResponse(gIpAddress);
                    timer_CJ_Jieshou.Enabled = false;      //应用完成之后 不再进行 接收其他信息
                }

                #region rbox提示信息
                rickMessage.AppendText("-------------------------------------------------------------\r\n");
                rickMessage.AppendText("采集本接收信息" + "\r\n");
                rickMessage.AppendText("汇总本IP地址" + ipAddress + "\r\n");
                rickMessage.AppendText("-------------------------------------------------------------\r\n");
                #endregion
            }
        }

        /// <summary>
        /// 采集本接收汇总本的广播信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_CJ_JieShou_Tick(object sender, EventArgs e)
        {
            if (!back_CaiJi_Jieshou.IsBusy)
            {
                back_CaiJi_Jieshou.RunWorkerAsync();
            }
        }

        #region 采集本 其他方法
        /// <summary>
        /// 应用 链接、设置 信息
        /// </summary>
        /// <returns></returns>
        public bool UseRight(string str)
        {
            #region rbox提示信息
            rickMessage.AppendText("-------------------------------------------------------------\r\n");
            rickMessage.AppendText("采集本应用“链接”信息" + "\r\n");
            rickMessage.AppendText("-------------------------------------------------------------\r\n");
            #endregion

            return true;
        }

        /// <summary>
        /// 采集本接收成功，发送给汇总本接收成功消息
        /// </summary>
        public void ReceiveResponse(string iPAddress)
        {
            UdpClient udpClient = new UdpClient(6677);
            try
            {
                if (!string.IsNullOrEmpty(iPAddress))
                {
                    Byte[] sendBytes = Encoding.UTF8.GetBytes(iPAddress + "~" + "链接成功!" + DateTime.Now);
                    udpClient.Send(sendBytes, sendBytes.Length, iPAddress, 7788);
                    udpClient.Close();
                }
            }
            catch (Exception ee)
            {
            }

            #region rbox提示信息
            rickMessage.AppendText("-------------------------------------------------------------\r\n");
            rickMessage.AppendText("采集本发送给汇总本链接成功" + "\r\n");
            rickMessage.AppendText("-------------------------------------------------------------\r\n");
            #endregion
        }

        #endregion

        #endregion
 
        #region 汇总本业务处理

        #region 汇总本发送
        private void back_HuiZong_Fasong_DoWork(object sender, DoWorkEventArgs e)
        {
            string sendStr = e.Argument.ToString();

            UdpClient udpClient = new UdpClient(5566);
            try
            {
                string broadcastAddress = InternetHepler.GetBroadcast();
                if (!string.IsNullOrEmpty(broadcastAddress))
                {
                    udpClient.Connect(IPAddress.Parse(broadcastAddress), 8899);

                    Byte[] sendBytes = Encoding.UTF8.GetBytes(sendStr);

                    udpClient.Send(sendBytes, sendBytes.Length);

                    udpClient.Close();
                    e.Result = "汇总本广播发送成功";
                }
                else
                {
                    e.Result = "Error:汇总本 未正确获取到该计算机的广播地址";
                }
            }
            catch (Exception ee)
            {
                e.Result = "Error:汇总本 " + ee.ToString();
            }
        }

        private void back_HuiZong_Fasong_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string str = e.Result.ToString();

            #region rbox提示信息
            rickMessage.AppendText("-------------------------------------------------------------\r\n");
            rickMessage.AppendText(str + "\r\n");
            rickMessage.AppendText("-------------------------------------------------------------\r\n");
            #endregion
        }
        #endregion

        #region 汇总本接收
        private void back_HuiZong_Jieshou_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                Byte[] receiveBytes = Hz_udpClientReceive.Receive(ref RemoteIpEndPoint);
                string str = Encoding.UTF8.GetString(receiveBytes);
                Hz_udpClientReceive.Close();
                e.Result = str;
            }
            catch (Exception ee)
            {
                e.Result = "Error:" + ee.ToString();
            }
        }

        private void back_HuiZong_Jieshou_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Result.ToString()))
            {
                string[] str = e.Result.ToString().Split('~');
                if (str != null && str.Length == 2)
                {
                    if (gHZDic.ContainsKey(str[0]))
                    {
                        gHZDic[str[0]] = str[1];
                    }
                    else
                    {
                        gHZDic.Add(str[0], str[1]);
                    }
                }
            }

            #region rbox提示信息
            rickMessage.AppendText("-------------------------------------------------------------\r\n");
            rickMessage.AppendText("汇总本接受采集本信息" + e.Result.ToString() + "\r\n");
            rickMessage.AppendText("当前汇总本链接数量" + gHZDic.Count + "\r\n");
            rickMessage.AppendText("-------------------------------------------------------------\r\n");
            #endregion

            if (gHZDic != null && gHZDic.Count >= numericUpDown1.Value)     //超过5个链接发送成功  则终止广播
            {
                timer_HZ_Fasong.Enabled = false;              //汇总接收
                timer_HZ_Jieshou.Enabled = false;             //汇总发送

                #region rbox提示信息
                rickMessage.AppendText("-------------------------------------------------------------\r\n");
                rickMessage.AppendText("汇总本链接超过指定数量，停止广播 \r\n");
                rickMessage.AppendText("-------------------------------------------------------------\r\n");
                #endregion
            }
        }
        #endregion

        /// <summary>
        /// 汇总本接收采集本信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_HZ_Jieshou_Tick(object sender, EventArgs e)
        {
            if (!back_HuiZong_Jieshou.IsBusy)
            {
                back_HuiZong_Jieshou.RunWorkerAsync();
            }
        }

        /// <summary>
        /// 汇总本广播汇总本信息--供采集本链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_HZ_FaSong_Tick(object sender, EventArgs e)
        {
            if (!back_HuiZong_Fasong.IsBusy)
            {
                if (InternetHepler.GetIpAddress(out gIpAddress, out gSubnetMask, out gGateway))
                {
                    back_HuiZong_Fasong.RunWorkerAsync(StrJiaMi.JiaMiStr(gIpAddress));
                }
            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            timer_CJ_Jieshou.Enabled = timer_HZ_Fasong.Enabled = timer_HZ_Jieshou.Enabled = false;

            #region rbox提示信息
            rickMessage.AppendText("-------------------------------------------------------------\r\n");
            rickMessage.AppendText("暂停 暂停 暂停\r\n");
            rickMessage.AppendText("-------------------------------------------------------------\r\n");
            #endregion
        }
    }
}
