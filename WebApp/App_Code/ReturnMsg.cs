using System.Collections;
using System.Collections.Generic;

namespace WebApp
{
    public class ReturnMsg
    {
        /// <summary>
        /// 状态码,主要用得到对应的信息,以后通过这个内容进行判断 操作是否完成 
        /// </summary>
        public StatusCode Code { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }

    }
}