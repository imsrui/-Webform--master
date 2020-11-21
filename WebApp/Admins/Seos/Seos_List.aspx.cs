using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Wuqi.Webdiyer;

namespace WebApp.Admins.Seos
{
    public partial class Seos_List : System.Web.UI.Page
    {
        private readonly  SeosService seoSvc = new SeosService();
        private readonly  WebMenusService menusSvc = new WebMenusService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            Bind("");

        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            Bind(this.txtSearch.Text);
        }


        public string getWebMenuTitle(Guid id)
        {
            var data = menusSvc.GetWebMenus(id);
            if (data == null)
                return "";
            else
                return data.WebMenus_Title;
        }

        protected void AspNetPager1_OnPageChanging(object src, PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            Bind(this.txtSearch.Text);
        }

        public void Bind(string title)
        {
            var data = seoSvc.GetSeosByTitle(title);

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = data;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            AspNetPager1.RecordCount = data.Count;
            pds.PageSize = AspNetPager1.PageSize;

            this.RepSeosList.DataSource = pds;
            this.RepSeosList.DataBind();

        }
    }
}