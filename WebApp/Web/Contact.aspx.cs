using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace WebApp.Web
{
    public partial class Contact : System.Web.UI.Page
    {
        private readonly ContactService contactSvc = new ContactService();
        public string tel = "", fax = "", email = "", address = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            Bind();
        }

        public void Bind()
        {
            var data = contactSvc.GetAll();
            tel = data.Contact_Phone;
            fax = data.Contact_Fax;
            email = data.Contact_Email;
            address = data.Contact_Address;
        }
    }
}