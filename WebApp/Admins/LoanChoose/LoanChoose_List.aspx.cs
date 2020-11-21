using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace WebApp.Admins.LoanChoose
{
    public partial class LoanChoose_List : System.Web.UI.Page
    {
        private readonly LoanChooseService chooseSvc = new LoanChooseService();
        private readonly LoanTypeService typeSvc = new LoanTypeService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            Bind("");
        }

        public void Bind(string title)
        {
            var data = chooseSvc.GetLoanChooseByTitle(title);
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = data;
            pds.AllowPaging = true;
            pds.PageSize = AspNetPager1.PageSize;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            AspNetPager1.RecordCount = data.Count;

            this.RepLoanChooseList.DataSource = pds;
            this.RepLoanChooseList.DataBind();
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

        public string GetLoanTypeName(Guid loanTypeId)
        {
            var data = typeSvc.GetLoadTypeById(loanTypeId);

            return data == null ? "" : data.LoanType_Title;
        }

    }
}