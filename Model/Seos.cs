using System;

namespace Model
{
    public class Seos 
    {
        public Guid Seos_Id { get; set; } = Guid.NewGuid();

        public int Seos_DeleteId { get; set; } = 1;

        public DateTime Seos_CreateTime { get; set; } = DateTime.Now;
        public DateTime Seos_UpdateTime { get; set; } = DateTime.Now;
        public string Seos_Title { get; set; }
        public string Seos_Keyword { get; set; }
        public string Seos_Description { get; set; }

        public Guid Seos_WebMenuId { get; set; }
    }
}