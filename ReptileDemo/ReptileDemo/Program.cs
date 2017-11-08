using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

namespace Reptile
{
    class Program
    {
        static void Main(string[] args)
        {

            ////抓去网上图片，下载到指定路径
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            //下载源网页代码  
            string html = wc.DownloadString("https://dongxi.douban.com/articles/");
            MatchCollection matches = Regex.Matches(html, "<img.*src=\"(.+?)\".*>");
            foreach (Match item in matches)
            {
                //下载图片到指定路径  
                wc.DownloadFile(item.Groups[1].Value, @"E:\pic\" + Path.GetFileName(item.Groups[1].Value));
            }

            //博客园大神文章列表 及阅读详情
            //WebClient wc = new WebClient();
            //wc.Encoding = Encoding.UTF8;
            //string html = wc.DownloadString("http://www.cnblogs.com/artech/");
            //MatchCollection matches = Regex.Matches(html, "\">(.*?)</a>");
            //foreach (Match item in matches)
            //{

            //    if (item.Groups[1].Value.Contains("c_b_p_desc") )
            //    {
            //    }
            //    else
            //    {
            //       string str =  ReplaceHtmlTag(item.Groups[1].Value);
            //       Console.WriteLine(str); 
            //    }
            //}

            //string url = "http://zhidao.baidu.com/link?url=cvF0de2o9gkmk3zW2jY23TLEUs6wX-79E1DQVZG7qaBhEVT_xlh6TO7p0W4qwuAZ_InLymC_-mJBBcpdbzTeq_";
            //WebClient wc = new WebClient();
            //wc.Encoding = Encoding.UTF8;
            //string str = wc.DownloadString(url);
            //MatchCollection matchs = Regex.Matches(str, @"\w+@([-\w])+([\.\w])+", RegexOptions.ECMAScript);
            //foreach (Match item in matchs)
            //{
            //    Console.WriteLine(item.Value);
            //}
            //Console.WriteLine(matchs.Count);  


        }
        /// <summary>
        /// 去除html代码
        /// </summary>
        /// <param name="html"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string ReplaceHtmlTag(string html, int length = 0)
        {
            string strText = System.Text.RegularExpressions.Regex.Replace(html, "<[^>]+>", "");
            strText = System.Text.RegularExpressions.Regex.Replace(strText, "&[^;]+;", "");

            if (length > 0 && strText.Length > length)
                return strText.Substring(0, length);

            return strText;
        }
    }
}
