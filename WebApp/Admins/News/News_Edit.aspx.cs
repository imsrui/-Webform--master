using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebApp.Admins.News
{
    public partial class News_Edit : System.Web.UI.Page
    {
        private readonly  NewsService newsSvc = new NewsService();
        public string imgSrc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            Bind();
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            var id = Guid.Parse(this.hfNewsId.Value);
            var data = newsSvc.GetNewsById(id);
            var img = upFileName(FileUpload1, "../../upload/news/");
            if (img != "")
            {
                data.News_Image = img;
            }

            data.News_Title = this.txtName.Text;
            data.News_Content = this.txtNewsContent.Value;
            data.News_UpdateTime = DateTime.Now;
            var rs = newsSvc.Edit(data);
            var rm = rs > 0 ? new ReturnMsg()
            {
                Code = StatusCode.Ok,
                Message = "修改新闻成功",
                Data = null
            } : new ReturnMsg()
            {
                Code = StatusCode.Error,
                Message = "修改新闻失败",
                Data = null
            };
            Session["Msg"] = rm;
            Response.Redirect("News_List.aspx");

        }

        protected void btnReset_OnClick(object sender, EventArgs e)
        {
            Bind();
        }


        public void Bind()
        {
            var id = Request.Params["action"] == null ? Guid.Empty : Guid.Parse(Request.Params["action"]);
            var data = newsSvc.GetNewsById(id);
            if (data == null)
            {
                ReturnMsg rm = new ReturnMsg()
                {
                    Code = StatusCode.Error,
                    Message = "数据丢失,请稍后再试",
                    Data = null
                };
                Session["Msg"] = rm;
                Response.Redirect("News_List.aspx");
            }
            else
            {
                this.hfNewsId.Value = data.News_Id.ToString();
                this.txtName.Text = data.News_Title;
                this.txtNewsContent.Value = data.News_Content;
                imgSrc = data.News_Image;
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