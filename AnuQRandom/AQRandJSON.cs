using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using AnuQRandom.Model;

namespace AnuQRandom
{
    public enum DataType{uint8, uint16, hex16}


    /// <summary>
    /// Query the service QRNG@ANU JSON API
    /// </summary>
    public class AQRandJSON
    {
        #region constructor
        public AQRandJSON()
        {
            
        }
        #endregion

        #region public
        /// <summary>
        /// loads array of bytes calling the web api with the correct parameter (uint8/uint16/hex16)
        /// </summary>
        /// <param name="dt">parameter to pass to ANU JSON API</param>
        /// <param name="arrayLength">Length of the array</param>
        /// <returns></returns>
        public byte[] getBinary(DataType dt, int arrayLength)
        {
            ObjResult obj = getObjResult(dt, arrayLength);
            return obj.getBinary();
        }

        /// <summary>
        /// return a random string with the correct Length
        /// </summary>
        /// <param name="TotLength">Length of string</param>
        /// <returns></returns>
        public string getString(int TotLength)
        {
            char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            StringBuilder result = new StringBuilder();

            while (result.Length <= TotLength)
            {
                ObjResult16 obj = (ObjResult16)getObjResult(DataType.uint16, 1024);
                foreach (UInt16 u in obj.data)
                {
                    result.Append(chars[u % (chars.Length)]);
                }
            }

            return result.ToString().Substring(0,TotLength);
        }
        #endregion

        #region private
        private ObjResult getObjResult(DataType dt, int arrayLength)
        {
            WebClient webClient = new WebClient();
            ObjResult obj = null;
            string text;

            switch (dt)
            {
                case DataType.uint8:
                    text = webClient.DownloadString("https://qrng.anu.edu.au/API/jsonI.php?length=" + arrayLength + "&type=uint8");
                    obj = JsonConvert.DeserializeObject<ObjResult8>(text);
                    break;
                case DataType.uint16:
                    text = webClient.DownloadString("https://qrng.anu.edu.au/API/jsonI.php?length=" + arrayLength + "&type=uint16");
                    obj = JsonConvert.DeserializeObject<ObjResult16>(text);
                    break;
                case DataType.hex16:
                    text = webClient.DownloadString("https://qrng.anu.edu.au/API/jsonI.php?length=" + arrayLength + "&type=hex16&size=4");
                    obj = JsonConvert.DeserializeObject<ObjResultEx>(text);
                    break;
            }
            return obj;
        }
        #endregion
    }
}

/*
StringBuilder sb = new StringBuilder();
            List<byte> rv = new List<byte>();
            ObjResult obj = getObjResult();

            foreach (byte u in obj.data)
            {
                byte[] intBytes = BitConverter.GetBytes(u);
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(intBytes);
                byte[] result = intBytes;
                rv = rv.Concat(result).ToList();
            }

            byte[] bb = Encoding.UTF8.GetBytes(sb.ToString());

            string ss = Encoding.UTF8.GetString(bb);

            bool b = sb.ToString().Equals(ss);


*/


/*
StringBuilder sb = new StringBuilder();
            List<byte> rv = new List<byte>();
            ObjResult obj = getObjResult();

            foreach (ushort u in obj.data)
            {
                char c = (char)u;
                sb.Append(c);
            }

            byte[] bb = Encoding.UTF8.GetBytes(sb.ToString());

            string ss = Encoding.UTF8.GetString(bb);

            bool b = sb.ToString().Equals(ss);


            
            byte[] result = new byte[obj.data.Length * 2];
            byte[] result2 = new byte[obj.data.Length];
            Buffer.BlockCopy(obj.data, 0, result, 0, result.Length);
            Buffer.BlockCopy(obj.data, 0, result2, 0, result2.Length);



*/