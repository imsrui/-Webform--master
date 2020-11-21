using System;

namespace Model
{
    public class Copyrights 
    {
        public Guid Copyrights_Id { get; set; } = Guid.NewGuid();

        public int Copyrights_DeleteId { get; set; } = 1;

        public DateTime Copyrights_CreateTime { get; set; } = DateTime.Now;
        public DateTime Copyrights_UpdateTime { get; set; } = DateTime.Now;
        public string Copyrights_Title { get; set; }
        public string Copyrights_Details { get; set; }
        public string Copyrights_Tel { get; set; }
        public string Copyrights_Mobile { get; set; }
        public string Copyrights_QQ { get; set; }
        public string Copyrights_QQ2 { get; set; }
        public string Copyrights_Email { get; set; }
        public string Copyrights_Logo { get; set; }
        public string Copyrights_Image { get; set; }
        public string Copyrights_Address { get; set; }
    }
}