using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
using BLL;
namespace WebApp.Admins.Users
{
    public partial class Users_List : System.Web.UI.Page
    {
        private readonly  UsersService usersSvc = new UsersService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            object ob = Session["LoginOk"];
            if (ob == null)
            {
                Response.Write("<script>alert('账号过期,请重新登入');location.href='../Login.aspx'</script>");
            }

            Bind("");
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            Bind(this.txtSearch.Text);
        }

        protected void AspNetPager1_OnPageChanging(object src, PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            Bind(this.txtSearch.Text);
        }

        public void Bind(string nickName)
        {
            var data = usersSvc.GetUsersByNickName(nickName);
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = data;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1; //设置当前页面从第一页开始,下标为0
            pds.PageSize = AspNetPager1.PageSize;
            AspNetPager1.RecordCount = data.Count;

            this.RepUsersList.DataSource = pds;
            this.RepUsersList.DataBind();
        }
    }
}