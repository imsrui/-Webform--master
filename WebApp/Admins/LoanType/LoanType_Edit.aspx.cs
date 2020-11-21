using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebApp.Admins.LoanType
{
    public partial class LoanType_Edit : System.Web.UI.Page
    {
        private readonly LoanTypeService typeSvc = new LoanTypeService();
        public string imgUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            Bind();
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
           //1. 先去进行查询一次,我们对查询出来的数据进行更改

           var data = typeSvc.GetLoadTypeById(Guid.Parse(this.hfTypeId.Value));
           var img = upFileName(FileUpload1, "../../upload/loantype/");
           if (img != "")
           {
               data.LoanType_Image = img;
           }

           data.LoanType_Title = this.txtName.Text;
           data.LoanType_Detail = this.txtTypeContent.Value;
           data.LoanType_IsShow = this.rbHidden.Checked ? 0 : 1;

           var rs = typeSvc.Edit(data);

           var rm = rs > 0 ? new ReturnMsg()
           {
               Code = StatusCode.Ok,
               Message = "编辑成功",
               Data = null
           }: new ReturnMsg()
           {
               Code = StatusCode.Error,
               Message = "编辑失败",
               Data = null
           };
           Session["Msg"] = rm;
           Response.Redirect("LoanType_List.aspx");
        }

        protected void btnReset_OnClick(object sender, EventArgs e)
        {
            Bind();
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
                Response.Redirect("LoanType_List.aspx");

            }
            else
            {
                var data = typeSvc.GetLoadTypeById(id);
                this.hfTypeId.Value = data.LoanType_Id.ToString();
                this.txtName.Text = data.LoanType_Title;
                this.txtTypeContent.Value = data.LoanType_Detail;
                if (data.LoanType_IsShow == 1)
                {
                    this.rbShow.Checked = true;
                    this.rbHidden.Checked = false;
                }
                else
                {
                    this.rbHidden.Checked = true;
                    this.rbShow.Checked = false;
                }

                imgUrl = data.LoanType_Image;
            }
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