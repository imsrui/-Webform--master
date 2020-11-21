using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Model;

namespace BLL
{
    public class ProductService
    {
        private  readonly ProductManager dal = new ProductManager();
        public int Add(Product model)
        {
            return dal.Add(model);
        }

        public int Edit(Product model)
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

        public IList<Product> GetAll()
        {
            return dal.GetAll();
        }

        public IList<Product> GetProductsByTitle(string title)
        {
            return dal.GetProductsByTitle(title);
        }

        public Product GetProductById(Guid id)
        {
            return dal.GetProductById(id);
        }

        public IList<Product> GetAllInTrash()
        {
            return dal.GetAllInTrash();
        }

        public IList<Product> GetProductsByTitleInTrash(string title)
        {
            return dal.GetProductsByTitleInTrash(title);
        }

        public Product GetProductByLoanTypeId(Guid loanTypeId)
        {
            return dal.GetProductByLoanTypeId(loanTypeId);
        }
    }
}