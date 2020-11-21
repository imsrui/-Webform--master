using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Model;

namespace BLL
{
    public class LoanTypeService
    {
        private readonly LoanTypeManager dal = new LoanTypeManager();
        public int Add(LoanType model)
        {
            return dal.Add(model);
        }


        public int Edit(LoanType model)
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


        public IList<LoanType> GetAll()
        {
            return dal.GetAll();
        }

        public IList<LoanType> GetLoanTypesByIsShow()
        {
            return dal.GetLoanTypesByIsShow();
        }

        public IList<LoanType> GetLoanTypesByTitle(string title)
        {
            return dal.GetLoanTypesByTitle(title);
        }

        public LoanType GetLoadTypeById(Guid id)
        {
            return dal.GetLoadTypeById(id);
        }

        public IList<LoanType> GetLoanTypesByTitleInTrash(string title)
        {
            return dal.GetLoanTypesByTitleInTrash(title);
        }

        public IList<LoanType> GetAllInTrash()
        {
            return dal.GetAllInTrash();
        }
    }
}