using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CPL_Adapter
{
    public class converter
    {
        public static readonly converter _converter = new converter();
        private BoxData bdata = new BoxData();
        private GlasData gdata = new GlasData();

        /// <summary>
        /// HexString 转 byte[]
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public byte[] HexStringToByteArray(String s)
        {
            try
            {
                if (s != null)
                {
                    char[] seperater = { ' ' };
                    String[] str = s.Split(seperater, StringSplitOptions.RemoveEmptyEntries);
                    byte[] b = new byte[str.LongLength];
                    for (long i = 0; i < str.LongLength; i++)
                    {
                        b[i] = byte.Parse(str[i], System.Globalization.NumberStyles.AllowHexSpecifier);
                    }
                    return b;
                }
                else return null;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return null;
            }
        }
        /// <summary>
        /// byte[] 转 HexString
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string ByteArrayToHexString(byte[] data)
        {
            try
            {
                StringBuilder sb = new StringBuilder(data.Length * 3);
                foreach (byte b in data)
                    sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
                return sb.ToString().ToUpper();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return null;
            }
        }

        public BoxData ConvertBoxData(BoxData bd)
        {
            try
            {
                for (int k = 0; k < 10; k++)
                {
                    bd.HLL[k] = bd.HexData[610 * k + 600 + 5 + 1];//HookLoad
                    bd.HLH[k] = bd.HexData[610 * k + 600 + 5 + 2];
                    bd.BPI_L[k] = bd.HexData[610 * k + 600 + 5 + 5];//BPI2
                    bd.BPI_H[k] = bd.HexData[610 * k + 600 + 5 + 6];
                    for (int t = 0; t < 100; t++)
                    {
                        bd.Spp1L[100 * k + t] = bd.HexData[6 * t + 610 * k + 5 + 1];//Origin
                        bd.Spp1H[100 * k + t] = bd.HexData[6 * t + 610 * k + 5 + 2];
                        bd.Spp2L[100 * k + t] = bd.HexData[6 * t + 610 * k + 5 + 3];//DC
                        bd.Spp2H[100 * k + t] = bd.HexData[6 * t + 610 * k + 5 + 4];
                        bd.Spp3L[100 * k + t] = bd.HexData[6 * t + 610 * k + 5 + 5];//Filter
                        bd.Spp3H[100 * k + t] = bd.HexData[6 * t + 610 * k + 5 + 6];
                    }
                }
                return bd;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        // Sample Rate Convert 1000-->200
        public GlasData ConvertGlasData(BoxData bd)
        {
            try
            {
                for (int i = 0; i < 200; i++)
                {
                    gdata.spp[2 * i] = bd.Spp1L[5 * i];// 400-1000SPP mapping
                    gdata.spp[2 * i + 1] = bd.Spp1H[5 * i];
                }
                for (int j = 0; j < 2; j++)
                {
                    gdata.HL[2 * j] = bd.HLL[4]; // 10
                    gdata.HL[2 * j + 1] = bd.HLH[4];
                }
                for (int k = 0; k < 2; k++)
                {
                    gdata.BPI[2 * k] = bd.BPI_H[4];// 10
                    gdata.BPI[2 * k + 1] = bd.BPI_L[4];
                }
                return gdata;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
