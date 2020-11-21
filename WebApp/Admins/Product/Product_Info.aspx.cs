using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
namespace WebApp.Admins.Product
{
    public partial class Product_Info : System.Web.UI.Page
    {
        private readonly LoanTypeService typeSvc = new LoanTypeService();
        private readonly ProductService proSvc = new ProductService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            Bind();

            var id = Guid.Parse(this.ddlLoanType.SelectedValue);
            var data = proSvc.GetProductByLoanTypeId(id);
            if (data != null)
            {
                this.txtProductContent.Value = data.Product_Detail;
            }
        }


        public void Bind() 
        {
            #region 绑定下拉列表
            this.ddlLoanType.DataSource = typeSvc.GetAll();
            this.ddlLoanType.DataValueField = "LoanType_Id";
            this.ddlLoanType.DataTextField = "LoanType_Title";
            this.ddlLoanType.DataBind();
            #endregion
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var id = Guid.Parse(this.ddlLoanType.SelectedValue);
            int res = 0;
            var data = proSvc.GetProductByLoanTypeId(id);
            if (data == null)
            {
                data = new Model.Product()
                {
                    LoanType_Id = Guid.Parse(this.ddlLoanType.SelectedValue),
                    Product_Detail = this.txtProductContent.Value
                };
                res = proSvc.Add(data);
            }
            else 
            {
                data.LoanType_Id = Guid.Parse(this.ddlLoanType.SelectedValue);
                data.Product_Detail = this.txtProductContent.Value;
                res = proSvc.Edit(data);
            }
            var rm = res > 0 ? new ReturnMsg {
                Code = StatusCode.Ok,
                Message = "编辑产品介绍成功",
                Data = null
            } : new ReturnMsg {
                Code = StatusCode.Error,
                Message = "编辑产品介绍失败",
                Data = null
            };
            Session["Msg"] = rm;
            Response.Redirect("Product_Info.aspx");

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Bind();
        }

        protected void ddlLoanType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = Guid.Parse(this.ddlLoanType.SelectedValue);
            var data = proSvc.GetProductByLoanTypeId(id);
            if (data != null)
            {
                this.txtProductContent.Value = data.Product_Detail;
            }
            else 
            {
                this.txtProductContent.Value = "";
            }
        }
    }
}