using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace WebApp.Admins.LoanChoose
{
    public partial class LoanChoose_Add : System.Web.UI.Page
    {
        private readonly LoanTypeService typeSvc = new LoanTypeService();
        private readonly LoanChooseService chooseSvc = new LoanChooseService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            Bind(); //这个是下拉列表绑定

        }

        public void Bind()
        {
            this.ddlLoanType.DataSource = typeSvc.GetAll();
            this.ddlLoanType.DataTextField = "LoanType_Title";
            this.ddlLoanType.DataValueField = "LoanType_Id";
            this.ddlLoanType.DataBind();
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var res = chooseSvc.Add(new Model.LoanChoose
            {
                LoanChoose_Detail = this.txtLoanChooseContent.Value,
                LoanType_Id = Guid.Parse(this.ddlLoanType.SelectedValue)
            });

            var rm = res > 0 ? new ReturnMsg
            {
                Code = StatusCode.Ok,
                Message = "新增贷款条件成功",
                Data = null
            } : new ReturnMsg
            {
                Code = StatusCode.Error,
                Message = "新增贷款条件失败",
                Data = null
            };
            Session["Msg"] = rm;
            Response.Redirect("LoanChoose_List.aspx");

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            this.txtLoanChooseContent.Value = "";
            this.ddlLoanType.SelectedIndex = 0;
        }
    }
}