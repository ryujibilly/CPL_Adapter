using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPL_Adapter
{
    public class BoxData
    {
        /// <summary>
        /// Frag Data
        /// </summary>
        public byte[] HexData = new byte[6112];
        /// <summary>
        /// Original
        /// </summary>
        public byte[] Spp1L = new byte[1000];
        public byte[] Spp1H = new byte[1000];
        /// <summary>
        /// D C
        /// </summary>
        public byte[] Spp2L = new byte[1000];
        public byte[] Spp2H = new byte[1000];
        /// <summary>
        /// Filteration
        /// </summary>
        public byte[] Spp3L = new byte[1000];
        public byte[] Spp3H = new byte[1000];
        /// <summary>
        /// HookLoad
        /// </summary>
        public byte[] HLL = new byte[10];
        public byte[] HLH = new byte[10];
        /// <summary>
        /// BPI2
        /// </summary>
        public byte[] BPI_L = new byte[10];
        public byte[] BPI_H = new byte[10];

        public BoxData()
        {
            HexData[0] = 0x55;
            HexData[1] = 0x55;
            HexData[2] = 0x55;
            HexData[3] = 0x55;
        }
    }
}
