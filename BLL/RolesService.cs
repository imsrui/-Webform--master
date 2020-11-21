using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Model;

namespace BLL
{
    public class RolesService
    {
        private readonly  RolesManager dal = new RolesManager();

        public int Add(Roles roles)
        {
            return dal.Add(roles);
        }

        public int Edit(Roles roles)
        {
            return dal.Edit(roles);
        }

        public int PutTrash(Guid id)
        {
            return dal.PutTrash(id);
        }

        public int Restore(Guid id)
        {
            return dal.Restore(id);
        }

        public int Delete(Guid id)
        {
            return dal.Delete(id);
        }

        public IList<Roles> GetAll()
        {
            return dal.GetAll();
        }

        public IList<Roles> GetRolesByTitle(string title)
        {
            return dal.GetRolesByTitle(title);
        }


        public Roles GetRolesById(Guid id)
        {
            return dal.GetRolesById(id);
        }

        public IList<Roles> GetAllInTrash()
        {
            return dal.GetAllInTrash();
        }

        public IList<Roles> GetRolesByTitleInTrash(string title)
        {
            return dal.GetRolesByTitleInTrash(title);
        }

    }
}