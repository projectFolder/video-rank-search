using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace WindowsFormsApp2.Class
{
    public class HttpWebRequetClass
    {

        private MainForm main;
        HttpWebRequest PostReq;

        #region [ Constructor ]

        public HttpWebRequetClass(MainForm main)
        {
            this.main = main;
        }

        #endregion

        #region [ Pc 검색 ]

        private String pc_searchKeyword(String keyWord, String searchUrl)
        {

            String Html;
            String[] pageVal = { "1", "17", "33", "49", "65", "81", "97", "113", "129", "145" };

            for (int i = 0; i < pageVal.Length - 1; i++)
            {

                int findIdx = 0;

                String Url = "https://s.search.naver.com/p/videosearch/search.naver?ssl=1&query=" + HttpUtility.UrlEncode(keyWord) + "&where=video&listmode=v&sort=rel&period=&playtime=&stype=&ptype=&spq=0&ac=1&aq=0&&selected_cp=&start=" + pageVal[i] + "&display=16&m=1&video_more=1&rev=43&sm=mtb_pge&x_video=cr^vdo_lst&_callback=videoMoreList";

                HttpWebRequest PostReq = (HttpWebRequest)WebRequest.Create(Url);
                PostReq.Method = "GET";
                PostReq.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.89 Safari/537.36";
                PostReq.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
                PostReq.Referer = "https://search.naver.com/search.naver?where=video&sort=rel&listmode=v&stype=&playtime=&period=&selected_cp=&ninth_cp=&query=";
                PostReq.Headers.Add("upgrade-insecure-requests", "1");

                WebResponse Res = PostReq.GetResponse();
                using (StreamReader Sr = new StreamReader(Res.GetResponseStream()))
                {
                    Html = Sr.ReadToEnd();
                }

                main.label4.Text = "PC에서 " + keyWord + " 키워드 " + i + "페이지를 검색중입니다.";

                foreach (String val in Html.Split(new String[] { "video_bx api_ani_send _svp_content" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (val.Contains(searchUrl))
                    {
                        main.label4.Text = keyWord + " 키워드 " + i + "페이지 " + findIdx + "위";
                        return (Convert.ToInt16(pageVal[i]) + findIdx) + "위";
                    }
                    findIdx += 1;
                }


                if (Convert.ToInt16(pageVal[i]) >= 145)
                {
                    break;
                }

            }
            return "결과없음";
        }

        #endregion

        #region [ mb 검색 ]

        private String mb_searchKeyword(String keyWord, String searchUrl)
        {

            String Html;
            int findIdx = 0;
            String[] pageVal = { "1", "16", "31", "46", "61", "76", "91", "106", "121", "136" };

            for (int i = 0; i < pageVal.Length - 1; i++)
            {
                String Url = "https://m.search.naver.com/search.naver?where=m_video&sm=mtb_jum&query=" + HttpUtility.UrlEncode(keyWord)  + "&start=" + pageVal[i] +"";
                HttpWebRequest PostReq = (HttpWebRequest)WebRequest.Create(Url);
                PostReq.Method = "GET";
                PostReq.UserAgent = "Mozilla/5.0 (Linux; Android 4.0.4; Galaxy Nexus Build/IMM76B) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.76 Mobile Safari/537.36";
                PostReq.Accept = "*/*";
                PostReq.Referer = "https://m.search.naver.com/search.naver?sm=mtb_hty.top&where=m_video&oquery=";

                WebResponse Res = PostReq.GetResponse();
                using (StreamReader Sr = new StreamReader(Res.GetResponseStream(), System.Text.Encoding.Default))
                {
                    Html = Regex.Split(Sr.ReadToEnd(), "video_clip_list _more_list mvli1 li1 _svp_list")[1];
                }
                
                main.label4.Text = "모바일에서 " + keyWord + " 키워드 " + i + "페이지를 검색중입니다.";

                if (Html.Contains(searchUrl))
                {
                    foreach (String val in Html.Split(new String[] { "info_area" }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        findIdx += 1;
                        if (val.Contains(searchUrl))
                        {
                            main.label4.Text = keyWord + " 키워드 " + i + "페이지 " + findIdx + "위";
                            return i + findIdx + "위";
                        }
                    }
                }

                if (Convert.ToInt16(pageVal[i]) >= 136)
                {
                    break;
                }

            }

            return "결과없음";
        }

        #endregion

        #region [ 순위 검색 ]

        public Tuple<String, String> getRank(String keyWord, String searchUrl)
        {

            String item1 = pc_searchKeyword(keyWord, searchUrl);
            String item2 = mb_searchKeyword(keyWord, searchUrl);

            return Tuple.Create(item1, item2);
        }

        #endregion

    }
}
