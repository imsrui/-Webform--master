using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
namespace BLL
{
    public class SystemMenusService
    {
        private readonly SystemMenuManager dal = new SystemMenuManager();

        public int Add(SystemMenus model)
        {
            return dal.Add(model);
        }

        public int Edit(SystemMenus model)
        {
            return dal.Edit(model);
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


        public IList<SystemMenus> GetAll()
        {
            return dal.GetAll();
        }

        public IList<SystemMenus> GetSystemMenuByTitle(string title)
        {
            return dal.GetSystemMenuByTitle(title);
        }

        public SystemMenus GetSystemMenus(Guid id)
        {
            return dal.GetSystemMenus(id);
        }

        public IList<SystemMenus> GetAllInTrash()
        {
            return dal.GetAllInTrash();
        }

        public IList<SystemMenus> GetSystemMenuByTitleInTrash(string title)
        {
            return dal.GetSystemMenuByTitleInTrash(title);
        }

        public IList<SystemMenus> GetSystemMenusByParentId(Guid parentId)
        {
            return dal.GetSystemMenusByParentId(parentId);
        }

        public IList<SystemMenus> GetSystemMenusesByIdList(string idList)
        {
            return dal.GetSystemMenusesByIdList(idList);
        }

        public IList<SystemMenus> GetSystemMenusByRolesIdAndParnetId(Guid rid, Guid parentId)
        {
            return dal.GetSystemMenusByRolesIdAndParnetId(rid, parentId);
        }
    }
}
