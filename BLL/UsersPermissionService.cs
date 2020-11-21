using System;
using System.Collections.Generic;
using DAL;
using Model;

namespace BLL
{
    public class UsersPermissionService
    {
        private readonly  UsersPermissionsManager dal = new UsersPermissionsManager();

        public int Add(UsersPermissions model)
        {
            return dal.Add(model);
        }

        public int Delete(Guid id)
        {
            return dal.Delete(id);
        }

        public IList<UsersPermissions> GetUsersPermissionsesByRolesId(Guid rid)
        {
            return dal.GetUsersPermissionsesByRolesId(rid);
        }

    }
}