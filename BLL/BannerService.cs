using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Model;

namespace BLL
{
    public class BannerService
    {
        private readonly BannerManager dal = new BannerManager();
        public int Add(Banner model)
        {
            return dal.Add(model);
        }


        public int Edit(Banner model)
        {
            return dal.Edit(model);
        }

        public int Delete(Guid id)
        {
            return dal.Delete(id);
        }

        public int PutTrash(Guid id)
        {
            return dal.PutTrash(id);
        }

        public int Restore(Guid id)
        {
            return dal.Restore(id);
        }

        public IList<Banner> GetAll()
        {
            return dal.GetAll();
        }

        public IList<Banner> GetBannerByTitle(string title)
        {
            return dal.GetBannerByTitle(title);
        }

        public IList<Banner> GetBannerByWebMenuId(Guid webMenuId)
        {
            return dal.GetBannerByWebMenuId(webMenuId);
        }

        public Banner GetBannerById(Guid id)
        {
            return dal.GetBannerById(id);
        }

        public IList<Banner> GetAllInTrash()
        {
            return dal.GetAllInTrash();
        }

        public IList<Banner> GetBannerByTitleInTrash(string title)
        {
            return dal.GetBannerByTitleInTrash(title);
        }
    }
}