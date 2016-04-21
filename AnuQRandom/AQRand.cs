using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using HtmlAgilityPack;


//http://qrng.anu.edu.au/index.php
//https://github.com/pcragone/anurandom/blob/master/java/AnuRandom.java
//http://james.newtonking.com/pages/json-net.aspx

namespace AnuQRandom
{
    /// <summary>
    /// Load Data parsing the content of html page
    /// </summary>
    public class AQRand
    {
        #region constructor
        public AQRand()
        {
            
        }
        #endregion

        #region public
        /// <summary>
        /// return array of bytes parsing the html page RawChar.php
        /// </summary>
        /// <param name="TotNumOfBytes"></param>
        /// <returns></returns>
        public byte[] getBinary(int TotNumOfBytes)
        {
            if(TotNumOfBytes <= 0)
                return new byte[]{};

            List<byte> rv = new List<byte>();

            while (rv.Count < TotNumOfBytes)
            {
                string text = getText("RawHex.php");
                byte[] arrByte = lib.HexToByteArray(text);
                rv = rv.Concat(arrByte).ToList();
            }

            return rv.GetRange(0, TotNumOfBytes).ToArray();
        }

        /// <summary>
        /// load random string parsing the html page RawChar.php
        /// </summary>
        /// <param name="TotLength"></param>
        /// <returns></returns>
        public string getString(int TotLength)
        {
            if (TotLength <= 0)
                return string.Empty;

            string result = string.Empty;
            while (result.Length < TotLength)
            {
                result += getText("RawChar.php");
            }

            return result.Substring(0, TotLength);
        }
        #endregion

        #region private
        private string getText(string page)
        {
            string result = string.Empty;
            WebClient client = new WebClient();
            //string value = client.DownloadString("http://150.203.48.55/RawChar.php");
            //string value = client.DownloadString("http://150.203.48.55/RawHex.php");
            string value = client.DownloadString("https://qrng.anu.edu.au/" + page);

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(value); 

            HtmlNode node = doc.DocumentNode.SelectSingleNode("//table/tr/td");
            result = node.InnerHtml.Trim();

            return result;
        }
        #endregion
    }
}
