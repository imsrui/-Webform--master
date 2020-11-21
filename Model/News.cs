using System;

namespace Model
{
    public class News 
    {
        public Guid News_Id { get; set; } = Guid.NewGuid();

        public int News_DeleteId { get; set; } = 1;

        public DateTime News_CreateTime { get; set; } = DateTime.Now;
        public DateTime News_UpdateTime { get; set; } = DateTime.Now;
        public string  News_Title { get; set; }
        public string News_Content { get; set; }
        public string News_Image { get; set; }
    }
}