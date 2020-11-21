using System;

namespace Model
{
    /// <summary>
    /// 申请资料
    /// </summary>
    public class Materials 
    {
        public Guid Materials_Id { get; set; } = Guid.NewGuid();

        public int Materials_DeleteId { get; set; } = 1;

        public DateTime Materials_CreateTime { get; set; } = DateTime.Now;
        public DateTime Materials_UpdateTime { get; set; } = DateTime.Now;
        public Guid LoanType_Id { get; set; }
        public string Materials_Detail { get; set; }
    }
}