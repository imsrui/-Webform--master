using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Model;

namespace BLL
{
    public class MaterialsService
    {
        private readonly  MaterialsManager dal = new MaterialsManager();

        public int Add(Materials model)
        {
            return dal.Add(model);
        }

        public int Edit(Materials model)
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

        public IList<Materials> GetAll()
        {
            return dal.GetAll();
        }

        public IList<Materials> GetMaterialsByTitle(string title)
        {
            return dal.GetMaterialsByTitle(title);
        }

        public Materials GetMaterialsById(Guid id)
        {
            return dal.GetMaterialsById(id);
        }

        public IList<Materials> GetAllInTrash()
        {
            return dal.GetAllInTrash();
        }

        public IList<Materials> GetMaterialsByTitleInTrash(string title)
        {
            return dal.GetMaterialsByTitleInTrash(title);
        }

        public IList<Materials> GetMaterialsByLoanTypeId(Guid loanTypeId)
        {
            return dal.GetMaterialsByLoanTypeId(loanTypeId);
        }



    }
}