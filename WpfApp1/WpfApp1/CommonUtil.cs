using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
   public class CommonUtil
    {
        public static string GetSizeString(long byteSize)
        {
            float byteSizeF = byteSize;
            if (byteSizeF < 1024)
                return byteSizeF.ToString("0.00 B");
            byteSizeF /= 1024;
            if (byteSizeF < 1024)
                return byteSizeF.ToString("0.00 KB");
            byteSizeF /= 1024;
            if (byteSizeF < 1024)
                return byteSizeF.ToString("0.00 MB");
            byteSizeF /= 1024;
            return byteSizeF.ToString("0.00 GB");
        }
    }
}
