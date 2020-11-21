using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebApp.Web
{
    public partial class index : System.Web.UI.Page
    {
        private readonly NewsService newsSvc = new NewsService();
        private readonly SeosService seoSvc = new SeosService();
        private readonly LoanTypeService typeSvc = new LoanTypeService();
        public string title = "", keyword = "", description = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            //var data = seoSvc.GetSeos("首页");
            //title = data.Seos_Title;
            //keyword = data.Seos_Keyword;
            //description = data.Seos_Description;
            #region Seo优化
            var data = seoSvc.GetSeosByWebMenuId(Guid.Parse("375D112E-4684-463C-8812-66326799D877"));
            if (data == null)
            {
                title = "好信速贷首页";
                keyword = "好信速贷";
                description = "好信速贷";
            }
            else
            {
                title = data.Seos_Title;
                keyword = data.Seos_Keyword;
                description = data.Seos_Description;
            }
            #endregion

            #region 新闻列表绑定
            this.RepNewsList.DataSource = newsSvc.GetNewsTopFour();
            this.RepNewsList.DataBind();
            #endregion

            #region 贷款类型绑定

            this.RepLoanTypeList.DataSource = typeSvc.GetLoanTypesByIsShow();
            this.RepLoanTypeList.DataBind();
            #endregion


        }
    }
}