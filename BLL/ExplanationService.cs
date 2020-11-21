using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Model;

namespace BLL
{
    public class ExplanationService
    {
        private readonly ExplanationManager dal = new ExplanationManager();

        public int Add(Explanation model)
        {
            return dal.Add(model);
        }

        public int Edit(Explanation model)
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

        public IList<Explanation> GetAll()
        {
            return dal.GetAll();
        }

        public IList<Explanation> GetExplanationsByTitle(string title)
        {
            return dal.GetExplanationsByTitle(title);
        }

        public Explanation GetExplanation(Guid id)
        {
            return dal.GetExplanation(id);
        }
        public IList<Explanation> GetAllInTrash()
        {
            return dal.GetAllInTrash();
        }

        public IList<Explanation> GetExplanationsByTitleInTrash(string title)
        {
            return dal.GetExplanationsByTitleInTrash(title);
        }

        public Explanation GetExplanationsByLoanTypeId(Guid loanTypeId)
        {
            return dal.GetExplanationsByLoanTypeId(loanTypeId);
        }

    }
}