using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace DAL
{
    public class ProductManager
    {
        public int Add(Product model)
        {
            string sql = "insert into Product(Product_Id,LoanType_Id,Product_Detail,Product_DeleteId,Product_CreateTime,Product_UpdateTime) values(@Product_Id,@LoanType_Id,@Product_Detail,@Product_DeleteId,@Product_CreateTime,@Product_UpdateTime)";
            return SqlHelper<Product>.ExceuteNonQuery(sql, model);
        }

        public int Edit(Product model)
        {
            string sql =
                "update Product set LoanType_Id=@LoanType_Id,Product_Detail=@Product_Detail,Product_UpdateTime=@Product_UpdateTime whereProduct_Id = @Product_Id ";
            return SqlHelper<Product>.ExceuteNonQuery(sql, model);
        }

        public int Delete(Guid id)
        {
            string sql = "delete from Product where Product_DeleteId = 0 and  Product_Id = @Product_Id";
            return SqlHelper<Product>.ExceuteNonQuery(sql, new Product(){ Product_Id = id});
        }

        public int PutTrash(Guid id)
        {
            string sql = "update Product set Product_DeleteId = 0 where Product_Id = @Product_Id";
            return SqlHelper<Product>.ExceuteNonQuery(sql, new Product() { Product_Id = id });
        }

        public int Restore(Guid id)
        {
            string sql = "update Product set Product_DeleteId = 1 where Product_Id = @Product_Id";
            return SqlHelper<Product>.ExceuteNonQuery(sql, new Product() { Product_Id = id });
        }

        public IList<Product> GetAll()
        {
            string sql = "select * from Product where Product_DeleteId = 1 order by Product_UpdateTime desc";
            return SqlHelper<Product>.Query(sql, null);
        }

        public IList<Product> GetProductsByTitle(string title)
        {
            string sql = "select * from Product where Product_DeleteId = 1  and Product_Detail like @Product_Detail order by Product_UpdateTime desc";
            return SqlHelper<Product>.Query(sql, new Product(){ Product_Detail =  "%"+title+"%"});
        }

        public Product GetProductById(Guid id)
        {
            string sql = "select * from Product where Product_Id = @Product_Id";
            return SqlHelper<Product>.Query(sql, new Product() { Product_Id = id }).FirstOrDefault();
        }

        public IList<Product> GetAllInTrash()
        {
            string sql = "select * from Product where Product_DeleteId = 0 order by Product_UpdateTime desc";
            return SqlHelper<Product>.Query(sql, null);
        }

        public IList<Product> GetProductsByTitleInTrash(string title)
        {
            string sql = "select * from Product where Product_DeleteId = 0  and Product_Detail like @Product_Detail order by Product_UpdateTime desc";
            return SqlHelper<Product>.Query(sql, new Product() { Product_Detail = "%" + title + "%" });
        }

        public Product GetProductByLoanTypeId(Guid loanTypeId)
        {
            string sql =
                "select * from Product where Product_DeleteId = 1 and LoanType_Id = @LoanType_Id order by Product_UpdateTime desc";
            return SqlHelper<Product>.Query(sql, new Product() { LoanType_Id = loanTypeId }).FirstOrDefault();
        }
    }
}