using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebApp.Web
{
    public partial class About : System.Web.UI.Page
    {
        private readonly  AboutService aboutSvc = new AboutService();
        public string title = "", content = "", time = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            var data = aboutSvc.GetAll();
            title = data.About_Title;
            content = data.About_Content;
            time = data.About_UpdateTime.ToString("yyyy年MM月dd日");
        }
    }
}