using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

namespace WebApp.Admins.Order
{
    public partial class Examine_Edit : System.Web.UI.Page
    {
        private readonly OrderService orderSvc = new OrderService();
        private readonly ExamineService examineSvc = new ExamineService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            Bind();
        }


        public void Bind()
        {
            var id = Request.Params["action"] == null ? Guid.Empty : Guid.Parse(Request.Params["action"]);
            var data = examineSvc.GetExamineByOrderId(id);
            if (data != null)
            {
                //这个是代表我们审核信息是存在的,我们进行正常的绑定
                this.hfOrderId.Value = id.ToString();
                this.hfExamineId.Value = data.Examine_Id.ToString();
                this.txtName.Text = orderSvc.GetOrderName(id);
                this.ddlResult.SelectedValue = data.Examine_Result;
                this.txtExamineContent.Value = data.Examine_Reason;
            }
            else
            {
                this.hfOrderId.Value = id.ToString();
                this.ddlResult.SelectedValue = "审核未通过";
                this.txtName.Text = orderSvc.GetOrderName(id);
            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            ReturnMsg msg = null;
            if (this.hfExamineId.Value == "")
            {
                //新增
                var model = new Examine
                {
                    Examine_OrderId = Guid.Parse(this.hfOrderId.Value),
                    Examine_Result = this.ddlResult.SelectedValue,
                    Examine_Reason = this.txtExamineContent.Value
                };

                var res = examineSvc.Add(model);
                msg = res > 0 ? new ReturnMsg()
                {
                    Code = StatusCode.Ok,
                    Message = "编辑审核信息成功",
                    Data = null
                } : new ReturnMsg()
                {
                    Code = StatusCode.Ok,
                    Message = "编辑审核信息失败",
                    Data = null
                };
            }
            else
            {
                //执行修改

                var model = new Examine
                {
                    Examine_Id = Guid.Parse(this.hfExamineId.Value),
                    Examine_OrderId = Guid.Parse(this.hfOrderId.Value),
                    Examine_Result = this.ddlResult.SelectedValue,
                    Examine_Reason = this.txtExamineContent.Value,
                };

                var res = examineSvc.Edit(model);
                msg = res > 0 ? new ReturnMsg()
                {
                    Code = StatusCode.Ok,
                    Message = "编辑审核信息成功",
                    Data = null
                } : new ReturnMsg()
                {
                    Code = StatusCode.Ok,
                    Message = "编辑审核信息失败",
                    Data = null
                };
            }
            Session["Msg"] = msg;

            orderSvc.ContactOrder(Guid.Parse(this.hfOrderId.Value));

            Response.Redirect("Order_List.aspx");
        }

        protected void btnReset_OnClick(object sender, EventArgs e)
        {
            Bind();
        }
    }
}