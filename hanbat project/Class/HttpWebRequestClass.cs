using hanbat_project.CustomClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace hanbat_project.Class
{
    public class HttpWebRequestClass
    {

        object obj;
        CookieContainer cookies = new CookieContainer();

        #region [ Construct ]

        public HttpWebRequestClass(object obj)
        {
            this.obj = obj;
        }

        #endregion

    }
}
