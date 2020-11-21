using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Web
{
    public partial class Loan : System.Web.UI.Page
    {
        private readonly LoanTypeService typeSvc = new LoanTypeService();
        private readonly LoanChooseService chooseSvc = new LoanChooseService();
        private readonly ProductService proSvc = new ProductService();
        private readonly SeosService seoSvc = new SeosService();
        public string productDetail = "", title = "", keyword = "", description = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            var type = Request.Params["type"];

            #region 贷款产品介绍绑定
            switch (type)
            {
                case "credit":
                    title = "信用贷款";
                    break;
                case "house":
                    title = "房产贷款";
                    break;
                case "car":
                    title = "车辆贷款";
                    break;
                case "company":
                    title = "企业贷款";
                    break;
                case "person":
                    title = "我要贷款";
                    break;

            }
            var data = typeSvc.GetLoanTypesByTitle(title).FirstOrDefault();
            productDetail = proSvc.GetProductByLoanTypeId(data.LoanType_Id).Product_Detail;

            #endregion

            #region 贷款条件绑定
            var chooseData = chooseSvc.GetLoanChooseByLoanTypeId(data.LoanType_Id);
            this.RepChoose.DataSource = chooseData;
            this.RepChoose.DataBind();
            #endregion


            #region Seo优化
            var seoModel = seoSvc.GetSeosByTitle(title).FirstOrDefault();
            if (seoModel != null)
            {
                keyword = seoModel.Seos_Keyword;
                description = seoModel.Seos_Description;
            }
            else 
            {
                keyword = title;
                description = title;
            }
            #endregion

        }
    }
}