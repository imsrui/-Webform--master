using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace WebApp.Admins.LoanChoose
{
    public partial class LoanChoose_Remove : System.Web.UI.Page
    {
        private readonly LoanChooseService chooseSvc = new LoanChooseService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
                return;


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
                var res = chooseSvc.PutTrash(id);
                var rm = res > 0 ? new ReturnMsg()
                {
                    Code = StatusCode.Ok,
                    Message = "放入回收站成功",
                    Data = null
                }: new ReturnMsg()
                {
                    Code = StatusCode.Error,
                    Message = "放入回收站失败",
                    Data = null
                };
            }

        }
    }
}