using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Model;

namespace BLL
{
    public class SeosService
    {
        private SeoManager dal = new SeoManager();

        public int Add(Seos model)
        {
            return dal.Add(model);
        }

        public int Edit(Seos model)
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

        public IList<Seos> GetAll()
        {
            return dal.GetAll();
        }

        public IList<Seos> GetSeosByTitle(string title)
        {
            return dal.GetSeosByTitle(title);
        }


        public IList<Seos> GetAllInTrash()
        {
            return dal.GetAllInTrash();
        }

        public IList<Seos> GetSeosByTitleInTrash(string title)
        {
            return dal.GetSeosByTitleInTrash(title);
        }

        public Seos GetSeosById(Guid id)
        {
            return dal.GetSeosById(id);
        }

        public Seos GetSeos(string title)
        {
            return dal.GetSeos(title);
        }

        public Seos GetSeosByWebMenuId(Guid id)
        {
            return dal.GetSeosByWebMenuId(id);
        }
    }
}