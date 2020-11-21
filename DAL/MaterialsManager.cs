using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace DAL
{
    public class MaterialsManager
    {
        public int Add(Materials model)
        {
            string sql = "insert into Materials(Materials_Id,LoanType_Id,Materials_Detail,Materials_DeleteId,Materials_CreateTime,Materials_UpdateTime) values(@Materials_Id,@LoanType_Id,@Materials_Detail,@Materials_DeleteId,@Materials_CreateTime,@Materials_UpdateTime)";
            return SqlHelper<Materials>.ExceuteNonQuery(sql,model);
        }

        public int Edit(Materials model)
        {
            string sql = "update Materials set LoanType_Id = @LoanType_Id , Materials_Detail = @Materials_Detail ,Materials_DeleteId = @Materials_DeleteId ,Materials_CreateTime = @Materials_CreateTime , Materials_UpdateTime = @Materials_UpdateTime where Materials_Id = @Materials_Id ";
            return SqlHelper<Materials>.ExceuteNonQuery(sql, model);
        }

        public int Delete(Guid id)
        {
            string sql = "delete from Materials where Materials_DeleteId = 0 and Materials_Id = @Materials_Id";
            return  SqlHelper<Materials>.ExceuteNonQuery(sql, new Materials(){ Materials_Id = id});
        }

        public int PutTrash(Guid id)
        {
            string sql = "update Materials set Materials_DeleteId = 0 where Materials_Id = @Materials_Id";
            return SqlHelper<Materials>.ExceuteNonQuery(sql, new Materials() { Materials_Id = id });
        }

        public int Restore(Guid id)
        {
            string sql = "update Materials set Materials_DeleteId = 1 where Materials_Id = @Materials_Id";
            return SqlHelper<Materials>.ExceuteNonQuery(sql, new Materials() { Materials_Id = id });
        }

        public IList<Materials> GetAll()
        {
            string sql = "select * from Materials where Materials_DeleteId = 1 order by Materials_UpdateTime";
            return SqlHelper<Materials>.Query(sql,null);
        }

        public IList<Materials> GetMaterialsByTitle(string title)
        {
            string sql = "select * from Materials where Materials_DeleteId = 1 and Materials_Detail like @Materials_Detail order by Materials_UpdateTime";
            return SqlHelper<Materials>.Query(sql, new Materials(){ Materials_Detail = "%"+title+"%"});
        }

        public Materials GetMaterialsById(Guid id)
        {
            string sql = "select * from Materials where Materials_Id = @Materials_Id";
            return SqlHelper<Materials>.Query(sql, new Materials() {Materials_Id = id}).FirstOrDefault();
        }

        public IList<Materials> GetAllInTrash()
        {
            string sql = "select * from Materials where Materials_DeleteId = 0 order by Materials_UpdateTime";
            return SqlHelper<Materials>.Query(sql, null);
        }

        public IList<Materials> GetMaterialsByTitleInTrash(string title)
        {
            string sql = "select * from Materials where Materials_DeleteId = 0 and Materials_Detail like @Materials_Detail order by Materials_UpdateTime";
            return SqlHelper<Materials>.Query(sql, new Materials() { Materials_Detail = "%" + title + "%" });
        }

        public IList<Materials> GetMaterialsByLoanTypeId(Guid loanTypeId)
        {
            string sql = "select * from Materials where Materials_DeleteId = 1 and LoanType_Id = @LoanType_Id";
            return SqlHelper<Materials>.Query(sql, new Materials() {LoanType_Id = loanTypeId});
        }
    }
}