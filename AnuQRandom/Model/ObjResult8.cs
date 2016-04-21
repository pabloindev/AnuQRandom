using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;

namespace AnuQRandom.Model
{
    class ObjResult8 : ObjResult
    {
        public byte[] data { get; set; }

        public override byte[] getBinary()
        {
            List<byte> rv = new List<byte>();

            foreach (byte u in this.data)
            {
                rv.Add(u);
            }
            return rv.ToArray();
        }

    }
}
