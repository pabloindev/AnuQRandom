using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;

namespace AnuQRandom.Model
{
    class ObjResult16 : ObjResult
    {
        public UInt16[] data { get; set; }

        public override byte[] getBinary()
        {
            List<byte> rv = new List<byte>();

            foreach (UInt16 u in this.data)
            {
                byte[] intBytes = BitConverter.GetBytes(u);
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(intBytes);
                rv = rv.Concat(intBytes).ToList();
            }
            return rv.GetRange(0, this.length).ToArray();
        }
    }
}
