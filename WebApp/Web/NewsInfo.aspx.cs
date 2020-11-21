using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebApp.Web
{
    public partial class NewsInfo : System.Web.UI.Page
    {
        private readonly NewsService newsSvc = new NewsService();
        public string title = "", content = "", time = "";
        public string preLink = "", preTitle = "";
        public string nextLink = "", nextTitle = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;


            var id = Request.Params["id"] == null ? Guid.Empty : Guid.Parse(Request.Params["id"]);
            var data = newsSvc.GetNewsById(id);
            if (data == null)
            {
                Response.Redirect("NewsList.aspx");
            }
            else
            {
                title = data.News_Title;
                content = data.News_Content;
                time = data.News_CreateTime.ToString("yyyy年MM月dd日");


                var preInfo = newsSvc.GetNewsPre(data.News_CreateTime);
                if (preInfo == null)
                {
                    preLink = data.News_Id.ToString();
                    preTitle = "当前是首页";
                }
                else
                {
                    preLink = preInfo.News_Id.ToString();
                    preTitle = preInfo.News_Title;
                }

                

                var nextInfo = newsSvc.GetNewsNext(data.News_CreateTime);
                if (nextInfo == null)
                {
                    nextLink = data.News_Id.ToString(); 
                    nextTitle = "当前是尾页";
                }
                else
                {
                    nextLink = nextInfo.News_Id.ToString();
                    nextTitle = nextInfo.News_Title;
                }

               

            }








        }
    }
}