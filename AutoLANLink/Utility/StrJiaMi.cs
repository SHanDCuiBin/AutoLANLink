using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLANLink.Utility
{
    class StrJiaMi
    {
        public static string MinYao
        {
            get
            { return "m1223456655522"; }
        }
        /// <summary>
        ///  本地加密字符串
        /// </summary>
        /// <param name="ysstr"></param>
        /// <returns></returns>
        public static string JiaMiStr(string ysstr)
        {
            try
            {
                string s = MuHuaJiaMi.EncryptUtil.Encrypt3DES(ysstr, MinYao);
                if (s == "")
                {
                    return ysstr;
                }
                return s;
            }
            catch (Exception)
            {
                return ysstr;
            }
        }
        public static string JiaMiStr(string ysstr, string keyName)
        {
            try
            {
                string s = MuHuaJiaMi.EncryptUtil.Encrypt3DES(ysstr, keyName);
                if (s == "")
                {
                    return ysstr;
                }
                return s;
            }
            catch (Exception)
            {
                return ysstr;
            }
        }
        /// <summary>
        /// 本地解密字符串
        /// </summary>
        /// <param name="jmstr"></param>
        /// <returns></returns>
        public static string JieMiStr(string jmstr)
        {
            try
            {
                string s = MuHuaJiaMi.EncryptUtil.Decrypt3DES(jmstr, MinYao);
                if (s == "" && jmstr != "Q+8xeg03WHQ=")
                {
                    return jmstr;
                }
                return s;
            }
            catch (Exception)
            {
                return jmstr;
            }
        }

        /// <summary>
        /// 本地解密字符串
        /// </summary>
        /// <param name="jmstr"></param>
        /// <param name="KeyName"></param>
        /// <returns></returns>
        public static string JieMiStr(string jmstr, string KeyName)
        {
            try
            {
                string s = MuHuaJiaMi.EncryptUtil.Decrypt3DES(jmstr, KeyName);
                if (s == "" && jmstr != "Q+8xeg03WHQ=")
                {
                    return jmstr;
                }
                return s;
            }
            catch (Exception)
            {
                return jmstr;
            }
        }

        /// <summary>
        ///  解密字符串 统一加密方式
        /// </summary>
        /// <param name="jmstr">解密字符串</param>
        /// <returns></returns>
        public static string JieMiStr_Yun(string jmstr)
        {
            try
            {
                return MuHuaJiaMi.EncryptUtil.Decrypt3DES(jmstr, MinYao);
            }
            catch (Exception)
            {

                return jmstr;
            }
        }

        /// <summary>
        ///  解密字符串 统一加密方式
        /// </summary>
        /// <param name="jmstr">解密字符串</param>
        /// <returns></returns>
        public static string JieMiStr_Yun(string jmstr, string key)
        {
            try
            {
                return MuHuaJiaMi.EncryptUtil.Decrypt3DES(jmstr, key);
            }
            catch (Exception)
            {

                return jmstr;
            }
        }
        /// <summary>
        ///  加密字符串 统一加密方式
        /// </summary>
        /// <param name="ysstr">加密字符串</param>
        /// <returns></returns>
        public static string JiaMiStr_Yun(string ysstr)
        {
            try
            {
                return MuHuaJiaMi.EncryptUtil.Encrypt3DES(ysstr, MinYao);
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
