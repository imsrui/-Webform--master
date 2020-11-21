using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace WebApp.Admins.LoanChoose
{
    public partial class LoanChoose_Edit : System.Web.UI.Page
    {
        private readonly LoanTypeService typeSvc = new LoanTypeService();
        private readonly LoanChooseService chooseSvc = new LoanChooseService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            #region 下拉列表绑定

            this.ddlLoanType.DataSource = typeSvc.GetAll();
            this.ddlLoanType.DataValueField = "LoanType_Id";
            this.ddlLoanType.DataTextField = "LoanType_Title";
            this.ddlLoanType.DataBind();

            #endregion

        }


        public void Bind()
        {
            var id = Request.Params["action"] == null ? Guid.Empty : Guid.Parse(Request.Params["action"]);
            if (id == Guid.Empty)
            {
                var rm = new ReturnMsg()
                {
                    Code = StatusCode.NotFound,
                    Message = "数据丢失,请稍后再试",
                    Data = null
                };
                Session["Msg"] = rm;
                Response.Redirect("LoanChoose_List.aspx");
            }
            else
            {
                var data = chooseSvc.GetLoanChooseById(id);
                this.hfLoanChooseId.Value = data.LoanChoose_Id.ToString();
                this.txtLoanChooseContent.Value = data.LoanChoose_Detail;
                this.ddlLoanType.SelectedValue = data.LoanType_Id.ToString();
            }

           

        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            var model = new Model.LoanChoose
            {
                LoanChoose_Id = Guid.Parse(this.hfLoanChooseId.Value),
                LoanChoose_Detail =  this.txtLoanChooseContent.Value,
                LoanType_Id = Guid.Parse(this.ddlLoanType.SelectedValue),
                LoanChoose_UpdateTime = DateTime.Now
            };
            var res = chooseSvc.Edit(model);
            var rm = res > 0 ? new ReturnMsg()
            {
                Code = StatusCode.Ok,
                Message = "编辑贷款条款成功",
                Data = null
            } : new ReturnMsg()
            {
                Code = StatusCode.Error,
                Message = "编辑贷款条款失败",
                Data = null
            };
            Session["Msg"] = rm;
            Response.Redirect("LoanChoose_List.aspx");
        }

        protected void btnReset_OnClick(object sender, EventArgs e)
        {
            Bind();
        }
    }
}