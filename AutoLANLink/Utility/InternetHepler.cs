using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AutoLANLink.Utility
{
    class InternetHepler
    {
        /// <summary>
        /// 测试是否连接外网
        /// </summary>
        /// <returns></returns>
        public static bool TestInternet()
        {
            try
            {
                Ping ping = new Ping();
                //INIHelper ini = new INIHelper("MuHuaHealthy.ini");
                //配置文件中获取测试网络地址  读不通就默认百度
                // string url = ini.ReadString("internet", "interurl", "MLV6kGlONaWWBcqsfRVpeQ==");
                //PingReply pingReply = ping.Send(StrJiaMi.JieMiStr(url));
                PingReply pingReply = ping.Send(StrJiaMi.JieMiStr("www.baidu.com"));
                if (pingReply.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        /// <summary>
        /// 获取电脑的 ip地址，子网掩码，网关
        /// </summary>
        /// <returns></returns>
        public static bool GetIpAddress(out string ipAddress, out string subnetMask, out string gateway)
        {
            ipAddress = "";
            subnetMask = "";
            gateway = "";
            try
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection nics = mc.GetInstances();
                foreach (ManagementObject nic in nics)
                {
                    if (Convert.ToBoolean(nic["ipEnabled"]) == true && nic["DefaultIPGateway"] != null)
                    {
                        ipAddress = (nic["IPAddress"] as String[])[0];
                        subnetMask = (nic["IPSubnet"] as String[])[0];
                        gateway = (nic["DefaultIPGateway"] as String[])[0];
                        return true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        /// <summary>
        /// 获得广播地址
        /// </summary>
        /// <param name="ipAddress">IP地址</param>
        /// <param name="subnetMask">子网掩码</param>
        /// <returns>广播地址</returns>
        public static string GetBroadcast()
        {
            string ipAddress = "";
            string subnetMask = "";
            string gateway = "";
            if (GetIpAddress(out ipAddress, out subnetMask, out gateway))
            {
                byte[] ip = IPAddress.Parse(ipAddress).GetAddressBytes();
                byte[] sub = IPAddress.Parse(subnetMask).GetAddressBytes();

                // 广播地址=子网按位求反 再 或IP地址
                for (int i = 0; i < ip.Length; i++)
                {
                    ip[i] = (byte)((~sub[i]) | ip[i]);
                }
                return new IPAddress(ip).ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
