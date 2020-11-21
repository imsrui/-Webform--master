using Model;
using System;
using System.Linq;

namespace DAL
{
    public class ContactManager
    {
        public int Add(Contact model)
        {
            string sql = "insert into Contact(Contact_Id,Contact_Address,Contact_QQ1,Contact_QQ2,Contact_Wechat,Contact_Weibo,Contact_Phone,Contact_Worktime,Contact_QRCode,Contact_DeleteId,Contact_CreateTime,Contact_UpdateTime,Contact_Fax,Contact_Email) values(@Contact_Id,@Contact_Address,@Contact_QQ1,@Contact_QQ2,@Contact_Wechat,@Contact_Weibo,@Contact_Phone,@Contact_Worktime,@Contact_QRCode,@Contact_DeleteId,@Contact_CreateTime,@Contact_UpdateTime,@Contact_Fax,@Contact_Email)";
            return SqlHelper<Contact>.ExceuteNonQuery(sql, model);
        }


        public int Edit(Contact model)
        {
            string sql =
                "update Contact set Contact_Address=@Contact_Address,Contact_QQ1=@Contact_QQ1,Contact_QQ2=@Contact_QQ2,Contact_Wechat=@Contact_Wechat,Contact_Weibo=@Contact_Weibo,Contact_Phone=@Contact_Phone,Contact_Worktime=@Contact_Worktime,Contact_QRCode=@Contact_QRCode,Contact_UpdateTime=@Contact_UpdateTime,Contact_Fax = @Contact_Fax,Contact_Email = @Contact_Email where Contact_Id=@Contact_Id";
            return SqlHelper<Contact>.ExceuteNonQuery(sql, model);
        }

        public Contact GetAll()
        {
            string sql = "select top 1 * from Contact where Contact_DeleteId = 1 order by Contact_DeleteId desc";
            return SqlHelper<Contact>.Query(sql, null).FirstOrDefault();
        }
    }
}