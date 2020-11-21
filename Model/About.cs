using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class About 
    {
        public Guid About_Id { get; set; } = Guid.NewGuid();
        public int About_DeleteId { get; set; } = 1;
        public DateTime About_CreateTime { get; set; } = DateTime.Now;
        public DateTime About_UpdateTime { get; set; } = DateTime.Now;
        public string About_Title { get; set; }
        public string About_Content { get; set; }
        public string About_Image { get; set; }
    }
}
