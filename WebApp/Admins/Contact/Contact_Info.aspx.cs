using System;

using System.Web.UI.WebControls;

using BLL;
using Model;
namespace WebApp.Admins.Contact
{
    public partial class Contact_Info : System.Web.UI.Page
    {
        private readonly ContactService contactSvc = new ContactService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            Bind();
        }

        public void Bind()
        {
            var data = contactSvc.GetAll();
            if (data != null)
            {
                this.hfContactId.Value = data.Contact_Id.ToString();
                this.txtAddress.Text = data.Contact_Address;
                this.txtPhone.Text = data.Contact_Phone;
                this.txtQQ1.Text = data.Contact_QQ1;
                this.txtQQ2.Text = data.Contact_QQ2;
                this.txtWeiBo.Text = data.Contact_Weibo;
                this.txtWeiXin.Text = data.Contact_Wechat;
                this.txtWorkTime.Text = data.Contact_WorkTime;
                if (string.IsNullOrEmpty(data.Contact_QRCode))
                {
                    this.Image1.Visible = false;
                }
                else
                {
                    this.Image1.ImageUrl = "../../upload/contact/" + data.Contact_QRCode;
                }
            }
            else
            {
                this.Image1.Visible = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int res = 0;
            if (this.hfContactId.Value == "" || this.hfContactId.Value == null)
            {
                //执行新增
                var model = new Model.Contact
                {
                    Contact_Address = this.txtAddress.Text,
                    Contact_Phone = this.txtPhone.Text,
                    Contact_QQ1 = this.txtQQ1.Text,
                    Contact_QQ2 = this.txtQQ2.Text,
                    Contact_QRCode = upFileName(FileUpload1, "../../upload/contact/"),
                    Contact_Wechat = this.txtWeiXin.Text,
                    Contact_Weibo = this.txtWeiBo.Text,
                    Contact_Email = this.txtEmail.Text,
                    Contact_Fax = this.txtFax.Text,
                    Contact_WorkTime = this.txtWorkTime.Text
                };

                res = contactSvc.Add(model);

            }
            else
            {
                //修改
                var model = contactSvc.GetAll();
                if (upFileName(FileUpload1, "../../upload/contact/") != "")
                {
                    model.Contact_QRCode = upFileName(FileUpload1, "../../upload/contact/");
                }
                model.Contact_Address = this.txtAddress.Text;
                model.Contact_Phone = this.txtPhone.Text;
                model.Contact_QQ1 = this.txtQQ1.Text;
                model.Contact_QQ2 = this.txtQQ2.Text;
                model.Contact_Wechat = this.txtWeiXin.Text;
                model.Contact_Weibo = this.txtWeiBo.Text;
                model.Contact_WorkTime = this.txtWorkTime.Text;
                model.Contact_Fax = this.txtFax.Text;
                model.Contact_Email = this.txtEmail.Text;


                res = contactSvc.Edit(model);
            }

            var rm = res > 0 ? new ReturnMsg
            {
                Code = StatusCode.Ok,
                Message = "编辑联系我们成功",
                Data = null
            } : new ReturnMsg
            {
                Code = StatusCode.Ok,
                Message = "编辑联系我们失败",
                Data = null
            };

            Session["Msg"] = rm;
            Response.Redirect("Contact_Info.aspx");
        }

        protected void btnReset_Click(object sender, EventArgs e)
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