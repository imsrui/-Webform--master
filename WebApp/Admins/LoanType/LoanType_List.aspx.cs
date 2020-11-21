using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Wuqi.Webdiyer;

namespace WebApp.Admins.LoanType
{
    public partial class LoanType_List : System.Web.UI.Page
    {
        private readonly LoanTypeService typeSvc = new LoanTypeService();
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

        protected void AspNetPager1_OnPageChanging(object src, PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            Bind(this.txtSearch.Text);
        }


        public void Bind(string title)
        {
            var data = typeSvc.GetLoanTypesByTitle(title);
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = data;
            pds.PageSize = AspNetPager1.PageSize;
            AspNetPager1.RecordCount = data.Count;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.AllowPaging = true;
            this.RepLoanTypeList.DataSource = pds;
            this.RepLoanTypeList.DataBind();
        }

    }
}