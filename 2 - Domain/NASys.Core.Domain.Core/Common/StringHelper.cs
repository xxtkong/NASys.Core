using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace NASys.Core.Domain.Core.Common
{
    public class StringHelper
    {
        public static string SubStr(string contents, int length, bool append = false)
        {
            if (length < 1) return string.Empty;
            if (string.IsNullOrEmpty(contents)) return contents;
            int totalCount = System.Text.Encoding.Default.GetByteCount(contents);
            if (totalCount <= length) return contents;

            int x = 0;
            int index = 0;
            char[] chars = contents.ToCharArray();
            foreach (var item in chars)
            {
                int count = System.Text.Encoding.Default.GetByteCount(chars, index, 1);
                int tmp = x + count;
                if (tmp > length)
                {
                    string contact = contents.Substring(0, index);
                    return append ? contact + "..." : contact;
                }
                else
                {
                    x = tmp;
                }
                index++;
            }
            return contents;
        }
    }
}
