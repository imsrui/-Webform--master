using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace DAL
{
    public class ExplanationManager
    {
        public int Add(Explanation model)
        {
            string sql = "insert into Explanation(Explanation_Id,LoanType_Id,Explanation_Detail,Explanation_DeleteId,Explanation_CreateTime,Explanation_UpdateTime) values(@Explanation_Id,@LoanType_Id,@Explanation_Detail,@Explanation_DeleteId,@Explanation_CreateTime,@Explanation_UpdateTime)";
            return SqlHelper<Explanation>.ExceuteNonQuery(sql,model);
        }

        public int Edit(Explanation model)
        {
            string sql = "update Explanation set LoanType_Id=@LoanType_Id,Explanation_Detail=@Explanation_Detail,Explanation_UpdateTime=@Explanation_UpdateTime where Explanation_Id=@Explanation_Id";
            return SqlHelper<Explanation>.ExceuteNonQuery(sql, model); 
        }
        public int Delete(Guid id)
        {
            string sql = "delete from Explanation where Explanation_DeleteId = 0 and Explanation_Id=@Explanation_Id";
            return SqlHelper<Explanation>.ExceuteNonQuery(sql, new Explanation(){ Explanation_Id = id});
        }
        public int PutTrash(Guid id)
        {
            string sql = "update Explanation set Explanation_DeleteId = 0 where Explanation_Id = @Explanation_Id";
            return SqlHelper<Explanation>.ExceuteNonQuery(sql, new Explanation() { Explanation_Id = id });
        }
        public int Restore(Guid id)
        {
            string sql = "update Explanation set Explanation_DeleteId = 1 where Explanation_Id = @Explanation_Id";
            return SqlHelper<Explanation>.ExceuteNonQuery(sql, new Explanation() { Explanation_Id = id });
        }

        public IList<Explanation> GetAll()
        {
            string sql = "select * from Explanation where Explanation_DeleteId = 1 order by CreateTime ";
            return SqlHelper<Explanation>.Query(sql,null);
        }

        public IList<Explanation> GetExplanationsByTitle(string title)
        {
            string sql = "select * from Explanation where Explanation_DeleteId = 1 and Explanation_Detail like @Explanation_Detail order by CreateTime ";
            return SqlHelper<Explanation>.Query(sql, new Explanation(){ Explanation_Detail =  "%"+title+"%"});
        }

        public Explanation GetExplanation(Guid id)
        {
            string sql = "select * from Explanation where Explanation_Id = @Explanation_Id";
            return SqlHelper<Explanation>.Query(sql, new Explanation() { Explanation_Id = id}).FirstOrDefault();
        }
        public IList<Explanation> GetAllInTrash()
        {
            string sql = "select * from Explanation where Explanation_DeleteId = 0 order by CreateTime ";
            return SqlHelper<Explanation>.Query(sql, null);
        }

        public IList<Explanation> GetExplanationsByTitleInTrash(string title)
        {
            string sql = "select * from Explanation where Explanation_DeleteId = 0 and Explanation_Detail like @Explanation_Detail order by CreateTime ";
            return SqlHelper<Explanation>.Query(sql, new Explanation() { Explanation_Detail = "%" + title + "%" });
        }

        public Explanation GetExplanationsByLoanTypeId(Guid loanTypeId)
        {
            string sql = "select * from Explanation where Explanation_DeleteId = 1 and LoanType_Id = @LoanType_Id order by CreateTime";
            return SqlHelper<Explanation>.Query(sql, new Explanation() {LoanType_Id = loanTypeId }).FirstOrDefault();
        }

    }
}