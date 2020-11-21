using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebApp.Admins.About
{
    public partial class About_List : System.Web.UI.Page
    {
        private readonly  AboutService aboutSvc = new AboutService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            Bind();
        }


        public void Bind()
        {
            var data = aboutSvc.GetAll();
            if (data != null)
            {
                this.hfAboutId.Value = data.About_Id.ToString();
                this.txtName.Text = data.About_Title;
                this.txtAboutContent.Value = data.About_Content;
            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            int res = 0;
            if (this.hfAboutId.Value == "")
            {
                //这种情况下我们去执行新增方法
              res =  aboutSvc.Add(new Model.About()
                {
                    About_Title = this.txtName.Text, 
                    About_Content = this.txtAboutContent.Value,
                    About_Image = upFileName(FileUpload1, "../../upload/about/")
                });
            }
            else
            {
                var oldModel = aboutSvc.GetAll();
                //这种情况下我们执行修改方法
                var imgName = upFileName(FileUpload1, "../../upload/about/");
                if (imgName != "")
                {
                    //我们上传图片了
                    oldModel.About_Image = imgName;
                }

                oldModel.About_Title = this.txtName.Text;
                oldModel.About_Content = this.txtAboutContent.Value;
                oldModel.About_UpdateTime = DateTime.Now;

                res = aboutSvc.Edit(oldModel);
            }

            ReturnMsg rm = res > 0 ? new ReturnMsg()
            {
                Code =  StatusCode.Ok,
                Message = "编辑成功",
                Data = null
            } : new ReturnMsg()
            {
                Code = StatusCode.Error,
                Message = "编辑失败",
                Data = null

            };
            Session["Msg"] = rm;
            Response.Redirect("About_List.aspx");
        }

        protected void btnReset_OnClick(object sender, EventArgs e)
        {
           Bind();
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