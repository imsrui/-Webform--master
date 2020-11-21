using System;
using System.Linq;
using DAL;
using Model;

namespace BLL
{
    public class ExamineService
    {
        private readonly ExamineManager dal = new ExamineManager();

        public int Add(Examine model)
        {
            return dal.Add(model);
        }

        public int Edit(Examine model)
        {
            return dal.Edit(model);
        }

        public Examine GetExamineByOrderId(Guid orderId)
        {
            return dal.GetExamineByOrderId(orderId);
        }
    }
}