using System;

namespace Model
{
    /// <summary>
    /// 费用说明
    /// </summary>
    public class Explanation 
    {
        public Guid Explanation_Id { get; set; } = Guid.NewGuid();

        public int Explanation_DeleteId { get; set; } = 1;

        public DateTime Explanation_CreateTime { get; set; } = DateTime.Now;
        public DateTime Explanation_UpdateTime { get; set; } = DateTime.Now;
        public Guid LoanType_Id { get; set; }
        public string Explanation_Detail { get; set; }

    }
}