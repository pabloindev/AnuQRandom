using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnuQRandom.Model
{
    class ObjResultEx : ObjResult
    {
        public string[] data { get; set; }

        public override byte[] getBinary()
        {
            List<byte> rv = new List<byte>();

            foreach (string s in data)
            {
                rv = rv.Concat(lib.HexToByteArray(s)).ToList();
            }
            return rv.GetRange(0, this.length).ToArray();
        }

    }
}
