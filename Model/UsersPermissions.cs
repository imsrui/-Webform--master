using System;

namespace Model
{
    public class UsersPermissions 
    {
        public Guid UsersPermissions_Id { get; set; } = Guid.NewGuid();

        public int UsersPermissions_DeleteId { get; set; } = 1;

        public DateTime UsersPermissions_CreateTime { get; set; } = DateTime.Now;
        public DateTime UsersPermissions_UpdateTime { get; set; } = DateTime.Now;
        public Guid UsersPermissions_RolesId { get; set; }
        public Guid UsersPermissions_SystemMenuId { get; set; }

    }
}