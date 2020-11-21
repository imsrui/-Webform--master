using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Wuqi.Webdiyer;

namespace WebApp.Web
{
    public partial class NewsList : System.Web.UI.Page
    {
        private readonly NewsService newsSvc = new NewsService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            var data = newsSvc.GetAll();
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = data;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            AspNetPager1.RecordCount = data.Count;
            pds.PageSize = AspNetPager1.PageSize;

            this.RepNewsList.DataSource = pds;
            this.RepNewsList.DataBind();

        }




        protected void AspNetPager1_OnPageChanging(object src, PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        }
    }
}