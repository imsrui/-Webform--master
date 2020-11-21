using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebApp.Admins.News
{
    public partial class News_Add : System.Web.UI.Page
    {
        private readonly NewsService newsSvc = new NewsService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            Model.News news = new Model.News()
            {
                News_Title = this.txtName.Text,
                News_Content = this.txtNewsContent.Value,
                News_Image = upFileName(FileUpload1,"../../upload/news/")
            };

            var res = newsSvc.Add(news);
            ReturnMsg rs = res > 0
                ? new ReturnMsg()
                {
                    Code = StatusCode.Ok,
                    Message = "添加新闻成功",
                    Data = null
                }
                : new ReturnMsg()
                {
                    Code = StatusCode.Error,
                    Message = "添加新闻失败",
                    Data = null
                };
            Session["Msg"] = rs;
            Response.Redirect("News_List.aspx");
        }

        protected void btnReset_OnClick(object sender, EventArgs e)
        {
            this.txtName.Text = this.txtNewsContent.Value = "";
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