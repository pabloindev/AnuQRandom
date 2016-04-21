using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnuQRandom.Model
{
    abstract class ObjResult
    {
        public string type { get; set; }
        public int length { get; set; }
        //public byte[] data { get; set; }
        public bool success { get; set; }

        public abstract byte[] getBinary();
        
    }
}
