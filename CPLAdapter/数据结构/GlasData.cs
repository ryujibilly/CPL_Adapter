using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPL_Adapter
{
    public class GlasData
    {
        /// <summary>
        /// 400 xspp
        /// </summary>
        public byte[] spp = new byte[800];
        /// <summary>
        /// 2 xBPI2
        /// </summary>
        public byte[] BPI = new byte[4];
        /// <summary>
        /// 2 xHL
        /// </summary>
        public byte[] HL = new byte[4];
    }
}
