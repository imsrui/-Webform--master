using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace DAL
{
    public class LoanChooseManager
    {
        public int Add(LoanChoose model)
        {
            string sql = "insert into LoanChoose(LoanChoose_Id,LoanType_Id,LoanChoose_Detail,LoanChoose_DeleteId,LoanChoose_CreateTime,LoanChoose_UpdateTime) values(@LoanChoose_Id,@LoanType_Id,@LoanChoose_Detail,@LoanChoose_DeleteId,@LoanChoose_CreateTime,@LoanChoose_UpdateTime)";
            return SqlHelper<LoanChoose>.ExceuteNonQuery(sql,model);
        }

        public int Add(LoanChoose model)
        {
            string sql = "insert into LoanChoose(LoanChoose_Id,LoanType_Id,LoanChoose_Detail,LoanChoose_DeleteId,LoanChoose_CreateTime,LoanChoose_UpdateTime) values(@LoanChoose_Id,@LoanType_Id,@LoanChoose_Detail,@LoanChoose_DeleteId,@LoanChoose_CreateTime,@LoanChoose_UpdateTime)";
            return SqlHelper<LoanChoose>.ExceuteNonQuery(sql, model);
        }

        public int Edit(LoanChoose model)
        {
            string sql = "update LoanChoose set LoanType_Id=@LoanType_Id,LoanChoose_Detail=@LoanChoose_Detail,LoanChoose_UpdateTime=@LoanChoose_UpdateTime where LoanChoose_Id = @LoanChoose_Id";
            return SqlHelper<LoanChoose>.ExceuteNonQuery(sql, model);
        }

        public int Delete(Guid id)
        {
            string sql = "delete from LoanChoose where LoanChoose_DeleteId = 0 and LoanChoose_Id = @LoanChoose_Id";
            return SqlHelper<LoanChoose>.ExceuteNonQuery(sql, new LoanChoose() { LoanChoose_Id = id });
        }

        public int PutTrash(Guid id)
        {
            string sql = "update LoanChoose set LoanChoose_DeleteId = 0 where LoanChoose_Id = @LoanChoose_Id";
            return SqlHelper<LoanChoose>.ExceuteNonQuery(sql, new LoanChoose() { LoanChoose_Id = id });
        }

        public int Restore(Guid id)
        {
            string sql = "update LoanChoose set LoanChoose_DeleteId = 1 where LoanChoose_Id = @LoanChoose_Id";
            return SqlHelper<LoanChoose>.ExceuteNonQuery(sql, new LoanChoose() { LoanChoose_Id = id });
        }

        public IList<LoanChoose> GetAll()
        {
            string sql = "select * from LoanChoose where LoanChoose_DeleteId = 1 order by LoanChoose_CreateTime ";
            return SqlHelper<LoanChoose>.Query(sql, null);
        }

        public IList<LoanChoose> GetLoanChooseByTitle(string title)
        {
            string sql = "select * from LoanChoose where LoanChoose_DeleteId = 1 and LoanChoose_Detail like @LoanChoose_Detail order by LoanChoose_CreateTime ";
            return SqlHelper<LoanChoose>.Query(sql, new LoanChoose() { LoanChoose_Detail = "%" + title + "%" });
        }

        public LoanChoose GetLoanChooseById(Guid id)
        {
            string sql = "select * from LoanChoose  where LoanChoose_Id = @LoanChoose_Id ";
            return SqlHelper<LoanChoose>.Query(sql, new LoanChoose() { LoanChoose_Id = id }).FirstOrDefault();
        }

        public IList<LoanChoose> GetAllInTrash()
        {
            string sql = "select * from LoanChoose where LoanChoose_DeleteId = 0 order by LoanChoose_CreateTime ";
            return SqlHelper<LoanChoose>.Query(sql, null);
        }

        public IList<LoanChoose> GetLoanChooseByTitleInTrash(string title)
        {
            string sql = "select * from LoanChoose where LoanChoose_DeleteId = 0 and LoanChoose_Detail like @LoanChoose_Detail order by LoanChoose_CreateTime ";
            return SqlHelper<LoanChoose>.Query(sql, new LoanChoose() { LoanChoose_Detail = "%" + title + "%" });
        }

        public IList<LoanChoose> GetLoanChooseByLoanTypeId(Guid loanTypeId)
        {
            string sql = "select top 4 * from LoanChoose where LoanChoose_DeleteId = 1 and LoanType_Id = @LoanType_Id order by LoanChoose_CreateTime";
            return SqlHelper<LoanChoose>.Query(sql, new LoanChoose() { LoanType_Id = loanTypeId });
        }

    }
}