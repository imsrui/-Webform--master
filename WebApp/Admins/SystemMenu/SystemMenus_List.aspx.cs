using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Admins.SystemMenu
{
    public partial class SystemMenus_List : System.Web.UI.Page
    {
        private readonly SystemMenusService menuSvc = new SystemMenusService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            var ob = Session["LoginOk"];
            if (ob == null) 
            {
                Response.Write("<script>alert('登入超时,请重新登入');location.href='../Login.aspx'</script>");
            }
            Bind(""); //调用我们下面自己写的绑定方法
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bind(this.txtSearch.Text);
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            Bind(this.txtSearch.Text);
        }

        public void Bind(string title) 
        {
            var data = menuSvc.GetSystemMenuByTitle(title);
            //下面开始分页插件的绑定使用
            PagedDataSource pds = new PagedDataSource();

            pds.DataSource = data;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;
            pds.AllowPaging = true;
            AspNetPager1.RecordCount = data.Count;

            this.RepSystemMenusList.DataSource = pds;
            this.RepSystemMenusList.DataBind();
        }

        public string GetMenusTitle(Guid id) 
        {
            if (id == Guid.Empty) 
            {
                return "一级菜单";
            }
            var data = menuSvc.GetSystemMenus(id);
            return data.SystemMenus_Title;
        }
    }
}