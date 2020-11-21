using System;

namespace Model
{
    /// <summary>
    /// 预约审核表
    /// </summary>
    public class Examine
    {
        public Guid Examine_Id { get; set; } = Guid.NewGuid();

        public Guid Examine_OrderId { get; set; }

        public string Examine_Result { get; set; }

        public string Examine_Reason { get; set; }
    }
}