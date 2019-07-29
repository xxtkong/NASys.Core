using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;

namespace NASys.Core.Domain.Core.Common
{
    public static class ConvertHelper
    {
        public static string ExtendFile<T>(this T t, string fileName, string def = "")
        {
            if (t == null)
                return def;
            else
            {
                return typeof(T).GetProperty(fileName).GetValue(t) != null ? typeof(T).GetProperty(fileName).GetValue(t).ToString() : def;
            }
        }
        public static string StringDefault(this string str, string def)
        {
            if (string.IsNullOrEmpty(str))
                return def;
            return str;
        }

        public static string[] StrByArr(this string str, char split = ',')
        {

            if (split == ',')
            {
                if (string.IsNullOrEmpty(str))
                {
                    return new string[] { "" };
                }
                return str.Split(',');
            }
            else
            {
                return str.Split(split);
            }

        }
        public static int? IntByStr(this string str, int? def = 0)
        {
            if (string.IsNullOrEmpty(str))
            {
                return def;
            }
            int i;
            int.TryParse(str, out i);
            return i;
        }

        public static decimal? DecimalByStr(this string str, decimal? def = 0)
        {
            if (string.IsNullOrEmpty(str))
            {
                return def;
            }
            decimal i;
            decimal.TryParse(str, out i);
            return i;
        }

        public static DateTime? DateTimeByStr(this string str, DateTime? def = null)
        {
            if (string.IsNullOrEmpty(str))
            {
                return def;
            }
            DateTime i;
            DateTime.TryParse(str, out i);
            return i;
        }
        /// <summary>
        /// 时间格式转换
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string StrByDateTime(this DateTime? dt, string format = "yyyy-MM-dd")
        {
            if (dt == null)
                return "";
            return dt.Value.ToString(format);

        }
        public static string StrByObj(this object str)
        {
            if (str == null)
                return null;
            return str.ToString();
        }
        public static int IntByObj(this object str)
        {
            if (str == null)
                return 0;
            return Convert.ToInt32(str);
        }
        public static string StrByDecimal(this decimal? d, string def)
        {
            if (d == null)
                return def;
            else
                return d.ToString();
        }
        public static string DefaultPrice(this decimal? d, string def)
        {
            if (d == null || d.Value == 0)
                return def;
            else
                return d.ToString();
        }

        public static void Add<T>(this IEnumerable<T> collection, T value)
        {
            (collection as List<T>).Add(value);
        }
        /// <summary>
        /// 从集合中删除元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="value"></param>
        public static void Remove<T>(this IEnumerable<T> collection, T value)
        {
            (collection as List<T>).Remove(value);
        }
        /// <summary>
        /// 检索集合中是否包含某个元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool STContains<T>(this IEnumerable<T> collection, T value)
        {
            return (collection as List<T>).Contains(value);
        }

        public static string CommonState(this int? s)
        {
            if (s == null)
                return "删除";
            else
            {
                return Enum.GetName(typeof(CommonState), s);
            }
        }
        public static string CommonStateByShort(this short s)
        {
            return Enum.GetName(typeof(CommonState), s);
        }

        public static string ConvertEnumByShort<T>(this short s)
        {
            return Enum.GetName(typeof(T), s);
        }
        public static string ConvertEnum<T>(this int? s)
        {
            if (s == null)
                return "";

            return Enum.GetName(typeof(T), s);
        }

        public static int ConvertInt(this int? i)
        {
            if (i == null)
                return 0;
            return i.Value;
        }

        /// <summary>
        /// 系统通知类-是否阅读
        /// </summary>
        public static string ReadState(this int? s)
        {
            if (s == 0)
                return "未读";
            else
            {
                return "已读";
            }
        }

        /// <summary>
        /// 系统通知类-消息类型
        /// </summary>
        public static string MessageType(this int? s)
        {
            if (s == 0)
                return "个人";
            else
            {
                return "全体";
            }
        }
        public static long ObjectToInt64(object expression, long defValue)
        {
            if (expression != null)
                return StrToInt64(expression.ToString(), defValue);

            return defValue;
        }
        public static float StrToFloat(object strValue)
        {
            if ((strValue == null))
                return 0;

            return StrToFloat(strValue.ToString(), 0);
        }
        /// <summary>
        /// string型转换为float型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static float StrToFloat(string strValue, float defValue)
        {
            if ((strValue == null))
                return defValue;

            float intValue = defValue;
            if (strValue != null)
            {
                //bool IsFloat = Regex.IsMatch(strValue, @"^([-]|[0-9])[0-9]*(\.\w*)?$");
                //if (IsFloat)
                if (!float.TryParse(strValue, out intValue))
                    return defValue;
            }
            return intValue;
        }
        /// <summary>
        /// string型转换为Long型
        /// </summary>
        /// <param name="source">字符串</param>
        /// <param name="defValue">默认值</param>
        /// <returns></returns>
        public static long StrToInt64(string source, long defValue)
        {
            long result = 0;
            try
            {
                result = Convert.ToInt64(source);
            }
            catch
            {
                result = defValue;
            }
            return result;
        }

