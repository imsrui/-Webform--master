using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class LoanTypeManager
    {
        public int Add(LoanType model)
        {
            string sql = "insert into LoanType(LoanType_Id,LoanType_Title,LoanType_Detail,LoanType_Image,LoanType_IsShow,LoanType_DeleteId,LoanType_CreateTime,LoanType_UpdateTime) values(@LoanType_Id,@LoanType_Title,@LoanType_Detail,@LoanType_Image,@LoanType_IsShow,@LoanType_DeleteId,@LoanType_CreateTime,@LoanType_UpdateTime)";
            return SqlHelper<LoanType>.ExceuteNonQuery(sql, model);
        }


        public int Edit(LoanType model)
        {
            string sql = "update LoanType set LoanType_Title=@LoanType_Title,LoanType_Detail=@LoanType_Detail,LoanType_Image=@LoanType_Image,LoanType_IsShow=@LoanType_IsShow,LoanType_UpdateTime=@LoanType_UpdateTime where LoanType_Id=@LoanType_Id  ";
            return SqlHelper<LoanType>.ExceuteNonQuery(sql, model);
        }

        public int Delete(Guid id)
        {
            string sql = "delete from LoanType where LoanType_DeleteId = 0 and LoanType_Id=@LoanType_Id";
            return SqlHelper<LoanType>.ExceuteNonQuery(sql,new LoanType(){ LoanType_Id = id});
        }

        public int PutTrash(Guid id)
        {
            string sql = "update LoanType set LoanType_DeleteId = 0 where LoanType_Id=@LoanType_Id";
            return SqlHelper<LoanType>.ExceuteNonQuery(sql, new LoanType() { LoanType_Id = id });
        }

        public int Restore(Guid id)
        {
            string sql = "update LoanType set LoanType_DeleteId = 1 where LoanType_Id=@LoanType_Id";
            return SqlHelper<LoanType>.ExceuteNonQuery(sql, new LoanType() { LoanType_Id = id });
        }


        public IList<LoanType> GetAll()
        {
            string sql = "select * from LoanType where LoanType_DeleteId = 1 order By LoanType_UpdateTime desc";
            return SqlHelper<LoanType>.Query(sql, null);
        }

        public IList<LoanType> GetLoanTypesByIsShow()
        {
            string sql = "select top 3 * from LoanType where LoanType_DeleteId = 1 and LoanType_IsShow = 1 order By LoanType_CreateTime";
            return SqlHelper<LoanType>.Query(sql, null);
        }

        public IList<LoanType> GetLoanTypesByTitle(string title)
        {
            string sql = "select * from LoanType where LoanType_DeleteId = 1 and LoanType_Title like @LoanType_Title order By LoanType_UpdateTime desc";
            return SqlHelper<LoanType>.Query(sql, new LoanType(){ LoanType_Title = "%"+title+"%"});
           
        }

        public LoanType GetLoadTypeById(Guid id)
        {
            string sql = "select * from LoanType where LoanType_Id = @LoanType_Id";
            return SqlHelper<LoanType>.Query(sql, new LoanType() {LoanType_Id = id}).FirstOrDefault();
        }

        public IList<LoanType> GetLoanTypesByTitleInTrash(string title)
        {
            string sql = "select * from LoanType where LoanType_DeleteId = 0 and LoanType = @LoanType order By LoanType_UpdateTime desc";
            return SqlHelper<LoanType>.Query(sql, new LoanType() { LoanType_Title = "%" + title + "%" });
        }

        public IList<LoanType> GetAllInTrash()
        {
            string sql = "select * from LoanType where LoanType_DeleteId = 0 order By LoanType_UpdateTime desc";
            return SqlHelper<LoanType>.Query(sql, null);
        }
    }
}