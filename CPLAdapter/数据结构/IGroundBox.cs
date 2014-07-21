using System;
using System.Collections.Generic;
using System.Text;

namespace CPL_Adapter
{
    interface IGroundBox
    {
        bool Start();
        void Stop();
        void SaveData(string strBytes);
    }
}
