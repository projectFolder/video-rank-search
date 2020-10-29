﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Class
{
    class fileCheck
    {
        WebBrowser wb = new WebBrowser(); String Serial_Page, body, Station, Expired_date; Boolean state = true;
        byte[] Skey = new byte[8];

        public enum checkState
        {
            Formally,
            Demo,
            ban
        }

        public Enum License(MainForm main)
        {
            try
            {
                wb.Navigate("http://ghtmxld.dothome.co.kr/Serial.php?id=" + getHddNum() + "");

                do
                {
                    Application.DoEvents();
                    Serial_Page = wb.DocumentText;
                } while (!Serial_Page.Contains("</error>"));
                wb.DocumentText = null;

                body = Regex.Split(Serial_Page, "<br><br><br>")[1]; Station = "";
                if (body.Contains("서버 상태 :")) Station = Regex.Split(body, "서버 상태 : ")[1];
                foreach (String content in (Serial_Page.Split(new String[] { "등록정보:" }, StringSplitOptions.RemoveEmptyEntries)))
                {
                    String[] info = body.Split('|');
                    if (content.Contains("인증성공") && content.Contains(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name))
                    {
                        MessageBox.Show("사용등록된 PC입니다. 아래는 프로그램 등록정보 입니다." + '\n' + '\n' +
                               "사용자 : " + info[4] + "" + '\n' +
                               "프로그램 이름 : " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "" + '\n' +
                               "등록기간 : " + info[6] + "" + '\n' +
                               "만료기간 : " + info[7] + "" + '\n' +
                               "사용 잔여일 : " + Regex.Split(info[7], "<")[0], "인증성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Expired_date = info[6];
                        //main.label16.Text = "기간만료일 : " + info[6];
                        //main.label17.Text = "잔여일  : " + Regex.Split(info[7], "<")[0];
                        return checkState.Formally;
                    }
                }
                if (Station.Contains("점검 진행")) return checkState.ban; else return checkState.Demo;
            }
            catch (Exception e)
            {
                MessageBox.Show("서버와의 인증이 진행되는 도중에 오류가 발생하였습니다." + '\n' + "다시 시도해주세요.", "인증실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return checkState.ban;
            }

        }

        public void showMsg(String pas)
        {
            System.Windows.Forms.Clipboard.SetDataObject(pas, true, 5, 200);
            MessageBox.Show("'" + pas + "'" + '\n' + "위의 코드는 등록되지 않은 PC입니다." + '\n' + '\n' +
                             "코드는 자동으로 복사되니, 정식등록 절차시 해당코드를 관리자에게 전달해주시길 바랍니다.", "인증실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public String getHddNum()
        {
            ManagementObject manageobject = new ManagementObject("win32_logicaldisk.deviceid=\"" + "C" + ":\"");
            manageobject.Get();

            Decimal HextoDec(string str)
            {
                str = str.Replace("x", string.Empty);
                long result = 0;
                long.TryParse(str, System.Globalization.NumberStyles.HexNumber, null, out result);
                return result;
            }
            return HextoDec(manageobject["VolumeSerialNumber"].ToString()).ToString();

        }

        private static readonly string defaultKeyASE256 ="ABCDEABCDEABCDEABCDEABCDEABCDEAB";

// 암호화
public static String AESEncrypt256(String Input)
        {
            RijndaelManaged aes = new RijndaelManaged();
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = Encoding.UTF8.GetBytes(defaultKeyASE256);
            aes.IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            var encrypt = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] xBuff = null;
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, encrypt, CryptoStreamMode.Write))
                {
                    byte[] xXml = Encoding.UTF8.GetBytes(Input);
                    cs.Write(xXml, 0, xXml.Length);
                }

                xBuff = ms.ToArray();
            }

            String Output = Convert.ToBase64String(xBuff);
            return Output;
        }

        // 복호화
        public static String AESDecrypt256(String Input)
        {
            RijndaelManaged aes = new RijndaelManaged();
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = Encoding.UTF8.GetBytes(defaultKeyASE256);
            aes.IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            var decrypt = aes.CreateDecryptor();
            byte[] xBuff = null;
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, decrypt, CryptoStreamMode.Write))
                {
                    byte[] xXml = Convert.FromBase64String(Input);
                    cs.Write(xXml, 0, xXml.Length);
                }

                xBuff = ms.ToArray();
            }

            String Output = Encoding.UTF8.GetString(xBuff);
            return Output;
        }



    }
}
