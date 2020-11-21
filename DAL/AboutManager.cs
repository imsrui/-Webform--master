using System;
using System.Linq;
using Model;

namespace DAL
{
    public class AboutManager
    {
        public int Add(About model)
        {
            string sql = "insert into About(About_Id,About_Title,About_Content,About_Image,About_DeleteId,About_CreateTime,About_UpdateTime) values(@About_Id,@About_Title,@About_Content,@About_Image,@About_DeleteId,@About_CreateTime,@About_UpdateTime)";
            return SqlHelper<About>.ExceuteNonQuery(sql, model);
        }

        public int Edit(About model)
        {
            string sql = "update About set About_Title =@About_Title,About_Content=@About_Content,About_DeleteId=@About_DeleteId,About_CreateTime=@About_CreateTime,About_UpdateTime=@About_UpdateTime where About_Id=@About_Id";
            return SqlHelper<About>.ExceuteNonQuery(sql,model);
        }


        public About GetAll()
        {
            string sql = "select * from About order by About_CreateTime";
            return SqlHelper<About>.Query(sql, null).FirstOrDefault();
        }
    }
}