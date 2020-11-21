using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebApp.Admins.LoanType
{
    public partial class LoanType_Add : System.Web.UI.Page
    {
        private readonly LoanTypeService typeSvc = new LoanTypeService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            var res = typeSvc.Add(new Model.LoanType()
            {
                LoanType_Title =  this.txtName.Text,
                LoanType_Detail = this.txtTypeContent.Value,
                LoanType_Image =  upFileName(FileUpload1,"../../upload/loantype/"),
                LoanType_IsShow = this.rbHidden.Checked ? 0 : 1
            });

            var rm = res > 0 ? new ReturnMsg()
            {
                Code = StatusCode.Ok,
                Message = "新增贷款类型成功",
                Data = null
            } : new ReturnMsg()
            {
                Code = StatusCode.Error,
                Message = "新增贷款类型失败",
                Data = null
            };
            Session["Msg"] = rm;
            Response.Redirect("LoanType_List.aspx");
        }

        protected void btnReset_OnClick(object sender, EventArgs e)
        {
            this.txtTypeContent.Value = this.txtName.Text = "";
        }


        #region 上传图像
        public string upFileName(FileUpload f, string url)
        {
            string res = "";
            try
            {
                Random ran = new Random();
                string filePath = f.FileName;
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Convert.ToString(ran.Next(1, 1 + 9999));
                if (filePath != "")
                {
                    string fileType = filePath.Substring(filePath.LastIndexOf(".") + 1);
                    //string filePic = Server.MapPath(url + filePath);
                    string filePic = Server.MapPath(url + fileName + "." + fileType);
                    f.PostedFile.SaveAs(filePic);
                    res = fileName + "." + fileType;
                }
            }
            catch (Exception ex)
            {
                res = "";
            }


            return res;
        }
        #endregion
    }
}