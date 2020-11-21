using System;
using System.Collections;
using System.Collections.Generic;
using Model;

namespace DAL
{
    public class UsersPermissionsManager
    {
        public int Add(UsersPermissions model)
        {
            string sql = "insert into UsersPermissions(UsersPermissions_Id,UsersPermissions_RolesId,UsersPermissions_SystemMenuId,UsersPermissions_DeleteId,UsersPermissions_CreateTime,UsersPermissions_UpdateTime) values(@UsersPermissions_Id,@UsersPermissions_RolesId,@UsersPermissions_SystemMenuId,@UsersPermissions_DeleteId,@UsersPermissions_CreateTime,@UsersPermissions_UpdateTime)";
            return SqlHelper<UsersPermissions>.ExceuteNonQuery(sql, model);
        }


        public int Delete(Guid id)
        {
            string sql = "delete from UsersPermissions where UsersPermissions_Id = @UsersPermissions_Id";
            return SqlHelper<UsersPermissions>.ExceuteNonQuery(sql, new UsersPermissions() { UsersPermissions_Id = id });
        }

        public IList<UsersPermissions> GetUsersPermissionsesByRolesId(Guid rid)
        {
            string sql = "select * from UsersPermissions where  UsersPermissions_RolesId = @UsersPermissions_RolesId";
            return SqlHelper<UsersPermissions>.Query(sql, new UsersPermissions() { UsersPermissions_RolesId = rid });
        }



    }
}