using System;

namespace Model
{
    public class WebMenus 
    {
        public Guid WebMenus_Id { get; set; } = Guid.NewGuid();

        public int WebMenus_DeleteId { get; set; } = 1;

        public DateTime WebMenus_CreateTime { get; set; } = DateTime.Now;
        public DateTime WebMenus_UpdateTime { get; set; } = DateTime.Now;
        public string WebMenus_Title { get; set; }
        public string WebMenus_Link { get; set; }
        public Guid WebMenus_ParentId { get; set; }
        public string WebMenus_Icon { get; set; }
    }
}