using System;
using System.Net;
using System.Web;

namespace BusinessLogic
{
    public static class ClientDataParser
    {
        public static string GetUserIp(HttpRequestBase request)
        {
            string szRemoteAddr = request.UserHostAddress;
            string szXForwardedFor = request.ServerVariables["X_FORWARDED_FOR"];
            string szIP = "";

            if (szXForwardedFor == null)
            {
                szIP = szRemoteAddr;
            }
            else
            {
                szIP = szXForwardedFor;
                if (szIP.IndexOf(",", StringComparison.Ordinal) > 0)
                {
                    string[] arIPs = szIP.Split(',');

                    foreach (string item in arIPs)
                    {
                        if (!IsPrivateIp(item))
                        {
                            return item;
                        }
                    }
                }
            }
            return szIP;
        }

        private static bool IsPrivateIp(string ipAddress)
        {
            IPAddress ip = IPAddress.Parse(ipAddress);
            byte[] octets = ip.GetAddressBytes();

            bool is24BitBlock = octets[0] == 10;
            if (is24BitBlock) return true; // Return to prevent further processing

            bool is20BitBlock = octets[0] == 172 && octets[1] >= 16 && octets[1] <= 31;
            if (is20BitBlock) return true; // Return to prevent further processing

            bool is16BitBlock = octets[0] == 192 && octets[1] == 168;
            if (is16BitBlock) return true; // Return to prevent further processing

            bool isLinkLocalAddress = octets[0] == 169 && octets[1] == 254;
            return isLinkLocalAddress;
        }
    }
}