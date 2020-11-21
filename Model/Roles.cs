using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Roles 
    {

        public Guid Roles_Id { get; set; } = Guid.NewGuid();

        public int Roles_DeleteId { get; set; } = 1;

        public DateTime Roles_CreateTime { get; set; } = DateTime.Now;
        public DateTime Roles_UpdateTime { get; set; } = DateTime.Now;

        public string Roles_Title { get; set; }


    }
}
