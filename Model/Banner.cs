using System;

namespace Model
{
    public class Banner 
    {
        public Guid Banner_Id { get; set; } = Guid.NewGuid();

        public int Banner_DeleteId { get; set; } = 1;

        public DateTime Banner_CreateTime { get; set; } = DateTime.Now;

        public DateTime Banner_UpdateTime { get; set; } = DateTime.Now;

        public string Banner_Img { get; set; }

        public string Banner_Title { get; set; }
        public string Banner_Link { get; set; }
        public Guid Banner_WebMenuId { get; set; }

    }
}