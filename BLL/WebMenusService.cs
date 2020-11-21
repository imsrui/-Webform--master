using System;
using System.Collections.Generic;
using DAL;
using Model;

namespace BLL
{
    public class WebMenusService
    {
        private readonly WebMenusManager dal = new WebMenusManager();

        public int Add(WebMenus model)
        {
            return dal.Add(model);
        }

        public int Edit(WebMenus model)
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


        public IList<WebMenus> GetAll()
        {
            return dal.GetAll();
        }

        public IList<WebMenus> GetAllWhatIsShow()
        {
            return dal.GetAllWhatIsShow();
        }

        public IList<WebMenus> GetWebMenusByTitle(string title)
        {
            return dal.GetWebMenusByTitle(title);
        }

        public WebMenus GetWebMenus(Guid id)
        {
            return dal.GetWebMenus(id);
        }

        public IList<WebMenus> GetAllInTrash()
        {
            return dal.GetAllInTrash();
        }

        public IList<WebMenus> GetWebMenusByTitleInTrash(string title)
        {
            return dal.GetWebMenusByTitleInTrash(title);
        }

        public IList<WebMenus> GetWebMenusByParentId(Guid parentId)
        {
            return dal.GetWebMenusByParentId(parentId);
        }







    }
}