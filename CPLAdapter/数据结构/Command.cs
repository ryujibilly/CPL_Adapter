using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPL_Adapter
{
    internal class Command
    {
        public static readonly Command CMD = new Command();
        /// <summary>
        /// RE SEND
        /// </summary>
        public static byte[] RESEND = new byte[] { 0xcc, 0xcc, 0xcc, 0xcc, 0xa0 };
        public static byte[] GO_ON = new byte[] { 0xcc, 0xcc, 0xcc, 0xcc, 0xa1 };
        public static byte[] SEND = new byte[] { 0xcc, 0xcc, 0xcc, 0xcc, 0xa2 };
        public static byte[] TEST = new byte[] { 0xcc, 0xcc, 0xcc, 0xcc, 0xa3 };
        public static byte[] VERSIONS = new byte[] { 0xcc, 0xcc, 0xcc, 0xcc, 0xa4 }; //return 11 09 01 04
    }
}
