using System;
using System.Linq;
using Model;

namespace DAL
{
    public class ExamineManager
    {
        public int Add(Examine model)
        {
            string sql = "insert into Examine(Examine_Id,Examine_OrderId,Examine_Result,Examine_Reason) values(@Examine_Id,@Examine_OrderId,@Examine_Result,@Examine_Reason)";
            return SqlHelper<Examine>.ExceuteNonQuery(sql, model);
        }

        public int Edit(Examine model)
        {
            string sql = "update Examine set Examine_OrderId = @Examine_OrderId ,Examine_Result = @Examine_Result,Examine_Reason= @Examine_Reason where Examine_Id =@Examine_Id ";
            return SqlHelper<Examine>.ExceuteNonQuery(sql, model);
        }

        public Examine GetExamineByOrderId(Guid orderId)
        {
            string sql = "select * from Examine where Examine_OrderId = @Examine_OrderId";
            return SqlHelper<Examine>.Query(sql, new Examine() {Examine_OrderId = orderId}).FirstOrDefault();
        }
    }
}