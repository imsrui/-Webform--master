using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WebApp.Web.shared
{
    public partial class Frontend : System.Web.UI.MasterPage
    {
        private readonly WebMenusService webMenusSvc = new WebMenusService();
        private readonly AboutService aboutSvc = new AboutService();
        public string aboutContent = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            #region 绑定导航导航栏

            this.RepWebMenusList.DataSource = webMenusSvc.GetAllWhatIsShow();
            this.RepWebMenusList.DataBind();

            #endregion

            #region 绑定关于我们

            var data = aboutSvc.GetAll();
            aboutContent = data.About_Content;

            #endregion

        }
    }
}