using System;

namespace Model
{
    public class Contact 
    {
        public Guid Contact_Id { get; set; } = Guid.NewGuid();

        public int Contact_DeleteId { get; set; } = 1;

        public DateTime Contact_CreateTime { get; set; } = DateTime.Now;
        public DateTime Contact_UpdateTime { get; set; } = DateTime.Now;
        public string Contact_Address { get; set; }

        public string Contact_QQ1 { get; set; }

        public string Contact_QQ2 { get; set; }

        public string Contact_Wechat { get; set; }

        public string Contact_Weibo { get; set; }
        public string Contact_Phone { get; set; }
        public string Contact_WorkTime { get; set; }
        public string Contact_QRCode { get; set; }

        public string Contact_Fax { get; set; }

        public string Contact_Email { get; set; }


    }
}