using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Model;

namespace BLL
{
    public class LoanChooseService
    {
        private readonly LoanChooseManager dal = new LoanChooseManager();

        public int Add(LoanChoose model)
        {
            return dal.Add(model);
        }

        public int Edit(LoanChoose model)
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

        public IList<LoanChoose> GetAll()
        {
            return dal.GetAll();
        }

        public IList<LoanChoose> GetLoanChooseByTitle(string title)
        {
            return dal.GetLoanChooseByTitle(title);
        }

        public LoanChoose GetLoanChooseById(Guid id)
        {
            return dal.GetLoanChooseById(id);
        }

        public IList<LoanChoose> GetAllInTrash()
        {
            return dal.GetAllInTrash();
        }

        public IList<LoanChoose> GetLoanChooseByTitleInTrash(string title)
        {
            return dal.GetLoanChooseByTitleInTrash(title);
        }

        public IList<LoanChoose> GetLoanChooseByLoanTypeId(Guid loanTypeId)
        {
            return dal.GetLoanChooseByLoanTypeId(loanTypeId);
        }


    }
}