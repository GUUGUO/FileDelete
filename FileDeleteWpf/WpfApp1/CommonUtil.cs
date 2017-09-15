namespace FileDeleteWpf
{
   public static class CommonUtil
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