        public static TSource YDBSFirst<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                return default(TSource);
            }
            var c = source.Count(predicate);
            if (c > 0)
                return source.First(predicate);
            return default(TSource);

        }

        public static void YDBSEach(this string[] source, Action<string> predicate)
        {
            foreach (var item in source)
            {
                predicate(item);
            }
        }
        public static void Each<T>(this IEnumerable<T> source, Action<T> predicate)
        {
            foreach (var item in source)
            {
                predicate(item);
            }
        }

        public static string StringSum<T>(this IEnumerable<T> source, Expression<Func<T, string>> predicate)
        {
            StringBuilder sb = new StringBuilder();
            source.Each(s =>
            {
                var value = predicate.Compile().Invoke(s);
                sb.Append(value + ",");
            });
            if (sb.Length > 0)
                return sb.ToString().TrimEnd(',');
            return "";
        }

        //public static string YDBSReplace<TSource>(this string str,char o,char n)
        //{
        //    if (string.IsNullOrEmpty(str))
        //        return default(string);
        //    else {
        //        return str.Replace(o, n);
        //    }
        //}
        public static string YDBSReplace(this string str, string o, string n)
        {
            if (string.IsNullOrEmpty(str))
                return default(string);
            else
            {
                return str.Replace(o, n);
            }
        }
        public static string[] YDBSSplit(this string str, params char[] separator)
        {
            if (string.IsNullOrEmpty(str))
                return new string[0];
            else
            {
                return str.Split(separator);
            }
        }
        public static IEnumerable<TSource> YDBSTake<TSource>(this IEnumerable<TSource> source, int count)
        {
            if (source == null)
                return null;
            else
            {
                if (count > source.Count())
                {
                    return source.Take(source.Count());
                }
                return source.Take(count);
            }
        }
        public static IEnumerable<TSource> YDBSSkip<TSource>(this IEnumerable<TSource> source, int count)
        {
            if (source == null)
                return null;
            else
            {
                if (count > source.Count())
                {
                    return source.Skip(source.Count());
                }
                return source.Skip(count);
            }
        }

        public static int[] StrByIntArr(this string[] str)
        {
            return Array.ConvertAll<string, int>(str, delegate (string s) { return int.Parse(s); });
        }
        public static string StrArrByStr(this string[] str)
        {
            return string.Join(",", str);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val">需要替换的对象</param>
        /// <param name="bIndex">开始替换的位置</param>
        /// <param name="aLength">星号的长度</param>
        /// <param name="length">替换的长度：默认为0，为0表示替换开始位置后的所有字符串，大于0表示替换指定长度的字符串</param>
        /// <param name="eLength">尾部保留几位固定长度，大于0时aLength、length无效</param>
        /// <returns></returns>
        public static string ToStrAsterisk(this string val, int bIndex, int aLength = 3, int length = 0, int eLength = 0)
        {
            if (val == null)
                return "";
            var str = val.ToString();
            if (bIndex < 0 || aLength < 0 || length < 0)
                return str;
            int vCont = System.Text.Encoding.Default.GetByteCount(str);
            if (bIndex >= vCont)
                return str;
            string tmp = SubStrPlus(str, bIndex);
            if (eLength > 0)
            {
                if (vCont > (bIndex + eLength))
                {
                    var endStr = SubStrPlus(str, vCont - eLength, eLength);
                    tmp = tmp.PadRight(str.Length - endStr.Length, '*');
                    tmp += endStr;
                }
                else
                    tmp = str;
            }
            else if (length > 0)
            {
                if (vCont - bIndex > length)
                {
                    var asteriskStr = SubStrPlus(str, bIndex, length);
                    tmp = tmp.PadRight(tmp.Length + asteriskStr.Length, '*')
                        + SubStrPlus(str, bIndex + length, vCont - bIndex - length);
                }
                else
                {
                    tmp = tmp.PadRight(str.Length, '*');
                }
            }
            else
            {
                tmp = tmp.PadRight(tmp.Length + aLength, '*');
            }
            return tmp;
        }


        /// <summary>
        /// 截取字符串，不足一个字算一个字
        /// </summary>
        /// <param name="contents">内容</param>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string SubStrPlus(string contents, int length)
        {
            int len = length;
            return StringHelper.SubStr(contents, len, append: false);
        }
        /// <summary>
        /// 截取字符串，不足一个字算一个字
        /// </summary>
        /// <param name="contents">内容</param>
        /// <param name="startIndex">起始位置</param>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string SubStrPlus(string contents, int startIndex, int length)
        {
            string firstStr = SubStrPlus(contents, startIndex);
            Regex r = new Regex("(" + firstStr + "){1}");
            return SubStrPlus(r.Replace(contents, "", 1, 0), length);
        }
        //去掉html标签
        public static string NoHTML(string Htmlstring)
        {
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring = Htmlstring.Replace("&ldquo;", "“");
            Htmlstring = Htmlstring.Replace("&rdquo;", "”");

            Htmlstring = Htmlstring.Replace("<", "");
            Htmlstring = Htmlstring.Replace(">", "");
            Htmlstring = Htmlstring.Replace("\r\n", "");
            //Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;
        }

        /// <summary>
        /// 根据时间返回时间的所属区间（早上、中午、下午、晚上）
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToTimeDist(this DateTime date)
        {
            int hour = date.Hour;
            if (hour >= 5 && hour < 11)
                return "早上";
            else if (hour >= 11 && hour < 13)
                return "中午";
            else if (hour >= 13 && hour < 18)
                return "下午";
            else
                return "晚上";
        }

        public static bool IsEmpty(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
        public static bool IsMatch(this string str, string pattern)
        {
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
            return r.IsMatch(str);
        }
        public static bool IsMatch(this string str, string pattern, RegexOptions IgnoreCase)
        {
            Regex r = new Regex(pattern, IgnoreCase);
            return r.IsMatch(str);
        }


        public static string StrByInt(this int? i)
        {
            if (i == null)
                return "";
            else
                return i.Value.ToString();
        }


        public static List<KeyValuePair<String, String>> ExtendObj<T>(this T t)
        {
            List<KeyValuePair<String, String>> paramList = new List<KeyValuePair<string, string>>();
            var properties = typeof(T).GetProperties();
            foreach (var item in properties)
            {
                string name = item.Name;
                var val = item.GetValue(t);
                if (val == null)
                    val = "";
                var p = new KeyValuePair<string, string>(name, val.ToString());
                paramList.Add(p);
            }
            return paramList;
        }


        public static string ConventPrice(this decimal? price)
        {
            if (price == null)
                return "已售罄";
            else
            {
                if (price == 0)
                    return "面议";
                return price.ToString();
            }
        }


        /// <summary>
        /// 用于 as 的SQL语句。。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr"></param>
        /// <returns></returns>
        public static string GetPropertyName<T>(Expression<Func<T, object>> expr)
        {
            var result = "";
            if (expr.Body is UnaryExpression)
            {
                result = ((MemberExpression)((UnaryExpression)expr.Body).Operand).Member.Name;
            }
            else if (expr.Body is MemberExpression)
            {
                result = ((MemberExpression)expr.Body).Member.Name;
            }
            else if (expr.Body is ParameterExpression)
            {
                result = ((ParameterExpression)expr.Body).Type.Name;
            }
            return result;
        }

        /// <summary>
        /// decimal保留指定位数小数
        /// </summary>
        /// <param name="num">原始数量</param>
        /// <param name="scale">保留小数位数</param>
        /// <returns>截取指定小数位数后的数量字符串</returns>
        public static string ToString(this decimal num, int scale)
        {
            string numToString = num.ToString();

            int index = numToString.IndexOf(".");
            int length = numToString.Length;
            if (index != -1)
            {
                return string.Format("{0}.{1}",
                                  numToString.Substring(0, index),
                                  numToString.Substring(index + 1, Math.Min(length - index - 1, scale)));
            }
            else
            {
                return num.ToString();
            }
        }

        public static decimal ToDecimal(this decimal num, int scale)
        {
            decimal tempOdds = Math.Round(num, scale);
            if (tempOdds > num)
            {
                num = (decimal)((double)(tempOdds - (decimal)Math.Pow(10, -scale)));
            }
            else
            {
                num = (decimal)((double)tempOdds);
            }
            return num;
        }

        public static int ToSum(this int num)
        {
            char[] numArray = num.ToString().ToCharArray();
            int sum = 0;
            for (int i = 0; i < numArray.Length; i++)
            {
                sum += int.Parse(numArray[i].ToString());
            }
            return sum;
        }
    }
}
