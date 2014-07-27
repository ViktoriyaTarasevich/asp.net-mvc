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
                if (szIP.IndexOf(",", System.StringComparison.Ordinal) > 0)
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
            var ip = IPAddress.Parse(ipAddress);
            var octets = ip.GetAddressBytes();

            var is24BitBlock = octets[0] == 10;
            if (is24BitBlock) return true; // Return to prevent further processing

            var is20BitBlock = octets[0] == 172 && octets[1] >= 16 && octets[1] <= 31;
            if (is20BitBlock) return true; // Return to prevent further processing

            var is16BitBlock = octets[0] == 192 && octets[1] == 168;
            if (is16BitBlock) return true; // Return to prevent further processing

            var isLinkLocalAddress = octets[0] == 169 && octets[1] == 254;
            return isLinkLocalAddress;
        }
    }
}
